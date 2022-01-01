using Microsoft.Toolkit.Mvvm.ComponentModel;

using System.Collections.ObjectModel;

namespace QuAnalyzer.Features.Monitoring;

public partial class TestCase : ObservableObject
{
    [ObservableProperty]
    private MonitoringStatus status;

    public event Action<TestCase, TestResults>? OnResult;
    public event Action<TestCase, TestResults>? OnAdd;

    public TestDefinition Definition { get; private set; }

    public int InstanceId { get; set; }
    public string Name => Definition.Name;

    public ObservableCollection<TestResults> Results { get; } = new();

    public List<TestCase> PrecedingStepsInstances { get; private set; } = new();
    private readonly List<object> PrecedingStepsData = new();

    public bool AllPrecedingStepsDone { get; internal set; } = true;

    private void preceding_Done(TestCase source, TestResults obj)
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

    public void raiseAdd(TestResults r)
    {
        OnAdd?.Invoke(this, r);
    }

    public void raiseResult(TestResults r)
    {
        OnResult?.Invoke(this, r);
    }



    public TestCase(TestDefinition TestDefinition)
    {
        this.Definition = TestDefinition;

    }

    public void AttachPrecedingStepInstances(IEnumerable<TestCase> steps)
    {
        this.PrecedingStepsInstances = steps.ToList();
        this.AllPrecedingStepsDone = this.PrecedingStepsInstances.Count == 0;
        foreach (var m in PrecedingStepsInstances)
        {
            m.OnResult += preceding_Done;
        }
    }
}
