using BenchmarkDotNet.Attributes;

using System.Collections.Generic;
using System.Linq;

namespace QuAnalyzer.Features.Comparison.Tests;

public class ComparisonPerfTests : ComparisonTests
{
    [Benchmark]
    public async void RunPerfTest()
    {
        var firstData = Data1.First();
        var comparer = GetComparer((IEnumerable<object[]>)firstData[0], (IEnumerable<object[]>)firstData[1]);

        var nbSamplesShown = -1;
        var nbSamplesCompared = -1;

        await Comparison.RunAsync(new[] { comparer }, nbSamplesCompared, nbSamplesShown);
    }

}
