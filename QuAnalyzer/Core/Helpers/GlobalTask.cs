namespace QuAnalyzer.Core.Helpers;

public partial class GlobalTask : ObservableObject
{
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private double? progress;

    public CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();
}
