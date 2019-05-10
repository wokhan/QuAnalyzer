using QuAnalyzer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace QuAnalyzer.Logic
{
    public static class Comparison
    {
        public enum ProgressType
        {
            LoadingData = 0,
            LoadingDone = 1,
            GettingSamples = 10,
            Filtering = 20,
            Comparing = 30,
            CheckingSourceOnly = 50,
            CheckingTargetOnly = 60,
            CheckingSourceMissing = 70,
            CheckingTargetMissing = 80,
            Done = 100,
            Canceling = -1,
            Canceled = -2,
            Failed = -3
        }

        public static void Run<T>(IEnumerable<ComparerStruct<T>> comparerData, int nbSamplesCompared, int nbSamplesShown, Action<ComparerStruct<T>> progressCallback = null, bool useParallelism = true) where T : class
        {
            if (progressCallback == null)
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

                        var t1 = Task.Run(() =>
                        {
                            var start = Stopwatch.StartNew();
                            var item = r.Source;
                            f.Results.Source.StartTime = DateTime.Now;
                            var res = f.GetSourceData().Select((a, i) => { token.ThrowIfCancellationRequested(); item.Count = i + 1; return a; }); //.ToList();
                            if (!f.IsOrdered)
                            {
                                res = res.ToList();
                            }
                            start.Stop();
                            f.Results.Source.LoadingTime = start.ElapsedMilliseconds;
                            return res;
                        });

                        var t2 = Task.Run(() =>
                        {
                            var start = Stopwatch.StartNew();
                            var item = r.Target;
                            f.Results.Target.StartTime = DateTime.Now;
                            var res = f.GetTargetData().Select((a, i) => { token.ThrowIfCancellationRequested(); item.Count = i + 1; return a; });//.ToList();
                            if (!f.IsOrdered)
                            {
                                res = res.ToList();
                            }
                            start.Stop();
                            f.Results.Target.LoadingTime = start.ElapsedMilliseconds;
                            return res;
                        });

                        IEnumerable<T> srcData = await t1;
                        IEnumerable<T> trgData = await t2;

                        setProgress(f, ProgressType.LoadingDone, 1, progressCallback);

                        Task.WaitAll(t1, t2);

                        if (srcData != null && trgData != null)
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
                    t.ContinueWith((task) => runForOne(cd));
                }
            }
            else
            {
                Parallel.ForEach(comparerData, runForOne);
            }
        }


        private static void setProgress<T>(ComparerStruct<T> f, ProgressType progressType, int p, Action<ComparerStruct<T>> progressCallback)
        {
            f.Results.Progress = progressType;
            f.Results.SubProgress = p;

            progressCallback(f);
        }

        public static T[][] GetSamples<T>(int nbSamples, params IEnumerable<T>[] collections)
        {
            Random rdm = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            int min = collections.Min(c => c.Count());
            nbSamples = Math.Min(min, nbSamples);

            int[] rdmIdxs = new byte[nbSamples].Select(i => rdm.Next(min)).ToArray();

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
            if (srcData == null)
            {
                throw new ArgumentNullException("Source");
            }

            if (trgData == null)
            {
                throw new ArgumentNullException("Target");
            }

            var srcMissing = new List<T>();
            var trgMissing = new List<T>();
            var srcDiff = new List<T>();
            var trgDiff = new List<T>();
            var srcDups = new List<T>();
            var trgDups = new List<T>();

            var srcPrev = default(T);
            var trgPrev = default(T);

            var scmp = new SequenceComparer(f.SourceKeys != null ? f.SourceKeys.ToArray() : Enumerable.Range(0, f.SourceHeaders.Count).Select(i => i.ToString()).ToArray());
            var sqc = new SequenceEqualityComparer();

            using (var srcEnum = srcData.GetEnumerator())
            using (var trgEnum = trgData.GetEnumerator())
            {
                bool issrc = true;
                bool istrg = true;
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
                            srcDups.Add(srcEnum.Current);
                        }

                        if (!sametrg && default(T) != trgPrev && sqc.Equals((IEnumerable<object>)trgPrev, (IEnumerable<object>)trgEnum.Current))
                        {
                            trgDups.Add(trgEnum.Current);
                        }

                        trgPrev = trgEnum.Current;
                        srcPrev = srcEnum.Current;

                        if (!issrc)
                        {
                            // add all remaining trgEnum to missing from src
                            srcMissing.Add(trgEnum.Current);
                            istrg = trgEnum.MoveNext();
                            samesrc = true;
                            continue;
                        }

                        if (!istrg)
                        {
                            // add all remaining srcEnum to missing from trg
                            trgMissing.Add(srcEnum.Current);
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
                            srcMissing.Add(trgEnum.Current);
                            istrg = trgEnum.MoveNext();
                            samesrc = true;
                        }
                        else if (cmp < 0)
                        {
                            trgMissing.Add(srcEnum.Current);
                            issrc = srcEnum.MoveNext();
                            sametrg = true;
                        }
                        else if (cmp == int.MaxValue)
                        {
                            srcDiff.Add(srcEnum.Current);
                            trgDiff.Add(trgEnum.Current);
                            scannext = false;
                        }
                    }
                }
            }

            setProgress(f, ProgressType.Done, 0, progressCallback);

            f.Results.Source.Missing = srcMissing;
            f.Results.Source.Differences = srcDiff;
            f.Results.Source.Duplicates = srcDups;
            f.Results.Target.Missing = trgMissing;
            f.Results.Target.Differences = trgDiff;
            f.Results.Target.Duplicates = trgDups;

        }

        public static void Compare<T>(ComparerStruct<T> f, IEnumerable<T> srcData, IEnumerable<T> trgData, Action<ComparerStruct<T>> progressCallback, CancellationToken token)
        {
            if (srcData == null)
            {
                throw new ArgumentNullException("Source");
            }

            if (trgData == null)
            {
                throw new ArgumentNullException("Target");
            }

            int countA = f.Results.Source.Count;
            int countB = f.Results.Target.Count;

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
            int i = 0;
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

                if (f.KeysComparer != null)
                {
                    var differences = sourceOnly.Join(targetOnly, s => s, t => t, (s, t) => new { s, t }, f.KeysComparer).ToList();

                    // Should be improved, dude.
                    f.Results.Source.Differences = differences.Select(d => d.s).ToList();
                    f.Results.Target.Differences = differences.Select(d => d.t).ToList();

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
            if (keysComparer == null)
            {
                itemResult.PerfectDups = srcData.GroupBy(x => x, comparer).Where(g => g.Count() > 1).SelectMany(g => g).ToList();
            }
            else
            {
                itemResult.Duplicates = srcData.GroupBy(x => x, keysComparer).Where(g => g.Count() > 1).SelectMany(g => g).ToList();
                itemResult.PerfectDups = itemResult.Duplicates.GroupBy(x => x, comparer).Where(g => g.Count() > 1).SelectMany(g => g).ToList();
            }
        }

        private static List<T> RetrieveOnly<T>(List<T> a, List<T> b, ComparerStruct<T> f, Action<ComparerStruct<T>> progressCallback, ProgressType type)
        {
            int ix = 0;
            return a.AsParallel()
                    .Select(m => { setProgress(f, type, Interlocked.Increment(ref ix) * 10 / a.Count, progressCallback); return m; })
                    .Except(b.AsParallel(), f.Comparer)
                    .ToList();
        }


        public class SequenceComparer : IComparer<IEnumerable<object>>
        {
            private static SequenceEqualityComparer sec = new SequenceEqualityComparer();
            private string[] keys;

            public SequenceComparer()
            {
                keys = null;
            }

            public SequenceComparer(params string[] keys)
            {
                this.keys = keys;
            }

            public int Compare(IEnumerable<object> x, IEnumerable<object> y)
            {
                if (sec.Equals(x, y))
                {
                    return 0;
                }

                if (sec.Equals(keys.Select((k, i) => x.ElementAt(i)), keys.Select((k, i) => y.ElementAt(i))))
                {
                    return int.MaxValue;
                }

                var id = keys.Select((k, i) => i)
                           .SkipWhile(i => x.ElementAt(i).Equals(y.ElementAt(i)))
                           .First();

                var xi = x.ElementAt(id);
                var yi = y.ElementAt(id);
                if (xi is string)
                {
                    return String.CompareOrdinal((string)xi, (string)yi);
                }

                return ((IComparable)xi).CompareTo((IComparable)yi);
            }
        }

        public class SequenceEqualityComparer : IEqualityComparer<IEnumerable<object>>
        {
            private static IEqualityComparer<object> cmp = new SmartEqualityComparer();// EqualityComparer<object>.Default;

            private int startFrom;
            private int maxCount;

            public SequenceEqualityComparer(int startFrom = 0, int maxCount = int.MaxValue)
            {
                this.startFrom = startFrom;
                this.maxCount = maxCount;
            }

            public bool Equals(IEnumerable<object> x, IEnumerable<object> y)
            {
                return x.Skip(startFrom).Take(maxCount).SequenceEqual(y.Skip(startFrom).Take(maxCount), cmp);
            }

            // Computes an aggregated Hash Code to speed up comparison process.
            // If two hashcodes are different, then it means that the object are different. Calling Equals is only required
            // if two hashcodes are equal (meaning that equality will be checked at a deeper level).
            // To ensure that Equals is always called, you can return 0.
            public int GetHashCode(IEnumerable<object> obj)
            {
                return obj.Skip(startFrom).Take(maxCount).Aggregate(17, (a, i) => (a * 23) + (i == null || i is DBNull ? 0 : i.GetHashCode()));
            }
        }

        public class SmartEqualityComparer : IEqualityComparer<object>
        {
            public new bool Equals(object x, object y)
            {
                return (x is DBNull && y == null) || (y is DBNull && x == null) || Object.Equals(x, y);
            }

            public int GetHashCode(object obj)
            {
                return obj == null || obj is DBNull ? 0 : obj.GetHashCode();
            }
        }
    }
}
