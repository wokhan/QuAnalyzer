using QuAnalyzer.Features.Comparison.Comparers;
using QuAnalyzer.Features.Comparison;
using System.Collections.Generic;

namespace QuAnalyzer.Tests.Features.Comparison;

internal class SharedHelper
{
    internal static ComparerDefinition<object[]> GetComparer(IEnumerable<object[]> sourceData, IEnumerable<object[]> targetData, bool newMode = false)
    {
        return new ComparerDefinition<object[]>()
        {
            GetSourceData = () => sourceData,
            GetTargetData = () => targetData,
            IsOrdered = true,
            Comparer = newMode ? new NewSequenceComparer<object>() : new SequenceComparer<IEnumerable<object>, object>()
        };
    }
}
