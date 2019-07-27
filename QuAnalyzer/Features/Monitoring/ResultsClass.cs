using QuAnalyzer.Generic;
using System;

namespace QuAnalyzer.Features.Monitoring
{
    public class ResultsClass : NotifierHelper
    {
        public MonitorItem Step { get; set; }

        public bool IsOK { get; set; }
        public DateTime LastCheck { get; } = DateTime.Now;

        private long _resultCount;
        public long ResultCount
        {
            get { return _resultCount; }
            set { _resultCount = value; NotifyPropertyChanged("ResultCount"); }
        }

        private long _duration;
        public long Duration
        {
            get { return _duration; }
            set { _duration = value; NotifyPropertyChanged("Duration"); }
        }

        public int Occurence { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; NotifyPropertyChanged("IsSelected"); }
        }

        private object _data;
        public object Data
        {
            get { return _data; }
            set { _data = value; NotifyPropertyChanged("Data"); }
        }
    }
}
