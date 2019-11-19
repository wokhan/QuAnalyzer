using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Wokhan.Core.ComponentModel;

namespace QuAnalyzer.Features.Monitoring
{
    public class MonitoringItemInstance : NotifierHelper
    {
        public event Action<MonitoringItemInstance, ResultsClass> OnResult;
        public event Action<MonitoringItemInstance, ResultsClass> OnAdd;

        public MonitorItem monitorItem { get; private set; }

        public int InstanceId { get; set; }
        public string Name => monitorItem.Name;

        public ObservableCollection<ResultsClass> Results { get; } = new ObservableCollection<ResultsClass>();

        private MonitoringStatus _status;
        public MonitoringStatus Status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged(); }
        }

        public List<MonitoringItemInstance> PrecedingStepsInstances { get; set; }
        public bool AllPrecedingStepsDone { get; internal set; }

        private void preceding_Done(MonitoringItemInstance source, ResultsClass obj)
        {
            PrecedingStepsInstances.Remove(source);
            PrecedingStepsData.Add(obj.Data);

            if (PrecedingStepsInstances.Count == 0)
            {
                AllPrecedingStepsDone = true;
            }
        }

        public void Stop()
        {
            Status = MonitoringStatus.NOT_STARTED;
        }

        private int cnt = 0;

        public void raiseAdd(ResultsClass r)
        {
            OnAdd?.Invoke(this, r);
        }

        public void raiseResult(ResultsClass r)
        {
            OnResult?.Invoke(this, r);
        }


        private List<object> PrecedingStepsData = new List<object>();

        public MonitoringItemInstance(MonitorItem monitorItem)
        {
            this.monitorItem = monitorItem;

        }

        internal void AttachPrecedingStepInstances(IEnumerable<MonitoringItemInstance> steps)
        {
            this.PrecedingStepsInstances = steps.ToList();
            foreach (var m in PrecedingStepsInstances)
            {
                m.OnResult += preceding_Done;
            }
        }
    }
}
