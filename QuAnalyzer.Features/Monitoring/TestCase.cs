using CommunityToolkit.Mvvm.ComponentModel;

using System.Collections.ObjectModel;

namespace QuAnalyzer.Features.Monitoring;

public partial class TestCase : ObservableObject
{
    [ObservableProperty]
    private TestCaseStatus status;

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
#pragma warning disable CS8604 // Existence possible d'un argument de référence null pour le paramètre 'item' dans 'void List<object>.Add(object item)'.
        PrecedingStepsData.Add(obj.Data);
#pragma warning restore CS8604 // Existence possible d'un argument de référence null pour le paramètre 'item' dans 'void List<object>.Add(object item)'.

        if (PrecedingStepsInstances.Count == 0)
        {
            AllPrecedingStepsDone = true;
        }
    }

    public void Stop()
    {
        Status = TestCaseStatus.NOT_STARTED;
    }

    public void raiseAdd(TestResults r)
    {
        OnAdd?.Invoke(this, r);
    }

    public void raiseResult(TestResults r)
    {
        OnResult?.Invoke(this, r);
    }

    internal TestCase(TestDefinition TestDefinition)
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
