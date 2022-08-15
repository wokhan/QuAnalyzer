using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Comparison.Comparers;

namespace QuAnalyzer.Tests.Features.Comparison;

internal class SharedHelper
{
    internal static ComparerDefinition<object[]> GetComparer(IEnumerable<object[]> sourceData, IEnumerable<object[]> targetData)
    {
        return new ComparerDefinition<object[]>()
        {
            SourceQuery = () => sourceData,
            TargetQuery = () => targetData,
            IsOrdered = true,
            Comparer = SequenceComparer<object>.Default
        };
    }
}
