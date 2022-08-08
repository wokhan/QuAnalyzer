
using CommunityToolkit.Mvvm.Input;

using QuAnalyzer.Features.Statistics;

using Wokhan.Data.Providers.Contracts;

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
        var (prov, repo) = App.Instance.CurrentSelection;
        if (prov is not null && _autoCompute)
        {
            Computedata(prov, repo);

        }

        RunCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand(CanExecute = nameof(CanExecuteRun))]
    private void Run()
    {
        var (prov, repo) = App.Instance.CurrentSelection;
        Computedata(prov, repo);
    }

    private bool CanExecuteRun => App.Instance.CurrentSelection is not (null, null);

    private async void Computedata(IDataProvider prv, string repo)
    {
        Progress = 0;
        ComputedStats.Clear();

        await Task.Run(() =>
        {
            var headers = prv.GetColumns(repo);

            var data = prv.GetQueryable(repo);

            var results = headers.ToDictionary(h => h, h => new StatisticsHolder() { Name = h.Name, Source = data });
            DispatcherQueue.TryEnqueue(() =>
            {
                Progress = -1;

                ComputedStats.AddAll(results.Values);
                headers.AsParallel().ForAll(h => results[h].Update(h));

                Progress = 100;
            });
        }).ConfigureAwait(false);
    }
}
