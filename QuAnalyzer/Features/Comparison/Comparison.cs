using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuAnalyzer.Features.Comparison
{
    public static class Comparison
    {
        public static void Run<T>(IEnumerable<ComparerStruct<T>> comparerData, int nbSamplesCompared, int nbSamplesShown, Action<ComparerStruct<T>> progressCallback = null, bool useParallelism = true) where T : class
        {
            Contract.Requires(comparerData is not null);

            if (progressCallback is null)
            {
                progressCallback = (s) => { };
            }

            Action<ComparerStruct<T>> runForOne =
                async (f) =>
                {
                    try
                    {
                        CancellationToken token = f.TokenSource.Token;

                        token.Register(() => setProgress(f, ProgressType.Canceling, 0, progressCallback));

                        var r = f.Results;
                        var totaltime = Stopwatch.StartNew();

                        setProgress(f, ProgressType.LoadingData, 0, progressCallback);

                        var t1 = LoadData(f, f.Results.Source, f.GetSourceData(), token);
                        var t2 = LoadData(f, f.Results.Target, f.GetTargetData(), token);

                        IEnumerable<T> srcData = await t1;
                        IEnumerable<T> trgData = await t2;

                        setProgress(f, ProgressType.LoadingDone, 1, progressCallback);

                        Task.WaitAll(t1, t2);

                        if (srcData is not null && trgData is not null)
                        {
                            if (nbSamplesShown > 0)
                            {
                                setProgress(f, ProgressType.GettingSamples, 0, progressCallback);

                                var samples = GetSamples(nbSamplesShown, srcData, trgData);
                                r.Source.Samples = samples.First();
                                r.Target.Samples = samples.Last();

                                setProgress(f, ProgressType.GettingSamples, 15, progressCallback);
                            }

                            if (nbSamplesCompared > 0)
                            {
                                setProgress(f, ProgressType.Filtering, 0, progressCallback);

                                var samples = GetSamples(nbSamplesCompared, srcData, trgData);
                                srcData = samples.First();
                                trgData = samples.Last();

                                setProgress(f, ProgressType.Filtering, 15, progressCallback);
                            }

                            if (f.IsOrdered)
                            {
                                CompareOrdered(f, srcData, trgData, progressCallback, token);
                            }
                            else
                            {
                                Compare(f, srcData, trgData, progressCallback, token);
                            }
                        }

                        setProgress(f, ProgressType.Done, 0, progressCallback);

                        totaltime.Stop();
                        f.Results.TotalTime = totaltime.ElapsedMilliseconds;
                    }
                    catch (OperationCanceledException)
                    {
                        setProgress(f, ProgressType.Canceled, 0, progressCallback);
                    }
                    catch (InvalidDataException ed)
                    {
                        f.Results.Message = "The following attribute could not be loaded: " + ed.Message + "\r\nThe inner exception is: " + ed.InnerException.Message + "\r\nPlease check your providers and mappings.";
                        setProgress(f, ProgressType.Failed, 0, progressCallback);
                    }
                    catch (Exception e)
                    {
                        f.Results.Message = e.Message + "\r\nStacktrace: " + e.StackTrace;
                        setProgress(f, ProgressType.Failed, 0, progressCallback);
                    }
                };

            if (!useParallelism)
            {
                var t = Task.Run(() => runForOne(comparerData.First()));
                foreach (var cd in comparerData)
                {
                    t.ContinueWith(_ => runForOne(cd));
                }
            }
            else
            {
                comparerData.AsParallel().ForAll(runForOne);
            }
        }

        private static Task<IEnumerable<T>> LoadData<T>(ComparerStruct<T> f, ItemResult<T> item, IEnumerable<T> tr, CancellationToken token) where T : class
        {
            return Task.Run(() =>
            {
                var start = Stopwatch.StartNew();
                item.StartTime = DateTime.Now;
                var res = tr.Select((a, i) => { token.ThrowIfCancellationRequested(); item.Count = i + 1; return a; }); //.ToList();
                if (!f.IsOrdered)
                {
                    res = res.ToList();
                }
                start.Stop();
                item.LoadingTime = start.ElapsedMilliseconds;
                return res;
            });
        }

        private static void setProgress<T>(ComparerStruct<T> f, ProgressType progressType, int p, Action<ComparerStruct<T>> progressCallback)
        {
            f.Results.Progress = progressType;
            f.Results.SubProgress = p;

            progressCallback(f);
        }

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
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="f"></param>
        /// <param name="srcData"></param>
        /// <param name="trgData"></param>
        /// <param name="progressCallback"></param>
        /// <param name="token"></param>
        public static void CompareOrdered<T>(ComparerStruct<T> f, IEnumerable<T> srcData, IEnumerable<T> trgData, Action<ComparerStruct<T>> progressCallback, CancellationToken token) where T : class
        {
            Contract.Requires(srcData is not null);
            Contract.Requires(trgData is not null);

            var srcPrev = default(T);
            var trgPrev = default(T);

            f.Results.Source.Duplicates = new ObservableCollection<T>();
            f.Results.Target.Duplicates = new ObservableCollection<T>();
            f.Results.Source.Differences = new ObservableCollection<T>();
            f.Results.Target.Differences = new ObservableCollection<T>();
            f.Results.Source.Missing = new ObservableCollection<T>();
            f.Results.Target.Missing = new ObservableCollection<T>();
            f.Results.Source.PerfectDups = new ObservableCollection<T>();
            f.Results.Target.PerfectDups = new ObservableCollection<T>();

            var scmp = new SequenceComparer(f.SourceKeys is not null ? f.SourceKeys.ToArray() : Enumerable.Range(0, f.SourceHeaders.Count).Select(i => i.ToString()).ToArray());
            // TODO : gen type
            var sqc = new SequenceEqualityComparer<object>();

            using (var srcEnum = srcData.GetEnumerator())
            using (var trgEnum = trgData.GetEnumerator())
            {
                var issrc = true;
                var istrg = true;
                bool samesrc;
                bool sametrg;
                bool scannext;

                while (issrc || istrg)
                {
                    setProgress(f, ProgressType.LoadingData, 0, progressCallback);

                    issrc = srcEnum.MoveNext();
                    istrg = trgEnum.MoveNext();
                    samesrc = false;
                    sametrg = false;
                    scannext = true;

                    while ((issrc || istrg) && scannext)
                    {
                        if (!samesrc && default(T) != srcPrev && sqc.Equals((IEnumerable<object>)srcPrev, (IEnumerable<object>)srcEnum.Current))
                        {
                            f.Results.Source.Duplicates.Add(srcEnum.Current);
                        }

                        if (!sametrg && default(T) != trgPrev && sqc.Equals((IEnumerable<object>)trgPrev, (IEnumerable<object>)trgEnum.Current))
                        {
                            f.Results.Target.Duplicates.Add(trgEnum.Current);
                        }

                        trgPrev = trgEnum.Current;
                        srcPrev = srcEnum.Current;

                        if (!issrc)
                        {
                            // add all remaining trgEnum to missing from src
                            f.Results.Source.Missing.Add(trgEnum.Current);
                            istrg = trgEnum.MoveNext();
                            samesrc = true;
                            continue;
                        }

                        if (!istrg)
                        {
                            // add all remaining srcEnum to missing from trg
                            f.Results.Target.Missing.Add(srcEnum.Current);
                            issrc = srcEnum.MoveNext();
                            sametrg = true;
                            continue;
                        }

                        var cmp = scmp.Compare((IEnumerable<object>)srcEnum.Current, (IEnumerable<object>)trgEnum.Current);

                        if (cmp == 0)
                        {
                            f.Results.MatchingCount++;
                            scannext = false;
                        }
                        else if (cmp > 0 && cmp < int.MaxValue)
                        {
                            f.Results.Source.Missing.Add(trgEnum.Current);
                            istrg = trgEnum.MoveNext();
                            samesrc = true;
                        }
                        else if (cmp < 0)
                        {
                            f.Results.Target.Missing.Add(srcEnum.Current);
                            issrc = srcEnum.MoveNext();
                            sametrg = true;
                        }
                        else if (cmp == int.MaxValue)
                        {
                            f.Results.Source.Differences.Add(srcEnum.Current);
                            f.Results.Target.Differences.Add(trgEnum.Current);
                            scannext = false;
                        }
                    }
                }
            }

            setProgress(f, ProgressType.Done, 0, progressCallback);
        }

        public static void Compare<T>(ComparerStruct<T> f, IEnumerable<T> srcData, IEnumerable<T> trgData, Action<ComparerStruct<T>> progressCallback, CancellationToken token)
        {
            Contract.Requires(srcData is not null);
            Contract.Requires(trgData is not null);
            Contract.Requires(progressCallback is not null);

            var countA = f.Results.Source.Count;
            var countB = f.Results.Target.Count;

            if (countA == 0)
            {
                f.Results.Source.Missing = trgData.ToList();
                f.Results.MatchingCount = 0;
                InitiateDuplicates(trgData, f.Results.Target, f.KeysComparer, f.Comparer);
                return;
            }

            if (countB == 0)
            {
                f.Results.Target.Missing = srcData.ToList();
                f.Results.MatchingCount = 0;
                InitiateDuplicates(srcData, f.Results.Source, f.KeysComparer, f.Comparer);
                return;
            }

            ParallelQuery<T> srcPrl = srcData.AsParallel();
            ParallelQuery<T> trgPrl = trgData.AsParallel();

            InitiateDuplicates(srcData, f.Results.Source, f.KeysComparer, f.Comparer);
            InitiateDuplicates(trgData, f.Results.Target, f.KeysComparer, f.Comparer);

            //progressCallback(cName, ProgressType.Comparing, 0);
            var i = 0;
            var matchingItems = srcPrl.Select(m => { setProgress(f, ProgressType.Comparing, Interlocked.Increment(ref i) * 20 / countA, progressCallback); return m; })
                                      .Intersect(trgPrl, f.Comparer)
                                      .ToList()
                                      .AsParallel();

            f.Results.MatchingCount = matchingItems.Count();

            if (countA != f.Results.MatchingCount || countB != f.Results.MatchingCount)
            {
                // Rem matches from source
                var filteredA = srcPrl.Except(matchingItems, f.Comparer).ToList();

                // Rem matches from target
                var filteredB = trgPrl.Except(matchingItems, f.Comparer).ToList();

                // Get items only in source = get items missing from the target
                var sourceOnly = RetrieveOnly(filteredA, filteredB, f, progressCallback, ProgressType.CheckingSourceOnly);

                // Get items only in target = get items missing from the source
                var targetOnly = RetrieveOnly(filteredB, filteredA, f, progressCallback, ProgressType.CheckingTargetOnly);

                if (f.KeysComparer is not null)
                {
                    f.Results.Source.Differences = new ObservableCollection<T>();
                    f.Results.Target.Differences = new ObservableCollection<T>();

                    var differences = sourceOnly.Join(targetOnly, s => s, t => t, (s, t) => (s, t), f.KeysComparer);
                    foreach (var diff in differences)
                    {
                        f.Results.Source.Differences.Add(diff.s);
                        f.Results.Target.Differences.Add(diff.t);
                    }

                    // Get source missing: check "source only" keys against "target only" keys
                    // If the key does not exist, the item is a really missing one.
                    f.Results.Source.Missing = RetrieveOnly(targetOnly, f.Results.Target.Differences, f, progressCallback, ProgressType.CheckingSourceMissing);//targetOnly.Except(f.Results.Target.Differences, f.Comparer).ToList();
                    // Get target missing: check "target only" keys against "source only" keys
                    f.Results.Target.Missing = RetrieveOnly(sourceOnly, f.Results.Source.Differences, f, progressCallback, ProgressType.CheckingTargetMissing); //sourceOnly.Except(f.Results.Source.Differences, f.Comparer).ToList();
                }
                else
                {
                    f.Results.Source.Missing = f.Results.Source.Differences = targetOnly;
                    f.Results.Target.Missing = f.Results.Target.Differences = sourceOnly;
                }
            }
            else
            {
                setProgress(f, ProgressType.Comparing, 55, progressCallback);
            }
        }

        public static ItemResult<T> InitiateDuplicates<T>(IEnumerable<T> srcData, IEqualityComparer<T> keyComparer, IEqualityComparer<T> comparer)
        {
            var ret = new ItemResult<T>();

            InitiateDuplicates(srcData, ret, keyComparer, comparer);

            return ret;
        }

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

        private static IList<T> RetrieveOnly<T>(IList<T> a, IList<T> b, ComparerStruct<T> f, Action<ComparerStruct<T>> progressCallback, ProgressType type)
        {
            var ix = 0;
            return a.AsParallel()
                    .Select(m => { setProgress(f, type, Interlocked.Increment(ref ix) * 10 / a.Count, progressCallback); return m; })
                    .Except(b.AsParallel(), f.Comparer)
                    .ToList();
        }
    }
}
