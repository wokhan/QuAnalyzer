using CommunityToolkit.Mvvm.Input;

using QuAnalyzer.Core.Helpers;

using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Comparison.Comparers;

using System.Linq.Dynamic.Core;

using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.UI.Pages;

[ObservableObject]
public partial class Duplicates : Page
{

    [ObservableProperty]
    private bool _keepDuplicates;


    [ObservableProperty]
    private bool _keepColumns = true;

    public Duplicates()
    {
        InitializeComponent();

        App.Instance.PropertyChanged += App_PropertyChanged;
        lstColumns.SelectionChanged += LstColumns_SelectionChanged;

        UpdateSelection();
    }

    private void LstColumns_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        RunCommand.NotifyCanExecuteChanged();
    }

    private void App_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(App.CurrentSelection))
        {
            UpdateSelection();
        }
    }

    private void UpdateSelection()
    {
        if (this.Parent is null)
        {
            return;
        }

        var (prov, repo) = App.Instance.CurrentSelection;
        if (prov is not null)
        {
            lstColumns.ItemsSource = prov.GetColumns(repo);
        }
    }

    [RelayCommand(AllowConcurrentExecutions = false, CanExecute = nameof(CanExecuteRun))]
    private async Task Run()
    {
        var (prov, repository) = App.Instance.CurrentSelection;

        var columns = prov.GetColumns(repository);
        string[] keys;
        string[] headers;
        if (lstColumns.SelectedItems.Count > 0)
        {
            keys = lstColumns.SelectedItems.Cast<ColumnDescription>().Select(c => c.Name).ToArray();
            headers = columns.OrderBy(h => keys.Contains(h.Name) ? 0 : 1).Select(h => h.Name).ToArray();
        }
        else
        {
            headers = columns.Select(h => h.Name).ToArray();
            keys = headers;
        }

        var progressCallback = new Progress<int>((i) => gridData.Status = $"Checked {i} entries");

        gridData.LoadingProgress = -1;

        var duplicates = await Task.Run(() =>
        {
            var data = prov.GetQueryable(repository);

            var keysAsString = String.Join(",", keys);

            if (!KeepDuplicates || !KeepColumns)
            {
                data = data.Select($"new({keysAsString})");
            }

            // Ordering by selected columns is required for comparison as items need to be sorted first.
            data = data.OrderBy(keysAsString);

            var comparer = DynamicComparer.Create(data.ElementType, keys);

            var duplicates = GenericMethodHelper.InvokeGenericStatic<IEnumerable>(typeof(Comparison), nameof(Comparison.GetDuplicates), new[] { data.ElementType }, data, keys, comparer, progressCallback);

            if (!KeepDuplicates)
            {
                duplicates = duplicates.AsQueryable()
                                       .GroupBy($"new({keysAsString})")
                                       .Select($"new({String.Join(",", keys.Select(key => "Key." + key))},Count() as Count)")
                                       .OrderBy("Count descending");
            }

            return duplicates;
        }).ConfigureAwait(true);

        gridData.ItemsSource = duplicates;
        gridData.LoadingProgress = 100;
    }

    private bool CanExecuteRun => lstColumns?.SelectedItems.Count > 0;
}
