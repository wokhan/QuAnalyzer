using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace QuAnalyzer.Features.Comparison;

/// <summary>
/// Only here because Generic classes are not inheriting ObservableObject properly (probably for some good reason, though)
/// </summary>
public abstract partial class ResultStructBase : ObservableObject
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
}