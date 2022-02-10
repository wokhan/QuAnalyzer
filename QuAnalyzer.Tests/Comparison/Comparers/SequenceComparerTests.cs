using Xunit;

namespace QuAnalyzer.Features.Comparison.Comparers.Tests;

/// <summary>
/// TODO: Add complex object comparison
/// </summary>
public class SequenceComparerTests
{
    [Theory()]
    [InlineData(new[] { "alpha", "beta", "tango" }, new[] { "alpha", "tango", "tango" }, -2)]
    [InlineData(new[] { "alpha", "beta", "tango" }, new[] { "alphx", "alpha", "tango" }, -1)]
    [InlineData(new[] { "alpha", "beta", "tango" }, new[] { "alpha", "beta", "tbngo" }, -3)]
    [InlineData(new[] { "alpha", "beta", "tango" }, new[] { "alpha", "alpha", "Aango" }, 2)]
    public void CompareTest(object[] data1, object[] data2, int result)
    {
        Assert.Equal(result, SequenceComparer<object>.Default.Compare(data1, data2));
    }
}
