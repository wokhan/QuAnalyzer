using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.NetworkInformation;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Features.Monitoring
{
    static class Monitoring
    {
        public static readonly Dictionary<string, string> MonitoringTypes = new Dictionary<string, string> {
            { MonitoringModes.COUNTALL, "Count" },
            { MonitoringModes.CHECKVAL, "Retrieve attributes values" },
            { MonitoringModes.PERF, "Performance check" },
            { MonitoringModes.PING, "Server ping" }
            //{ "Any modification", "CHECKMOD" },
        };

        public static long Monitor(IDataProvider provider, string key, string repository, out object data, string filter = null, string attribute = null)
        {
            if (!MonitoringTypes.ContainsKey(key))
            {
                throw new ArgumentException("The specified monitoring type does not exist for the current provider.");
            }

            switch (key)
            {
                case MonitoringModes.PING:
                    data = null;
                    return Ping(provider.Host);

                case MonitoringModes.PERF:
                    data = null;
                    return PerfTest(provider, repository);

                case MonitoringModes.CHECKVAL:
                    if (string.IsNullOrEmpty(attribute))
                    {
                        throw new ArgumentNullException("attribute");
                    }
                    var q = provider.GetData(repository);
                    if (!string.IsNullOrEmpty(filter))
                    {
                        q = q.Where(filter);
                    }
                    data = ((IEnumerable<dynamic>)q.Select("new(" + attribute + ")")).ToList();
                    return ((IList)data).Count;

                case MonitoringModes.COUNTALL:
                    data = null;
                    var qc = provider.GetData(repository);
                    if (!string.IsNullOrEmpty(filter))
                    {
                        qc = qc.Where(filter);
                    }
                    return qc.Count();

                default:
                    data = null;
                    return 0;
            }

        }


        public static long GetMTU(string host)
        {
            var pong = new Ping();
            PingReply ret = null;

            var startsize = 2000;
            var smaller = 0;
            var higher = 4000;

            var keepgoing = true;
            while (keepgoing)
            {
                ret = pong.Send(host, 5000, new byte[startsize], new PingOptions() { DontFragment = true });

                if (ret.Status == IPStatus.PacketTooBig)
                {
                    higher = startsize;
                    startsize = higher - (higher - smaller) / 2;
                }

                if (ret.Status == IPStatus.Success)
                {
                    smaller = startsize;
                    startsize = smaller + (higher - smaller) / 2;
                }


                if (smaller == higher - 1)
                {
                    keepgoing = false;
                    startsize = smaller;
                }
            }

            return startsize;
        }

        // TODO: replace with new PerfTest implementation
        public static long PerfTest(IDataProvider provider, string repository)
        {
            var sw = Stopwatch.StartNew();
            provider.GetData(repository).ToList();
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        public static long Ping(string host)
        {
            return new Ping().Send(host).RoundtripTime;
        }


        public static double MeasureBandwidth(string host)
        {
            var optsize = GetMTU(host);

            var pong = new Ping();
            PingReply ret = pong.Send(host, 5000, new byte[optsize * 10], new PingOptions() { DontFragment = false });

            if (ret.Status == IPStatus.Success)
            {
                return optsize / ret.RoundtripTime / 10 * 1000;
            }
            else
            {
                return 0;
            }
        }

    }
}
