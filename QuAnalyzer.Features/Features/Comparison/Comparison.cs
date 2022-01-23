using Microsoft.Toolkit.HighPerformance.Helpers;

using QuAnalyzer.Features.Comparison.Comparers;

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Core.Extensions;

namespace QuAnalyzer.Features.Comparison;

public static class Comparison
{
    public static void Run<T>(IEnumerable<ComparerDefinition<T>> comparerData, int nbSamplesCompared, int nbSamplesShown, IProgress<ComparerDefinition<T>>? progressCallback = null, bool useParallelism = true) where T : class
    {
        var runner = new Runner<T>(progressCallback, nbSamplesShown, nbSamplesCompared);

        if (!useParallelism)
        {
            //var t = Task.Run(() => runner.Invoke(comparerData.First()));
            foreach (var cd in comparerData)
            {
                //await t.ContinueWith(_ => runner.Invoke(cd));
                runner.Invoke(cd);
            }
        }
        else
        {
            ParallelHelper.ForEach<ComparerDefinition<T>, Runner<T>>(comparerData.ToArray(), runner);
            //Task.WaitAll(comparerData.Select(cd => runForOne(cd, progressCallback)).ToArray());// AsParallel().Select(runForOne));
        }
    }

    private readonly struct Runner<T> : IInAction<ComparerDefinition<T>> where T : class
    {
        private readonly IProgress<ComparerDefinition<T>>? callback;

        private readonly int nbSamplesShown;
        private readonly int nbSamplesCompared;

        public Runner(IProgress<ComparerDefinition<T>>? callback, int nbSamplesShown, int nbSamplesCompared)
        {
            this.callback = callback;
            this.nbSamplesShown = nbSamplesShown;
            this.nbSamplesCompared = nbSamplesCompared;
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

                var t1 = LoadData(definition, definition.Results.Source, definition.GetSourceData(), token);
                var t2 = LoadData(definition, definition.Results.Target, definition.GetTargetData(), token);

                var allTasks = Task.WhenAll(t1, t2);
                allTasks.Wait();
                var (srcData, trgData) = allTasks.Result;

                SetProgress(definition, ProgressType.LoadingDone, 1, callback);

                if (srcData is not null && trgData is not null)
                {
                    if (nbSamplesShown > 0)
                    {
                        SetProgress(definition, ProgressType.GettingSamples, 0, callback);

                        var samples = GetSamples(nbSamplesShown, srcData, trgData);
                        r.Source.Samples = samples[0];
                        r.Target.Samples = samples[1];

                        SetProgress(definition, ProgressType.GettingSamples, 15, callback);
                    }

                    if (nbSamplesCompared > 0)
                    {
                        SetProgress(definition, ProgressType.Filtering, 0, callback);

                        var samples = GetSamples(nbSamplesCompared, srcData, trgData);
                        srcData = samples[0];
                        trgData = samples[1];

                        SetProgress(definition, ProgressType.Filtering, 15, callback);
                    }

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

    private static Task<IEnumerable<T>> LoadData<T>(ComparerDefinition<T> f, ItemResult<T> item, IEnumerable<T> tr, CancellationToken token) where T : class
    {
        return Task.Run(() =>
        {
            var start = Stopwatch.StartNew();
            item.StartTime = DateTime.Now;
            var res = tr.Select((a, i) => { token.ThrowIfCancellationRequested(); item.Count = i + 1; return a; }); //.ToList();
            if (!f.IsOrdered)
            {
                res = res.OrderByAll().ToList();
            }
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

    //TODO: What about unordered collections? BTW, looks really unoptimized to me
    public static T?[][] GetSamples<T>(int nbSamples, params IEnumerable<T>[] collections)
    {
        var rdm = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        var min = collections.Min(c => c.Count());
        nbSamples = Math.Min(min, nbSamples);

        var rdmIdxs = Enumerable.Range(0, nbSamples).Select(_ => rdm.Next(min)).ToArray();

        return collections.Select(c => rdmIdxs.Select(i => c.ElementAtOrDefault(i)).ToArray()).ToArray();
    }


    /// <summary>
    /// Comparison of already ordered sets (both sets have to be ordered the same or it will FAIL with no clue)
    /// TODO: check if both are indeed ordered by comparing previous and current values?
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="f"></param>
    /// <param name="srcData"></param>
    /// <param name="trgData"></param>
    /// <param name="progressCallback"></param>
    /// <param name="token"></param>
    public static void CompareOrdered<T>(ComparerDefinition<T> f, IEnumerable<T> srcData, IEnumerable<T> trgData, CancellationToken token) where T : class
    {
        Contract.Requires(srcData is not null);
        Contract.Requires(trgData is not null);

        f.Results.InitCollections(() => new ObservableCollection<T>());

        IEqualityComparer<IEnumerable<object>> dupKeyComparer = new SequenceEqualityComparer<IEnumerable<object>, object>(0, f.SourceKeys?.Count ?? int.MaxValue);
        //TODO : key comparison
        IEqualityComparer<IEnumerable<object>>? dupRemComparer = null;
        if (f.SourceKeys is not null)
        {
            dupRemComparer = new SequenceEqualityComparer<IEnumerable<object>, object>(f.SourceKeys.Count);
        }

        using var srcEnum = srcData.GetEnumerator();
        using var trgEnum = trgData.GetEnumerator();

        var srcPrev = default(T);
        var trgPrev = default(T);

        var advanceSource = true;
        var advanceTarget = true;

        var issrc = srcEnum.MoveNext();
        var istrg = trgEnum.MoveNext();

        var keepGoing = issrc || istrg;
        
        while (keepGoing)
        {
            if (advanceSource && issrc)
                CheckDuplicate(f.Results.Source, srcPrev, srcEnum.Current, dupKeyComparer, dupRemComparer);

            if (advanceTarget && istrg)
                CheckDuplicate(f.Results.Target, trgPrev, trgEnum.Current, dupKeyComparer, dupRemComparer);

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

                case int.MaxValue:
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
    private static void CheckDuplicate<T>(ItemResult<T> f, T? previous, T? current, IEqualityComparer<IEnumerable<object>> sqcKeysOrAll, IEqualityComparer<IEnumerable<object>>? sqcRemaining) where T : class
    {
        if (default(T) != previous && sqcKeysOrAll.Equals((IEnumerable<object>)previous, (IEnumerable<object>)current))
        {
            f.Duplicates.Add(current);

            //TODO: Maybe check if PerfectDups should be used instead of Duplicates when no keys have been specified?
            if (sqcRemaining is not null && sqcRemaining.Equals((IEnumerable<object>)previous, (IEnumerable<object>)current))
            {
                f.PerfectDups.Add(current);
            }
        }
    }

    public static ItemResult<T> GetDuplicates<T>(IEnumerable<T> data, IList<string>? keys, bool keysOnly = false) where T : class
    {
        ItemResult<T> ret = new();

        IEqualityComparer<IEnumerable<object>> dupKeyComparer = new SequenceEqualityComparer<IEnumerable<object>, object>(0, keys?.Count ?? int.MaxValue);
        //TODO : key comparison
        IEqualityComparer<IEnumerable<object>>? dupRemComparer = null;
        if (!keysOnly && keys is not null)
        {
            dupRemComparer = new SequenceEqualityComparer<IEnumerable<object>, object>(keys.Count);
        }

        var prev = default(T);
        var enumerator = data.GetEnumerator();
        while (enumerator.MoveNext())
        {
            CheckDuplicate(ret, prev, enumerator.Current, dupKeyComparer, dupRemComparer);
            prev = enumerator.Current;
        }

        return ret;
    }
}
