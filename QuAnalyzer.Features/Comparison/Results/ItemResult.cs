
using CommunityToolkit.Mvvm.ComponentModel;

using System.Collections.ObjectModel;

namespace QuAnalyzer.Features.Comparison;

public partial class ItemResult<T> : ObservableObject
{
    [ObservableProperty]
    private int count;

    [ObservableProperty]
    private ObservableCollection<T> differences = new();

    //TODO: rename DuplicatesByKey?
    [ObservableProperty]
    private ObservableCollection<T> duplicates = new();

    //TODO: rename FullDuplicates? Clones?
    [ObservableProperty]
    private ObservableCollection<T> perfectDups = new();

    [ObservableProperty]
    private ObservableCollection<T> missing = new();

    public IEnumerable<T>? Samples { get; internal set; }

    [ObservableProperty]
    private long loadingTime;

    [ObservableProperty]
    private DateTime startTime;
}
