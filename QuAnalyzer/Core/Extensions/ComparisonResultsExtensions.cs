using QuAnalyzer.Features.Comparison.Results;
using QuAnalyzer.Features.Comparison;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuAnalyzer.Core.Extensions;

internal static class ComparisonResultsExtensions
{
    public static void InitDiff(this ComparisonResult<object[]> source, ComparerDefinition<object[]> definition)
    {
        if (source.MergedDiff is null)
        {
            source.MergedHeaders = definition.SourceHeaders.Zip(definition.TargetHeaders, (src, trg) => src + (src != trg ? "/" + trg : String.Empty)).ToArray();

            var allFalse = new bool[source.MergedHeaders.Length];
            source.MergedDiff = source.Differences.SelectMany(x => new[] {
                                    new Diff<object[]>(Source: definition.SourceName, Values: x.First),
                                    new Diff<object[]>(
                                        Source: definition.TargetName,
                                        Values: x.Second,
                                        //TODO: this is awful.
                                        IsDiff: (x.First as object[]).Zip(x.Second as object[]).Select((xi, i) => i >= x.Index && !Equals(xi.First, xi.Second)).ToArray()
                                    )
                                });
        }
    }

}
