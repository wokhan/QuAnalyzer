using QuAnalyzer.Features.Monitoring;

using Wokhan.Data.Providers;

using Xunit;

namespace QuAnalyzer.Features.Performance.Tests;

public class PerformanceTests
{
    [Fact()]
    public async void RunTest()
    {
        var item = new TestDefinition() { Type = "COUNTALL", RunWhenStarted = true, Provider = new RandomDataProvider(), Repository = "Address book" };
        var instance = item.CreateInstance();

        await Monitoring.Monitoring.RunAsync(new TestCasesCollection() { TestCases = { instance } }, 1, 1, 1);
        
        Assert.Equal(TestCaseStatus.DONE, instance.Status);
    }
}
