namespace QuAnalyzer.Features.Comparison;

public struct SimpleMap
{
    public string Source { get; set; } = String.Empty;
    public string Target { get; set; } = String.Empty;
    public bool IsKey { get; set; } = false;

    public SimpleMap()
    {

    }

    public SimpleMap(string s, string t)
    {
        this.Source = s;
        this.Target = t;
    }
}
