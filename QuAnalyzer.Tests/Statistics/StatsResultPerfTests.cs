using BenchmarkDotNet.Attributes;

namespace QuAnalyzer.Features.Statistics.Tests;

public class StatsResultPerfTests
{
    [Benchmark]
    public void Test1()
    {
        var data = new[] {
            new { Key = "#1", Attr1 = (string?)"MyAttributeA", AttrNum1 = (int?)1 },
            new { Key = "#2", Attr1 = (string?)"MyAttributeC", AttrNum1 = (int?)2 },
            new { Key = "#3", Attr1 = (string?)"MyAttributeB", AttrNum1 = (int?)7 },
            new { Key = "#4", Attr1 = (string?)"", AttrNum1 = (int?)0 },
            new { Key = "#4", Attr1 = (string?)null, AttrNum1 = (int?)null },
            new { Key = "#5", Attr1 = (string?)"MyAttributeC", AttrNum1 = (int?)2 }
        };

        var statsForString = StatsResult.GetStats(data.AsQueryable(), "Attr1", typeof(string));
    }

    [Benchmark]
    public void Test2()
    {
        var data = new[] {
            new { Key = "#1", Attr1 = (string?)"MyAttributeA", AttrNum1 = (int?)1 },
            new { Key = "#2", Attr1 = (string?)"MyAttributeC", AttrNum1 = (int?)2 },
            new { Key = "#3", Attr1 = (string?)"MyAttributeB", AttrNum1 = (int?)7 },
            new { Key = "#4", Attr1 = (string?)"", AttrNum1 = (int?)0 },
            new { Key = "#4", Attr1 = (string?)null, AttrNum1 = (int?)null },
            new { Key = "#5", Attr1 = (string?)"MyAttributeC", AttrNum1 = (int?)2 }
        };

        var statsForString = StatsResult.GetStats(data.AsQueryable(), "Attr1");
    }

}