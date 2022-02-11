
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

    

    //      public ObservableDictionary<string, Series> ComputedStatsForGraph { get; } = new ObservableDictionary<string, Series>();
    public ObservableCollection<StatisticsHolder> ComputedStats { get; } = new ObservableCollection<StatisticsHolder>();

   
    public StatisticsPage()
    {
        //ComputedStats = new Dictionary<string, ResultsStruct>();

        InitializeComponent();

        //LiveCharts.HasMapFor<Values>((v, point) => { point.PrimaryValue = v.Frequency; });

        //ComputedStats.CollectionChanged += ComputedStats_CollectionChanged;
        App.Instance.PropertyChanged += (s, e) => { if (e.PropertyName == nameof(App.CurrentSelection)) { UpdateSelection(); } };
    }

    private void ComputedStats_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        //((ResultsStruct)e.NewItems[0]).Frequencies.CollectionChanged += null;
        //            ComputedStatsForGraph.AddAll(e.NewItems.Cast<ResultsStruct>().Select(x => new PieSeries(Mappers.Pie<ResultsStruct>().Value(data => data))));
    }

    private void UpdateSelection()
    {
        var (prov, repo) = App.Instance.CurrentSelection;
        if (prov is not null && btnAuto.IsChecked.Value)
        {
            Computedata(prov, repo);
        }
    }

    [ICommand(CanExecute =nameof(CanExecuteRun))]
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

        await Task.Run(async () =>
        {
            Progress = -1;

            var headers = prv.GetColumns(repo);

            var data = prv.GetQueryable(repo);

            var results = headers.ToDictionary(h => h, h => new StatisticsHolder() { Name = h.Name, Source = data });
            await Dispatcher.InvokeAsync(() => ComputedStats.AddAll(results.Values));

            headers.AsParallel().ForAll(h => results[h].Update(h, Dispatcher));
        }).ConfigureAwait(false);
    }
}
