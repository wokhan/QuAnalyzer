using System.Windows.Threading;

using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.Features.Statistics;

public partial class StatisticsHolder : ObservableObject
{
    public IQueryable Source { get; set; }
    public string Name { get; set; }
    public ObservableCollection<OccurencesResult> Occurences { get; } = new ObservableCollection<OccurencesResult>();

    [ObservableProperty]
    private StatsResult _statistics;
    
    private void UpdateStats(string attribute)
    {
        Statistics = StatsResult.GetStats(Source, attribute);
    }

    private async void UpdateOccurences(ColumnDescription column, Dispatcher dispatcher)
    {
        var occurences = OccurencesResult.CountOccurences(Source, column);
        await dispatcher.InvokeAsync(() => Occurences.AddAll(occurences));
    }

    internal void Update(ColumnDescription h, Dispatcher dispatcher)
    {
        UpdateStats(h.Name);
        UpdateOccurences(h, dispatcher);
    }
}
