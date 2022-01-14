
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace QuAnalyzer.Features.Comparison;

public class ItemResult<T> : ObservableObject
{
    private int count;
    public int Count
    {
        get => count;
        internal set => this.SetProperty(ref count, value);
    }

    private IList<T> differences;
    public IList<T> Differences
    {
        get => differences;
        internal set => this.SetProperty(ref differences, value);
    }

    private IList<T> duplicates;
    //TODO: rename DuplicatesByKey?
    public IList<T> Duplicates
    {
        get => duplicates;
        internal set => this.SetProperty(ref duplicates, value);
    }

    private IList<T> perfectDups;
    //TODO: rename FullDuplicates? Clones?
    public IList<T> PerfectDups
    {
        get => perfectDups;
        internal set => this.SetProperty(ref perfectDups, value);
    }

    private IList<T> missing;
    public IList<T> Missing
    {
        get => missing;
        internal set => this.SetProperty(ref missing, value);
    }

    public IEnumerable<T> Samples { get; internal set; }

    private long loadingTime;
    public long LoadingTime
    {
        get => loadingTime;
        internal set => this.SetProperty(ref loadingTime, value);
    }

    private DateTime startTime;
    public DateTime StartTime
    {
        get => startTime;
        internal set => this.SetProperty(ref startTime, value);
    }
}
