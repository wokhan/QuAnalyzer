using QuAnalyzer.DataProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using QuAnalyzer.Extensions;
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;
using QuAnalyzer.Logic;
using LinqExpressions = System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Collections;
using System.Data.Entity;
using AlphaChiTech.Virtualization;
using QuAnalyzer.Helpers;
using System.Windows.Threading;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Logique d'interaction pour DataViewer.xaml
    /// </summary>
    public partial class Viewer : Page, INotifyPropertyChanged
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

        private int _loadingProgress;
        public int LoadingProgress
        {
            get { return _loadingProgress; }
            set { _loadingProgress = value; NotifyPropertyChanged("LoadingProgress"); }
        }

        private ObservableCollection<string> _grouping = new ObservableCollection<string>();
        public ObservableCollection<string> Grouping
        {
            get { return _grouping; }
        }

        private ObservableCollection<FilterStruct> _filters = new ObservableCollection<FilterStruct>();
        public ObservableCollection<FilterStruct> Filters
        {
            get { return _filters; }
        }


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

        private ObservableCollection<ComputeStruct> _compute = new ObservableCollection<ComputeStruct>();
        public ObservableCollection<ComputeStruct> Compute
        {
            get { return _compute; }
        }

        private string SortOrder { get { return (currentSortAttribute != null && (!_grouping.Any() || _grouping.Concat(_compute.Select(f => f.Attribute)).Contains(currentSortAttribute))) ? currentSortAttribute : (_grouping.FirstOrDefault() ?? allHeaders.Keys.First()); } }

        public Viewer()
        {
            InitializeComponent();

            VirtualizationHelper.Init(Dispatcher);
        }

        private Dictionary<string, Type> allHeaders;
        private List<string> dispHeaders;
        private void lstDataSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstDataSources.SelectedItem != null)
            {
                ClearAll();

                btnApply_Click(null, null);
            }
            else
            {
                gridData.ItemsSource = null;
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
            if (!_grouping.Contains(src))
            {
                _grouping.Add(src);
                foreach (var h in gridData.Columns.Select(c => c.SortMemberPath).Except(_grouping).Except(_compute.Select(c => c.Attribute)))
                {
                    _compute.Add(new ComputeStruct() { Attribute = h, Aggregate = null });
                }
            }
        }

        private void gridCompute_Drop(object sender, DragEventArgs e)
        {
            _compute.Add(new ComputeStruct() { Attribute = (string)e.Data.GetData(typeof(string)), Aggregate = null });
        }

        private void gridFilters_Drop(object sender, DragEventArgs e)
        {
            var attr = (string)e.Data.GetData(typeof(string));
            _filters.Add(new FilterStruct() { Attribute = attr, Type = allHeaders[attr] });
        }

        private async void btnApply_Click(object sender, RoutedEventArgs e)
        {
            var prov = (IDataProvider)lstDataProviders.SelectedItem;
            var repository = (string)lstDataSources.SelectedItem;
            
            await Task.Run(() =>
            {
                LoadingProgress = -1;
                Status = "Initializing...";

                IQueryable query = prov.GetData(repository);
                allHeaders = prov.GetHeaders(repository);

                if (_filters.Any())
                {
                    var values = _filters.Select(f => f.TargetValueAsObject).ToArray();
                    query = query.Where(_filters.Select((f, i) => f.Attribute + f.ComparerExpression + " @" + i).Aggregate((a, b) => a + " AND " + b), values);
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

                var cmpAttrs = _compute.Where(c => c.Aggregate != null);
                if (_grouping.Any() && cmpAttrs.Any())
                {
                    query = DynamicQueryable.GroupBy(query, "new(" + String.Join(",", _grouping) + ")", "it")
                                                 .Select("new(it.Key." + String.Join(",it.Key.", _grouping) + "," + String.Join(",", cmpAttrs.Select(c => String.Format(c.Aggregate, c.Attribute) + " as " + c.Attribute)) + ")");
                }
                else
                {
                    /*if (!prov.IsDirectlyBindable)
                    {
                        dispHeaders = allHeaders.Keys.ToList();

                        Dispatcher.Invoke(GenHeaders);
                    }*/
                }

                LoadingProgress = 0;
                Status = "Loading data...";

                var data = VirtualizationHelper.GetVirtualizedSource(query.OrderBy(SortOrder + (currentSortDirectionAsc ? "" : " descending")));
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
    }
}
