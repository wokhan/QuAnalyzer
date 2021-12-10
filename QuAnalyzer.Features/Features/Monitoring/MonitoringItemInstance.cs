using Microsoft.Toolkit.Mvvm.ComponentModel;

using System.Collections.ObjectModel;

namespace QuAnalyzer.Features.Monitoring;

public partial class MonitoringItemInstance : ObservableObject
{
    [ObservableProperty]
    private MonitoringStatus status;

    public event Action<MonitoringItemInstance, ResultsClass>? OnResult;
    public event Action<MonitoringItemInstance, ResultsClass>? OnAdd;

    public MonitorItem monitorItem { get; private set; }

    public int InstanceId { get; set; }
    public string Name => monitorItem.Name;

    public ObservableCollection<ResultsClass> Results { get; } = new ObservableCollection<ResultsClass>();

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

    private readonly int cnt = 0;

    public void raiseAdd(ResultsClass r)
    {
        OnAdd?.Invoke(this, r);
    }

    public void raiseResult(ResultsClass r)
    {
        OnResult?.Invoke(this, r);
    }


    private readonly List<object> PrecedingStepsData = new List<object>();

    public MonitoringItemInstance(MonitorItem monitorItem)
    {
        this.monitorItem = monitorItem;

    }

    public void AttachPrecedingStepInstances(IEnumerable<MonitoringItemInstance> steps)
    {
        this.PrecedingStepsInstances = steps.ToList();
        foreach (var m in PrecedingStepsInstances)
        {
            m.OnResult += preceding_Done;
        }
    }
}
