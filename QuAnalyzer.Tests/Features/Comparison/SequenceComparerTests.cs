using Xunit;
using System.Collections.Generic;
using QuAnalyzer.Features.Comparison.Tests;

namespace QuAnalyzer.Features.Comparison.Comparers.Tests;

public class SequenceComparerTests
{

    [Theory()]
    [ClassData(typeof(TestDataRowGenerator))]
    public void CompareEqualTest(IEnumerable<object> x, IEnumerable<object> y)
    {
        var comparer = new SequenceComparer<IEnumerable<object>, object>();
        Assert.Equal(0, comparer.Compare(x, y));
    }
}
