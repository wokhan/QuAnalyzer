using BenchmarkDotNet.Attributes;

using QuAnalyzer.Tests.Features.Comparison;

namespace QuAnalyzer.Features.Comparison.Tests;

public class ComparisonPerfTests
{
    private TestDataRowGenerator data = new TestDataRowGenerator(100000, 7000);

    [Benchmark]
    public void UsingLegacyComparer()
    {
        var comparer = SharedHelper.GetComparer(data.SourceData, data.TargetData);

        var nbSamplesShown = -1;
        var nbSamplesCompared = -1;

        Comparison.Run(new[] { comparer }, nbSamplesCompared, nbSamplesShown);
    }

    [Benchmark]
    public void UsingNewComparer()
    {
        var comparer = SharedHelper.GetComparer(data.SourceData, data.TargetData, true);

        var nbSamplesShown = -1;
        var nbSamplesCompared = -1;

        Comparison.Run(new[] { comparer }, nbSamplesCompared, nbSamplesShown);
    }


}
