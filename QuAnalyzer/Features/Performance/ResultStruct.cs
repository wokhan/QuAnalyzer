using System.Collections.Generic;
using System.ComponentModel;

namespace QuAnalyzer.Features.Performance
{
    public class ResultStruct : INotifyPropertyChanged
    {
        public string Name;
        public int Index;
        public string Id;

        private Status _status;
        public Status Status { get => _status; set { _status = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status))); } }

        private double _start;
        public double Start { get => _start; set { _start = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Start))); } }

        private double _end;
        public double End { get => _end; set { _end = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(End))); } }

        private Dictionary<string, long> _durations = new Dictionary<string, long>();
        public Dictionary<string, long> Duration { get => _durations; set { _durations = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Duration))); } }

        private object _result;
        public object Result { get => _result; set { _result = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result))); } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
