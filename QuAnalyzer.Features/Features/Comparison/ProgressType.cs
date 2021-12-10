namespace QuAnalyzer.Features.Comparison;

public enum ProgressType
{
    LoadingData = 0,
    LoadingDone = 1,
    GettingSamples = 10,
    Filtering = 20,
    Comparing = 30,
    CheckingSourceOnly = 50,
    CheckingTargetOnly = 60,
    CheckingSourceMissing = 70,
    CheckingTargetMissing = 80,
    Done = 100,
    Canceling = -1,
    Canceled = -2,
    Failed = -3
}
