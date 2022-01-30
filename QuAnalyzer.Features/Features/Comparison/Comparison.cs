
using CommunityToolkit.HighPerformance.Helpers;

using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Core.Extensions;

namespace QuAnalyzer.Features.Comparison;

public static class Comparison
{
    public static void Run<T>(IEnumerable<ComparerDefinition<T>> comparerData, double samplesPct = -1, IProgress<ComparerDefinition<T>>? progressCallback = null, bool useParallelism = true) where T : class
    {
        var runner = new Runner<T>(progressCallback, samplesPct);

        if (!useParallelism)
        {
            foreach (var cd in comparerData)
            {
                runner.Invoke(cd);
            }
        }
        else
        {
            ParallelHelper.ForEach<ComparerDefinition<T>, Runner<T>>(comparerData.ToArray(), runner);
        }
    }

    private readonly struct Runner<T> : IInAction<ComparerDefinition<T>> where T : class
    {
        private readonly IProgress<ComparerDefinition<T>>? callback;

        private readonly double samplesPct;

        public Runner(IProgress<ComparerDefinition<T>>? callback, double samplesPct)
        {
            this.callback = callback;
            this.samplesPct = samplesPct;
        }

        public void Invoke(in ComparerDefinition<T> definition)
        {
            try
            {
                CancellationToken token = definition.TokenSource.Token;

                var localCallback = callback;
                var localDef = definition; // Copying reference to a local to be able to use it in the lambda above (might be the wrong way though)
                token.Register(() => SetProgress(localDef, ProgressType.Canceling, 0, localCallback));

                var r = definition.Results;
                var totaltime = Stopwatch.StartNew();

                SetProgress(definition, ProgressType.LoadingData, 0, callback);

                var t1 = LoadData(definition, definition.Results.Source, definition.GetSourceData, token);
                var t2 = LoadData(definition, definition.Results.Target, definition.GetTargetData, token);

                var allTasks = Task.WhenAll(t1, t2);
                allTasks.Wait();
                var (srcData, trgData) = allTasks.Result;

                SetProgress(definition, ProgressType.LoadingDone, 1, callback);

                if (srcData is not null && trgData is not null)
                {
                    if (samplesPct > 0)
                    {
                        SetProgress(definition, ProgressType.GettingSamples, 0, callback);

                        var samples = GetSamples(samplesPct, srcData, trgData);
                        srcData = r.Source.Samples = samples[0];
                        trgData = r.Target.Samples = samples[1];

                        SetProgress(definition, ProgressType.GettingSamples, 15, callback);
                    }

                    SetProgress(definition, ProgressType.Comparing, 0, callback);

                    CompareOrdered(definition, srcData, trgData, token);
                }

                SetProgress(definition, ProgressType.Done, 0, callback);

                totaltime.Stop();
                definition.Results.TotalTime = totaltime.ElapsedMilliseconds;
            }
            catch (OperationCanceledException)
            {
                SetProgress(definition, ProgressType.Canceled, 0, callback);
            }
            catch (InvalidDataException ed)
            {
                definition.Results.Message = "The following attribute could not be loaded: " + ed.Message + "\r\nThe inner exception is: " + ed.InnerException.Message + "\r\nPlease check your providers and mappings.";
                SetProgress(definition, ProgressType.Failed, 0, callback);
            }
            catch (Exception e)
            {
                definition.Results.Message = e.Message + "\r\nStacktrace: " + e.StackTrace;
                SetProgress(definition, ProgressType.Failed, 0, callback);
            }
        }
    }

    private static Task<IEnumerable<T>> LoadData<T>(ComparerDefinition<T> f, ItemResult<T> item, Func<IEnumerable<T>> dataGetter, CancellationToken token) where T : class
    {
        return Task.Run(() =>
        {
            var start = Stopwatch.StartNew();
            
            item.StartTime = DateTime.Now;

            var data = dataGetter();
            if (!f.IsOrdered)
            {
                data = data.OrderByAll();//.ToList();
            }

            // TODO: cancelation should be done in the data loading implementation (to keep a Queryable here after)
            // BTW, since enumerating will not take place here... we only mesure the preparation time. Doesn't make sense.
            var res = data.Select((a, i) => { token.ThrowIfCancellationRequested(); item.Count = i + 1; return a; }); //.ToList();

            start.Stop();
            
            item.LoadingTime = start.ElapsedMilliseconds;
            
            return res;
        });
    }

    private static void SetProgress<T>(ComparerDefinition<T> f, ProgressType progressType, int p, IProgress<ComparerDefinition<T>>? progressCallback)
    {
        f.Results.Progress = progressType;
        f.Results.SubProgress = p;

        progressCallback?.Report(f);
    }

