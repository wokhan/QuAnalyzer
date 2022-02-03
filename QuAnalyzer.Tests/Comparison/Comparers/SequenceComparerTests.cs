using Xunit;

namespace QuAnalyzer.Features.Comparison.Comparers.Tests;

public class SequenceComparerTests
{
    [Theory()]
    [InlineData(new[] { "alpha", "beta", "tango" }, new[] { "alpha", "tango", "tango" }, -2)]
    [InlineData(new[] { "alpha", "beta", "tango" }, new[] { "alpha", "alpha", "tango" }, 2)]
    [InlineData(new[] { "alpha", "beta", "tango" }, new[] { "alpha", "beta", "tbngo" }, 3)]
    [InlineData(new[] { "alpha", "beta", "tango" }, new[] { "alpha", "alpha", "Aango" }, -3)]
    public void CompareTest(object[] data1, object[] data2, int result)
    {
        var comparer = new SequenceComparer<object>();
        Assert.Equal(result, comparer.Compare(data1, data2));
    }
}
