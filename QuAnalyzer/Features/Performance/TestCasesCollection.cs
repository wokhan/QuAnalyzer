using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuAnalyzer.Features.Performance
{
    public class TestCasesCollection
    {
        public string Name { get; set; }
        public List<Dictionary<string, string>> ValuesSet { get; set; }
        public string ValuesSetExpr { set => Init(value); }

        public async void Init(string expr)
        {
            this.ValuesSet = (List<Dictionary<string, string>>)await CSharpScript.EvaluateAsync(expr);
        }

        public ValueSelectors.Selector Selector { get; set; }
        public IList<TestCase> TestCases { get; set; }
        public bool DistinctParallelValues { get; set; }

        public TestCasesCollection this[string n]
        {
            get
            {
                var tests = this.TestCases.Where(t => t.Name == n).ToList();
                if (!tests.Any())
                {
                    throw new IndexOutOfRangeException($"Configuration '{n}' does not exist for this TestCasesCollection instance.");
                }
                return new TestCasesCollection()
                {
                    Name = this.Name,
                    ValuesSet = this.ValuesSet,
                    Selector = this.Selector,
                    TestCases = tests
                };
            }
        }

        /*public ITestCase this[int i]
        {
            get => TestCases[i];
        }*/
    }
}
