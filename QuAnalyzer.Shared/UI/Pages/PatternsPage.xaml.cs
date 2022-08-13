using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Controls.Primitives;

using System.Linq.Dynamic.Core;

namespace QuAnalyzer.UI.Pages;

[ObservableObject]
public partial class PatternsPage : Page
{
    private List<string> stringAttributes;

    public int SimThreshold { get; set; }
    public bool AutoUpdate { get; set; }

    [ObservableProperty]
    private IEnumerable data;

    [ObservableProperty]
    private double progress;

    [ObservableProperty]
    private string status;

    public PatternsPage()
    {
        InitializeComponent();

        App.Instance.PropertyChanged += (s, e) => { if (e.PropertyName == nameof(App.CurrentSelection)) { UpdateSelection(); } };

        UpdateSelection();
    }

    private async void UpdateSelection()
    {
        if (this.Parent is null)
        {
            return;
        }

        RunCommand.NotifyCanExecuteChanged();

        var (prov, repo) = App.Instance.CurrentSelection;
        var attr = (string)lstAttributes.SelectedValue;

        if (repo is not null && attr is null)
        {
            stringAttributes = prov.GetColumns(repo).Where(h => h.Type == typeof(string)).Select(h => h.Name).ToList();
            lstAttributes.ItemsSource = stringAttributes;
        }
        else if (AutoUpdate)
        {
            await RunCommand.ExecuteAsync(null);
            //await Run().ConfigureAwait(false);
        }
    }

    [RelayCommand(AllowConcurrentExecutions = false, CanExecute = nameof(CanExecuteRun))]
    private async Task Run()
    {
        var (prov, repo) = App.Instance.CurrentSelection;
        var attr = (string)lstAttributes.SelectedValue;

        gridPatterns.LoadingProgress = -1;
        gridPatterns.Status = "Analyzing...";

        await Task.Run(() =>
        {
            DispatcherQueue.TryEnqueue(() => Progress = 0);

            Data = prov.GetQueryable(repo)
                           .Select(attr)
                           .AsEnumerable()
                           .AsParallel()
                           .Select(value => value.ToString())
                           .Select(stringValue => new { stringValue, reg = Features.Patterns.Patterns.GetRegEx(stringValue, SimThreshold) })
                           .GroupBy(s => s.reg)
                           .Select(g => new { Pattern = g.Key, Count = g.Count(), Sample = g.First().stringValue })
                           .OrderByDescending(g => g.Count)
                           .ToList();
        });

        gridPatterns.LoadingProgress = 0;
        gridPatterns.Status = "Done!";

    }

    private bool CanExecuteRun => lstAttributes?.SelectedItems.Count > 0;

    private void lstDataSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateSelection();
    }

    private void slideSim_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        SimThreshold = (int)e.NewValue;
        if (gridPatterns is not null)
        {
            UpdateSelection();
        }
    }
}
