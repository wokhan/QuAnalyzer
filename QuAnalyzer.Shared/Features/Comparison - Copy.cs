using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuAnalyzer.Extensions;

namespace QuAnalyzer.Logic
{
    public static class Comparison
    {
        public enum ProgressType
        {
            LoadingSource = 0,
            LoadingTarget = 15,
            GettingSamples = 30,
            Filtering = 45,
            Comparing = 60,
            CheckingSource = 80,
            CheckingTarget = 90,
            Done = 100
        }

        public class ResultStruct<T>
        {
            public string Name { get; internal set; }
            public string SourceName { get; internal set; }
            public string TargetName { get; internal set; }
            public int SourceCount { get; internal set; }
            public int TargetCount { get; internal set; }
            public int MatchingCount { get; internal set; }
            public IEnumerable<T> SourceMissing { get; internal set; }
            public IEnumerable<T> TargetMissing { get; internal set; }
            public IEnumerable<T> SourceSamples { get; internal set; }
            public IEnumerable<T> TargetSamples { get; internal set; }

            public IEnumerable<T> Diff { get; internal set; }
        }

        public class ComparerStruct<T>
        {
            public string Name;
            public string SourceName;
            public string TargetName;
            public Func<IEnumerable<T>> GetSourceData;
            public Func<IEnumerable<T>> GetTargetData;
            public IEqualityComparer<T> Comparer;
            public DateTime SourceDate;
            public DateTime TargetDate;
        }

        public static void Run<T>(IEnumerable<ComparerStruct<T>> comparerData, int nbSamplesCompared, int nbSamplesShown, Action<ResultStruct<T>> resultCallback, Action<string, ProgressType, int> progressCallback = null)
        {
            _run(comparerData, nbSamplesCompared, nbSamplesShown, resultCallback, true, progressCallback);
        }

        public static void RunSequential<T>(IEnumerable<ComparerStruct<T>> comparerData, int nbSamplesCompared, int nbSamplesShown, Action<ResultStruct<T>> resultCallback, Action<string, ProgressType, int> progressCallback = null)
        {
            _run(comparerData, nbSamplesCompared, nbSamplesShown, resultCallback, false, progressCallback);
        }

        private static void _run<T>(IEnumerable<ComparerStruct<T>> comparerData, int nbSamplesCompared, int nbSamplesShown, Action<ResultStruct<T>> resultCallback, bool useParallelism, Action<string, ProgressType, int> progressCallback = null)
        {
            if (progressCallback == null)
            {
                progressCallback = (s, t, v) => { };
            }

            Action<ComparerStruct<T>> runForOne =
            (f) =>
            {
                ResultStruct<T> r = new ResultStruct<T>()
                {
                    Name = f.Name,
                    SourceName = f.SourceName,
                    TargetName = f.TargetName
                };

                progressCallback(r.Name, ProgressType.LoadingSource, 0);
                IEnumerable<T> csvData = f.GetSourceData().ToArray();

                progressCallback(r.Name, ProgressType.LoadingTarget, 0);
                IEnumerable<T> viewData = f.GetTargetData().ToArray();

                if (csvData != null && viewData != null)
                {
                    r.SourceCount = csvData.Count();
                    r.TargetCount = viewData.Count();

                    if (nbSamplesShown > 0)
                    {
                        progressCallback(r.Name, ProgressType.GettingSamples, 0);

                        var samples = GetSamples(nbSamplesShown, viewData, csvData);
                        r.SourceSamples = samples.First();
                        r.TargetSamples = samples.Last();

                        progressCallback(r.Name, ProgressType.GettingSamples, 15);
                    }

                    if (nbSamplesCompared > 0)
                    {
                        progressCallback(r.Name, ProgressType.Filtering, 0);

                        var samples = GetSamples(nbSamplesCompared, viewData, csvData);
                        viewData = samples.First();
                        csvData = samples.Last();

                        progressCallback(r.Name, ProgressType.Filtering, 15);
                    }

                    IEnumerable<T> sMiss;
                    IEnumerable<T> tMiss;

                    r.MatchingCount = Compare(viewData, csvData, f.Comparer, out sMiss, out tMiss, r.Name, progressCallback);

                    r.SourceMissing = sMiss;
                    r.TargetMissing = tMiss;
                }

                progressCallback(r.Name, ProgressType.Done, 0);

                resultCallback(r);
            };

            if (useParallelism)
            {
                Parallel.ForEach(comparerData, runForOne);
            }
            else
            {
                foreach (var f in comparerData)
                {
                    runForOne(f);
                }
            }
        }

        public static T[][] GetSamples<T>(int nbSamples, params IEnumerable<T>[] collections)
        {
            Random rdm = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            int min = collections.Min(c => c.Count());
            nbSamples = Math.Min(min, nbSamples);

            int[] rdmIdxs = new byte[nbSamples].Select(i => rdm.Next(min)).ToArray();

            return collections.Select(c => rdmIdxs.Select(i => c.ElementAtOrDefault(i)).ToArray()).ToArray();
        }

