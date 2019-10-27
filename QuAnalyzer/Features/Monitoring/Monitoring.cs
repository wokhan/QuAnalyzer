﻿using QuAnalyzer.Features.Performance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.NetworkInformation;

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

        public static ResultsClass Monitor(MonitorItem item, int occurence)
        {
            var r = new ResultsClass();
            r.Step = item;
            r.Occurence = occurence;

            item.raiseAdd(r);

            if (!MonitoringTypes.ContainsKey(item.Type))
            {
                throw new ArgumentException("The specified monitoring type does not exist for the current provider.");
            }

            switch (item.Type)
            {
                case MonitoringModes.PING:
                    r.Data = null;
                    r.Duration = new Dictionary<string, long> { [nameof(MonitoringModes.PING)] = Ping(item.Provider.Host) };
                    break;

                case MonitoringModes.PERF:
                    var res = new ObservableCollection<ResultsClass>();
                    res.CollectionChanged += (o, e) =>
                    {
                        if (e.Action == NotifyCollectionChangedAction.Add)
                        {
                            var resstruct = (ResultsClass)e.NewItems[0];
                            item.raiseAdd(resstruct);
                        }
                    };
                    Performance.Performance.Run(new TestCasesCollection()
                    {
                        TestCases = new[] { new TestCase() {
                        GetData = (values, stats) => item.Provider.GetQueryable(item.Repository, values, stats)  } }
                    }, 10, 10, res);
                    r.Duration = new Dictionary<string, long> {
                        ["Average"] = (long)res.Select(result => result.Duration.Sum(_=> _.Value)).Average(),
                        ["Count"] = (long)res.Average(result => result.ResultCount)
                    };
                    r.Data = null;
                    break;

                case MonitoringModes.CHECKVAL:
                    if (string.IsNullOrEmpty(item.Attributes))
                    {
                        throw new ArgumentNullException("attribute");
                    }
                    var q = item.Provider.GetQueryable(item.Repository, statisticsBag: r.Duration);
                    if (!string.IsNullOrEmpty(item.Filter))
                    {
                        q = q.Where(item.Filter);
                    }
                    // Removed new(attribute)
                    r.Data = q.Select(item.Attributes).AsEnumerable().ToList();
                    break;

                case MonitoringModes.COUNTALL:
                    var qc = item.Provider.GetQueryable(item.Repository, statisticsBag: r.Duration);
                    if (!string.IsNullOrEmpty(item.Filter))
                    {
                        qc = qc.Where(item.Filter);
                    }
                    r.Data = new { Count = qc.Count() };
                    break;

                default:
                    r.Data = null;
                    break;
            }

            return r;

        }

        private static void Res_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static long GetMTU(string host)
        {
            var pong = new Ping();
            var startsize = 2000;
            var smaller = 0;
            var higher = 4000;

            var keepgoing = true;
            while (keepgoing)
            {
                PingReply ret = pong.Send(host, 5000, new byte[startsize], new PingOptions() { DontFragment = true });
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