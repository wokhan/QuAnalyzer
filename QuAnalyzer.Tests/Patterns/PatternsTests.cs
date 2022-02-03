using Xunit;

namespace QuAnalyzer.Features.Patterns.Tests;

public class PatternsTests
{
    [Theory()]
    [InlineData("Test_With_1_2_3", 1, "\\w{4}\\_{1}\\w{4}\\_{1}\\d{1}\\_{1}\\d{1}\\_{1}\\d{1}")]
    [InlineData("Test_With_1_2_3", 2, "\\w*\\_*\\w*\\_*\\d*\\_*\\d*\\_*\\d*")]
    [InlineData("Test_With_1_2_3", 3, "\\w*\\x*\\w*\\x*\\d*\\x*\\d*\\x*\\d*")]
    public void GetRegExTest(string src, int threshold, string expectedResult)
    {
        var result = Patterns.GetRegEx(src, threshold);
        Assert.Equal(expectedResult, result);
    }
}
