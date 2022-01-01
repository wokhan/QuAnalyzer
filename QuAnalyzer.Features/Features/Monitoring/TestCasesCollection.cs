using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace QuAnalyzer.Features.Monitoring;

public class TestCasesCollection
{
    public string Name { get; set; }
    public IList<TestCase> TestCases { get; set; } = new List<TestCase>();
    public List<Dictionary<string, string>>? ValuesSet { get; set; }
    public string ValuesSetExpr { set => Init(value); }
    public ValueSelectors.Selector Selector { get; set; } = ValueSelectors.SequentialSelector;
    public bool DistinctParallelValues { get; set; }

    public async void Init(string expr)
    {
        ValuesSet = (List<Dictionary<string, string>>)await CSharpScript.EvaluateAsync(expr).ConfigureAwait(false);
    }

    public TestCasesCollection this[string name]
    {
        get
        {
            var tests = TestCases.Where(testcase => testcase.Name == name).ToList();
            if (!tests.Any())
            {
                throw new IndexOutOfRangeException($"Configuration '{name}' does not exist for this TestCasesCollection instance.");
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
