using System.Threading;

namespace QuAnalyzer.Core.Helpers;

public partial class GlobalTask : ObservableObject
{
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private double progress = -1;

    public CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();
}
