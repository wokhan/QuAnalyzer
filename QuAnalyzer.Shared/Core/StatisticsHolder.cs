using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.Features.Statistics;

public partial class StatisticsHolder : ObservableObject
{
    public IQueryable Source { get; set; }
    public string Name { get; set; }
    public ObservableCollection<OccurencesResult> Occurences { get; } = new ObservableCollection<OccurencesResult>();

    [ObservableProperty]
    private StatsResult _statistics;
    
    private async void UpdateStats(string attribute)
    {
        Statistics = await Task.Run(() => StatsResult.GetStats(Source, attribute, Source.ElementType.GetProperty(attribute).PropertyType));
    }

    private async void UpdateOccurences(ColumnDescription column)
    {
        var occurences = await Task.Run(() => OccurencesResult.CountOccurences(Source, column));
        Occurences.AddAll(occurences);
    }

    internal void Update(ColumnDescription h)
    {
        UpdateStats(h.Name);
        UpdateOccurences(h);
    }
}
