
using Xunit;

namespace QuAnalyzer.Features.Statistics.Tests;

public class StatsResultTests
{
    [Fact()]
    public void GetStatsTest()
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

        Assert.Equal(6, statsForString.Count);
        Assert.Equal("", statsForString.Min);
        Assert.Equal("MyAttributeC", statsForString.Max);
        Assert.Equal("N/A", statsForString.Average);
        Assert.Equal(5, statsForString.DistinctCount);
        Assert.Equal(2, statsForString.EmptyCount);

        var statsForNum = StatsResult.GetStats(data.AsQueryable(), "AttrNum1");

        Assert.Equal(6, statsForNum.Count);
        Assert.Equal(0, statsForNum.Min);
        Assert.Equal(7, statsForNum.Max);
        //Assert.Equal(2, statsForNum.Average);
        Assert.Equal(5, statsForNum.DistinctCount);
        Assert.Equal(1, statsForNum.EmptyCount);

    }
}
