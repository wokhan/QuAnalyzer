
using CommunityToolkit.HighPerformance.Helpers;

using System.Collections;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq.Dynamic.Core;
using System.Runtime.CompilerServices;

namespace QuAnalyzer.Features.Comparison;

public static class Comparison
{
    public static void Run<T>(IEnumerable<ComparerDefinition<T>> comparerData, double samplesPct = -1, IProgress<ComparerDefinition<T>>? progressCallback = null, bool useParallelism = true, Func<bool>? checkCancellation = null) where T : class
    {
        var runner = new Runner<T>(progressCallback, samplesPct, checkCancellation);

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

        //TODO: is it better than a cancellation token? See how the latter could fit within Tookit's MVVM RelayCommand.
        private readonly Func<bool>? isCancellationRequested;

        public Runner(IProgress<ComparerDefinition<T>>? callback, double samplesPct, Func<bool>? isCancellationRequested)
        {
            this.callback = callback;
            this.samplesPct = samplesPct;
            this.isCancellationRequested = isCancellationRequested;
        }

        public void Invoke(in ComparerDefinition<T> definition)
        {
            try
            {
                CancellationToken token = definition.TokenSource.Token;

                // Copying references to local variables to be able to use it in the lambda below (might be the wrong way though)
                var localCallback = callback;
                var localDef = definition;
                token.Register(() => SetProgress(localDef, ProgressType.Canceling, localCallback));

                var r = definition.Results;
                var totaltime = Stopwatch.StartNew();

                SetProgress(definition, ProgressType.LoadingData, callback);

                var srcData = definition.SourceEnumerable;
                var trgData = definition.TargetEnumerable;

                if (srcData is not null && trgData is not null)
                {
                    if (samplesPct > 0)
                    {
                        SetProgress(definition, ProgressType.GettingSamples, callback);

                        var samples = GetSamples(samplesPct, callback, srcData, trgData);
                        srcData = r.Source.Samples = samples[0];
                        trgData = r.Target.Samples = samples[1];

                        SetProgress(definition, ProgressType.GettingSamples, callback);
                    }

                    CompareOrdered(definition, srcData, trgData, token, callback);
                }

                totaltime.Stop();
                definition.Results.TotalTime = totaltime.ElapsedMilliseconds;
            }
            catch (OperationCanceledException)
            {
                SetProgress(definition, ProgressType.Canceled, callback);
            }
            catch (InvalidDataException ed)
            {
                definition.Results.Message = "The following attribute could not be loaded: " + ed.Message + "\r\nThe inner exception is: " + ed.InnerException.Message + "\r\nPlease check your providers and mappings.";
                SetProgress(definition, ProgressType.Failed, callback);
            }
            catch (Exception e)
            {
                definition.Results.Message = e.Message + "\r\nStacktrace: " + e.StackTrace;
                SetProgress(definition, ProgressType.Failed, callback);
            }
        }
    }

    private static void SetProgress<T>(ComparerDefinition<T> f, ProgressType progressType, IProgress<ComparerDefinition<T>>? progressCallback)
    {
        f.Results.Progress = progressType;

        //TODO: check if I can rely on Observable properties directly instead of a callback (but it should mean having a listener on the said properties changes (use a Weak listener maybe?)
        progressCallback?.Report(f);
    }

