using System.Threading;

namespace QuAnalyzer.Core.Helpers;

public partial class GlobalTask : ObservableObject
{
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private double progress = -1;

    public IProgress<double> ProgressCallback { get; private set; }

    public CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();

    public static ObservableCollection<GlobalTask> Tasks { get; } = new();

    public static GlobalTask AddNew(string title)
    {
        var task = new GlobalTask() { Title = title };

        task.ProgressCallback = new Progress<double>(i => task.Progress = i);
        
        Tasks.Add(task);

        return task;
    }
}
