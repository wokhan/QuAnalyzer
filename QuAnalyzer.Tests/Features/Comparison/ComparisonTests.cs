using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

using QuAnalyzer.Tests.Features.Comparison;

using Xunit;
using Xunit.Abstractions;

namespace QuAnalyzer.Features.Comparison.Tests;

public class ComparisonTests
{
    private readonly ITestOutputHelper output;

    public ComparisonTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Theory()]
    [ClassData(typeof(TestDataForCompare))]
    public void RunTest(IEnumerable<object[]> sourceData, IEnumerable<object[]> targetData, int expMatches, int expSrcDiffs, int expTrgDiffs, int expSrcDups, int expTrgDups, int expSrcMissing, int expTrgMissing)
    {
        var comparer = SharedHelper.GetComparer(sourceData, targetData);

        var nbSamplesShown = -1;
        var nbSamplesCompared = -1;

        Comparison.Run(new[] { comparer }, nbSamplesCompared, nbSamplesShown);

        Assert.Equal(expMatches, comparer.Results.MatchingCount);
        Assert.Equal(expSrcDiffs, comparer.Results.Source.Differences.Count);
        Assert.Equal(expSrcDiffs, comparer.Results.Target.Differences.Count);
        Assert.Equal(expSrcDups, comparer.Results.Source.PerfectDups.Count);
        Assert.Equal(expTrgDups, comparer.Results.Target.PerfectDups.Count);
        //Assert.Equal(expSrcDups, comparer.Results.Source.Duplicates.Count);
        //Assert.Equal(expTrgDups, comparer.Results.Target.Duplicates.Count);
        Assert.Equal(expSrcMissing, comparer.Results.Source.Missing.Count);
        Assert.Equal(expTrgMissing, comparer.Results.Target.Missing.Count);
    }

    [Theory()]
    [InlineData(new[] { "a", "b", "c", "d", "e" }, 4, null)]
    [InlineData(new[] { "a", "b", "c", "d" }, 4, new[] { "a", "b", "c", "d" })]
    public void GetSamplesTest(object[] sourceData, int expectedLength, object[]? expectedSamples = null)
    {
        var samples = Comparison.GetSamples(expectedLength, sourceData);
        Assert.Equal(expectedLength, samples.First().Length);

        if (expectedSamples is not null)
        {
            Assert.Equal(expectedSamples, samples.First());
        }
    }

    [Fact()]
    [Benchmark]
    public void CompareOrderedTest()
    {
        Assert.True(false, "This test needs an implementation");
    }

    [Fact()]
    public void CompareTest()
    {
        Assert.True(false, "This test needs an implementation");
    }

    [Fact()]
    public void InitiateDuplicatesTest()
    {
        Assert.True(false, "This test needs an implementation");
    }

    [Fact()]
    public void RunBenchmark()
    {
        var report = BenchmarkRunner.Run(typeof(ComparisonPerfTests), DefaultConfig.Instance.WithOptions(ConfigOptions.DisableOptimizationsValidator));
        output.WriteLine(report.Table.ToString());
    }
}
