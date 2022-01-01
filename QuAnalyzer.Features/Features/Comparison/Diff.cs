namespace QuAnalyzer.Features.Comparison;

public class Diff
{
    public string Source { get; set; }
    public object[] Values { get; set; }
    public bool[] IsDiff { get; set; }
}
