using System.Diagnostics;

namespace QuAnalyzer.Core.Helpers;

public class ResourcesWatcher : ObservableObject
{
    public static ResourcesWatcher Instance { get; } = new ResourcesWatcher();

    private PerformanceCounter cpuCounter;

    private PerformanceCounter memoryCounter;

    private PerformanceCounter threadsCounter;

    public string MemoryUseFormatted => (int)(memoryCounter.NextValue() / 1024f / 1024f) + "MB";

    public int ThreadsCount => (int)threadsCounter.NextValue();

    public int CPUUsage => (int)cpuCounter.NextValue();

    private DispatcherTimer timer;

    private ResourcesWatcher()
    {
        string processName;
        using (Process process = Process.GetCurrentProcess())
        {
            processName = process.ProcessName;
        }

        memoryCounter = new PerformanceCounter("Process", "Working Set - Private", processName, readOnly: true);
        threadsCounter = new PerformanceCounter("Process", "Thread Count", processName, readOnly: true);
        cpuCounter = new PerformanceCounter("Process", "% Processor Time", processName, readOnly: true);

        timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1.0) };
        timer.Tick += Timer_Tick;
        timer.Start(); 
    }

    ~ResourcesWatcher()
    {
        timer?.Stop();
        memoryCounter.Dispose();
        threadsCounter.Dispose();
        cpuCounter.Dispose();
    }

    private void Timer_Tick(object sender, object e)
    {
        OnPropertyChanged(nameof(MemoryUseFormatted));
        OnPropertyChanged(nameof(CPUUsage));
        OnPropertyChanged(nameof(ThreadsCount));
    }
}