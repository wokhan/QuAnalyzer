using System;

namespace QuAnalyzer.Features.Comparison;

public class SimpleMap
{
    public string Source { get; set; } = String.Empty;
    public string Target { get; set; } = String.Empty;
    public bool IsKey { get; set; }

    public SimpleMap()
    {

    }

    public SimpleMap(string s, string t)
    {
        this.Source = s;
        this.Target = t;
    }
}
