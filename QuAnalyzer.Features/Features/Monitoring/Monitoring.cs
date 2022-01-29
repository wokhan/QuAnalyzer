using System.Diagnostics;
using System.Linq.Dynamic.Core;

namespace QuAnalyzer.Features.Monitoring;

public static class Monitoring
{
    public static async Task RunAsync(TestCasesCollection testsCollection, int occurence, int burstOccurences, int threads, IProgress<TestResults>? progress = null)
    {
        await Task.Run(() =>
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
        });
    }

    private static void RunForOne(TestCasesCollection testsCollection, int occurence, IProgress<TestResults>? callback, int x)
    {
        IList<Dictionary<string, string>>? values = null;
        if (testsCollection.ValuesSet is not null)// && tests.DistinctParallelValues)
        {
            values = testsCollection.Selector(testsCollection.ValuesSet, x);
        }

        testsCollection.TestCases
               .Select((test, ix) => (test, results: new TestResults()
               {
                   Id = $"{occurence}.{x}.{ix}",
                   Name = test.Name,
                   //Index = x,
                   Status = TestResultStatus.Pending,
                   Values = values
               }))
               .AsParallel()
               .WithDegreeOfParallelism(testsCollection.TestCases.Count)
               .ForAll(testWithResults =>
               {
                   callback?.Report(testWithResults.results);

                   var sw = Stopwatch.StartNew();
                   try
                   {
                       var definition = testWithResults.test.Definition;
                       switch (definition.Type)
                       {
                           case MonitoringModes.PING:
                               testWithResults.results.Data = null;
                               testWithResults.results.Duration.Add(nameof(MonitoringModes.PING), SimpleNetworkTests.Ping(definition.Provider.Host));
                               break;

                           case MonitoringModes.CHECKVAL:
                               if (string.IsNullOrEmpty(definition.Attributes))
                               {
                                   throw new NullReferenceException($"The {nameof(definition.Attributes)} attribute must not be null.");
                               }
                               var q = definition.GetData(values, testWithResults.results.Duration);
                               if (!string.IsNullOrEmpty(definition.Filter))
                               {
                                   q = q.Where(definition.Filter);
                               }
                               // Removed new(attribute)
                               testWithResults.results.Status = TestResultStatus.Loading;
                               testWithResults.results.Data = q.Select(definition.Attributes).AsEnumerable().ToList();
                               break;

                           case MonitoringModes.COUNTALL:
                               var qc = definition.GetData(values, testWithResults.results.Duration);
                               if (!string.IsNullOrEmpty(definition.Filter))
                               {
                                   qc = qc.Where(definition.Filter);
                               }
                               testWithResults.results.Status = TestResultStatus.Loading;
                               testWithResults.results.Data = new { Count = qc.Count() };
                               break;

                           default:
                               testWithResults.results.Data = null;
                               break;
                       }

                       testWithResults.results.Status = TestResultStatus.Success;
                   }
                   catch (Exception e)
                   {
                       testWithResults.results.Data = e;
                       testWithResults.results.Status = TestResultStatus.Error;
                   }
                   finally
                   {
                       sw.Stop();
                   }

                   testWithResults.results.Duration.Add("_TOTAL_DEFAULT", sw.ElapsedMilliseconds);
                   testWithResults.results.End = testWithResults.results.LastCheck.AddMilliseconds(sw.ElapsedMilliseconds);

               });
    }
}
