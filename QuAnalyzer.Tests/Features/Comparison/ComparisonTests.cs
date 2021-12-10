using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace QuAnalyzer.Features.Comparison.Tests;

public class ComparisonTests
{
    public static IEnumerable<object[]> Data1;
    //private static IEnumerable<object[]> DifferentData1;

    static ComparisonTests()
    {
        Data1 = new[] {
            new object[]
            {
             /* source data */ 
                new [] {
                    new object[] { "a1", "b1", "c1" },
                    new object[] { "a2", "b2", "c2" },
                    new object[] { "a3", "b3", "c3", "d3" },
                    new object[] { "a3", "b3", "c3", "d3" },
                    new object[] { "a3", "b3", "c3", "d3" }
                },
             /* target data */ 
                new [] {
                    new object[] { "a1", "b1", "c1" },
                    new object[] { "a2", "b2", "c2", "d2" },
                    new object[] { "a3", "XX", "c3", "d3" },
                    new object[] { "a3", "XX", "c3", "d3" }
                },
             /* expected matches */ 1,
             /* expected source differences */ 2,
             /* expected target differences */ 3,
             /* expected source duplicates */ 3,
             /* expected target duplicates */ 2
            }
        };
    }

    [Theory()]
    [MemberData(nameof(Data1))]
    public async void RunTest(IEnumerable<object[]> sourceData, IEnumerable<object[]> targetData, int expMatches, int expSrcDiffs, int expTrgDiffs, int expSrcDups, int expTrgDups)
    {
        var comparer = GetComparer(sourceData, targetData);

        var nbSamplesShown = -1;
        var nbSamplesCompared = -1;

        await Comparison.Run(new[] { comparer }, nbSamplesCompared, nbSamplesShown);

        Assert.Equal(expMatches, comparer.Results.MatchingCount);
        Assert.Equal(expSrcDiffs, comparer.Results.Source.Differences.Count);
        Assert.Equal(expSrcDiffs, comparer.Results.Target.Differences.Count);
        Assert.Equal(expSrcDups, comparer.Results.Source.PerfectDups.Count);
        Assert.Equal(expTrgDups, comparer.Results.Target.PerfectDups.Count);
        //Assert.Equal(expSrcDups, comparer.Results.Source.Duplicates.Count);
        //Assert.Equal(expTrgDups, comparer.Results.Target.Duplicates.Count);
    }

    
    protected static ComparerStruct<object[]> GetComparer(IEnumerable<object[]> sourceData, IEnumerable<object[]> targetData)
    {
        return new ComparerStruct<object[]>()
        {
            GetSourceData = () => sourceData,
            GetTargetData = () => targetData,
            Comparer = new SequenceEqualityComparer<object>()
        };
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
        var report = BenchmarkRunner.Run(typeof(ComparisonPerfTests));
        Console.Write(report.ToString());
    }
}
