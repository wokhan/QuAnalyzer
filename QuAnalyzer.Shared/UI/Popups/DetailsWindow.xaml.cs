﻿
using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Navigation;

using QuAnalyzer.Core.Extensions;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Comparison.Results;
using QuAnalyzer.UI.Controls;
using QuAnalyzer.UI.Windows;

using Wokhan.Data.Providers.Bases;

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

        NavView_ItemInvoked(NavView, null);
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

    private void InitGrids(ComparerDefinition<object[]> r)
    {
        var results = r.Results;

        results.InitDiff(r);

        displayDiffData(dgDiff, results.MergedDiff, results.MergedHeaders, r.SourceKeys.Count);

        displayData(dgMissingSource, results.Source.Missing, r.SourceHeaders.ToArray(), r.SourceKeys.Count);
        displayData(dgMissingTarget, results.Target.Missing, r.TargetHeaders.ToArray(), r.TargetKeys.Count);

        displayData(dgSourceDups, results.Source.Duplicates, r.SourceHeaders.ToArray(), r.SourceKeys.Count);
        displayData(dgTargetDups, results.Target.Duplicates, r.TargetHeaders.ToArray(), r.TargetKeys.Count);

        displayData(dgSourcePerfectDups, results.Source.PerfectDups, r.SourceHeaders.ToArray(), r.SourceKeys.Count);
        displayData(dgTargetPerfectDups, results.Target.PerfectDups, r.TargetHeaders.ToArray(), r.TargetKeys.Count);
    }

    private void displayDiffData(ExtendedDataGridView gridData, IEnumerable<Diff<object[]>> data, string[] headers, int keysCount)
    {
        gridData.Columns.Clear();

        gridData.Columns.Add(new DataGridTextColumn() { Header = "Origin", Binding = new Binding() { Path = new PropertyPath(nameof(Diff<object[]>.Source)) } });

        if (data is not null && data.Any())
        {
            /*if (headers is null)
            {
                headers = Enumerable.Range(0, data.First().Values.Count()).Select(h => "P" + h).ToArray();
            }*/

            for (int i = 0; i < headers.Length; i++)
            {
                //TODO: WINUI
                //var trigger = new DataTrigger()
                //{
                //    Value = true,
                //    Binding = new Binding($"{nameof(Diff<object[]>.IsDiff)}[{i}]"),
                //    Setters = { new Setter(Control.ForegroundProperty, Brushes.Red) }
                //};

                //var style = new Style()
                //{
                //    TargetType = typeof(DataGridCell),
                //    BasedOn = gridData.CellStyle,
                //    Triggers = { trigger }
                //};

                var col = new DataGridTextColumn()
                {
                    Header = headers[i],
                    Binding = new Binding() { Path = new PropertyPath($"{nameof(Diff<object[]>.Values)}[{i}]") },
                    FontWeight = (i < keysCount ? FontWeights.Bold : FontWeights.Normal),
                    //CellStyle = style
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
            gridData.CustomHeaders = headers.Select((h, i) => new ColumnDescription() { Name = $"it[{i}]", DisplayName = h + (i < keysCount ? "*" : "") }).ToList();
            gridData.ItemsSource = data;
        }
        else
        {
            gridData.IsEnabled = false;
        }
    }
}
