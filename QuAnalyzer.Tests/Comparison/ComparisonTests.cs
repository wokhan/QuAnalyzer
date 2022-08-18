
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

    //TODO: adds nothing compared to CompareOrderedTest. To be reviewed.
    [Theory()]
    [ClassData(typeof(ComparisonTestsData))]
    public void RunTest(IEnumerable<object[]> sourceData, IEnumerable<object[]> targetData, int expMatches, int expDiffs, int expSrcDups, int expTrgDups, int expSrcMissing, int expTrgMissing)
    {
        var comparer = SharedHelper.GetComparer(sourceData, targetData);

        Comparison.Run(new[] { comparer });

        Assert.Equal(ProgressType.Done, comparer.Results.Progress);
        Assert.Equal(Math.Max(sourceData.Count(), targetData.Count()), comparer.Results.ScannedCount);
        Assert.Equal(expMatches, comparer.Results.MatchingCount);
        Assert.Equal(expDiffs, comparer.Results.Differences.Count);
        Assert.Equal(expSrcDups, comparer.Results.Source.PerfectDups.Count);
        Assert.Equal(expTrgDups, comparer.Results.Target.PerfectDups.Count);
        Assert.Equal(expSrcDups, comparer.Results.Source.Duplicates.Count);
        Assert.Equal(expTrgDups, comparer.Results.Target.Duplicates.Count);
        Assert.Equal(expSrcMissing, comparer.Results.Source.Missing.Count);
        Assert.Equal(expTrgMissing, comparer.Results.Target.Missing.Count);
    }

    [Theory()]
    [InlineData(new[] { "a", "b", "c", "d", "e" }, 0.9, 4, null)]
    [InlineData(new[] { "a", "b", "c", "d" }, 1, 4, new[] { "a", "b", "c", "d" })]
    public void GetSamplesTest(object[] sourceData, double samplesPct, int expectedLength, object[]? expectedSamples = null)
    {
        var samples = Comparison.GetSamples(samplesPct, null, sourceData);
        Assert.Equal(expectedLength, samples[0].Count());

        if (expectedSamples is not null)
        {
            Assert.Equal(expectedSamples, samples[0]);
        }
    }

    [Theory()]
    [ClassData(typeof(ComparisonTestsData))]
    public void CompareOrderedTest(IEnumerable<object[]> sourceData, IEnumerable<object[]> targetData, int expMatches, int expDiffs, int expSrcDups, int expTrgDups, int expSrcMissing, int expTrgMissing)
    {
        var comparer = SharedHelper.GetComparer(sourceData, targetData);

        Comparison.CompareOrdered(comparer);

        Assert.Equal(ProgressType.Done, comparer.Results.Progress);
        Assert.Equal(Math.Max(sourceData.Count(), targetData.Count()), comparer.Results.ScannedCount);
        Assert.Equal(expMatches, comparer.Results.MatchingCount);
        Assert.Equal(expDiffs, comparer.Results.Differences.Count);
        Assert.Equal(expSrcDups, comparer.Results.Source.PerfectDups.Count);
        Assert.Equal(expTrgDups, comparer.Results.Target.PerfectDups.Count);
        Assert.Equal(expSrcDups, comparer.Results.Source.Duplicates.Count);
        Assert.Equal(expTrgDups, comparer.Results.Target.Duplicates.Count);
        Assert.Equal(expSrcMissing, comparer.Results.Source.Missing.Count);
        Assert.Equal(expTrgMissing, comparer.Results.Target.Missing.Count);
    }

    [Theory()]
    [InlineData(new[] { "alpha", "alpha", "beta", "gamma" }, new[] { "alpha" })]
    public void GetDuplicatesTest(IEnumerable<string> source, IEnumerable<string> expected)
    {
        var result = Comparison.GetDuplicates(source, null, StringComparer.InvariantCulture);

        Assert.Equal(expected, result);
    }

    //[Fact()]
    //public void RunBenchmark()
    //{
    //    var report = BenchmarkRunner.Run<ComparisonPerfTests>(DefaultConfig.Instance.WithOptions(ConfigOptions.DisableOptimizationsValidator));
    //    output.WriteLine(report.Table.ToString());
    //}
}
