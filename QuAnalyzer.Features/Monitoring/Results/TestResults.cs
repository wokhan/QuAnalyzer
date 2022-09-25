
using CommunityToolkit.Mvvm.ComponentModel;

using System.Collections;

namespace QuAnalyzer.Features.Monitoring;

public partial class TestResults : ObservableObject
{
    public TestDefinition Step { get; internal set; }

    public bool IsOK { get; internal set; }
    public DateTimeOffset LastCheck { get; } = DateTimeOffset.Now;

    public TestResultStatus Status { get; internal set; }

    public DateTimeOffset End { get; internal set; }
    public long Duration { get; internal set; } = -1;

    public long ResultCount { get; internal set; } = -1;

    public ObservableDictionary<string, long> Statistics { get; } = new ObservableDictionary<string, long>();

    public int Occurence { get; internal set; }

    public bool IsSelected { get; internal set; }

    public IEnumerable? Data { get; internal set; }

    public string Name { get; internal set; }
    public string Id { get; internal set; }
    //public int Index { get; internal set; }
    public IList<Dictionary<string, string>>? Values { get; internal set; }

    public void RaisePropertyChanged()
    {
        OnPropertyChanged(nameof(Status));
        OnPropertyChanged(nameof(Data));
        OnPropertyChanged(nameof(ResultCount));
        OnPropertyChanged(nameof(Statistics));
        OnPropertyChanged(nameof(Duration));
        OnPropertyChanged(nameof(End));
    }
}
