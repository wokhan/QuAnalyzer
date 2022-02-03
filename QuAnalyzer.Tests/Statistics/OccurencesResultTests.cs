using Xunit;

namespace QuAnalyzer.Features.Statistics.Tests;

public class OccurencesResultTests
{
    [Fact()]
    public void CountOccurencesTest()
    {
        var source = new[] { new { Test = "a" }, new { Test = "a" } };
        var result = OccurencesResult.CountOccurences(source.AsQueryable(), new Wokhan.Data.Providers.Bases.ColumnDescription() { Type = typeof(string), Name = "Test" });

        var expected = new[] { new OccurencesResult("a", 0, 2) };

        Assert.Equal(expected, result);
    }
}
