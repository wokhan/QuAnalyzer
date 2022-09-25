namespace QuAnalyzer.Features.Monitoring;

public static class MonitoringModes
{
    public const string COUNTALL = nameof(COUNTALL);
    public const string PING = nameof(PING);
    public const string CHECKVAL = nameof(CHECKVAL);
    public const string PERF = nameof(PERF);

    public static readonly Dictionary<string, string> MonitoringTypes = new()
    {
        { MonitoringModes.COUNTALL, "Count" },
        { MonitoringModes.CHECKVAL, "Retrieve attributes values" },
        { MonitoringModes.PERF, "Performance check" },
        { MonitoringModes.PING, "Server ping" }
        //{ "Any modification", "CHECKMOD" },
    };
}
