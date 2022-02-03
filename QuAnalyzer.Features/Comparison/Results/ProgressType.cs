namespace QuAnalyzer.Features.Comparison;

public enum ProgressType
{
    LoadingData = 0,
    LoadingDone = 1,
    GettingSamples = 10,
    Filtering = 20,
    Comparing = 30,
    Done = 100,
    Canceling = -1,
    Canceled = -2,
    Failed = -3
}
