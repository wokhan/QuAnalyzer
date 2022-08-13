
using CommunityToolkit.Mvvm.ComponentModel;

using QuAnalyzer.Features.Comparison.Results;

namespace QuAnalyzer.Features.Comparison;

[ObservableObject]
public partial class ComparisonResult<T>
{
    [ObservableProperty]
    private string? message;

    [ObservableProperty]
    private ProgressType progress;

    [ObservableProperty]
    private int scannedCount;

    [ObservableProperty]
    private int matchingCount;

    [ObservableProperty]
    private long totalTime;

    public ItemResult<T> Source { get; } = new ItemResult<T>();

    public ItemResult<T> Target { get; } = new ItemResult<T>();

    [ObservableProperty]
    private IList<(T First, T Second, int Index)> differences = new List<(T, T, int)>();

    public string[]? MergedHeaders { get; set; }

    public IEnumerable<Diff<T>>? MergedDiff { get; set; } = null;
}
