using System.Collections;

namespace QuAnalyzer.Features.Comparison.Tests;

internal class ComparisonTestsData : IEnumerable<object[]>
{
    private readonly IList<object[]> allData = new List<object[]>();

    public ComparisonTestsData() : this(2, 1, 20) { }

    public ComparisonTestsData(int count, int nbDiffs, int nbIterations = 1)
    {
        var random = new Random();
        for (var i = 0; i < nbIterations; i++)
        {
            var data = new TestDataGenerator(count, nbDiffs);

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