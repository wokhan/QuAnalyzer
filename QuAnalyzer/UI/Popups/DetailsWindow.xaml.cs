using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Generic.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Wokhan.Collections.Extensions;
using LinqExpressions = System.Linq.Expressions;

namespace QuAnalyzer.UI.Popups
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Page
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static Dictionary<string, Func<IEnumerable<object>, object>> AggregationFormula
        {
            get
            {
                return new Dictionary<string, Func<IEnumerable<object>, object>>
                {
                    { "Ignore", null },
                    { "Count", (x) => x.Count() },
                    { "Distinct Count", (x) => x.Distinct().Count() },
                    { "First", Enumerable.First },
                    { "Last", Enumerable.Last },
                    { "Sum", (x) => x.Select(xi => Convert.ToDouble(xi)).Sum() },
                    { "Average", (x) => x.Select(xi => Convert.ToDouble(xi)).Average() },
                    { "Min", Enumerable.Min },
                    { "Max", Enumerable.Max }
                };
            }
        }

        /*private int _gridDiffExported;
        public int GridDiffExported
        {
            get { return _gridDiffExported; }
            set { _gridDiffExported = value; NotifyPropertyChanged("GridDiffExported"); }
        }*/

        public static Dictionary<string, Func<LinqExpressions.Expression, LinqExpressions.Expression, LinqExpressions.BinaryExpression>> FilterFormula
        {
            get
            {
                return new Dictionary<string, Func<LinqExpressions.Expression, LinqExpressions.Expression, LinqExpressions.BinaryExpression>>
                {
                    { "Equals", LinqExpressions.Expression.Equal },
                    { "Greater than", LinqExpressions.Expression.GreaterThan },
                    { "Greater than or equal", LinqExpressions.Expression.GreaterThanOrEqual },
                    { "Less than", LinqExpressions.Expression.LessThan },
                    { "Less than or equal", LinqExpressions.Expression.LessThanOrEqual }
                };
            }
        }

        public ObservableCollection<string> Grouping { get; } = new ObservableCollection<string>();
        public ObservableCollection<FilterStruct> Filters { get; } = new ObservableCollection<FilterStruct>();


        public class ComputeStruct
        {
            public string Attribute { get; set; }
            public Func<IEnumerable<object>, object> Aggregate { get; set; }
        }

        public class FilterStruct
        {
            public string Attribute { get; set; }
            public Type Type { get; set; }
            public Func<LinqExpressions.Expression, LinqExpressions.Expression, LinqExpressions.BinaryExpression> ComparerExpression { get; set; }

            public object TargetValueAsObject { get; private set; }
            public string TargetValue
            {
                get { return TargetValueAsObject != null ? TargetValueAsObject.ToString() : String.Empty; }
                set { TargetValueAsObject = Convert.ChangeType(value, Type); }
            }
        }

        public ObservableCollection<ComputeStruct> Compute { get; } = new ObservableCollection<ComputeStruct>();

        private Dictionary<string, Type> allHeaders;
        private List<string> dispHeaders;
        private IEnumerable<object[]> currentData;

        public DetailsWindow(IDataComparer r)
        {
            InitializeComponent();

            this.DataContext = r;
            mainGrid.DataContext = r;

            InitGrids(r);
            this.Loaded += DetailsWindow_Loaded;

        }

        private void InitGrids(IDataComparer r)
        {
            var results = (ResultStruct<object[]>)((dynamic)r).Results;

            results.InitDiff(r);

            displayDiffData(dgDiff, results.MergedDiff, results.MergedHeaders, r.SourceKeys.Count);

            displayData(dgMissingSource, results.Source.Missing, r.SourceHeaders.ToArray(), r.SourceKeys.Count);
            displayData(dgMissingTarget, results.Target.Missing, r.TargetHeaders.ToArray(), r.TargetKeys.Count);

            displayData(dgSourceDups, results.Source.Duplicates, r.SourceHeaders.ToArray(), r.SourceKeys.Count);
            displayData(dgTargetDups, results.Target.Duplicates, r.TargetHeaders.ToArray(), r.TargetKeys.Count);

            displayData(dgSourcePerfectDups, results.Source.PerfectDups, r.SourceHeaders.ToArray(), r.SourceKeys.Count);
            displayData(dgTargetPerfectDups, results.Target.PerfectDups, r.TargetHeaders.ToArray(), r.TargetKeys.Count);

        }

        void DetailsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var actTab = tabs.Items.Cast<TabItem>().FirstOrDefault(t => t.IsEnabled);
            if (actTab != null)
            {
                tabs.SelectedItem = actTab;
            }
            else
            {
                //await MahApps.Metro.Controls.Dialogs.DialogManager.ShowMessageAsync((MetroWindow)Window.GetWindow(this), "", "Nothing to show.");
                ((MetroWindow)Window.GetWindow(this)).ShowMessageAsync("", "Nothing to show.");
            }
        }

        private void displayDiffData(DataGrid gridData, IEnumerable<DiffClass> data, string[] headers, int keysCount)
        {
            gridData.Columns.Clear();

            gridData.AutoGenerateColumns = false;

            gridData.Columns.Add(new DataGridTextColumn() { Header = "Origin", Binding = new Binding("Values[0]") });

            if (data != null && data.Any())
            {
                /*if (headers == null)
                {
                    headers = Enumerable.Range(0, data.First().Values.Count()).Select(h => "P" + h).ToArray();
                }*/

                for (int i = 0; i < headers.Length; i++)
                {
                    var col = new DataGridTextColumn()
                    {
                        Header = headers[i],
                        Binding = new Binding("Values[" + (i + 1) + "]"),
                        FontWeight = (i < keysCount ? FontWeights.Bold : FontWeights.Normal)
                    };

                    Style style = new Style();
                    style.TargetType = typeof(DataGridCell);
                    style.BasedOn = gridData.CellStyle;

                    DataTrigger trigger = new DataTrigger();
                    trigger.Value = true;
                    trigger.Binding = new Binding("IsDiff[" + (i + 1) + "]");
                    trigger.Setters.Add(new Setter(DataGridCell.ForegroundProperty, Brushes.Red));

                    style.Triggers.Add(trigger);

                    col.CellStyle = style;

                    gridData.Columns.Add(col);
                }
            }
            else
            {
                gridData.IsEnabled = false;
            }

            gridData.ItemsSource = data;
        }

        private void displayData<T>(DataGrid gridData, IEnumerable<T> data, string[] headers, int keysCount)
        {
            gridData.Columns.Clear();

            gridData.AutoGenerateColumns = false;

            if (data != null && data.Any())
            {
                gridData.Columns.AddAll(headers.Select((h, i) => new DataGridTextColumn()
                {
                    Header = h,
                    Binding = new Binding("[" + i + "]"),
                    FontWeight = (i < keysCount ? FontWeights.Bold : FontWeights.Normal)
                }));

                gridData.ItemsSource = data;
            }
            else
            {
                gridData.IsEnabled = false;
            }
        }

        private void ExportHTML_Click(object sender, RoutedEventArgs e)
        {
            var dg = (DataGrid)((Button)sender).CommandParameter;
            dg.ExportAsHTML();
        }

        private void ExportCSV_Click(object sender, RoutedEventArgs e)
        {
            var dg = (DataGrid)((Button)sender).CommandParameter;
            dg.ExportAsXLSX();
        }

        private void DGCopy_Click(object sender, RoutedEventArgs e)
        {
            var dg = (DataGrid)((Button)sender).CommandParameter;
            dg.CopyToClipboard();
        }

        private void lstGrouping_Drop(object sender, DragEventArgs e)
        {
            var src = (string)e.Data.GetData(typeof(string));
            if (!Grouping.Contains(src))
            {
                Grouping.Add(src);
                foreach (var h in allHeaders.Keys.Except(Grouping).Except(Compute.Select(c => c.Attribute)))
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

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Improve.
            var grpAttrs = Grouping.Select(g => new { Attribute = g, i = allHeaders.Keys.ToList().IndexOf(g) }).ToArray();
            var cmpAttrs = Compute.Where(c => c.Aggregate != null).Select(c => new { c.Attribute, i = allHeaders.Keys.ToList().IndexOf(c.Attribute), f = c.Aggregate });
            var grpAndCmpIx = grpAttrs.Concat(cmpAttrs.Select(c => new { c.Attribute, c.i })).ToDictionary(c => c.Attribute, c => c.i);

            IEnumerable<object[]> multigroup = currentData;
            if (Filters.Any())
            {
                var param = LinqExpressions.Expression.Parameter(typeof(object[]));

                var computedFilters = Filters.Select(f => f.ComparerExpression(LinqExpressions.Expression.Convert(LinqExpressions.Expression.ArrayIndex(param, LinqExpressions.Expression.Constant(allHeaders.Keys.ToList().IndexOf(f.Attribute))), f.Type), LinqExpressions.Expression.Constant(f.TargetValueAsObject, f.Type)));

                var filtersExpr = LinqExpressions.Expression.Lambda<Func<object[], bool>>(computedFilters.Aggregate((f, ff) => LinqExpressions.Expression.AndAlso(f, ff)), param);

                multigroup = multigroup.Where(filtersExpr.Compile());
            }

            if (grpAndCmpIx.Any())
            {
                //multigroup = multigroup.Select(c => grpAndCmpIx.Select(k => c[k.Value]).ToArray());
                var sc = new SequenceEqualityComparer();
                multigroup = multigroup.GroupBy(c => grpAttrs.Select(a => c[a.i]), sc)
                                       .Select(g => g.Key.Select(gg => gg)
                                                         .Concat(cmpAttrs.Select(h => h.f(g.Select(gg => gg[h.i]))))
                                                         .ToArray());

                dispHeaders = grpAttrs.Select(k => k.Attribute).Concat(cmpAttrs.Select(k => k.Attribute)).ToList();
            }
            else
            {
                dispHeaders = allHeaders.Keys.ToList();
            }

            //GenHeaders();

            //gridData.ItemsSource = multigroup;
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
            //ClearAll();
        }
    }
}
