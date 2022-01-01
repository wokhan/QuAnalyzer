using QuAnalyzer.Features.Monitoring;

using Wokhan.Data.Providers;

using Xunit;

namespace QuAnalyzer.Features.Performance.Tests;

public class PerformanceTests
{
    [Fact()]
    public void RunTest()
    {
        var item = new TestDefinition() { Type = "COUNTALL", RunWhenStarted = true, Provider = new RandomDataProvider(), Repository = "Address book" };
        var instance = new TestCase(item);

        Monitoring.Run(new TestCasesCollection() { TestCases = { instance } }, 1, 1, 1);

        Assert.Equal(MonitoringStatus.DONE, instance.Status);
    }
}
