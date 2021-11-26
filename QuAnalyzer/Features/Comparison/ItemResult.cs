using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Wokhan.Core.ComponentModel;

namespace QuAnalyzer.Features.Comparison
{
    public class ItemResult<T> : NotifierHelper
    {
        private int _count;
        public int Count
        {
            get { return _count; }
            internal set { _count = value; NotifyPropertyChanged(); }
        }

        private IList<T> _differences;
        public IList<T> Differences
        {
            get { return _differences; }
            internal set { _differences = value; NotifyPropertyChanged(); }
        }

        private IList<T> _duplicates;
        public IList<T> Duplicates
        {
            get { return _duplicates; }
            internal set { _duplicates = value; NotifyPropertyChanged(); }
        }

        private IList<T> _perfDups;
        public IList<T> PerfectDups
        {
            get { return _perfDups; }
            internal set { _perfDups = value; NotifyPropertyChanged(); }
        }

        private IList<T> _missing;
        public IList<T> Missing
        {
            get { return _missing; }
            internal set { _missing = value; NotifyPropertyChanged(); }
        }

        public IEnumerable<T> Samples { get; internal set; }

        private long _loadingTime;
        public long LoadingTime
        {
            get { return _loadingTime; }
            internal set { _loadingTime = value; NotifyPropertyChanged(); }
        }

        private DateTime _startTime;
        public DateTime StartTime
        {
            get { return _startTime; }
            internal set { _startTime = value; NotifyPropertyChanged(); }
        }
    }
}
