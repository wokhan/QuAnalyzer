using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Generic.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Wokhan.Collections.Extensions;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Logique d'interaction pour DataViewer.xaml
    /// </summary>
    public partial class Duplicates : Page, INotifyPropertyChanged
    {
        public static Dictionary<string, string> AggregationFormula
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "Ignore", null },
                    { "Count", "Count()" },
                    //{ "Distinct Count", (x) => x.Distinct().Count() },
                    //{ "First", Enumerable.First },
                    //{ "Last", Enumerable.Last },
                    { "Sum", "Sum({0})" },
                    { "Average", "Average({0})" },
                    { "Min", "Min({0})" },
                    { "Max", "Max({0})" }
                };
            }
        }

        public static Dictionary<string, string> FilterFormula //Func<LinqExpressions.Expression, LinqExpressions.Expression, LinqExpressions.BinaryExpression>> FilterFormula
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "Equals", "=" },
                    { "Differs from", "<>" },
                    { "Greater than", ">" },
                    { "Greater than or equal", ">=" },
                    { "Less than", "<" },
                    { "Less than or equal", "<=" }
                };
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged("Status"); }
        }

        private bool _keepDuplicates;
        public bool KeepDuplicates
        {
            get { return _keepDuplicates; }
            set { _keepDuplicates = value; NotifyPropertyChanged("KeepDuplicates"); }
        }

        private bool _keepColumns = true;
        public bool KeepColumns
        {
            get { return _keepColumns; }
            set { _keepColumns = value; NotifyPropertyChanged("KeepColumns"); }
        }

        private int _loadingProgress;
        public int LoadingProgress
        {
            get { return _loadingProgress; }
            set { _loadingProgress = value; NotifyPropertyChanged("LoadingProgress"); }
        }

        public ObservableCollection<string> Grouping { get; } = new ObservableCollection<string>();
        public ObservableCollection<FilterStruct> Filters { get; } = new ObservableCollection<FilterStruct>();

        public class ComputeStruct
        {
            public string Attribute { get; set; }
            public string Aggregate { get; set; }
        }

        public class FilterStruct
        {
            public string Attribute { get; set; }
            public Type Type { get; set; }
            public string ComparerExpression { get; set; }

            public object TargetValueAsObject { get; private set; }
            public string TargetValue
            {
                get { return TargetValueAsObject != null ? TargetValueAsObject.ToString() : String.Empty; }
                set { TargetValueAsObject = Convert.ChangeType(value, Type); }
            }
        }

        public string CustomFilter { get; set; }

        public bool IsCustomFilterError { get { return CustomFilterError != null; } }

        private string _customFilterError;
        public string CustomFilterError
        {
            get { return _customFilterError; }
            set { _customFilterError = value; NotifyPropertyChanged("CustomFilterError"); NotifyPropertyChanged("IsCustomFilterError"); }
        }

        public ObservableCollection<ComputeStruct> Compute { get; } = new ObservableCollection<ComputeStruct>();

        private string SortOrder { get { return (currentSortAttribute != null && (!Grouping.Any() || Grouping.Concat(Compute.Select(f => f.Attribute)).Contains(currentSortAttribute))) ? currentSortAttribute : (Grouping.FirstOrDefault() ?? allHeaders.Keys.First()); } }

        public Duplicates()
        {
            InitializeComponent();

            VirtualizedQueryableExtensions.Init(Dispatcher);
        }

        private Dictionary<string, Type> allHeaders;
        private List<string> dispHeaders;
        private void lstDataSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstDataSources.SelectedItem != null)
            {
                lstColumns.ItemsSource = ((IDataProvider)lstDataProviders.SelectedItem).GetColumns((string)lstDataSources.SelectedItem);
            }
        }


        private void ClearAll()
        {
            gridData.ItemsSource = null;
            Grouping.Clear();
            Compute.Clear();
            Filters.Clear();
        }

        private void GlobalExportCSV_Click(object sender, RoutedEventArgs e)
        {
            gridData.ExportAsXLSX();
        }

        private void GlobalExportHTML_Click(object sender, RoutedEventArgs e)
        {
            gridData.ExportAsHTML();
        }

        private void GlobalCopy_Click(object sender, RoutedEventArgs e)
        {
            gridData.CopyToClipboard();
        }

        Point startPoint;
        private void DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void DataGrid_MouseMove(object sender, MouseEventArgs e)
        {
            Vector diff = startPoint - e.GetPosition(null);
            if (e.LeftButton == MouseButtonState.Pressed && (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                DragDrop.DoDragDrop((Control)sender, new DataObject(((DataGridColumnHeader)sender).Content), DragDropEffects.Link);
                e.Handled = true;
            }
        }

        private void lstGrouping_Drop(object sender, DragEventArgs e)
        {
            var src = (string)e.Data.GetData(typeof(string));
            if (!Grouping.Contains(src))
            {
                Grouping.Add(src);
                foreach (var h in gridData.Columns.Select(c => c.SortMemberPath).Except(Grouping).Except(Compute.Select(c => c.Attribute)))
                {
                    Compute.Add(new ComputeStruct() { Attribute = h, Aggregate = null });
                }
            }
        }

        private void gridCompute_Drop(object sender, DragEventArgs e)
        {
            Compute.Add(new ComputeStruct() { Attribute = (string)e.Data.GetData(typeof(string)), Aggregate = null });
        }

        private void gridFilters_Drop(object sender, DragEventArgs e)
        {
            var attr = (string)e.Data.GetData(typeof(string));
            Filters.Add(new FilterStruct() { Attribute = attr, Type = allHeaders[attr] });
        }

        private async void btnApply_Click(object sender, RoutedEventArgs e)
        {
            var prov = (IDataProvider)lstDataProviders.SelectedItem;
            var repository = (string)lstDataSources.SelectedItem;

            await Task.Run(() =>
            {
                LoadingProgress = -1;
                Status = "Initializing...";

                IEnumerable<object> data = null;// ((IDataProvider)prov).GetData(repository);
                //var ret = Comparison.InitiateDuplicates(data.Select(c => c), new Comparison.SequenceEqualityComparer(), new Comparison.SequenceEqualityComparer());
                LoadingProgress = 0;
                Status = "Loading data...";

                Dispatcher.Invoke(() =>
                {
                    gridData.ItemsSource = data;
                    gridData.Columns.Single(c => c.SortMemberPath == SortOrder).SortDirection = (currentSortDirectionAsc ? ListSortDirection.Ascending : ListSortDirection.Descending);
                });

                Status = "Done.";

            });
        }

        private void btnDeleteAggreg_Click(object sender, RoutedEventArgs e)
        {
            Compute.Remove((ComputeStruct)((Button)sender).Tag);
        }

        private void btnDeleteGrp_Click(object sender, RoutedEventArgs e)
        {
            Grouping.Remove((string)((Button)sender).Tag);
        }

        private void btnDeleteFilter_Click(object sender, RoutedEventArgs e)
        {
            Filters.Remove((FilterStruct)((Button)sender).Tag);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string currentSortAttribute = null;
        private bool currentSortDirectionAsc = true;
        private void gridData_Sorting(object sender, DataGridSortingEventArgs e)
        {
            currentSortDirectionAsc = (currentSortAttribute == e.Column.SortMemberPath) && !currentSortDirectionAsc;
            currentSortAttribute = e.Column.SortMemberPath;

            e.Column.SortDirection = currentSortDirectionAsc ? ListSortDirection.Ascending : ListSortDirection.Descending;

            btnApply_Click(null, null);

            e.Handled = true;
        }

        private async void btnRun_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();

            var prov = (IDataProvider)lstDataProviders.SelectedItem;
            var repository = (string)lstDataSources.SelectedItem;
            var allHeadersFu = prov.GetColumns(repository);
            string[] keys;
            string[] headers;
            if (lstColumns.SelectedItems.Count > 0)
            {
                keys = lstColumns.SelectedItems.Cast<string>().ToArray();
                headers = allHeadersFu.OrderBy(h => keys.Contains(h.Name) ? 0 : 1).Select(h => h.Name).ToArray();
            }
            else
            {
                headers = allHeadersFu.Select(h => h.Name).ToArray();
                keys = headers;
            }

            await Task.Run(() =>
            {
                LoadingProgress = -1;
                Status = "Loading data...";

                var data = prov.GetData(repository, headers);

                LoadingProgress = -1;

                var dataObjectArray = data.AsObjectCollection(KeepDuplicates && KeepDuplicates ? headers : keys).Select((a, i) => { Status = "Parsed " + i + " entries"; return a; }).ToList();

                LoadingProgress = 1;

                var keyComparer = new SequenceEqualityComparer(0, keys.Length);
                var cnt = dataObjectArray.Count();
                var ret = Comparison.InitiateDuplicates(dataObjectArray.Select((a, i) => { Status = "Checked " + i + " entries"; LoadingProgress = i * 100 / cnt; return a; }), keyComparer, new SequenceEqualityComparer()).Duplicates;

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

                LoadingProgress = 100;
                Status = "Done. " + cnt + " entries checked.";

            });
        }


        private void displayData(IEnumerable<object> data, string[] headers, int keysCount)
        {
            gridData.Columns.Clear();

            gridData.AutoGenerateColumns = false;

            if (data != null && data.Any())
            {
                if (KeepColumns && KeepDuplicates)
                {
                    gridData.Columns.AddAll(headers.Select((h, i) => new DataGridTextColumn() { Header = h, Binding = new Binding("[" + i + "]") }));
                }
                else
                {
                    gridData.Columns.AddAll(headers.Take(keysCount).Select((h, i) => new DataGridTextColumn() { Header = h, Binding = new Binding("[" + i + "]") }));
                }
                gridData.ItemsSource = data;
                gridData.IsEnabled = true;
            }
            else
            {
                gridData.IsEnabled = false;
            }
        }

    }
}
