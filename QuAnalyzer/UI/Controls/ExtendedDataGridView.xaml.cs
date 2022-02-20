using CommunityToolkit.Mvvm.Input;

using QuAnalyzer.Generic.Extensions;

using System.Linq.Dynamic.Core;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

using Wokhan.Data.Providers.Bases;
using Wokhan.Linq.Extensions;
using Wokhan.UI.Extensions;

namespace QuAnalyzer.UI.Controls;

[ObservableObject]
public partial class ExtendedDataGridView : DataGrid
{
    public IProgress<double> ExportProgressCallback { get; set; }

    public IEnumerable<string> DemoItems { get; } = new[] { "Item #1", "Item #2" };

    [ObservableProperty]
    private IQueryable _source;

    [ObservableProperty]
    private bool _enableAdvancedFilters;

    [ObservableProperty]
    private List<ColumnDescription> _customHeaders;

    [ObservableProperty]
    private string _status;

    [ObservableProperty]
    private int _loadingProgress;

    public ObservableCollection<string> Grouping { get; } = new();

    public ObservableCollection<FilterStruct> Filters { get; } = new();

    public string CustomFilter { get; set; }

    public bool IsCustomFilterError => CustomFilterError is not null;

    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(CustomFilterError), nameof(IsCustomFilterError))]
    private string _customFilterError;

    public ObservableCollection<ComputeStruct> Compute { get; } = new();

    private string SortOrder
    {
        get
        {
            if (currentSortAttribute is not null && (!Grouping.Any() || Grouping.Concat(Compute.Select(f => f.Attribute)).Contains(currentSortAttribute)))
            {
                return currentSortAttribute;
            }

            return (Grouping.FirstOrDefault() ?? CustomHeaders?.FirstOrDefault()?.Name);
        }
    }

    public ExtendedDataGridView()
    {
        InitializeComponent();

        this.PropertyChanged += ExtendedDataGridView_PropertyChanged;

        VirtualizedQueryableExtensions.Init(Dispatcher);
    }

    private void ExtendedDataGridView_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Source))
        {
            Dispatcher.Invoke(() =>
            {
                ClearAll();
                Reload();
            });
        }
    }

    [ICommand]
    private void ClearAll()
    {
        Grouping.Clear();
        Compute.Clear();
        Filters.Clear();
    }

    [ICommand]
    private void ExportCSV()
    {
        //TODO: Externalize (shouldn't be at the Control level)
        var (host, progress, cancellationToken) = App.Instance.AddTaskAndGetCallback("Exporting data");
        this.ExportAsXLSX(host: host, progress: progress, cancellationToken: cancellationToken);
    }

    [ICommand]
    private void ExportHTML()
    {
        //TODO: Externalize (shouldn't be at the Control level)
        this.ExportAsHTML();
    }
    
    [ICommand]
    private void Copy()
    {
        this.CopyToClipboard();
    }

    private Point startPoint;
    private void DataGrid_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        startPoint = e.GetPosition(null);
    }

    private void DataGrid_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
        Vector diff = startPoint - e.GetPosition(null);
        if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed && (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
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
            foreach (var h in this.Columns.Select(c => c.SortMemberPath).Except(Grouping).Except(Compute.Select(c => c.Attribute)))
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

    [ICommand(AllowConcurrentExecutions = false)]
    private async Task Reload()
    {
        if (Source is null)
        {
            this.ItemsSource = Enumerable.Range(0, 100);
            this.Columns.Add(new DataGridTextColumn() { Header = "..." });
            this.IsEnabled = false;
            return;
        }

        if (AutoGenerateColumns)
        {
            this.Columns.Clear();
        }
        this.IsEnabled = true;

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
                this.SelectedItems.Clear();
                this.ItemsSource = virtualizedData;
                if (SortOrder is not null && this.Columns.Any())
                {
                    this.Columns.First(c => c.SortMemberPath == SortOrder).SortDirection = (currentSortDirectionAsc ? ListSortDirection.Ascending : ListSortDirection.Descending);
                }
            });

            Status = "Done.";

        }).ConfigureAwait(false);
    }

    [ICommand]
    private void DeleteAggregation(ComputeStruct item)
    {
        Compute.Remove(item);
    }

    [ICommand]
    private void DeleteGroup(string groupName)
    {
        Grouping.Remove(groupName);
    }

    [ICommand]
    private void DeleteFilter(FilterStruct filter)
    {
        Filters.Remove(filter);
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
