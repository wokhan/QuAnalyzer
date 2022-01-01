using Xunit;
using System.Collections.Generic;
using QuAnalyzer.Features.Comparison.Comparers;

namespace QuAnalyzer.Features.Comparison.Comparers.Tests;

public class SequenceComparerTests
{

    [Theory()]
    [InlineData(new[] { "a", "b", "c" }, new[] { "a", "b", "c" })]
    public void CompareTest(IEnumerable<object> x, IEnumerable<object> y)
    {
        var comparer = new SequenceComparer();
        Assert.Equal(0, comparer.Compare(x, y));
    }
}
