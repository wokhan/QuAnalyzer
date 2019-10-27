using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wokhan.Data.Providers.Contracts;
using System.Linq.Dynamic.Core;
using Wokhan.Collections.Generic.Extensions;
using System.Collections.Generic;
using System;

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

            ((App)App.Current).CurrentSelection.CollectionChanged += CurrentSelection_CollectionChanged;
        }

        private async void CurrentSelection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var (prov, repo) = ((App)App.Current).CurrentSelection.FirstOrDefault();
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

        private void lstDataSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentSelection_CollectionChanged(null, null);
        }

        private async Task compute()
        {
            var (prov, repo) = ((App)App.Current).CurrentSelection.FirstOrDefault();

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
                CurrentSelection_CollectionChanged(null, null);
            }
        }

        private async void btnUpdate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            await compute();
        }
    }
}
