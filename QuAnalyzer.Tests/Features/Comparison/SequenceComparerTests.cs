using Xunit;
using System.Collections.Generic;

namespace QuAnalyzer.Features.Comparison.Tests;

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
