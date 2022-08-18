
using CommunityToolkit.Mvvm.ComponentModel;

using QuAnalyzer.Features.Comparison.Results;

namespace QuAnalyzer.Features.Comparison;

public partial class ComparisonResult<T> : ObservableObject
{
    public string? Message { get; internal set; }

    public int ProgressAsInt => (int)Progress;

    public ProgressType Progress { get; internal set; }

    public int ScannedCount { get; internal set; }

    public int MatchingCount { get; internal set; }

    public DateTime StartTime { get; internal set; }

    public long TotalTime { get; internal set; }

    public ItemResult<T> Source { get; } = new();

    public ItemResult<T> Target { get; } = new();

    public IList<(T First, T Second, int Index)> Differences { get; internal set; } = new List<(T, T, int)>();

    public string[]? MergedHeaders { get; set; }

    public IEnumerable<Diff<T>>? MergedDiff { get; set; }
}
