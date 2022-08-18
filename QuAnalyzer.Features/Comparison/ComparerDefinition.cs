
using CommunityToolkit.Mvvm.ComponentModel;

using System.Collections;
using System.Linq.Dynamic.Core;

#if !NET6_0_OR_GREATER
using ArgumentNullException = QuAnalyzer.Features.Exceptions.ExceptionsHelper._ArgumentNullException;
#endif

namespace QuAnalyzer.Features.Comparison;

public class ComparerDefinition<T> : ObservableObject
{
    public string Name { get; set; }
    public string SourceName { get; set; }
    public string TargetName { get; set; }
    public IList<string>? SourceKeys { get; set; }
    public IList<string>? TargetKeys { get; set; }
    public Func<object, List<string>, Type[], T>? Converter { get; }
    public IList<string> SourceHeaders { get; set; }
    public IList<string> TargetHeaders { get; set; }
    public bool IsOrdered { get; set; }
    public CancellationTokenSource TokenSource { get; } = new();
    public IComparer Comparer { get; set; }
    public IEnumerable<T> SourceEnumerable { get; set; }
    public IEnumerable<T> TargetEnumerable { get; set; }
    public ComparisonResult<T> Results { get; } = new();

    public ComparerDefinition()
    {
    }

    public ComparerDefinition(SourcesMapper s, IComparer comparer, Func<IQueryable, string[], IEnumerable<T>> map, Func<object, Type[], T>? convert = null)
    {
        var sourceMapFields = s.AllMappings.Select(m => m.Source).ToArray();
        var targetMapFields = s.AllMappings.Select(m => m.Target).ToArray();

        var sourceColumns = s.Source.GetColumns(s.SourceRepository);
        var targetColumns = s.Target.GetColumns(s.TargetRepository);

        string[]? sourceKeys = null;
        string[]? targetKeys = null;
        if (s.AllMappings.Any(a => a.IsKey))
        {
            sourceKeys = s.AllMappings.Where(a => a.IsKey).Select(m => m.Source).ToArray();
            targetKeys = s.AllMappings.Where(a => a.IsKey).Select(m => m.Target).ToArray();
        }

        Name = s.Name;
        SourceName = $"{s.Source.Name} ({s.SourceRepository})";
        TargetName = $"{s.Target.Name} ({s.TargetRepository})";
        SourceHeaders = sourceMapFields;
        TargetHeaders = targetMapFields;
        SourceKeys = sourceKeys;
        TargetKeys = targetKeys;
        Comparer = comparer ?? Comparer<T>.Default;

        var srcData = s.Source.GetQueryable(s.SourceRepository)
                              .OrderBy(String.Join(",", sourceKeys.Concat(sourceColumns.Select(h => h.Name)).Except(sourceKeys)));

        var trgData = s.Target.GetQueryable(s.TargetRepository)
                              .OrderBy(String.Join(",", targetKeys.Concat(targetColumns.Select(h => h.Name)).Except(targetKeys)));

        var sourceMapTypes = sourceMapFields.Join(sourceColumns, field => field, header => header.Name, (field, header) => header.Type).ToArray();
        var targetMapTypes = targetMapFields.Join(targetColumns, field => field, header => header.Name, (field, header) => header.Type).ToArray();

        // Normalize the current items types (to be able to compare them)
        if (!sourceMapTypes.SequenceEqual(targetMapTypes))
        {
            ArgumentNullException.ThrowIfNull(convert);

            SourceEnumerable = map(srcData, sourceMapFields).Select(item => convert(item, targetMapTypes));
        } else
        {
            SourceEnumerable = map(srcData, sourceMapFields);
        }

        TargetEnumerable = map(trgData, targetMapFields);

        //IsOrdered = s.IsOrdered;
    }


    public void RaiseResultChanged()
    {
        OnPropertyChanged(nameof(Results));
    }
}
