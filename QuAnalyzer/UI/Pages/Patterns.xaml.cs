using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wokhan.Collections.Extensions;
using Wokhan.Data.Providers.Contracts;
using System.Linq.Dynamic.Core;

namespace QuAnalyzer.UI.Pages
{

    /// <summary>
    /// Interaction logic for Patterns.xaml
    /// </summary>
    public partial class Patterns : Page
    {
        public int SimThreshold { get; set; }
        public bool AutoUpdate { get; set; }


        public Patterns()
        {
            InitializeComponent();

        }

        /*Regex patRegChar = new Regex(@"[a-zA-Z]*");
        Regex patRegNum = new Regex(@"\d*");
        Regex patRegOther = new Regex(@"^\w*");

        Regex reg = new Regex(@"^(?:(?:(?<a>[a-zA-Z]*?)|(?<nw>\W*?)|(?<d>\d*?))*?)$", RegexOptions.Multiline);
        */

        private async void lstDataSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var prov = (IDataProvider)lstDataProviders.SelectedItem;
            var repo = (string)lstDataSources.SelectedValue;
            var attr = (string)lstAttributes.SelectedValue;

            if (repo != null && attr == null)
            {
                lstAttributes.ItemsSource = prov.GetColumns(repo).Where(h => h.Type == typeof(string)).Select(h => h.Name);
            }
            else if (AutoUpdate)
            {
                await compute();
            }
        }

        private async Task compute()
        {
            var prov = (IDataProvider)lstDataProviders.SelectedItem;
            var repo = (string)lstDataSources.SelectedValue;
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
                });

                gridPatterns.ItemsSource = res;
            }
            else
            {
                gridPatterns.ItemsSource = null;
            }
        }


        private void slideSim_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            SimThreshold = (int)e.NewValue;
            if (gridPatterns != null)
            {
                lstDataSources_SelectionChanged(null, null);
            }
        }

        private async void btnUpdate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            await compute();
        }
    }
}
