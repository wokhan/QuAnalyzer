using QuAnalyzer.Features.Monitoring;

using System.Diagnostics;
using System.Linq.Dynamic.Core;

namespace QuAnalyzer.Features.Performance;

public static class Performance
{
    public static void Run(TestCasesCollection testsCollection, int occurence, int burstOccurences, int threads, IProgress<ResultsClass>? progress = null)
    {
        if (burstOccurences <= 0)
        {
            burstOccurences = 1;
        }
        if (threads <= 0)
        {
            threads = 1;
        }
     
        //TODO: use ParallelHelper from Community Toolkit
        int prevThreads, prevPorts;
        ThreadPool.GetMinThreads(out prevThreads, out prevPorts);
        ThreadPool.SetMinThreads(threads, prevPorts);

        try
        {
            var dtRun = DateTime.Now;

            Enumerable.Range(0, burstOccurences)
                      //.Select(x => new { x, valueset = (tests.ValuesSet is not null && !tests.DistinctParallelValues ? (tests.Selector ?? ValueSelectors.SequentialSelector).Invoke(tests.ValuesSet, x).Dump() : null) })
                      //.ToList()
                      .AsParallel()
                      //.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                      .WithDegreeOfParallelism(threads / testsCollection.TestCases.Count)
                      //.WithMergeOptions(ParallelMergeOptions.NotBuffered)
                      .ForAll(x => RunForOne(testsCollection, occurence, progress, x));
        }
        finally
        {
            // Restores the ThreadPool previous settings
            ThreadPool.SetMinThreads(prevThreads, prevPorts);
        }
    }

    private static void RunForOne(TestCasesCollection testsCollection, int occurence, IProgress<ResultsClass>? callback, int x)
    {
        IList<Dictionary<string, string>> values = null;
        if (testsCollection.ValuesSet is not null)// && tests.DistinctParallelValues)
        {
            values = (testsCollection.Selector ?? ValueSelectors.SequentialSelector).Invoke(testsCollection.ValuesSet, x);
        }
        testsCollection.TestCases
               .Select((test, ix) => (test, ix))
               .AsParallel()
               .WithDegreeOfParallelism(testsCollection.TestCases.Count)
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

                   callback?.Report(r);

                   var sw = Stopwatch.StartNew();
                   try
                   {
                       var monitorItem = a.test.monitorItem;
                       switch (monitorItem.Type)
                       {
                           case MonitoringModes.PING:
                               r.Data = null;
                               r.Duration.Add(nameof(MonitoringModes.PING), SimpleNetworkTests.Ping(monitorItem.Provider.Host));
                               break;

                           case MonitoringModes.CHECKVAL:
                               if (string.IsNullOrEmpty(monitorItem.Attributes))
                               {
                                   throw new NullReferenceException($"The {nameof(monitorItem.Attributes)} attribute must not be null.");
                               }
                               var q = monitorItem.GetData(values, r.Duration);
                               if (!string.IsNullOrEmpty(monitorItem.Filter))
                               {
                                   q = q.Where(monitorItem.Filter);
                               }
                               // Removed new(attribute)
                               r.Data = q.Select(monitorItem.Attributes).AsEnumerable().ToList();
                               break;

                           case MonitoringModes.COUNTALL:
                               var qc = monitorItem.GetData(values, r.Duration);
                               if (!string.IsNullOrEmpty(monitorItem.Filter))
                               {
                                   qc = qc.Where(monitorItem.Filter);
                               }
                               r.Data = new { Count = qc.Count() };
                               break;

                           default:
                               r.Data = null;
                               break;
                       }

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
    }
}
