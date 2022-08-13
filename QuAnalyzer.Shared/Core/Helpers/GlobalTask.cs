using System.Threading;

namespace QuAnalyzer.Core.Helpers;

public partial class GlobalTask : ObservableObject
{
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private double progress = -1;

    public CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();

    public static ObservableCollection<GlobalTask> Tasks { get; private set; } = new();

    /// <summary>
    /// Temporary method (the callback handling is not good, and the "host" retrieval ain't better)
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    internal static (Panel host, IProgress<double> progress, CancellationTokenSource cancelationToken) AddTaskAndGetCallback(string title)
    {
        var task = new GlobalTask() { Title = title };

        return (null,
                new Progress<double>(i =>
                {
                    if (task.Progress == -1)
                    {
                        Tasks.Add(task);
                    }
                    task.Progress = i;
                }),
                task.CancellationTokenSource
        );
    }
}
