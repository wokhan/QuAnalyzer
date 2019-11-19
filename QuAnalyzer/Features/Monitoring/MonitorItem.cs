using Newtonsoft.Json;
using QuAnalyzer.Features.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using Wokhan.Collections;
using Wokhan.Core.ComponentModel;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Features.Monitoring
{
    public class MonitorItem : NotifierHelper
    {
       
        public bool RunWhenStarted { get; set; }

        public ObservableDictionary<MonitorItem, bool> PrecedingSteps { get; } = new ObservableDictionary<MonitorItem, bool>();

        public List<string> AttributesList => Attributes.Split(',').ToList();

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(); }
        }

        public ValueSelectors.Selector Selector { get; set; }

        public string ProviderName { get; set; }

        private IDataProvider provider;
        [JsonIgnore]
        public IDataProvider Provider
        {
            get { return provider ??= ((App)System.Windows.Application.Current).CurrentProject.CurrentProviders.SingleOrDefault(c => c.Name == ProviderName); }
            set { ProviderName = value != null ? value.Name : string.Empty; }
        }

        public string Repository { get; set; }

        public Func<IList<Dictionary<string, string>>, Dictionary<string, long>, IQueryable> GetData => (values, statsBag) => Provider.GetQueryable(Repository, values, statsBag);

        public string Filter { get; set; }

        private int _interval;
        public int Interval
        {
            get { return _interval; }
            set { _interval = value; NotifyPropertyChanged(); }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; NotifyPropertyChanged(); }
        }

        //public void AttachEvent(Action<ResultsClass> monitor_OnAdd, Action<ResultsClass> monitor_OnResult)
        //{
        //    OnAdd -= monitor_OnAdd;
        //    OnAdd += monitor_OnAdd;
        //    OnResult -= monitor_OnResult;
        //    OnResult += monitor_OnResult;
        //}

        public string Attributes { get; set; } = "";

        internal MonitoringItemInstance GetInstance()
        {
            return new MonitoringItemInstance(this);
        }
    }
}
