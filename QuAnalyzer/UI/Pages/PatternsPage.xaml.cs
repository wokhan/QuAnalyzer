using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wokhan.Collections.Generic.Extensions;

namespace QuAnalyzer.UI.Pages
{

    /// <summary>
    /// Interaction logic for Patterns.xaml
    /// </summary>
    public partial class PatternsPage : Page
    {
        public int SimThreshold { get; set; }
        public bool AutoUpdate { get; set; }

        public PatternsPage()
        {
            InitializeComponent();

            ((App)App.Current).PropertyChanged += (s, e) => { if (e.PropertyName == nameof(App.CurrentSelection)) { UpdateSelection(); } }; 
        }

        private async void UpdateSelection()
        {
            var (prov, repo) = ((App)App.Current).CurrentSelection;
            var attr = (string)lstAttributes.SelectedValue;

            if (repo != null && attr == null)
            {
                lstAttributes.ItemsSource = prov.GetColumns(repo).Where(h => h.Type == typeof(string)).Select(h => h.Name);
            }
            else if (AutoUpdate)
            {
                await Compute().ConfigureAwait(false);
            }
        }

        private async Task Compute()
        {
            var (prov, repo) = ((App)App.Current).CurrentSelection;

            var attr = (string)lstAttributes.SelectedValue;

            if (repo != null && attr != null)
            {
                prg.IsIndeterminate = true;

                var res = await Task.Run(() =>
                {
                    var data = prov.GetQueryable(repo)
                                   .Select(attr)
                                   .AsEnumerable()
                                   .WithProgress(i => Dispatcher.InvokeAsync(() => txtStatus.Text = $"Loaded {i} entries..."))
                                   .Select(a => a.ToString())
                                   .ToList();

                    Dispatcher.Invoke(() =>
                    {
                        prg.IsIndeterminate = false;
                        prg.Maximum = data.Count;
                    });

                    return data.WithProgress(i => Dispatcher.InvokeAsync(() => prg.Value = i))
                               .Select(d => new { val = d, reg = Features.Patterns.Patterns.GetRegEx(d, SimThreshold) })
                               .ToList()
                               .GroupBy(s => s.reg)
                               .Select(g => new { Pattern = g.Key, Count = g.Count(), Sample = g.First().val })
                               .OrderByDescending(g => g.Count);
                }).ConfigureAwait(true);

                gridPatterns.ItemsSource = res;
            }
            else
            {
                gridPatterns.ItemsSource = null;
            }
        }

        private void lstDataSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelection();
        }

        private void slideSim_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            SimThreshold = (int)e.NewValue;
            if (gridPatterns != null)
            {
                UpdateSelection();
            }
        }

        private async void btnUpdate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            await Compute().ConfigureAwait(false);
        }
    }
}
