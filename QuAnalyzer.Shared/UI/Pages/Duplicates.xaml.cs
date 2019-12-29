using QuAnalyzer.Features.Comparison;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using Wokhan.Collections.Generic.Extensions;
using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Logique d'interaction pour DataViewer.xaml
    /// </summary>
    public partial class Duplicates : Page, INotifyPropertyChanged
    {

        private bool _keepDuplicates;
        public bool KeepDuplicates
        {
            get { return _keepDuplicates; }
            set { _keepDuplicates = value; NotifyPropertyChanged(); }
        }

        private bool _keepColumns = true;
        public bool KeepColumns
        {
            get { return _keepColumns; }
            set { _keepColumns = value; NotifyPropertyChanged(); }
        }

        public Duplicates()
        {
            InitializeComponent();

            ((App)App.Current).PropertyChanged += App_PropertyChanged;
        }

        private void App_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(App.CurrentSelection))
            {
                var (prov, repo) = ((App)App.Current).CurrentSelection;
                if (prov != null)
                {
                    lstColumns.ItemsSource = prov.GetColumns(repo);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void btnRun_Click(object sender, RoutedEventArgs e)
        {
            var (prov, repository) = ((App)App.Current).CurrentSelection;

            var allHeadersFu = prov.GetColumns(repository);
            string[] keys;
            string[] headers;
            if (lstColumns.SelectedItems.Count > 0)
            {
                keys = lstColumns.SelectedItems.Cast<ColumnDescription>().Select(c => c.Name).ToArray();
                headers = allHeadersFu.OrderBy(h => keys.Contains(h.Name) ? 0 : 1).Select(h => h.Name).ToArray();
            }
            else
            {
                headers = allHeadersFu.Select(h => h.Name).ToArray();
                keys = headers;
            }

            await Task.Run(() =>
            {
                gridData.LoadingProgress = -1;
                gridData.Status = "Loading data...";

                var data = prov.GetQueryable(repository);//.Select<dynamic>(headers);

                gridData.LoadingProgress = -1;

                var dataObjectArray = data.AsObjectCollection(KeepDuplicates && KeepDuplicates ? headers : keys)
                                          .WithProgress(i => gridData.Status = $"Parsed {i} entries")
                                          .ToList();

                gridData.LoadingProgress = 1;

                var keyComparer = new SequenceEqualityComparer<object>(0, keys.Length);
                var ret = Comparison.InitiateDuplicates(dataObjectArray.WithProgress(i => { gridData.Status = $"Checked {i} entries"; gridData.LoadingProgress = (int)(i * 100 / dataObjectArray.Count); }), keyComparer, new SequenceEqualityComparer<object>()).Duplicates;

                if (!KeepDuplicates)
                {
                    ret = ret.Distinct(keyComparer).ToList();
                }

                Dispatcher.InvokeAsync(() =>
                {
                    displayData(ret, headers, keys.Length);
                    //gridData.ItemsSource = ret.Duplicates;
                    //gridData.Columns.Single(c => c.SortMemberPath == SortOrder).SortDirection = (currentSortDirectionAsc ? ListSortDirection.Ascending : ListSortDirection.Descending);
                });

                gridData.LoadingProgress = 100;
            }).ConfigureAwait(false);
        }


        private void displayData(IEnumerable<object> data, string[] headers, int keysCount)
        {
            gridData.Columns.Clear();

            gridData.AutoGenerateColumns = false;

            var count = (KeepColumns && KeepDuplicates ? headers.Length : keysCount);
            gridData.CustomHeaders = headers.Take(count).Select(h => new ColumnDescription { Name = h, DisplayName = h }).ToList();

            if (data != null && data.Any())
            {
                gridData.Columns.AddAll(headers.Take(count).Select((h, i) => new DataGridTextColumn() { Header = h, Binding = new Binding("[" + i + "]") }));
                gridData.Source = data.AsQueryable();
            }
            else
            {
                gridData.Source = null;
            }
        }
    }
}
