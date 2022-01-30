using QuAnalyzer.Tests.DummyData;

using System.Collections;

using Wokhan.Collections.Generic.Extensions;

namespace QuAnalyzer.Features.Comparison.Tests;

internal class TestDataGenerator : IEnumerable<object[]>
{
    public IList<object[]> SourceData { get; init; }
    public IList<object[]> TargetData { get; init; }
    public int Matches { get; internal set; }
    public int SourceDiffs { get; internal set; }
    public int TargetDiffs { get; internal set; }
    public int SourceDups { get; internal set; }
    public int TargetDups { get; internal set; }
    public int SourceMissing { get; internal set; }
    public int TargetMissing { get; internal set; }

    public TestDataGenerator() : this(1, 1) { }

    public TestDataGenerator(int count, int nbDifferences)
    {
        IEnumerable<object[]> data = new List<object[]>();
        int cpt = 0;
        while (count - data.Count() > 0)
        {
            data = data.Concat(DummyPersons.Data.Take(count).Select(person => new[] { person[0] + "_" + cpt, person[1], person[2], person[3], person[4] }).ToList());
        }

        SourceData = data.OrderByMany(5).ToList();
        Matches = SourceData.Count;

        TargetData = new List<object[]>(SourceData);
        Alter(nbDifferences);
    }

    private readonly Random rnd = new();

    private void Alter(int nbDifferences)
    {
        var currentDiffIndex = 0;
        var alreadyUpdated = new List<int>(nbDifferences);

        int index;

        while (currentDiffIndex < nbDifferences)
        {
            do
            {
                index = rnd.Next(0, TargetData.Count);
            } while (alreadyUpdated.Contains(index));

            alreadyUpdated.Add(index);

            Matches--;
            SourceMissing++;
            TargetMissing++;

            TargetData[index] = DummyAlteredPersons.Data[currentDiffIndex % DummyAlteredPersons.Data.Count];

            currentDiffIndex++;
        }
    }

    //TODO : change to avoid zipping everytime? Not really that important for testing though.
    public IEnumerator<object[]> GetEnumerator() => SourceData.Zip(TargetData, (source, target) => new[] { source, target }).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => SourceData.Zip(TargetData, (source, target) => new[] { source, target }).GetEnumerator();
}