using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Data;

using System.Linq.Dynamic.Core;
using System.Windows.Threading;

using Windows.Devices.Input;
using Windows.UI.Core;

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

        this.PropertyChanged += ExtendedDataGridView_PropertyChanged;
    }

    private async void ExtendedDataGridView_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Source))
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                ClearAll();
                await Reload();
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
        //var (host, progress, cancellationToken) = App.Instance.AddTaskAndGetCallback("Exporting data");
        //this.ExportAsXLSX(host: host, progress: progress, cancellationToken: cancellationToken);
    }

    [ICommand]
    private void ExportHTML()
    {
        //TODO: Externalize (shouldn't be at the Control level)
        //this.ExportAsHTML();
    }

    [ICommand]
    private void Copy()
    {
        //this.CopyToClipboard();
    }

    //private Point startPoint;
    private void DataGrid_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        //startPoint = e.GetPosition(null);
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

        this.Columns.Clear();
        //TODO: review for non-arrays when CustomHeaders are used as it seems incorrect
        //BTW, CustomHeaders seem useless to me (should directly use Columns, right?)
        if (!AutoGenerateColumns && this.CustomHeaders is not null)
        {
            this.Columns.AddAll(CustomHeaders.Select((h, i) => new DataGridTextColumn()
            {
                Header = h.DisplayName,
                Binding = new Binding() { Path = new PropertyPath($"[{i}]") },
                //SortMemberPath = $"it[{i}]",
                FontWeight = (h.IsKey ? FontWeights.Bold : FontWeights.Normal)
            }));
        }

        this.IsEnabled = true;

        await Task.Run(async () =>
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
            // Virtualization doesn't work with arrays (and would be useless anyway as it's already in-memory)            
            if (query.ElementType.IsArray)
            {
                virtualizedData = query;
            }
            else
            {
                virtualizedData = query.AsVirtualized();
            }

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
            {
                this.SelectedItems.Clear();
                this.ItemsSource = virtualizedData;
                if (SortOrder is not null && this.Columns.Any())
                {
                    //this.Columns.First(c => c.SortMemberPath == SortOrder).SortDirection = (currentSortDirectionAsc ? ListSortDirection.Ascending : ListSortDirection.Descending);
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

    private void gridData_Sorting(object sender, DataGridColumnEventArgs e)
    {
        //currentSortDirectionAsc = (currentSortAttribute == e.Column.SortMemberPath) && !currentSortDirectionAsc;
        //currentSortAttribute = e.Column.SortMemberPath;

        //e.Column.SortDirection = currentSortDirectionAsc ? ListSortDirection.Ascending : ListSortDirection.Descending;

        //Reload();

        //e.Handled = true;
    }
}
