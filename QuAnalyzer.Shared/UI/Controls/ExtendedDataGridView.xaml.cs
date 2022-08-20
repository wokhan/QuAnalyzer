using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Data;

using QuAnalyzer.Core.Extensions;
using QuAnalyzer.Generic.Extensions;

using System.Linq.Dynamic.Core;
using System.Threading;

using Windows.Devices.Input;

using Wokhan.Data.Providers.Bases;
using Wokhan.Linq.Extensions;

namespace QuAnalyzer.UI.Controls;

[ObservableObject]
public partial class ExtendedDataGridView : UserControl
{
    public IProgress<double> ExportProgressCallback { get; set; }

    public IEnumerable<string> DemoItems { get; } = new[] { "Item #1", "Item #2" };

    [ObservableProperty]
    private bool _enableAdvancedFilters;

    [ObservableProperty]
    private List<ColumnDescription> _customHeaders;

    [ObservableProperty]
    private string _status;

    [ObservableProperty]
    private bool _sourceIsQueryable;
    
    [ObservableProperty]
    private int _loadingProgress;

    [ObservableProperty]
    private long _itemsCount;

    [ObservableProperty]
    private long _loadedCount;

    public ObservableCollection<string> Grouping { get; } = new();

    public ObservableCollection<FilterStruct> Filters { get; } = new();

    [ObservableProperty]
    public bool isFiltersEmpty = true;

    public string CustomFilter { get; set; }

    [ObservableProperty]
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

        this.Loaded += ExtendedDataGridView_Loaded;

        Filters.CollectionChanged += Filters_CollectionChanged;