        public static int Compare<T>(IEnumerable<T[]> xa, IEnumerable<T[]> xb, IEqualityComparer<T[]> comparer, out IOrderedEnumerable<object[]> mergedDifferences, string cName = null, Action<string, ProgressType, int> progressCallback = null)
        {
            IEnumerable<T[]> missingSrc;
            IEnumerable<T[]> missingTrg;

            int ret = Comparison.Compare(xa, xb, comparer, out missingSrc, out missingTrg);

            IEnumerable<IEnumerable<object>> sortedMiss = missingSrc.Select(m => new object[] { "A1" }.Concat(m.Cast<object>()).ToArray());
            IEnumerable<IEnumerable<object>> sortedTrg = missingTrg.Select(m => new object[] { "A2" }.Concat(m.Cast<object>()).ToArray());

            mergedDifferences = sortedMiss.Concat(sortedTrg).OrderByAll(1).ThenBy(r => r[0]);

            return ret;
        }

        public static int Compare<T>(IEnumerable<T> xa, IEnumerable<T> xb, IEqualityComparer<T> comparer, out IEnumerable<T> missingFromSource, out IEnumerable<T> missingFromTarget, string cName = null, Action<string, ProgressType, int> progressCallback = null)
        {
            if (progressCallback == null)
            {
                progressCallback = (s, t, v) => { };
            }

            missingFromSource = null;
            missingFromTarget = null;

            if (xa == null)
            {
                if (xb != null) return -1;
            }

            if (xb == null)
            {
                return -2;
            }

            int countA = xa.Count();
            int countB = xb.Count();

            if (countA == 0)
            {
                missingFromSource = xb;
                return 0;
            }

            if (countB == 0)
            {
                missingFromTarget = xa;
                return 0;
            }

            ParallelQuery<T> a = xa.AsParallel();
            ParallelQuery<T> b = xb.AsParallel();

            //progressCallback(cName, ProgressType.Comparing, 0);
            int i = 0;
            T[] matchingItems = a.Select(m => { progressCallback(cName, ProgressType.Comparing, i++ * 20 / countA); return m; })
                                 .Intersect(b, comparer)
                                 .ToArray();

            int countMatch = matchingItems.Length;

            if (countA != countMatch || countB != countMatch)
            {
                var filteredA = a.Except(matchingItems.AsParallel(), comparer).ToArray();
                var filteredB = b.Except(matchingItems.AsParallel(), comparer).ToArray();

                i = 0;
                //progressCallback(cName, ProgressType.CheckingSource, 0);
                missingFromSource = filteredB.Select(m => { progressCallback(cName, ProgressType.CheckingSource, i++ * 10 / countA); return m; })
                                             .Except(filteredA, comparer)
                                             .ToArray();

                i = 0;
                //progressCallback(cName, ProgressType.CheckingTarget, 0);
                missingFromTarget = filteredA.Select(m => { progressCallback(cName, ProgressType.CheckingTarget, i++ * 10 / countB); return m; })
                                             .Except(filteredB, comparer)
                                             .ToArray();
            }
            else
            {
                progressCallback(cName, ProgressType.Comparing, 55);
            }

            return countMatch;
        }


        //		private static void CheckMissing<T>(ParallelQuery<T> a, string srcName, ParallelQuery<T> b, string targetName, IEqualityComparer<T> comparer) 
        //		{
        //			T[] missing = a.Except(b, comparer).ToArray();
        //			if (missing.Length > 0)
        //			{
        //				("=> " + missing.Length + " item(s) in " + srcName + " but not in " + targetName).Dump();
        //				if (missing.GetType().GetElementType().IsArray) 
        //				{
        //					missing.Cast<object[]>().Select(i => i.AsProxiedObject()).Dump();
        //				} 
        //				else 
        //				{
        //					missing.Dump();
        //				}
        //			}	
        //		}

        public class SequenceComparer<T> : IEqualityComparer<IEnumerable<T>>
        {
            private IEqualityComparer<T> cmp = EqualityComparer<T>.Default;

            public SequenceComparer() { }

            public SequenceComparer(IEqualityComparer<T> cmp)
            {
                this.cmp = cmp;
            }

            public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
            {
                return x.SequenceEqual(y, cmp);
            }

            // Computes an aggregated Hash Code to speed up comparison process.
            // If two hashcodes are different, then it means that the object are different. Calling Equals is only required
            // if two hashcodes are equal (meaning that equality will be checked at a deeper level).
            // To ensure that Equals is always called, you can return 0.
            public int GetHashCode(IEnumerable<T> obj)
            {
                return obj.Aggregate(17, (a, i) => (a * 23) + i.GetHashCode());
            }
        }
    }
}
