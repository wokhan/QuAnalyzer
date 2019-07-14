using QuAnalyzer.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Threading;
using Wokhan.Data.Providers.Contracts;

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


    public class ResultsClass : NotifierHelper
    {
        public MonitorItem Step { get; set; }

        public bool IsOK { get; set; }

        private DateTime _lastcheck = DateTime.Now;
        public DateTime LastCheck
        {
            get { return _lastcheck; }
        }

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

    public class MonitorItem : NotifierHelper
    {
        public event Action<ResultsClass> OnResult;
        public event Action<ResultsClass> OnAdd;

        public bool RunWhenStarted { get; set; }

        public List<MonitorItem> PrecedingSteps { get; set; }

        public List<string> AttributesList
        {
            get { return Attributes.Split(',').ToList(); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
        }

        public string ProviderName { get; set; }

        [IgnoreDataMember()]
        public IDataProvider Provider
        {
            get { return ((App)System.Windows.Application.Current).CurrentProject.CurrentProviders.SingleOrDefault(c => c.Name == ProviderName); }
            set { ProviderName = value != null ? value.Name : string.Empty; }
        }

        public string Repository { get; set; }
        public string Filter { get; set; }

        private int _interval;
        public int Interval
        {
            get { return _interval; }
            set { _interval = value; NotifyPropertyChanged("Interval"); }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged("Status"); }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; NotifyPropertyChanged("Type"); }
        }

        private DispatcherTimer timer = new DispatcherTimer();

        public void Start()
        {
            if (PrecedingSteps.Any())
            {
                Status = "Waiting";
                foreach (var m in PrecedingSteps)
                {
                    m.OnResult -= preceding_Done;
                    m.OnResult += preceding_Done;
                }
            }
            else
            {
                setRunning();
            }
        }

        private void setRunning()
        {
            Status = "Running";

            timer.Interval = TimeSpan.FromSeconds(Interval);
            timer.Tick += timer_Tick;
            timer.Start();

            if (RunWhenStarted)
            {
                timer_Tick(null, null);
            }
        }

        private void preceding_Done(ResultsClass obj)
        {
            setRunning();
        }

        public void Stop()
        {
            timer.Stop();

            Status = "Stopped";
        }

        private bool _isChecking = false;
        private int cnt = 0;

        private async void timer_Tick(object sender, EventArgs e)
        {
            if (_isChecking)
            {
                return;
            }

            _isChecking = true;

            var r = new ResultsClass();
            r.Step = this;
            r.ResultCount = -1;
            r.Occurence = cnt++;

            OnAdd?.Invoke(r);

            var sw = Stopwatch.StartNew();

            object data = null;
            r.ResultCount = await Task.Run(() => Monitoring.Monitor(Provider, Type, Repository, out data, Filter, Attributes));
            r.Data = data;
            sw.Stop();

            var dbc = new DoubleConverter();

            r.Duration = sw.ElapsedMilliseconds;

            OnResult?.Invoke(r);

            _isChecking = false;
        }

        private ObservableCollection<DatePoint> _points = new ObservableCollection<DatePoint>();

        public ObservableCollection<DatePoint> Points
        {
            get { return _points; }
        }

        public void AttachEvent(Action<ResultsClass> monitor_OnAdd, Action<ResultsClass> monitor_OnResult)
        {
            OnAdd -= monitor_OnAdd;
            OnAdd += monitor_OnAdd;
            OnResult -= monitor_OnResult;
            OnResult += monitor_OnResult;
        }

        private string _attributes = "";
        public string Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }
    }
}
