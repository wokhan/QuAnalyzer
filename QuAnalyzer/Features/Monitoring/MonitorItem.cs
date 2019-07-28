using Newtonsoft.Json;
using QuAnalyzer.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Features.Monitoring
{
    public class MonitorItem : NotifierHelper
    {
        public event Action<ResultsClass> OnResult;
        public event Action<ResultsClass> OnAdd;

        public bool RunWhenStarted { get; set; }

        public List<MonitorItem> PrecedingSteps { get; set; }

        public List<string> AttributesList => Attributes.Split(',').ToList();

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(); }
        }

        public string ProviderName { get; set; }

        [JsonIgnore]
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
            set { _interval = value; NotifyPropertyChanged(); }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged(); }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; NotifyPropertyChanged(); }
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

            await Task.Run(() => Monitoring.Monitor(this, cnt++));

            _isChecking = false;
        }

        public void raiseAdd(ResultsClass r)
        {
            OnAdd?.Invoke(r);
        }

        public void raiseResult(ResultsClass r)
        {
            OnResult?.Invoke(r);
        }

        public ObservableCollection<MultiValueDatePoint> Points { get; } = new ObservableCollection<MultiValueDatePoint>();

        public void AttachEvent(Action<ResultsClass> monitor_OnAdd, Action<ResultsClass> monitor_OnResult)
        {
            OnAdd -= monitor_OnAdd;
            OnAdd += monitor_OnAdd;
            OnResult -= monitor_OnResult;
            OnResult += monitor_OnResult;
        }

        public string Attributes { get; set; } = "";
    }
}
