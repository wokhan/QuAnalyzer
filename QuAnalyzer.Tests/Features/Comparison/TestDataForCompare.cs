using System.Collections;

namespace QuAnalyzer.Features.Comparison.Tests;

internal class TestDataForCompare : IEnumerable<object[]>
{
    private readonly int COUNT = 2;
    private readonly int NB_DIFFERENCES = 1;
    private readonly int NB_ITERATION = 20;

    private readonly IList<object[]> allData = new List<object[]>();

    public TestDataForCompare()
    {
        var random = new Random();
        for (var i = 0; i < NB_ITERATION; i++)
        {
            var data = new TestDataRowGenerator(COUNT, NB_DIFFERENCES);

            allData.Add(new object[] {
                data.SourceData,
                data.TargetData,
                data.Matches,
                data.SourceDiffs,
                data.TargetDiffs,
                data.SourceDups,
                data.TargetDups,
                data.SourceMissing,
                data.TargetMissing});
        }
    }

    public IEnumerator<object[]> GetEnumerator() => allData.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => allData.GetEnumerator();
}