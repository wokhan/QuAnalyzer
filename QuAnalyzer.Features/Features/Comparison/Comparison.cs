using Microsoft.Toolkit.HighPerformance.Helpers;

using QuAnalyzer.Features.Comparison.Comparers;

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

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
                        r.Source.Samples = samples.First();
                        r.Target.Samples = samples.Last();

                        SetProgress(definition, ProgressType.GettingSamples, 15, callback);
                    }

                    if (nbSamplesCompared > 0)
                    {
                        SetProgress(definition, ProgressType.Filtering, 0, callback);

                        var samples = GetSamples(nbSamplesCompared, srcData, trgData);
                        srcData = samples.First();
                        trgData = samples.Last();

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

    //TODO: What about unordered collections?!
    public static T[][] GetSamples<T>(int nbSamples, params IEnumerable<T>[] collections)
    {
        var rdm = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        var min = collections.Min(c => c.Count());
        nbSamples = Math.Min(min, nbSamples);

        var rdmIdxs = new byte[nbSamples].Select(i => rdm.Next(min)).ToArray();

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

        var seqComparer = new SequenceComparer<object>(f.SourceKeys?.Count);// ?? f.SourceHeaders?.Count);

        var dupKeyComparer = new SequenceEqualityComparer<object>(0, f.SourceKeys?.Count ?? int.MaxValue);
        //TODO : key comparison
        SequenceEqualityComparer<object>? dupRemComparer = null;
        if (f.SourceKeys is not null)
        {
            dupRemComparer = new SequenceEqualityComparer<object>(f.SourceKeys.Count);
        }

        using var srcEnum = srcData.GetEnumerator();
        using var trgEnum = trgData.GetEnumerator();

        var srcPrev = default(T);
        var trgPrev = default(T);

        var advanceSource = true;
        var advanceTarget = true;

        var issrc = srcEnum.MoveNext();
        var istrg = trgEnum.MoveNext();

        var keepGoing = true;

        while (keepGoing)
        {
            if (advanceSource && issrc)
                CheckDuplicate(f.Results.Source, srcPrev, srcEnum.Current, dupKeyComparer, dupRemComparer);

            if (advanceTarget && istrg)
                CheckDuplicate(f.Results.Target, trgPrev, trgEnum.Current, dupKeyComparer, dupRemComparer);

            var cmp = seqComparer.Compare((IEnumerable<object>)srcEnum.Current, (IEnumerable<object>)trgEnum.Current);

            switch (cmp)
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

            trgPrev = trgEnum.Current;
            srcPrev = srcEnum.Current;

            keepGoing = (advanceSource && (issrc = srcEnum.MoveNext()));
            keepGoing = (advanceTarget && (istrg = trgEnum.MoveNext())) || keepGoing;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void CheckDuplicate<T>(ItemResult<T> f, T? previous, T? current, SequenceEqualityComparer<object> sqcKeysOrAll, SequenceEqualityComparer<object>? sqcRemaining) where T : class
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


    // TODO: review as this is totally absolutely inefficient... Maybe force order when it's not already ordered?
    // It will use more memory and will require a full data load, but is this really an issue since we're iterating multiple time over source and target collection anyway...
    //public static void Compare<T>(ComparerDefinition<T> f, IEnumerable<T> srcData, IEnumerable<T> trgData, IProgress<ComparerDefinition<T>>? progressCallback, CancellationToken token)
    //{
    //    Contract.Requires(srcData is not null);
    //    Contract.Requires(trgData is not null);

    //    var countA = f.Results.Source.Count;
    //    var countB = f.Results.Target.Count;

    //    if (countA == 0)
    //    {
    //        f.Results.Source.Missing = trgData.ToList();
    //        f.Results.MatchingCount = 0;
    //        InitiateDuplicates(trgData, f.Results.Target, f.KeysComparer, f.Comparer);
    //        return;
    //    }

    //    if (countB == 0)
    //    {
    //        f.Results.Target.Missing = srcData.ToList();
    //        f.Results.MatchingCount = 0;
    //        InitiateDuplicates(srcData, f.Results.Source, f.KeysComparer, f.Comparer);
    //        return;
    //    }

    //    ParallelQuery<T> srcPrl = srcData.AsParallel();
    //    ParallelQuery<T> trgPrl = trgData.AsParallel();

    //    InitiateDuplicates(srcData, f.Results.Source, f.KeysComparer, f.Comparer);
    //    InitiateDuplicates(trgData, f.Results.Target, f.KeysComparer, f.Comparer);

    //    //progressCallback(cName, ProgressType.Comparing, 0);
    //    var i = 0;
    //    var matchingItems = srcPrl.WithProgress(i => SetProgress(f, ProgressType.Comparing, (int)(i * 20 / countA), progressCallback))
    //                              .Intersect(trgPrl, f.Comparer)
    //                              .ToList()
    //                              .AsParallel();

    //    f.Results.MatchingCount = matchingItems.Count();

    //    if (countA != f.Results.MatchingCount || countB != f.Results.MatchingCount)
    //    {
    //        // Rem matches from source
    //        var filteredA = srcPrl.Except(matchingItems, f.Comparer).ToList();

    //        // Rem matches from target
    //        var filteredB = trgPrl.Except(matchingItems, f.Comparer).ToList();

    //        // Get items only in source = get items missing from the target
    //        var sourceOnly = RetrieveOnly(filteredA, filteredB, f, progressCallback, ProgressType.CheckingSourceOnly);

    //        // Get items only in target = get items missing from the source
    //        var targetOnly = RetrieveOnly(filteredB, filteredA, f, progressCallback, ProgressType.CheckingTargetOnly);

    //        if (f.KeysComparer is not null)
    //        {
    //            f.Results.Source.Differences = new ObservableCollection<T>();
    //            f.Results.Target.Differences = new ObservableCollection<T>();

    //            var differences = sourceOnly.Join(targetOnly, s => s, t => t, (s, t) => (s, t), f.KeysComparer);
    //            foreach (var diff in differences)
    //            {
    //                f.Results.Source.Differences.Add(diff.s);
    //                f.Results.Target.Differences.Add(diff.t);
    //            }

    //            // Get source missing: check "source only" keys against "target only" keys
    //            // If the key does not exist, the item is a really missing one.
    //            f.Results.Source.Missing = RetrieveOnly(targetOnly, f.Results.Target.Differences, f, progressCallback, ProgressType.CheckingSourceMissing);//targetOnly.Except(f.Results.Target.Differences, f.Comparer).ToList();
    //                                                                                                                                                       // Get target missing: check "target only" keys against "source only" keys
    //            f.Results.Target.Missing = RetrieveOnly(sourceOnly, f.Results.Source.Differences, f, progressCallback, ProgressType.CheckingTargetMissing); //sourceOnly.Except(f.Results.Source.Differences, f.Comparer).ToList();
    //        }
    //        else
    //        {
    //            f.Results.Source.Missing = f.Results.Source.Differences = targetOnly;
    //            f.Results.Target.Missing = f.Results.Target.Differences = sourceOnly;
    //        }
    //    }
    //    else
    //    {
    //        //SetProgress(f, ProgressType.Comparing, 55, progressCallback);
    //        SetProgress(f, ProgressType.Done, 0, progressCallback);
    //    }
    //}

    public static ItemResult<T> GetDuplicates<T>(IEnumerable<T> data, IList<string>? keys) where T : class
    {
        ItemResult<T> ret = new();

        var seqComparer = new SequenceComparer<object>(keys?.Count);// ?? f.SourceHeaders?.Count);
        var seqEqComparer = new SequenceEqualityComparer<object>();
        //TODO : key comparison
        SequenceEqualityComparer<object>? seqRemEqComparer = null;
        if (keys is not null)
        {
            seqRemEqComparer = new SequenceEqualityComparer<object>(keys.Count);
        }

        var prev = default(T);
        foreach(var item in data)
        {
            CheckDuplicate(ret, prev, item, seqEqComparer, seqRemEqComparer);
        }

        return ret;
    }

    public static ItemResult<T> InitiateDuplicates<T>(IEnumerable<T> srcData, IEqualityComparer<T> keyComparer, IEqualityComparer<T> comparer)
    {
        var ret = new ItemResult<T>();

        InitiateDuplicates(srcData, ret, keyComparer, comparer);

        return ret;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void InitiateDuplicates<T>(IEnumerable<T> srcData, ItemResult<T> itemResult, IEqualityComparer<T> keysComparer, IEqualityComparer<T> comparer)
    {
        if (keysComparer is null)
        {
            itemResult.PerfectDups = srcData.GroupBy(x => x, comparer).Where(g => g.Count() > 1).SelectMany(g => g).ToList();
        }
        else
        {
            itemResult.Duplicates = srcData.GroupBy(x => x, keysComparer).Where(g => g.Count() > 1).SelectMany(g => g).ToList();
            itemResult.PerfectDups = itemResult.Duplicates.GroupBy(x => x, comparer).Where(g => g.Count() > 1).SelectMany(g => g).ToList();
        }
    }

    //private static IList<T> RetrieveOnly<T>(IList<T> a, IList<T> b, ComparerDefinition<T> f, IProgress<ComparerDefinition<T>> progressCallback, ProgressType type)
    //{
    //    var ix = 0;
    //    return a.AsParallel()
    //            .WithProgress(p => SetProgress(f, type, (int)(p * 10 / a.Count), progressCallback))
    //            .Except(b.AsParallel(), f.Comparer)
    //            .ToList();
    //}
}
