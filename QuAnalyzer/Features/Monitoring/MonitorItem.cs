using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;

using Wokhan.Core.ComponentModel;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Features.Monitoring
{
    public class MonitorItem : NotifierHelper
    {
        public bool RunWhenStarted { get; set; }

        public ObservableDictionary<MonitorItem, bool> PrecedingSteps { get; private set; } = new();

        public List<string> AttributesList => Attributes.Split(',').ToList();

        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; NotifyPropertyChanged(); }
        }

        public ValueSelectors.Selector Selector { get; set; }

        public string ProviderName { get; set; }


        private IDataProvider provider;

        [JsonIgnore]
        public IDataProvider Provider
        {
            get => provider ??= ((App)System.Windows.Application.Current).CurrentProject.CurrentProviders.SingleOrDefault(c => c.Name == ProviderName);
            set => ProviderName = value is not null ? value.Name : string.Empty;
        }

        public string Repository { get; set; }

        // TODO: Why?
        //public Func<IList<Dictionary<string, string>>, Dictionary<string, long>, IQueryable> GetData => (values, statsBag) => Provider.GetQueryable(Repository, values, statsBag);
        public IQueryable GetData(IList<Dictionary<string, string>> values, Dictionary<string, long> statsBag)
        {
            return Provider.GetQueryable(Repository, values, statsBag);
        }

        public string Filter { get; set; }

        private int _interval;
        public int Interval
        {
            get => _interval;
            set { _interval = value; NotifyPropertyChanged(); }
        }

        private string _type;

        public string Type
        {
            get => _type;
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

        public MonitoringItemInstance CreateInstance()
        {
            return new MonitoringItemInstance(this);
        }

        public MonitorItem Clone()
        {
            return new()
            {
                Attributes = this.Attributes,
                Filter = this.Filter,
                PrecedingSteps = new(this.PrecedingSteps),
                Interval = this.Interval,
                Name = this.Name,
                ProviderName = this.ProviderName,
                Repository = this.Repository,
                RunWhenStarted = this.RunWhenStarted,
                Selector = this.Selector,
                Type = this.Type
            };
        }

    }
}
