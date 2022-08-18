using QuAnalyzer.Features.Comparison;

namespace QuAnalyzer.UI.Pages;

public class LocalComparerDefinition : ComparerDefinition<object[]>
{
    public LocalComparerDefinition(SourcesMapper s, IComparer comparer, Func<IQueryable, string[], IEnumerable<object[]>> map, Func<object, Type[], object[]> convert = null) : base(s, comparer, map, convert) { }
}
