using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Wokhan.Collections.Extensions;

namespace QuAnalyzer.Features.Performance
{
    public static class Performance
    {
        public static void Run(TestCasesCollection tests, int nbSamples, int nbThreads, ObservableCollection<ResultStruct> results, Action<ResultStruct, IList<Dictionary<string, string>>> callback = null)
        {
            if (nbSamples <= 0)
            {
                nbSamples = 1;
            }
            if (nbThreads <= 0)
            {
                nbThreads = 1;
            }
            int prevThreads, prevPorts;
            ThreadPool.GetMinThreads(out prevThreads, out prevPorts);
            ThreadPool.SetMinThreads(nbThreads, prevPorts);

            try
            {
                var dtRun = DateTime.Now;

                Enumerable.Range(0, nbSamples)
                          //.Select(x => new { x, valueset = (tests.ValuesSet != null && !tests.DistinctParallelValues ? (tests.Selector ?? ValueSelectors.SequentialSelector).Invoke(tests.ValuesSet, x).Dump() : null) })
                          //.ToList()
                          .AsParallel()
                          //.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                          .WithDegreeOfParallelism(nbThreads / tests.TestCases.Count())
                          //.WithMergeOptions(ParallelMergeOptions.NotBuffered)
                          .ForAll(x =>
                          {
                                  //var x = xx.x;
                                  //var values = xx.valueset;
                                  IList<Dictionary<string, string>> values = null;
                              if (tests.ValuesSet != null)// && tests.DistinctParallelValues)
                                  {
                                  values = (tests.Selector ?? ValueSelectors.SequentialSelector).Invoke(tests.ValuesSet, x);
                              }
                              tests.TestCases.AsParallel()
                                     .WithDegreeOfParallelism(tests.TestCases.Count())
                                     .Select((test, ix) => new { test, ix })
                                     .ForAll(a =>
                                     {
                                         var result = new ResultStruct() { Id = $"{x}.{a.ix}", Name = a.test.Name, Index = x, Start = DateTime.Now.Subtract(dtRun).TotalMilliseconds, Status = Status.Loading };
                                         callback?.Invoke(result, null);

                                         lock (results)
                                         {
                                             results.Add(result);
                                         }

                                         var sw = Stopwatch.StartNew();
                                         try
                                         {
                                             var data = a.test.Provider.GetData(a.test.Name, statisticsBag: result.Duration);
                                             result.Status = Status.Success;
                                             result.Result = data;
                                         }
                                         catch (Exception e)
                                         {
                                             result.Result = e;
                                             result.Status = Status.Error;
                                         }
                                         finally
                                         {
                                             sw.Stop();
                                         }

                                         result.End = result.Start + sw.ElapsedMilliseconds;
                                         
                                         callback?.Invoke(result, values);
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
