
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace QuAnalyzer.Features.Monitoring;

public partial class ResultsClass : ObservableObject
{
    public MonitorItem Step { get; set; }

    public bool IsOK { get; set; }
    public DateTimeOffset LastCheck { get; } = DateTimeOffset.Now;

    [ObservableProperty]
    private Status status;
    
    public DateTimeOffset End { get; set; }

    [ObservableProperty]
    private long resultCount;
    
    public ObservableDictionary<string, long> Duration { get; } = new ObservableDictionary<string, long>();

    public int Occurence { get; set; }

    [ObservableProperty]
    private bool isSelected;
    
    [ObservableProperty]
    private object data;
    
    public string Name { get; internal set; }
    public string Id { get; internal set; }
    //public int Index { get; internal set; }
    public IList<Dictionary<string, string>> Values { get; internal set; }
}
