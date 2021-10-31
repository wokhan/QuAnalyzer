using QuAnalyzer.Core.Helpers;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.UI.Windows;

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
using Wokhan.UI.Extensions;
using Wokhan.ComponentModel.Extensions;
using QuAnalyzer.Features.Comparison;
using System.Collections;

namespace QuAnalyzer.UI.Controls
{
    /// <summary>
    /// Logique d'interaction pour ExtendedDataGridView.xaml
    /// </summary>
    public partial class ExtendedDataGridView : UserControl, INotifyPropertyChanged
    {
        public bool AutoGenerateColumns { get => gridData.AutoGenerateColumns; set => gridData.AutoGenerateColumns = value; }
        public ObservableCollection<DataGridColumn> Columns => gridData.Columns;

        private IQueryable _source;
        public IQueryable Source
        {
            get => _source;
            set { _source = value; ClearAll(); Reload(); }
        }

        private bool _enableAdvancedFilters;
        public bool EnableAdvancedFilters
        {
            get => _enableAdvancedFilters;
            set => this.SetValue(ref _enableAdvancedFilters, value, NotifyPropertyChanged);
        }

        private List<ColumnDescription> _customHeaders;
        public List<ColumnDescription> CustomHeaders
        {
            get => _customHeaders;
            set => this.SetValue(ref _customHeaders, value, NotifyPropertyChanged);
        }


        public static Dictionary<string, string> AggregationFormula => new Dictionary<string, string>
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

        public static Dictionary<string, string> FilterFormula //Func<LinqExpressions.Expression, LinqExpressions.Expression, LinqExpressions.BinaryExpression>> FilterFormula
=> new Dictionary<string, string>
                {
                    { "Equals", "=" },
                    { "Differs from", "<>" },
                    { "Greater than", ">" },
                    { "Greater than or equal", ">=" },
                    { "Less than", "<" },
                    { "Less than or equal", "<=" }
                };

        private string _status;
        public string Status
        {
            get => _status;
            set => this.SetValue(ref _status, value, NotifyPropertyChanged);
        }

        private int _loadingProgress;
        public int LoadingProgress
        {
            get => _loadingProgress;
            set => this.SetValue(ref _loadingProgress, value, NotifyPropertyChanged);
        }

        public ObservableCollection<string> Grouping { get; } = new ObservableCollection<string>();

        public ObservableCollection<FilterStruct> Filters { get; } = new ObservableCollection<FilterStruct>();


        public class ComputeStruct
        {
            public string Attribute { get; set; }
            public string DisplayName { get; set; }
            public string Aggregate { get; set; }
        }

        public class FilterStruct
        {
            public string Attribute { get; set; }
            public string DisplayName { get; set; }
            public Type Type { get; set; }
            public string ComparerExpression { get; set; }

            public object TargetValue { get; set; }
            /*public string TargetValue
            {
                get { return TargetValueAsObject is not null ? TargetValueAsObject.ToString() : String.Empty; }
                set { TargetValueAsObject = Convert.ChangeType(value, Type); }
            }*/
        }

        public string CustomFilter { get; set; }

        public bool IsCustomFilterError => CustomFilterError is not null;

        private string _customFilterError;
        public string CustomFilterError
        {
            get => _customFilterError;
            set { _customFilterError = value; NotifyPropertyChanged(nameof(CustomFilterError)); NotifyPropertyChanged(nameof(IsCustomFilterError)); }
        }

        public ObservableCollection<ComputeStruct> Compute { get; } = new ObservableCollection<ComputeStruct>();

        private string SortOrder => (currentSortAttribute is not null && (!Grouping.Any() || Grouping.Concat(Compute.Select(f => f.Attribute)).Contains(currentSortAttribute))) ? currentSortAttribute : (Grouping.FirstOrDefault() ?? CustomHeaders?.FirstOrDefault()?.Name);

        public Style CellStyle => gridData.CellStyle;

        public ExtendedDataGridView()
        {
            InitializeComponent();

            VirtualizedQueryableExtensions.Init(Dispatcher);
        }


        private void ClearAll()
        {
            Grouping.Clear();
            Compute.Clear();
            Filters.Clear();
        }

        //TODO: Generic
        private void GlobalExportCSV_Click(object sender, RoutedEventArgs e)
        {
            var host = ((ModernMain)Window.GetWindow(this)).stackExports;
            gridData.ExportAsXLSX(host: host, callback: SharedCallback.GetCallBackForExport(host, "Export", null));
        }

        private void GlobalExportHTML_Click(object sender, RoutedEventArgs e)
        {
            gridData.ExportAsHTML();
        }

        private void GlobalCopy_Click(object sender, RoutedEventArgs e)
        {
            gridData.CopyToClipboard();
        }

        private Point startPoint;
        private void DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void DataGrid_MouseMove(object sender, MouseEventArgs e)
        {
            Vector diff = startPoint - e.GetPosition(null);
            if (e.LeftButton == MouseButtonState.Pressed && (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                DragDrop.DoDragDrop((Control)sender, new DataObject(((DataGridColumnHeader)sender).Column.SortMemberPath), DragDropEffects.Link);
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

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            Reload();
        }

        private async void Reload()
        {
            if (Source is null)
            {
                gridData.ItemsSource = Enumerable.Range(0, 100);
                gridData.Columns.Add(new DataGridTextColumn() { Header = "..." });
                gridData.IsEnabled = false;
                return;
            }

            if (AutoGenerateColumns)
            {
                gridData.Columns.Clear();
            }
            gridData.IsEnabled = true;

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

                if (!string.IsNullOrEmpty(CustomFilter))
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

                query = query.AggregateBy(Grouping, Compute.Where(c => c.Aggregate is not null).ToDictionary(c => c.Attribute, c => c.Aggregate));
                {
                    /*if (!prov.IsDirectlyBindable)
                    {
                        dispHeaders = allHeaders.Keys.ToList();

                        Dispatcher.Invoke(GenHeaders);
                    }*/
                }

                LoadingProgress = 0;
                Status = "Loading data...";

                if (SortOrder is not null)
                {
                    query = query.OrderBy(SortOrder + (currentSortDirectionAsc ? "" : " descending"));
                }

                IEnumerable virtualizedData;
                //TODO: temporary workaround since Object[] collections are not supported by AsVirtualized yet.
                // One could wonder WHY I'm using object[] collections for a start, but tbh I don't remember.
                // Performance was probably worse with dynamically typed collections?
                try
                {
                    virtualizedData = query.AsVirtualized();
                }
                catch
                {
                    virtualizedData = query;
                }

                Dispatcher.Invoke(() =>
                {
                    gridData.SelectedItems.Clear();
                    gridData.ItemsSource = virtualizedData;
                    if (SortOrder is not null && gridData.Columns.Any())
                    {
                        gridData.Columns.FirstOrDefault(c => c.SortMemberPath == SortOrder).SortDirection = (currentSortDirectionAsc ? ListSortDirection.Ascending : ListSortDirection.Descending);
                    }
                });

                Status = "Done.";

            }).ConfigureAwait(false);
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string currentSortAttribute = null;
        private bool currentSortDirectionAsc = true;
        private void gridData_Sorting(object sender, DataGridSortingEventArgs e)
        {
            currentSortDirectionAsc = (currentSortAttribute == e.Column.SortMemberPath) && !currentSortDirectionAsc;
            currentSortAttribute = e.Column.SortMemberPath;

            e.Column.SortDirection = currentSortDirectionAsc ? ListSortDirection.Ascending : ListSortDirection.Descending;

            Reload();

            e.Handled = true;
        }
    }
}
