namespace QuAnalyzer.UI.Controls;

public struct ComputeStruct
{
    public string Attribute { get; set; }
    public string DisplayName { get; set; }
    public string Aggregate { get; set; }

    public static Dictionary<string, string> Aggregations { get; } = new()
    {
        { "Ignore", null },
        { "Count", "Count()" },
        //{ "Distinct Count", (x) => x.Distinct().Count() },
        //{ "First", Enumerable.First },
        //{ "Last", Enumerable.Last },
        { "Sum", "Sum({0})" },
        { "Average", "Average({0})" },
        { "Min", "Min({0})" },
        { "Max", "Max({0})" }
    };
}

