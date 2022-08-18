
using CommunityToolkit.Mvvm.ComponentModel;

namespace QuAnalyzer.Features.Comparison;

public partial class ItemResult<T> : ObservableObject
{
    public int Count { get; internal set; }

    //TODO: rename DuplicatesByKey?
    public List<T> Duplicates { get; } = new();

    //TODO: rename FullDuplicates? Clones?
    public List<T> PerfectDups { get; } = new();

    public List<T> Missing { get; } = new();

    public IEnumerable<T>? Samples { get; internal set; }
}
