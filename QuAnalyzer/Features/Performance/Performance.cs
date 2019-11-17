using QuAnalyzer.Core.Helpers;
using QuAnalyzer.Features.Monitoring;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;

namespace QuAnalyzer.Features.Performance
{
    public static class Performance
    {
        public static void Run(TestCasesCollection tests, int occurence, int burstOccurences, int threads, Action<ResultsClass> callback = null)
        {
            if (burstOccurences <= 0)
            {
                burstOccurences = 1;
            }
            if (threads <= 0)
            {
                threads = 1;
            }
            int prevThreads, prevPorts;
            ThreadPool.GetMinThreads(out prevThreads, out prevPorts);
            ThreadPool.SetMinThreads(threads, prevPorts);

            try
            {
                var dtRun = DateTime.Now;

                Enumerable.Range(0, burstOccurences)
                          //.Select(x => new { x, valueset = (tests.ValuesSet != null && !tests.DistinctParallelValues ? (tests.Selector ?? ValueSelectors.SequentialSelector).Invoke(tests.ValuesSet, x).Dump() : null) })
                          //.ToList()
                          .AsParallel()
                          //.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                          .WithDegreeOfParallelism(threads / tests.TestCases.Count)
                          //.WithMergeOptions(ParallelMergeOptions.NotBuffered)
                          .ForAll(x =>
                          {
                              IList<Dictionary<string, string>> values = null;
                              if (tests.ValuesSet != null)// && tests.DistinctParallelValues)
                              {
                                  values = (tests.Selector ?? ValueSelectors.SequentialSelector).Invoke(tests.ValuesSet, x);
                              }
                              tests.TestCases.AsParallel()
                                     .WithDegreeOfParallelism(tests.TestCases.Count)
                                     .Select((test, ix) => new { test, ix })
                                     .ForAll(a =>
                                     {
                                         var r = new ResultsClass()
                                         {
                                             Id = $"{occurence}.{x}.{a.ix}",
                                             Name = a.test.Name,
                                             //Index = x,
                                             Status = Status.Loading,
                                             Values = values
                                         };

                                         callback?.Invoke(r);

                                         var sw = Stopwatch.StartNew();
                                         try
                                         {
                                             switch (a.test.Type)
                                             {
                                                 case MonitoringModes.PING:
                                                     r.Data = null;
                                                     r.Duration.Add(nameof(MonitoringModes.PING), SimpleNetworkTests.Ping(a.test.Provider.Host));
                                                     break;

                                                 case MonitoringModes.CHECKVAL:
                                                     if (string.IsNullOrEmpty(a.test.Attributes))
                                                     {
                                                         throw new NullReferenceException($"The {nameof(a.test.Attributes)} attribute must not be null.");
                                                     }
                                                     var q = a.test.GetData(values, r.Duration);
                                                     if (!string.IsNullOrEmpty(a.test.Filter))
                                                     {
                                                         q = q.Where(a.test.Filter);
                                                     }
                                                     // Removed new(attribute)
                                                     r.Data = q.Select(a.test.Attributes).AsEnumerable().ToList();
                                                     break;

                                                 case MonitoringModes.COUNTALL:
                                                     var qc = a.test.GetData(values, r.Duration);
                                                     if (!string.IsNullOrEmpty(a.test.Filter))
                                                     {
                                                         qc = qc.Where(a.test.Filter);
                                                     }
                                                     r.Data = new { Count = qc.Count() };
                                                     break;

                                                 default:
                                                     r.Data = null;
                                                     break;
                                             }

                                             // TODO: remove, just for test :-O
                                             Thread.Sleep(new Random().Next(0, 100));
                                             r.Status = Status.Success;
                                         }
                                         catch (Exception e)
                                         {
                                             r.Data = e;
                                             r.Status = Status.Error;
                                         }
                                         finally
                                         {
                                             sw.Stop();
                                         }

                                         r.Duration.Add("_TOTAL_DEFAULT", sw.ElapsedMilliseconds);
                                         r.End = r.LastCheck.AddMilliseconds(sw.ElapsedMilliseconds);

                                     });
                          });
            }
            finally
            {
                // Restores the ThreadPool previous settings
                ThreadPool.SetMinThreads(prevThreads, prevPorts);
            }
        }
    }
}
