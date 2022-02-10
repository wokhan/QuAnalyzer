using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

using Xunit;

namespace QuAnalyzer.Features.Statistics.Tests;

public class OccurencesResultTests
{
    [Fact()]
    [Benchmark]
    public void CountOccurencesTest()
    {
        var source = new[] { new { Test = "a" }, new { Test = "a" } };
        var result = OccurencesResult.CountOccurences(source.AsQueryable(), new Wokhan.Data.Providers.Bases.ColumnDescription() { Type = typeof(string), Name = "Test" });

        var expected = new[] { new OccurencesResult("a", 0, 2) };

        Assert.Equal(expected, result);
    }

    [Fact()]
    [Benchmark]
    public void CountOccurencesDynamicTest()
    {
        var source = new[] { new { Test = "a" }, new { Test = "a" } };
        var result = OccurencesResult.CountOccurences(source.AsQueryable(), "Test");

        var expected = new[] { new OccurencesResult("a", 0, 2) };

        Assert.Equal(expected, result);
    }

    [Fact()]
    public void RunBenchmark()
    {
        //var report = BenchmarkRunner.Run<OccurencesResultTests>(DefaultConfig.Instance.WithOptions(ConfigOptions.DisableOptimizationsValidator));
        //output.WriteLine(report.Table.ToString());
    }
}
