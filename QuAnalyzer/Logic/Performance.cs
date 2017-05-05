using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using QuAnalyzer.Extensions;

namespace QuAnalyzer.Logic
{
    public static class Performance
    {
        public class ResultStruct
        {
            public int Index;
            public double Start;
            public double End;
            public long Duration;
            public bool Passed;
            public object Result;
        }

        public static ResultStruct[] Run(Func<Stopwatch, object> exprTest, int nbSamples, bool useParallelism = true)
        {
            //int prevThreads, prevPorts;
            //ThreadPool.GetMinThreads(out prevThreads, out prevPorts);
            //ThreadPool.SetMinThreads(nbThreads, prevPorts);

            var dtRun = DateTime.Now;

            ResultStruct[] data = Enumerable.Range(0, nbSamples)
                                .AsParallel(useParallelism)
                                .Select(r =>
                                {
                                    var dt = DateTime.Now;
                                    var sw = new Stopwatch();
                                    object res = null;
                                    bool st;

                                    try
                                    {
                                        sw.Start();

                                        res = exprTest(sw);

                                        sw.Stop();
                                        st = true;
                                    }
                                    catch
                                    {
                                        st = false;
                                    }

                                    return new ResultStruct() { Index = r, Start = dt.Subtract(dtRun).TotalMilliseconds, End = dt.Subtract(dtRun).Add(sw.Elapsed).TotalMilliseconds, Duration = sw.ElapsedMilliseconds, Passed = st, Result = res };
                                })
                                .OrderBy(i => i.Index)
                                .ToArray();

            // Restores the ThreadPool previous settings
            //ThreadPool.SetMinThreads(prevThreads, prevPorts);

            return data;
        }
    }
}