    /// <summary>
    /// Gets the specified number of sample data from one or many collections (at the same index for each of those).
    /// Usefull when only a partial comparison is required.
    /// Warning: Sources data MUST be sorted the same for all or it will obviously fail!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="samplesPercentage">Number of requested data samples</param>
    /// <param name="collections">Source collections (sorted)</param>
    /// <returns></returns>
    public static IEnumerable<T>[] GetSamples<T>(double samplesPercentage, params IEnumerable<T>[] collections)
    {
        Contract.Requires(samplesPercentage <= 1);
        Contract.Requires(samplesPercentage > 0);

        if (samplesPercentage == 1)
        {
            return collections;
        }

        var rdm = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        var min = collections.Min(c => c.Count());
        var count = Math.Min(min, (int)(min * samplesPercentage));

        HashSet<int> indices = new HashSet<int>();
        while (indices.Count < count)
        {
            indices.Add(rdm.Next(min));
        }
        
        // TODO: Probably not the right way to do this. Maybe ordering should be forced here
        // (despite impact on perf when already done), and using ElementAt might not be the best way since it will create
        // as many requests as we need samples.
        return collections.Select(c => indices.Select(i => c.ElementAt(i)).ToArray()).ToArray();
    }


    /// <summary>
    /// Comparison of already ordered sets (both sets have to be ordered the same or it will FAIL with no clue)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="f"></param>
    /// <param name="srcData"></param>
    /// <param name="trgData"></param>
    /// <param name="progressCallback"></param>
    /// <param name="token"></param>
    public static void CompareOrdered<T>(ComparerDefinition<T> f, IEnumerable<T>? srcData = null, IEnumerable<T>? trgData = null, CancellationToken? token = null) where T : class
    {
        using var srcEnum = (srcData ?? f.GetSourceData()).GetEnumerator();
        using var trgEnum = (trgData ?? f.GetTargetData()).GetEnumerator();

        var srcPrev = default(T);
        var trgPrev = default(T);

        var advanceSource = true;
        var advanceTarget = true;

        var issrc = srcEnum.MoveNext();
        var istrg = trgEnum.MoveNext();

        var keepGoing = issrc || istrg;

        while (keepGoing)
        {
            token?.ThrowIfCancellationRequested();

            if (advanceSource && issrc)
            {
                CheckDuplicate(f.Results.Source, srcPrev, srcEnum.Current, f.Comparer, f.SourceKeys?.Count);
            }

            if (advanceTarget && istrg)
            {
                CheckDuplicate(f.Results.Target, trgPrev, trgEnum.Current, f.Comparer, f.SourceKeys?.Count);
            }

            srcPrev = srcEnum.Current;
            trgPrev = trgEnum.Current;

            var compResult = f.Comparer.Compare(srcEnum.Current, trgEnum.Current);

            switch (compResult)
            {
                case 0:
                    f.Results.MatchingCount++;
                    advanceSource = true;
                    advanceTarget = true;
                    break;

                case > 0 or < 0 when f.SourceKeys is not null && Math.Abs(compResult) < f.SourceKeys.Count:
                    f.Results.Source.Differences.Add(srcEnum.Current);
                    f.Results.Target.Differences.Add(trgEnum.Current);
                    advanceSource = true;
                    advanceTarget = true;
                    break;

                // Warning: do not use equality as some comparers will give back an actual index
                case > 0:
                    f.Results.Source.Missing.Add(trgEnum.Current);
                    advanceSource = false;
                    advanceTarget = true;
                    break;

                // Warning: do not use equality as some comparers will give back an actual index
                case < 0:
                    f.Results.Target.Missing.Add(srcEnum.Current);
                    advanceSource = true;
                    advanceTarget = false;
                    break;
            }

            keepGoing = false;

            if (advanceSource)
            {
                issrc = srcEnum.MoveNext();
            }

            if (advanceTarget)
            {
                istrg = trgEnum.MoveNext();
            }

            keepGoing = issrc && istrg;
        }

        // We reached the end of either enumeration: every other records are missing.
        while (issrc)
        {
            f.Results.Target.Missing.Add(srcEnum.Current);
            issrc = srcEnum.MoveNext();
        }

        while (istrg)
        {
            f.Results.Source.Missing.Add(trgEnum.Current);
            istrg = trgEnum.MoveNext();
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void CheckDuplicate<T>(ItemResult<T> f, T? previous, T? current, IComparer<T> comparer, int? keyCount) where T : class
    {
        if (previous is default(T))
        {
            return;
        }

        var comparison = comparer.Compare(previous, current);
        if (keyCount is not null && Math.Abs(comparison) > keyCount)
        {
            f.Duplicates.Add(current);
        }

        if (comparison == 0)
        {
            f.PerfectDups.Add(current);
        }
    }

    public static ItemResult<T> GetDuplicates<T>(IEnumerable<T> data, IList<string>? keys, IComparer<T> comparer, bool keysOnly = false) where T : class
    {
        ItemResult<T> ret = new();

        var prev = default(T);
        using var enumerator = data.GetEnumerator();
        while (enumerator.MoveNext())
        {
            CheckDuplicate(ret, prev, enumerator.Current, comparer, keys?.Count);
            prev = enumerator.Current;
        }

        return ret;
    }
}
