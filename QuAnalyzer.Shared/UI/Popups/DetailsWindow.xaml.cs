
using CommunityToolkit.WinUI.UI.Controls;
using CommunityToolkit.WinUI.UI.Converters;

using Microsoft.UI;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

using QuAnalyzer.Core.Extensions;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Comparison.Results;
using QuAnalyzer.UI.Controls;

using Windows.UI.Text;

namespace QuAnalyzer.UI.Popups;

public partial class DetailsWindow : Page
{
    public ComparerDefinition<object[]> Comparer { get; private set; }


    /*private int _gridDiffExported;
    public int GridDiffExported
    {
        get { return _gridDiffExported; }
        set { _gridDiffExported = value; NotifyPropertyChanged("GridDiffExported"); }
    }*/

    public DetailsWindow()
    {
        InitializeComponent();

        dgDiff.LoadingRow += DgDiff_LoadingRow;

        NavView_ItemInvoked(NavView, null);
    }

    private void DgDiff_LoadingRow(object sender, DataGridRowEventArgs e)
    {
        var mod = e.Row.GetIndex() % 4;
        if (mod == 1 || mod == 0)
        {
            e.Row.Background = new SolidColorBrush(Colors.DarkSlateGray);
        }
        else
        {
            e.Row.Background = null;
        }
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        Comparer = e.Parameter as ComparerDefinition<object[]>;

        GenericPopup.UpdateCurrent(this, title: $"Comparison details: {Comparer.Name} (Source: {Comparer.SourceName} / Target: {Comparer.TargetName})");

        InitGrids(Comparer);
    }

    private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        var navItems = sender.MenuItems.OfType<NavigationViewItem>();
        var item = args is not null ? navItems.First(x => (string)x.Content == (string)args.InvokedItem) : navItems.First();
        ContentFrame.Content = item.Tag;
    }

    private void InitGrids(ComparerDefinition<object[]> definition)
    {
        var results = definition.Results;

        //results.InitDiff(r);

        var sourceName = definition.SourceName;
        var targetName = definition.TargetName;

        var mergedHeaders = definition.SourceHeaders.Zip(definition.TargetHeaders, (src, trg) => src + (src != trg ? "/" + trg : String.Empty)).ToArray();

        var mergedDiff = results.Differences.SelectMany(x => new[] {
                                    new object [] { sourceName }.Concat(x.Source.Select(fs => new { Value = fs, IsTarget = false, IsDiff = false })).ToArray(),
                                    new object [] { targetName }.Concat(x.Target.Zip(x.Source).Select((zipped, i) => new { Value = zipped.First, IsTarget = true, IsDiff = i >= x.Index && !Equals(zipped.First, zipped.Second) })).ToArray()
                                });

        displayDiffData(dgDiff, mergedDiff, mergedHeaders, definition.SourceKeys.Count);

        displayData(dgMissingSource, results.Source.Missing, definition.SourceHeaders.ToArray(), definition.SourceKeys.Count);
        displayData(dgMissingTarget, results.Target.Missing, definition.TargetHeaders.ToArray(), definition.TargetKeys.Count);

        displayData(dgSourceDups, results.Source.Duplicates, definition.SourceHeaders.ToArray(), definition.SourceKeys.Count);
        displayData(dgTargetDups, results.Target.Duplicates, definition.TargetHeaders.ToArray(), definition.TargetKeys.Count);

        displayData(dgSourcePerfectDups, results.Source.PerfectDups, definition.SourceHeaders.ToArray(), definition.SourceKeys.Count);
        displayData(dgTargetPerfectDups, results.Target.PerfectDups, definition.TargetHeaders.ToArray(), definition.TargetKeys.Count);
    }

    public class BobbyConverter : BoolToObjectConverter
    {
        public new object Convert(object value, Type targetType, object parameter, string language)
        {
            var val = base.Convert(value, targetType, parameter, language);
            return val;
        }
    }

    public class CustomColumn : DataGridTemplateColumn
    {
        public bool IsKey { get; set; }
        public int Index { get; set; }
        public FontWeight FontWeight { get; set; }

        private static Brush RedBrush = new SolidColorBrush(Colors.Red);

        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            var data = (dynamic)((object[])dataItem)[Index];
            if (data.IsTarget && IsKey)
            {
                return new TextBlock();
            }

            return new TextBlock()
            {
                Text = data.Value.ToString(),
                Foreground = data.IsDiff ? RedBrush : null,
                FontWeight = IsKey ? FontWeights.Bold : FontWeights.Normal
            };
        }
    }

    private void displayDiffData(ExtendedDataGridView gridData, IEnumerable<object[]> data, string[] headers, int keysCount)
    {
        gridData.Columns.Clear();

        gridData.Columns.Add(new DataGridTextColumn() { Header = "Origin", Binding = new Binding() { Path = new PropertyPath("[0]") } });

        if (data is not null && data.Any())
        {
            for (int i = 0; i < headers.Length; i++)
            {
                var col = new CustomColumn()
                {
                    Index = i + 1,
                    Header = headers[i],
                    IsKey = (i < keysCount)
                };

                gridData.Columns.Add(col);
            }
        }
        else
        {
            gridData.IsEnabled = false;
        }

        gridData.ItemsSource = data;
    }

    private void displayData<T>(ExtendedDataGridView gridData, IEnumerable<T> data, string[] headers, int keysCount)
    {
        /*gridData.Columns.Clear();

        gridData.AutoGenerateColumns = false;

        if (data is not null && data.Any())
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
        }*/
        if (data is not null && data.Any())
        {
            var columns = headers.Select((h, i) => new DataGridTextColumn()
            {
                Header = h + (i < keysCount ? "*" : ""),
                Binding = new Binding() { Path = new PropertyPath($"[{i}]") }
            });

            gridData.Columns.AddAll(columns);
            //headers.Select((h, i) => new ColumnDescription() { Name = $"it[{i}]", DisplayName = h + (i < keysCount ? "*" : "") }).ToList();
            gridData.ItemsSource = data;
        }
        else
        {
            gridData.IsEnabled = false;
        }
    }
}
