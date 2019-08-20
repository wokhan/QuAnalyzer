using QuAnalyzer.Generic;
using System;
using System.Collections.Generic;
using Wokhan.Core.ComponentModel;

namespace QuAnalyzer.Features.Monitoring
{
    public class MultiValueDatePoint : NotifierHelper
    {
        public DateTime X { get; set; }

        private double _y;
        public double Y
        {
            get => _y;
            set { _y = value; NotifyPropertyChanged(); }
        }

        private Dictionary<string, long> values;
        public Dictionary<string, long> Values
        {
            get => values;
            set { values = value; NotifyPropertyChanged(); }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; NotifyPropertyChanged(); }
        }

    }
}
