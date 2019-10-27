using QuAnalyzer.Generic.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Wokhan.Data.Providers.Bases;
using Wokhan.Linq.Extensions;
using Wokhan.WPF.Extensions;

namespace QuAnalyzer.UI.Controls
{
    /// <summary>
    /// Logique d'interaction pour ExtendedDataGridView.xaml
    /// </summary>
    public partial class ExtendedDataGridView : UserControl
    {
        public bool AutoGenerateColumns { get => gridData.AutoGenerateColumns; set => gridData.AutoGenerateColumns = value; }
        public ObservableCollection<DataGridColumn> Columns { get => gridData.Columns; }

        private IQueryable _source;
        public IQueryable Source
        {
            get { return _source; }
            set { _source = value; ClearAll(); btnApply_Click(null, null); }
        }

        public List<ColumnDescription> CustomHeaders { get; set; }


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
            set { _status = value; NotifyPropertyChanged(nameof(Status)); }
        }

        private int _loadingProgress;
        public int LoadingProgress
        {
            get { return _loadingProgress; }
            set { _loadingProgress = value; NotifyPropertyChanged(nameof(LoadingProgress)); }
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

            public object TargetValue { get; set; }
            /*public string TargetValue
            {
                get { return TargetValueAsObject != null ? TargetValueAsObject.ToString() : String.Empty; }
                set { TargetValueAsObject = Convert.ChangeType(value, Type); }
            }*/
        }

        public string CustomFilter { get; set; }

        public bool IsCustomFilterError { get { return CustomFilterError != null; } }

        private string _customFilterError;
        public string CustomFilterError
        {
            get { return _customFilterError; }
            set { _customFilterError = value; NotifyPropertyChanged(nameof(CustomFilterError)); NotifyPropertyChanged(nameof(IsCustomFilterError)); }
        }

        public ObservableCollection<ComputeStruct> Compute { get; } = new ObservableCollection<ComputeStruct>();

        private string SortOrder { get { return (currentSortAttribute != null && (!Grouping.Any() || Grouping.Concat(Compute.Select(f => f.Attribute)).Contains(currentSortAttribute))) ? currentSortAttribute : (Grouping.FirstOrDefault() ?? CustomHeaders.First().Name); } }

        public ExtendedDataGridView()
        {
            InitializeComponent();

            VirtualizedQueryableExtensions.Init(Dispatcher);

            CurrentSelection_CollectionChanged(null, null);
        }

        private List<string> dispHeaders;

        private void CurrentSelection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                gridData.IsEnabled = true;

                ClearAll();

                btnApply_Click(null, null);
            }
            else
            {
                gridData.ItemsSource = Enumerable.Range(0, 100);
                gridData.Columns.Add(new DataGridTextColumn() { Header = "..." });
                gridData.IsEnabled = false;
            }
        }

        private void ClearAll()
        {
            Grouping.Clear();
            Compute.Clear();
            Filters.Clear();
        }

        private void GenHeaders()
        {
            gridData.Columns.Clear();

            gridData.AutoGenerateColumns = false;

            for (int i = 0; i < dispHeaders.Count; i++)
            {
                gridData.Columns.Add(new DataGridTextColumn() { Header = dispHeaders[i], Binding = new Binding(dispHeaders[i]) });
            }
        }

        private void GlobalExportCSV_Click(object sender, RoutedEventArgs e) => gridData.ExportAsXLSX();

        private void GlobalExportHTML_Click(object sender, RoutedEventArgs e) => gridData.ExportAsHTML();

        private void GlobalCopy_Click(object sender, RoutedEventArgs e) => gridData.CopyToClipboard();

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
            Filters.Add(new FilterStruct() { Attribute = attr, Type = CustomHeaders.First(c => c.Name == attr).Type });
        }

        private async void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (Source == null)
            {
                return;
            }

            await Task.Run(() =>
            {
                LoadingProgress = -1;
                Status = "Initializing...";

                IQueryable query = Source;
                
                if (Filters.Any())
                {
                    var values = Filters.Select(f => f.TargetValue).ToArray();
                    query = query.Where(Filters.Select((f, i) => f.Attribute + f.ComparerExpression + " @" + i).Aggregate((a, b) => a + " AND " + b), values);
                }

                if (!String.IsNullOrEmpty(CustomFilter))
                {
                    try
                    {
                        query = query.Where(CustomFilter);
                        CustomFilterError = null;
                    }
                    catch (Exception exc)
                    {
                        CustomFilterError = exc.Message;
                    }
                }

                query = query.AggregateBy(Grouping, Compute.Where(c => c.Aggregate != null).ToDictionary(c => c.Attribute, c => c.Aggregate));
                {
                    /*if (!prov.IsDirectlyBindable)
                    {
                        dispHeaders = allHeaders.Keys.ToList();

                        Dispatcher.Invoke(GenHeaders);
                    }*/
                }

                LoadingProgress = 0;
                Status = "Loading data...";

                var data = query.OrderBy(SortOrder + (currentSortDirectionAsc ? "" : " descending"))
                                .AsVirtualized();
                Dispatcher.Invoke(() =>
                {
                    gridData.ItemsSource = data;
                    gridData.Columns.Single(c => c.SortMemberPath == SortOrder).SortDirection = (currentSortDirectionAsc ? ListSortDirection.Ascending : ListSortDirection.Descending);
                });

                Status = "Done.";

            });
        }

        private void btnDeleteAggreg_Click(object sender, RoutedEventArgs e) => Compute.Remove((ComputeStruct)((Button)sender).Tag);

        private void btnDeleteGrp_Click(object sender, RoutedEventArgs e) => Grouping.Remove((string)((Button)sender).Tag);

        private void btnDeleteFilter_Click(object sender, RoutedEventArgs e) => Filters.Remove((FilterStruct)((Button)sender).Tag);

        private void btnClear_Click(object sender, RoutedEventArgs e) => ClearAll();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
    }
}
