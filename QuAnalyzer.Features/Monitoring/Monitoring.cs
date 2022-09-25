using CommunityToolkit.HighPerformance.Helpers;

using QuAnalyzer.Features.Monitoring.Definition;

using System.Diagnostics;
using System.Linq.Dynamic.Core;

namespace QuAnalyzer.Features.Monitoring;

public static class Monitoring
{
    public static void Run(IList<TestCase> tests, List<Dictionary<string, string>>? valuesSet, ValueSelectors.Selector? selector, int occurence, int burstOccurences, int threads, IProgress<(TestCase, TestResults)>? progress = null)
    {
        var runner = new Runner(tests, valuesSet, selector, occurence, progress);

        if (burstOccurences <= 0)
        {
            burstOccurences = 1;
        }

        ParallelHelper.For2D(0, burstOccurences, 0, tests.Count, runner, 1);//, (TestCase, int, IList<Dictionary<string, string>>), Runner>(testsCollection.TestCases.Select(test => new { test, x, values }).ToArray(), runner, 1);

        ////TODO: use ParallelHelper from Community Toolkit
        //int prevThreads, prevPorts;
        //ThreadPool.GetMinThreads(out prevThreads, out prevPorts);
        //ThreadPool.SetMinThreads(threads, prevPorts);

        //try
        //{
        //    //var dtRun = DateTime.Now;

        //    Enumerable.Range(0, burstOccurences)
        //              //.Select(x => new { x, valueset = (tests.ValuesSet is not null && !tests.DistinctParallelValues ? (tests.Selector ?? ValueSelectors.SequentialSelector).Invoke(tests.ValuesSet, x).Dump() : null) })
        //              //.ToList()
        //              .AsParallel()
        //              //.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
        //              .WithDegreeOfParallelism(threads / testsCollection.TestCases.Count)
        //              //.WithMergeOptions(ParallelMergeOptions.NotBuffered)
        //              .ForAll(x => RunForOne(testsCollection, occurence, progress, x));
        //}
        //finally
        //{
        //    // Restores the ThreadPool previous settings
        //    ThreadPool.SetMinThreads(prevThreads, prevPorts);
        //}
    }

    private readonly struct Runner : IAction2D
    {
        private readonly IProgress<(TestCase, TestResults)>? callback;

        //private readonly Func<bool>? isCancellationRequested;
        private readonly IList<TestCase> tests;
        private readonly int occurence;
        private readonly List<Dictionary<string, string>>? valuesSet;
        private readonly ValueSelectors.Selector selector = ValueSelectors.SequentialSelector;

        //private bool distinctParallelValues;

        public Runner(IList<TestCase> tests, List<Dictionary<string, string>>? valuesSet, ValueSelectors.Selector? selector, int occurence, IProgress<(TestCase, TestResults)>? callback)
        {
            this.occurence = occurence;
            this.tests = tests;
            this.callback = callback;
            this.valuesSet = valuesSet;
            if (selector is not null)
            {
                this.selector = selector;
            }
            //this.isCancellationRequested = isCancellationRequested;
        }

        public void Invoke(int x, int testindex)
        {
            var test = tests[testindex];

            if (!test.AllPrecedingStepsDone)
            {
                test.Status = TestCaseStatus.WAITING;
                return;
            }

            test.Status = TestCaseStatus.RUNNING;

            IList<Dictionary<string, string>>? values = null;
            if (valuesSet is not null)// && tests.DistinctParallelValues)
            {
                values = selector(valuesSet, x);
            };

            //CancellationToken token = definition.TokenSource.Token;

            //var localDef = definition;
            //token.Register(() => SetProgress(localDef, ProgressType.Canceling, localCallback));

            var results = new TestResults()
            {
                Occurence = occurence,
                Id = $"{occurence}.{testindex}.{x}",
                Name = test.Name,
                Status = TestResultStatus.Loading,
                Values = values,
                Step = test.Definition,
                ResultCount = -1
            };

            callback?.Report((test, results));

            var sw = Stopwatch.StartNew();
            try
            {
                var definition = test.Definition;
                switch (definition.Type)
                {
                    case MonitoringModes.PING:
                        results.ResultCount = SimpleNetworkTests.Ping(definition.Provider.Host);
                        break;

                    case MonitoringModes.PERF:
                    case MonitoringModes.CHECKVAL:
                        var q = definition.GetData(values, results.Statistics);
                        if (!string.IsNullOrEmpty(definition.Filter))
                        {
                            q = q.Where(definition.Filter);
                        }
                        var data = q.Select($"new({definition.Attributes})").AsEnumerable().ToList();
                        if (definition.Type == MonitoringModes.CHECKVAL)
                        {
                            results.Data = data;
                        }
                        results.ResultCount = data.Count;
                        break;

                    case MonitoringModes.COUNTALL:
                        var qc = definition.GetData(values, results.Statistics);
                        if (!string.IsNullOrEmpty(definition.Filter))
                        {
                            qc = qc.Where(definition.Filter);
                        }
                        results.ResultCount = qc.Count();
                        break;

                    default:
                        break;
                }

                results.Status = TestResultStatus.Success;
            }
            catch (Exception e)
            {
                results.Data = new[] { new { Exception = e } };
                results.Status = TestResultStatus.Error;
            }

            sw.Stop();

            results.Duration = sw.ElapsedMilliseconds;
            results.End = results.LastCheck.AddMilliseconds(sw.ElapsedMilliseconds);

            test.Status = TestCaseStatus.DONE;

            callback?.Report((test, results));
        }
    }
}