    /// <summary>
    /// Gets the specified number of sample data from one or many collections (at the same index for each of those).
    /// Usefull when only a partial comparison is required.
    /// Warning: Sources data MUST be sorted the same for all or it will obviously fail
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="samplesPercentage">Number of requested data samples</param>
    /// <param name="collections">Source collections (sorted)</param>
    /// <returns></returns>
    public static IEnumerable<T>[] GetSamples<T>(double samplesPercentage, IProgress<ComparerDefinition<T>>? callback, params IEnumerable<T>[] collections)
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
    /// <param name="definition"></param>
    /// <param name="srcData"></param>
    /// <param name="trgData"></param>
    /// <param name="progressCallback"></param>
    /// <param name="token"></param>
    public static void CompareOrdered<T>(ComparerDefinition<T> definition, IEnumerable<T>? srcData = null, IEnumerable<T>? trgData = null, CancellationToken? token = null, IProgress<ComparerDefinition<T>>? callback = null) where T : class
    {
        SetProgress(definition, ProgressType.Comparing, callback);

        using var srcEnum = (srcData ?? definition.SourceEnumerable).GetEnumerator();
        using var trgEnum = (trgData ?? definition.TargetEnumerable).GetEnumerator();

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
                definition.Results.Source.Count++;

                CheckDuplicate(definition.Results.Source, srcPrev, srcEnum.Current, definition.Comparer, definition.SourceKeys?.Count);
            }

            if (advanceTarget && istrg)
            {
                definition.Results.Target.Count++;

                CheckDuplicate(definition.Results.Target, trgPrev, trgEnum.Current, definition.Comparer, definition.SourceKeys?.Count);
            }

            srcPrev = srcEnum.Current;
            trgPrev = trgEnum.Current;

            var compResult = definition.Comparer.Compare(srcEnum.Current, trgEnum.Current);

            switch (compResult)
            {
                case 0:
                    definition.Results.MatchingCount++;
                    advanceSource = true;
                    advanceTarget = true;
                    break;

                case > 0 or < 0 when definition.SourceKeys is not null && Math.Abs(compResult) < definition.SourceKeys.Count:
                    definition.Results.Differences.Add((srcEnum.Current, trgEnum.Current, compResult));
                    advanceSource = true;
                    advanceTarget = true;
                    break;

                // Warning: do not use equality as some comparers will give back an actual index
                case > 0:
                    definition.Results.Source.Missing.Add(trgEnum.Current);
                    advanceSource = false;
                    advanceTarget = true;
                    break;

                // Warning: do not use equality as some comparers will give back an actual index
                case < 0:
                    definition.Results.Target.Missing.Add(srcEnum.Current);
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

            definition.Results.ScannedCount++;

            SetProgress(definition, ProgressType.Comparing, callback);
        }

        // We reached the end of either enumeration: every other records are missing.
        while (issrc)
        {
            definition.Results.Source.Count++;
            definition.Results.Target.Missing.Add(srcEnum.Current);

            issrc = srcEnum.MoveNext();

            if (issrc)
            {
                definition.Results.ScannedCount++;
            }

            SetProgress(definition, ProgressType.Comparing, callback);
        }

        while (istrg)
        {
            definition.Results.Target.Count++;
            definition.Results.Source.Missing.Add(trgEnum.Current);

            istrg = trgEnum.MoveNext();

            if (istrg)
            {
                definition.Results.ScannedCount++;
            }

            SetProgress(definition, ProgressType.Comparing, callback);
        }

        SetProgress(definition, ProgressType.Done, callback);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void CheckDuplicate<T>(ItemResult<T> f, T? previous, T? current, IComparer comparer, int? keyCount) where T : class
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

    /// <summary>
    /// Get duplicates (either by key or full duplicates, i.e. with all data being equal).
    /// WARNING: data must already be sorted either by key or by ALL columns. If not, results will be unexpected.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="keys"></param>
    /// <param name="comparer"></param>
    /// <param name="keysOnly"></param>
    /// <returns></returns>
    public static IEnumerable<T> GetDuplicates<T>(IEnumerable<T> data, IList<string>? keys, IComparer comparer, IProgress<int>? progressCallback = null) where T : class
    {
        ItemResult<T> ret = new();

        int i = 0;
        var prev = default(T);
        using var enumerator = data.GetEnumerator();
        while (enumerator.MoveNext())
        {
            CheckDuplicate(ret, prev, enumerator.Current, comparer, keys?.Count);
            prev = enumerator.Current;
            progressCallback?.Report(i++);
        }

        return ret.Duplicates.Concat(ret.PerfectDups);
    }
}
