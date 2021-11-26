using System;
using System.Collections.Generic;
using System.Linq;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Core.ComponentModel;

namespace QuAnalyzer.Features.Comparison
{
    public class ResultStruct<T> : NotifierHelper
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            internal set { _message = value; NotifyPropertyChanged(); }
        }

        private ProgressType _progress;
        public ProgressType Progress
        {
            get { return _progress; }
            internal set { _progress = value; NotifyPropertyChanged(); NotifyPropertyChanged("LocalProgress"); }
        }
        public int SubProgress { get; internal set; }
        public int LocalProgress { get { return (int)Progress + SubProgress; } }

        public ItemResult<T> Source { get; } = new ItemResult<T>();
        public ItemResult<T> Target { get; } = new ItemResult<T>();

        private int _matchincount;
        public int MatchingCount
        {
            get { return _matchincount; }
            internal set { _matchincount = value; NotifyPropertyChanged(); }
        }

        private long _totalTime;
        public long TotalTime
        {
            get { return _totalTime; }
            internal set { _totalTime = value; NotifyPropertyChanged(); }
        }

        public IEnumerable<DiffClass> MergedDiff { get; private set; } = null;

        public void InitDiff(IDataComparer r)
        {
            if (MergedDiff is null)
            {
                MergedHeaders = r.SourceHeaders.Select((h, i) => new { a = h, b = r.TargetHeaders[i] })
                                                .Select(x => x.a + (x.a != x.b ? "/" + x.b : string.Empty))
                                                .ToArray();

                IEnumerable<object[]> sortedMiss;
                if (Source.Differences is not null)
                {
                    sortedMiss = Source.Differences.Cast<object[]>().Select(m => m.Prepend(r.SourceName).ToArray());
                }
                else
                {
                    sortedMiss = new List<object[]>();
                }

                IEnumerable<object[]> sortedTrg;
                if (Target.Differences is not null)
                {
                    sortedTrg = Target.Differences.Cast<object[]>().Select(m => m.Prepend(r.TargetName).ToArray());
                }
                else
                {
                    sortedTrg = new List<object[]>();
                }

                object[] prev = null;
                var all = sortedMiss.Concat(sortedTrg);
                var ordered = r.SourceKeys?.Count > 0 ? all.OrderByMany(r.SourceKeys.Count, 1) : all.OrderByAll(1);

                MergedDiff = ordered.ThenBy(t => t[0]).Select(x =>
                {
                    var ret = new DiffClass()
                    {
                        //IsDiff = (prev is null || prev[0].Equals(x[0]) || (sortSrc is not null && sortSrc.Any(i => !Object.Equals(prev[i], x[i]))) ? new bool[x.Length] : prev.Select((y, i) => !Object.Equals(y, x[i])).ToArray()),
                        IsDiff = prev is null || prev[0].Equals(x[0]) || r.SourceKeys?.Count > 0 && !prev.Skip(1).Take(r.SourceKeys.Count).SequenceEqual(x.Skip(1).Take(r.SourceKeys.Count)) ? new bool[x.Length] : prev.Select((y, i) => !Equals(y, x[i])).ToArray(),
                        Values = x
                    };

                    prev = x;

                    return ret;
                });
            }
        }

        public string[] MergedHeaders { get; private set; }
    }
}