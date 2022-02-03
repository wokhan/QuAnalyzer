
using CommunityToolkit.Mvvm.ComponentModel;

namespace QuAnalyzer.Features.Comparison;

public partial class ItemResult<T> : ObservableObject
{
    [ObservableProperty]
    private int count;

    [ObservableProperty]
    private IList<T> differences = new List<T>();

    //TODO: rename DuplicatesByKey?
    [ObservableProperty]
    private IList<T> duplicates = new List<T>();

    //TODO: rename FullDuplicates? Clones?
    [ObservableProperty]
    private IList<T> perfectDups = new List<T>();

    [ObservableProperty]
    private IList<T> missing = new List<T>();

    public IEnumerable<T>? Samples { get; internal set; }

    [ObservableProperty]
    private long loadingTime;

    [ObservableProperty]
    private DateTime startTime;
}
