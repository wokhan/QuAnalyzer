﻿
using CommunityToolkit.Mvvm.ComponentModel;

using QuAnalyzer.Features.Comparison.Results;

using Wokhan.Collections.Generic.Extensions;

namespace QuAnalyzer.Features.Comparison;

public partial class ComparisonResult<T> : ObservableObject
{
    [ObservableProperty]
    private string message;

    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(LocalProgress))]
    private ProgressType progress;

    [ObservableProperty]
    private int subProgress;

    [ObservableProperty]
    private int matchingCount;

    [ObservableProperty]
    private long totalTime;

    public int LocalProgress => (int)progress + subProgress;

    public ItemResult<T> Source { get; } = new ItemResult<T>();
    public ItemResult<T> Target { get; } = new ItemResult<T>();

    [ObservableProperty]
    private IList<(T First, T Second, int Index)> differences = new List<(T, T, int)>();

    public string[]? MergedHeaders { get; set; }

    public IEnumerable<Diff<T>>? MergedDiff { get; set; } = null;
    
    public void InitCollections(Func<IList<T>> collectionCtor)
    {
        //Differences = collectionCtor();
        Source.Differences = collectionCtor();
        Target.Differences = collectionCtor();
        Source.Missing = collectionCtor();
        Target.Missing = collectionCtor();
        Source.Duplicates = collectionCtor();
        Target.Duplicates = collectionCtor();
        Source.PerfectDups = collectionCtor();
        Target.PerfectDups = collectionCtor();
    }
}
