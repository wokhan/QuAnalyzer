
using CommunityToolkit.Mvvm.Input;

using QuAnalyzer.Features.Statistics;

namespace QuAnalyzer.UI.Pages;

[ObservableObject]
public partial class StatisticsPage : Page
{
    public string[] ChartTypes { get; } = new[] { "Pie", "Bar", "Doughnut" };

    [ObservableProperty]
    private string _chartType = "Pie";

    [ObservableProperty]
    private bool _ignoreEmptyInChart = true;

    [ObservableProperty]
    private string _status;

    [ObservableProperty]
    private int _progress;

    [ObservableProperty]
    private bool _autoCompute;

    public ObservableCollection<StatisticsHolder> ComputedStats { get; } = new ObservableCollection<StatisticsHolder>();


    public StatisticsPage()
    {
        InitializeComponent();

        App.Instance.PropertyChanged += (s, e) => { if (e.PropertyName == nameof(App.CurrentSelection)) { UpdateSelection(); } };

        UpdateSelection();
    }

    private void UpdateSelection()
    {
        if (this.Parent is null)
        {
            return;
        }

        if (_autoCompute)
        {
            Run();
        }

        RunCommand.NotifyCanExecuteChanged();
    }

    private bool CanExecuteRun => App.Instance.CurrentSelection is not (null, null);

    [RelayCommand(CanExecute = nameof(CanExecuteRun))]
    private async void Run()
    {
        var (provider, repository) = App.Instance.CurrentSelection;

        if (provider is null)
        {
            return;
        }

        Status = "Preparing...";
        Progress = 0;
        ComputedStats.Clear();

        await Task.Run(() =>
        {
            var headers = provider.GetColumns(repository);

            var data = provider.GetQueryable(repository);

            var results = headers.ToDictionary(h => h, h => new StatisticsHolder() { Name = h.Name, Source = data });
            DispatcherQueue.TryEnqueue(() =>
            {
                Status = "Analyzing...";
                Progress = -1;

                ComputedStats.AddAll(results.Values);
                headers.AsParallel().ForAll(h => results[h].Update(h));

                Status = "Done!";
                Progress = 1;
            });
        }).ConfigureAwait(false);
    }
}
