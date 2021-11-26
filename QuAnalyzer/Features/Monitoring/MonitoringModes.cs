using System.Collections.Generic;

namespace QuAnalyzer.Features.Monitoring
{
    public static class MonitoringModes
    {
        internal const string COUNTALL = nameof(COUNTALL);
        internal const string PING = nameof(PING);
        internal const string CHECKVAL = nameof(CHECKVAL);
        internal const string PERF = nameof(PERF);

        public static readonly Dictionary<string, string> MonitoringTypes = new()
        {
            { MonitoringModes.COUNTALL, "Count" },
            { MonitoringModes.CHECKVAL, "Retrieve attributes values" },
            { MonitoringModes.PERF, "Performance check" },
            { MonitoringModes.PING, "Server ping" }
            //{ "Any modification", "CHECKMOD" },
        };
    }

}
