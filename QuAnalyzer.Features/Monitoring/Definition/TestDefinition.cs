using CommunityToolkit.Mvvm.ComponentModel;

using QuAnalyzer.Features.Monitoring.Definition;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Features.Monitoring;

public partial class TestDefinition : ObservableObject
{
    public bool RunWhenStarted { get; set; }

    public ObservableDictionary<TestDefinition, bool> PrecedingSteps { get; private set; } = new();

    public List<string> AttributesList => Attributes.Split(',').ToList();

    [ObservableProperty]
    private string name;

    public ValueSelectors.Selector? Selector { get; set; }

    [ObservableProperty]
    private IDataProvider? provider;

    [ObservableProperty]
    private string? _repository;

    // TODO: Why?
    //public Func<IList<Dictionary<string, string>>, Dictionary<string, long>, IQueryable> GetData => (values, statsBag) => Provider.GetQueryable(Repository, values, statsBag);
    public IQueryable GetData(IList<Dictionary<string, string>>? values, Dictionary<string, long> statsBag)
    {
        return Provider.GetQueryable(Repository, values, statsBag);
    }

    public string? Filter { get; set; }

    [ObservableProperty]
    private int interval;

    [ObservableProperty]
    private string type = MonitoringModes.PING;


    //public void AttachEvent(Action<TestResults> monitor_OnAdd, Action<TestResults> monitor_OnResult)
    //{
    //    OnAdd -= monitor_OnAdd;
    //    OnAdd += monitor_OnAdd;
    //    OnResult -= monitor_OnResult;
    //    OnResult += monitor_OnResult;
    //}

    public string Attributes { get; set; } = "";

    [ObservableProperty]
    public TestCaseStatus status;

    public TestCase CreateInstance()
    {
        return new TestCase(this);
    }

    public TestDefinition Clone()
    {
        return new()
        {
            Attributes = this.Attributes,
            Filter = this.Filter,
            PrecedingSteps = new(this.PrecedingSteps),
            Interval = this.Interval,
            Name = this.Name,
            Provider = this.Provider,
            Repository = this.Repository,
            RunWhenStarted = this.RunWhenStarted,
            Selector = this.Selector,
            Type = this.Type
        };
    }

}
