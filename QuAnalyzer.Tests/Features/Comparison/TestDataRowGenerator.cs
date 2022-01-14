using QuAnalyzer.Tests.DummyData;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Wokhan.Collections.Generic.Extensions;

namespace QuAnalyzer.Features.Comparison.Tests;

internal class TestDataRowGenerator : IEnumerable<object[]>
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

    private int nbDifferences;

    public TestDataRowGenerator() : this(1, 1) { }

    public TestDataRowGenerator(int count, int nbDifferences)
    {
        this.nbDifferences = nbDifferences;
        
        SourceData = DummyPersons.Data.Take(count).OrderByMany(5).ToList();
        Matches = SourceData.Count;

        TargetData = DummyPersons.Data.Take(count).Select(Alter).OrderByMany(5).ToList();
    }

    private readonly Random rnd = new();
    private int lastDifferentIndex;
    private int currentDiffIndex;

    private object[] Alter(object[] d)
    {
        if (currentDiffIndex < nbDifferences)
        {
            lastDifferentIndex = rnd.Next(lastDifferentIndex, SourceData.Count);
            Matches--;
            SourceMissing++;
            TargetMissing++;

            return DummyAlteredPersons.Data[currentDiffIndex++ % DummyAlteredPersons.Data.Count];
        }

        return (object[])d.Clone();
    }

    //TODO : change to avoid zipping everytime? Not really that important for testing though.
    public IEnumerator<object[]> GetEnumerator() => SourceData.Zip(TargetData, (source, target) => new[] { source, target }).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => SourceData.Zip(TargetData, (source, target) => new[] { source, target }).GetEnumerator();
}