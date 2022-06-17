using CommunityToolkit.Mvvm.ComponentModel;

namespace QuAnalyzer.Features.Comparison.Definition;

[ObservableObject]
public partial class SimpleMap
{
    [ObservableProperty]
    public string source = "";

    [ObservableProperty]
    public string target = "";

    [ObservableProperty]
    public bool isKey = false;

    public SimpleMap()
    {
    }

    public SimpleMap(string source, string target)
    {
        this.Source = source;
        this.Target = target;
    }
}