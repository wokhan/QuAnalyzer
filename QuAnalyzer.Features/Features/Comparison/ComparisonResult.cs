
using System.Collections.ObjectModel;

using Wokhan.Collections.Generic.Extensions;

namespace QuAnalyzer.Features.Comparison;

public partial class ComparisonResult<T> : ResultStructBase
{
    public ItemResult<T> Source { get; } = new ItemResult<T>();
    public ItemResult<T> Target { get; } = new ItemResult<T>();

    public string[]? MergedHeaders { get; private set; }

    public IEnumerable<Diff>? MergedDiff { get; private set; } = null;

    public void InitDiff(ComparerDefinition<T> definition)
    {
        if (MergedDiff is null)
        {
            MergedHeaders = definition.SourceHeaders.Zip(definition.TargetHeaders, (src, trg) => src + (src != trg ? "/" + trg : String.Empty)).ToArray();

            //TODO: Differences should already be an object array (at the expense of boxing / unboxing)
            var sortedSrc = definition.SourceKeys?.Count > 0 ? Source.Differences.Cast<object[]>().OrderByMany(definition.SourceKeys.Count) : Source.Differences.Cast<object[]>().OrderByAll();
            var sortedTrg = definition.SourceKeys?.Count > 0 ? Target.Differences.Cast<object[]>().OrderByMany(definition.SourceKeys.Count) : Target.Differences.Cast<object[]>().OrderByAll();

            var hasKeys = definition.SourceKeys?.Count > 0;
            var allFalse = new bool[MergedHeaders.Length];
            MergedDiff = sortedSrc.Zip(sortedTrg)
                                   .SelectMany(x => new[] {
                                       new Diff(Source: definition.SourceName, Values: x.First),
                                       new Diff(
                                           Source: definition.TargetName, 
                                           Values: x.Second, 
                                           IsDiff: hasKeys && !x.First.Take(definition.SourceKeys.Count).SequenceEqual(x.Second.Take(definition.SourceKeys.Count))
                                                       ? allFalse
                                                       : x.First.Zip(x.Second, (a, b) => !Equals(a, b)).ToArray()
                                       )
                                    });
        }
    }

    public void InitCollections(Func<IList<T>> collectionCtor)
    {
        Source.Differences = collectionCtor();
        Target.Differences = collectionCtor();
        Source.Missing = collectionCtor();
        Target.Missing = collectionCtor();
        Source.Duplicates = collectionCtor();
        Target.Duplicates = collectionCtor();
        Source.PerfectDups = collectionCtor();
        Target.PerfectDups = collectionCtor();
    }
}
