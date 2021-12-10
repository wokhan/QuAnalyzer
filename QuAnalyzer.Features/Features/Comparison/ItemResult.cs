
using Wokhan.ComponentModel.Extensions;
using Wokhan.Core.ComponentModel;

namespace QuAnalyzer.Features.Comparison;

public class ItemResult<T> : NotifierHelper
{
    private int count;
    public int Count
    {
        get => count;
        internal set => this.SetValue(ref count, value, NotifyPropertyChanged);
    }

    private IList<T> differences;
    public IList<T> Differences
    {
        get => differences;
        internal set => this.SetValue(ref differences, value, NotifyPropertyChanged);
    }

    private IList<T> duplicates;
    public IList<T> Duplicates
    {
        get => duplicates;
        internal set => this.SetValue(ref duplicates, value, NotifyPropertyChanged);
    }

    private IList<T> perfectDups;
    public IList<T> PerfectDups
    {
        get => perfectDups;
        internal set => this.SetValue(ref perfectDups, value, NotifyPropertyChanged);
    }

    private IList<T> missing;
    public IList<T> Missing
    {
        get => missing;
        internal set => this.SetValue(ref missing, value, NotifyPropertyChanged);
    }

    public IEnumerable<T> Samples { get; internal set; }

    private long loadingTime;
    public long LoadingTime
    {
        get => loadingTime;
        internal set => this.SetValue(ref loadingTime, value, NotifyPropertyChanged);
    }

    private DateTime startTime;
    public DateTime StartTime
    {
        get => startTime;
        internal set => this.SetValue(ref startTime, value, NotifyPropertyChanged);
    }
}