        Reload();
    }

    IList<ICommandBarElement> primaryCommands;
    private void ExtendedDataGridView_Loaded(object sender, RoutedEventArgs e)
    {
        if (primaryCommands is null)
        {
            primaryCommands = commandBar.PrimaryCommands.ToList();
        }

        commandBar.PrimaryCommands.ReplaceAll(CustomCommandBarElements.Concat(primaryCommands));
    }

    private void Filters_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        IsFiltersEmpty = !Filters.Any();
    }


    private List<ICommandBarElement> addedCommandBarElements = new();
    partial void OnItemsSourceChanged(IEnumerable value)
    {
        ClearAll();
        Reload();
    }

    [RelayCommand]
    private void ClearAll()
    {
        ItemsCount = 0;
        LoadedCount = 0;
        Grouping.Clear();
        Compute.Clear();
        Filters.Clear();
    }

    [RelayCommand]
    private void ExportCSV()
    {
        //TODO: Externalize (shouldn't be at the Control level)
        //var (host, progress, cancellationToken) = App.Instance.AddTaskAndGetCallback("Exporting data");
        //this.ExportAsXLSX(host: host, progress: progress, cancellationToken: cancellationToken);
    }

    [RelayCommand]
    private void ExportHTML()
    {
        //TODO: Externalize (shouldn't be at the Control level)
        //this.ExportAsHTML();
    }

    [RelayCommand]
    private void Copy()
    {
        //this.CopyToClipboard();
    }

    private void DataGrid_MouseMove(object sender, MouseEventArgs e)
    {
        //if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed && (Math.Abs(e.MouseDelta.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
        //{
        //    DragDrop.DoDragDrop((Control)sender, new DataObject(((DataGridColumnHeader)sender).Column.SortMemberPath), DragDropEffects.Link);
        //    e.Handled = true;
        //}
    }

    private async void lstGrouping_Drop(object sender, DragEventArgs e)
    {
        var src = await e.DataView.GetTextAsync();
        if (!Grouping.Contains(src))
        {
            Grouping.Add(src);
            //foreach (var h in this.Columns.Select(c => c.SortMemberPath).Except(Grouping).Except(Compute.Select(c => c.Attribute)))
            //{
            //    Compute.Add(new ComputeStruct() { Attribute = h, Aggregate = null });
            //}
        }
    }

    private async void gridCompute_Drop(object sender, DragEventArgs e)
    {
        var attr = await e.DataView.GetTextAsync();
        Compute.Add(new ComputeStruct() { Attribute = attr, Aggregate = null });
    }

    private async void gridFilters_Drop(object sender, DragEventArgs e)
    {
        var attr = await e.DataView.GetTextAsync();
        Filters.Add(new FilterStruct() { Attribute = attr, Type = CustomHeaders.First(c => c.Name == attr).Type });
    }


    [RelayCommand]
    private void Reload()
    {
        if (ItemsSource is null)
        {
            Status = "Waiting for data...";
            gridData.IsHitTestVisible = false;
            return;
        }

        //gridData.IncrementalLoadingTrigger = IncrementalLoadingTrigger.None;
        //gridData.ItemsSource = null;
        gridData.Columns.Clear();
        gridData.SelectedItem = null;
        if (gridData.SelectionMode == DataGridSelectionMode.Extended)
        {
            gridData.SelectedItems.Clear();
        }

        gridData.AutoGenerateColumns = this.AutoGenerateColumns;

        gridData.IsEnabled = true;
        gridData.IsHitTestVisible = true;

        LoadingProgress = -1;
        Status = "Initializing...";

        SourceIsQueryable = ItemsSource is IQueryable;
        
        IQueryable query = ItemsSource.AsQueryable();

        if (Filters.Any())
        {
            var values = Filters.Select(f => f.TargetValue).ToArray();
            query = query.Where(Filters.Select((f, i) => f.Attribute + f.ComparerExpression + " @" + i).Aggregate((a, b) => a + " AND " + b), values);
        }

        if (!string.IsNullOrEmpty(CustomFilter))
        {
            //TODO: Hum... that try/catch block is useless => it will never throw since enumeration doesn't take place here... Check that!
            try
            {
                query = query.Where(CustomFilter);
                CustomFilterError = null;
            }
            catch (Exception exc)
            {
                CustomFilterError = exc.Message;
                LoadingProgress = 0;
                Status = "Failed";
                return;
            }
        }

        query = query.AggregateBy(Grouping, Compute.Where(c => c.Aggregate is not null).ToDictionary(c => c.Attribute, c => c.Aggregate));

        if (SortOrder is not null)
        {
            query = query.OrderBy(SortOrder + (currentSortDirectionAsc ? "" : " descending"));
        }

        //TODO: review for non-arrays when CustomHeaders are used as it seems incorrect
        //BTW, CustomHeaders seem useless to me (should directly use Columns, right?)
        if (!gridData.AutoGenerateColumns && this.CustomHeaders is not null)
        {
            gridData.Columns.AddAll(CustomHeaders.Select((h, i) => new DataGridTextColumn()
            {
                Header = h.DisplayName,
                Binding = new Binding() { Path = new PropertyPath(query.ElementType.IsArray ? $"[{i}]" : h.Name) },
                //Tag = h.Name,
                FontWeight = (h.IsKey ? FontWeights.Bold : FontWeights.Normal)
            }));
        }

        // Computing count on another thread to avoid blocking the main one (if counting cost is significant)
        _ = Task.Run(() =>
        {
            var count = query.Count();
            DispatcherQueue.TryEnqueue(() => ItemsCount = count);
        });

        if (SortOrder is not null && gridData.Columns.Any())
        {
            gridData.Columns.First(c => ((DataGridBoundColumn)c).Binding.Path.Path == SortOrder).SortDirection = (currentSortDirectionAsc ? DataGridSortDirection.Ascending : DataGridSortDirection.Descending);
        }

        //gridData.IncrementalLoadingTrigger = IncrementalLoadingTrigger.Edge;
        gridData.ItemsSource = query.AsIncremental(200, onLoad, onDone, onError);
    }

    private void onLoad()
    {
        Status = SourceIsQueryable ? "Querying..." : "Enumerating...";
        LoadingProgress = -1;
        progressBar.ShowError = false;
    }

    private void onDone()
    {
        Status = "Done";
        LoadingProgress = 0;
        progressBar.ShowError = false;
        LoadedCount = Math.Min(ItemsCount, LoadedCount + 200);
    }

    private void onError(Exception e)
    {
        Status = "Error";
        progressBar.ShowError = true;
    }

    [RelayCommand]
    private void DeleteAggregation(ComputeStruct item)
    {
        Compute.Remove(item);
    }

    [RelayCommand]
    private void DeleteGroup(string groupName)
    {
        Grouping.Remove(groupName);
    }

    [RelayCommand]
    private void DeleteFilter(FilterStruct filter)
    {
        Filters.Remove(filter);
    }

    public void ExportAsXLSX(string path = null, string worksheetName = null, Panel host = null, IProgress<double> progress = null, CancellationTokenSource cancellationToken = null)
    {
        gridData?.ExportAsXLSX(path, worksheetName, host, progress, cancellationToken);
    }

    private string currentSortAttribute = null;
    private bool currentSortDirectionAsc = true;

    private void gridData_Sorting(object sender, DataGridColumnEventArgs e)
    {
        var sortby = ((DataGridBoundColumn)e.Column).Binding.Path.Path;
        currentSortDirectionAsc = (currentSortAttribute == sortby) && !currentSortDirectionAsc;
        currentSortAttribute = sortby;

        e.Column.SortDirection = currentSortDirectionAsc ? DataGridSortDirection.Ascending : DataGridSortDirection.Descending;

        Reload();
    }

    [ObservableProperty]
    private object customCommandBarContent;

    public IList<ICommandBarElement> CustomCommandBarElements { get; } = new List<ICommandBarElement>();

    public DataGridSelectionMode SelectionMode
    {
        get => gridData.SelectionMode;
        set => gridData.SelectionMode = value;
    }

    public DataGridGridLinesVisibility GridLinesVisibility
    {
        get => gridData.GridLinesVisibility;
        set => gridData.GridLinesVisibility = value;
    }

    public bool CanUserSortColumns
    {
        get => gridData.CanUserSortColumns;
        set => gridData.CanUserSortColumns = value;
    }

    public bool CanUserResizeColumns
    {
        get => gridData.CanUserResizeColumns;
        set => gridData.CanUserResizeColumns = value;
    }

    public bool CanUserReorderColumns
    {
        get => gridData.CanUserReorderColumns;
        set => gridData.CanUserReorderColumns = value;
    }

    public int FrozenColumnCount
    {
        get => gridData.FrozenColumnCount;
        set => gridData.FrozenColumnCount = value;
    }

    [ObservableProperty]
    public bool _autoGenerateColumns;

    public DataGridLength ColumnWidth
    {
        get => gridData.ColumnWidth;
        set => gridData.ColumnWidth = value;
    }

    [ObservableProperty]
    public IEnumerable _itemsSource;

    public ObservableCollection<Style> RowGroupHeaderStyles => gridData.RowGroupHeaderStyles;
}
