using Microsoft.Toolkit.Mvvm.ComponentModel;

using Newtonsoft.Json;

using System.Collections.ObjectModel;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Features.Monitoring;

public partial class MonitorItem : ObservableObject
{
    public static ObservableCollection<IDataProvider>? Providers { get; set; }

    public bool RunWhenStarted { get; set; }

    public ObservableDictionary<MonitorItem, bool> PrecedingSteps { get; private set; } = new();

    public List<string> AttributesList => Attributes.Split(',').ToList();

    [ObservableProperty]
    private string name;

    public ValueSelectors.Selector Selector { get; set; }

    public string ProviderName { get; set; }


    private IDataProvider provider;

    [JsonIgnore]
    public IDataProvider Provider
    {
        get => provider ??= Providers.First(c => c.Name == ProviderName);
        set
        {
            provider = value;
            ProviderName = value is not null ? value.Name : string.Empty;
        }
    }

    public string Repository { get; set; }

    // TODO: Why?
    //public Func<IList<Dictionary<string, string>>, Dictionary<string, long>, IQueryable> GetData => (values, statsBag) => Provider.GetQueryable(Repository, values, statsBag);
    public IQueryable GetData(IList<Dictionary<string, string>> values, Dictionary<string, long> statsBag)
    {
        return Provider.GetQueryable(Repository, values, statsBag);
    }

    public string Filter { get; set; }

    [ObservableProperty]
    private int interval;

    [ObservableProperty]
    private string type;


    //public void AttachEvent(Action<ResultsClass> monitor_OnAdd, Action<ResultsClass> monitor_OnResult)
    //{
    //    OnAdd -= monitor_OnAdd;
    //    OnAdd += monitor_OnAdd;
    //    OnResult -= monitor_OnResult;
    //    OnResult += monitor_OnResult;
    //}

    public string Attributes { get; set; } = "";

    [ObservableProperty]
    public MonitoringStatus status;

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
