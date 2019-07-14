using QuAnalyzer.Generic;
using QuAnalyzer.UI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using Wokhan.Collections.Extensions;

namespace QuAnalyzer.Features.Comparison
{
    public class ResultStruct<T> : NotifierHelper
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            internal set { _message = value; NotifyPropertyChanged("Message"); }
        }

        private Comparison.ProgressType _progress;
        public Comparison.ProgressType Progress
        {
            get { return _progress; }
            internal set { _progress = value; NotifyPropertyChanged("Progress"); NotifyPropertyChanged("LocalProgress"); }
        }
        public int SubProgress { get; internal set; }
        public int LocalProgress { get { return (int)Progress + SubProgress; } }

        private readonly ItemResult<T> _sourceResult = new ItemResult<T>();
        public ItemResult<T> Source
        {
            get { return _sourceResult; }
        }

        private readonly ItemResult<T> _targetResult = new ItemResult<T>();
        public ItemResult<T> Target
        {
            get { return _targetResult; }
        }

        private int _matchincount;
        public int MatchingCount
        {
            get { return _matchincount; }
            internal set { _matchincount = value; NotifyPropertyChanged("MatchingCount"); }
        }

        private long _totalTime;
        public long TotalTime
        {
            get { return _totalTime; }
            internal set { _totalTime = value; NotifyPropertyChanged("TotalTime"); }
        }

        public IEnumerable<DetailsWindow.DiffClass> MergedDiff { get; private set; } = null;

        public void InitDiff(IDataComparer r)
        {
            if (MergedDiff == null)
            {
                MergedHeaders = r.SourceHeaders.Select((h, i) => new { a = h, b = r.TargetHeaders[i] })
                                                .Select(x => x.a + (x.a != x.b ? "/" + x.b : string.Empty))
                                                .ToArray();

                IEnumerable<object[]> sortedMiss;
                if (Source.Differences != null)
                {
                    sortedMiss = Source.Differences.Cast<object[]>().Select(m => new object[] { r.SourceName }.Concat(m).ToArray());
                }
                else
                {
                    sortedMiss = new List<object[]>();
                }

                IEnumerable<object[]> sortedTrg;
                if (Target.Differences != null)
                {
                    sortedTrg = Target.Differences.Cast<object[]>().Select(m => new object[] { r.TargetName }.Concat(m).ToArray());
                }
                else
                {
                    sortedTrg = new List<object[]>();
                }

                object[] prev = null;
                var all = sortedMiss.Concat(sortedTrg);
                var ordered = r.SourceKeys.Count > 0 ? all.OrderByMany(r.SourceKeys.Count, 1) : all.OrderByAll(1);

                MergedDiff = ordered.ThenBy(t => t[0]).Select(x =>
                {
                    var ret = new DetailsWindow.DiffClass()
                    {
                        //IsDiff = (prev == null || prev[0].Equals(x[0]) || (sortSrc != null && sortSrc.Any(i => !Object.Equals(prev[i], x[i]))) ? new bool[x.Length] : prev.Select((y, i) => !Object.Equals(y, x[i])).ToArray()),
                        IsDiff = prev == null || prev[0].Equals(x[0]) || r.SourceKeys.Count > 0 && !prev.Skip(1).Take(r.SourceKeys.Count).SequenceEqual(x.Skip(1).Take(r.SourceKeys.Count)) ? new bool[x.Length] : prev.Select((y, i) => !Equals(y, x[i])).ToArray(),
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