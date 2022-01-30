using BenchmarkDotNet.Attributes;

using QuAnalyzer.Tests.Features.Comparison;

namespace QuAnalyzer.Features.Comparison.Tests;

public class ComparisonPerfTests
{
    private readonly TestDataGenerator data;
    private readonly ComparerDefinition<object[]> comparer;

    public ComparisonPerfTests()
    {
        data = new TestDataGenerator(100000, 5000);

        comparer = SharedHelper.GetComparer(data.SourceData, data.TargetData);
    }

    [Benchmark]
    public void CompareOrderedPerfTest()
    {
        Comparison.CompareOrdered(comparer);
    }

}
