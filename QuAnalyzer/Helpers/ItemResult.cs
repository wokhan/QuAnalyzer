using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuAnalyzer.Helpers
{
    public class ItemResult<T> : NotifierHelper
    {
        private int _count;
        public int Count
        {
            get { return _count; }
            internal set { _count = value; NotifyPropertyChanged("Count"); }
        }

        private List<T> _differences;
        public List<T> Differences
        {
            get { return _differences; }
            internal set { _differences = value; NotifyPropertyChanged("Differences"); }
        }

        private List<T> _duplicates;
        public List<T> Duplicates
        {
            get { return _duplicates; }
            internal set { _duplicates = value; NotifyPropertyChanged("Duplicates"); }
        }

        private List<T> _perfDups;
        public List<T> PerfectDups
        {
            get { return _perfDups; }
            internal set { _perfDups = value; NotifyPropertyChanged("PerfectDups"); }
        }

        private List<T> _missing;
        public List<T> Missing
        {
            get { return _missing; }
            internal set { _missing = value; NotifyPropertyChanged("Missing"); }
        }

        public IEnumerable<T> Samples { get; internal set; }

        private long _loadingTime;
        public long LoadingTime
        {
            get { return _loadingTime; }
            internal set { _loadingTime = value; NotifyPropertyChanged("LoadingTime"); }
        }

        private DateTime _startTime;
        public DateTime StartTime
        {
            get { return _startTime; }
            internal set { _startTime = value; NotifyPropertyChanged("StartTime"); }
        }
    }
}
