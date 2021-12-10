
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace QuAnalyzer.Features.Monitoring;

public partial class MultiValueDatePoint : ObservableObject
{
    public DateTime X { get; set; }

    [ObservableProperty]
    private double y;

    [ObservableProperty]
    private Dictionary<string, long> values;

    [ObservableProperty]
    private string name;
}
