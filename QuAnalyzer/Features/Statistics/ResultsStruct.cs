using QuAnalyzer.Generic;
using System.Collections.ObjectModel;
using Wokhan.Core.ComponentModel;

namespace QuAnalyzer.Features.Statistics
{

    public class ResultsStruct : NotifierHelper
    {
        public ObservableCollection<Values> Frequencies { get; } = new ObservableCollection<Values>();

        private Stats _statistics;
        public Stats Statistics
        {
            get { return _statistics; }
            internal set { _statistics = value; NotifyPropertyChanged(); }
        }

        public class Stats
        {
            public object Min { get; set; }
            public object Max { get; set; }
            public object Average { get; set; }
            public object Count { get; set; }
            public object DistinctCount { get; set; }
            public object EmptyCount { get; set; }
        }
    }
}
