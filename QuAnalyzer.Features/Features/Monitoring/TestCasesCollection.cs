using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace QuAnalyzer.Features.Monitoring;

public class TestCasesCollection
{
    public string Name { get; set; }
    public List<Dictionary<string, string>> ValuesSet { get; set; }
    public string ValuesSetExpr { set => Init(value); }

    public async void Init(string expr)
    {
        ValuesSet = (List<Dictionary<string, string>>)await CSharpScript.EvaluateAsync(expr).ConfigureAwait(false);
    }

    public ValueSelectors.Selector Selector { get; set; }
    public IList<MonitoringItemInstance> TestCases { get; set; }
    public bool DistinctParallelValues { get; set; }

    public TestCasesCollection this[string n]
    {
        get
        {
            var tests = TestCases.Where(t => t.Name == n).ToList();
            if (!tests.Any())
            {
                throw new IndexOutOfRangeException($"Configuration '{n}' does not exist for this TestCasesCollection instance.");
            }
            return new TestCasesCollection()
            {
                Name = Name,
                ValuesSet = ValuesSet,
                Selector = Selector,
                TestCases = tests
            };
        }
    }

    /*public ITestCase this[int i]
    {
        get => TestCases[i];
    }*/
}
