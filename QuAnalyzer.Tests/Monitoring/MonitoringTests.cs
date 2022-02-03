
using Wokhan.Data.Providers;

using Xunit;

namespace QuAnalyzer.Features.Monitoring.Tests;

public class MonitoringTests
{
    [Fact()]
    public void RunTest()
    {
        var item = new TestDefinition() { Type = "COUNTALL", RunWhenStarted = true, Provider = new RandomDataProvider(), Repository = "Address book" };
        var instance = item.CreateInstance();

        Monitoring.Run(new TestCasesCollection() { TestCases = { instance } }, 1, 1, 1);

        Assert.Equal(TestCaseStatus.DONE, instance.Status);
    }
}
