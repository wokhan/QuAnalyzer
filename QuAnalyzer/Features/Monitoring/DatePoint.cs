using QuAnalyzer.Generic;
using System;

namespace QuAnalyzer.Features.Monitoring
{
    public class DatePoint : NotifierHelper
    {
        public DateTime X { get; set; }

        private double _y;
        public double Y
        {
            get { return _y; }
            set { _y = value; NotifyPropertyChanged("Y"); }
        }

        private long _duration;
        public long Duration
        {
            get { return _duration; }
            set { _duration = value; NotifyPropertyChanged("Duration"); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
        }
    }
}
