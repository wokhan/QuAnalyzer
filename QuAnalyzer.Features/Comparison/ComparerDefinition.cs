
using System.Collections;
using System.Linq.Dynamic.Core;

namespace QuAnalyzer.Features.Comparison;

public class ComparerDefinition<T>
{
    public string Name { get; set; }
    public string SourceName { get; set; }
    public string TargetName { get; set; }
    public IList<string>? SourceKeys { get; set; }
    public IList<string>? TargetKeys { get; set; }
    public IList<string> SourceHeaders { get; set; }
    public IList<string> TargetHeaders { get; set; }
    public bool IsOrdered { get; set; }
    public CancellationTokenSource TokenSource { get; } = new CancellationTokenSource();
    public IComparer Comparer { get; set; }

    //TODO: check if directly using an IEnumerable or IQueryable wouldn't be alright (only exception I see is if data has to be fully retrieved before the enumeration takes place)
    public Func<IEnumerable<T>> GetSourceData { get; set; }
    //TODO: Same remark
    public Func<IEnumerable<T>> GetTargetData { get; set; }
    public ComparisonResult<T> Results { get; } = new ComparisonResult<T>();

    public ComparerDefinition()
    {
    }

    public static async Task<ComparerDefinition<T>> CreateAsync(SourcesMapper s, IComparer comparer, Func<IQueryable, List<string>, IEnumerable<T>> mapFunc, Func<IEnumerable, Type[], IEnumerable<T>>? converter = null)
    {
        return await Task.Run(() => new ComparerDefinition<T>(s, comparer, mapFunc));
    }

    private ComparerDefinition(SourcesMapper s, IComparer comparer, Func<IQueryable, List<string>, IEnumerable<T>> mapFunc, Func<IEnumerable, Type[], IEnumerable<T>>? converter = null)
    {
        var fieldsSrc = s.AllMappings.Select(m => m.Source).ToList();
        var fieldsTrg = s.AllMappings.Select(m => m.Target).ToList();

        var srcHeaders = s.Source.GetColumns(s.SourceRepository);
        var trgHeaders = s.Target.GetColumns(s.TargetRepository);

        var allTypesSrc = fieldsSrc.Select(m => srcHeaders.First(h => h.Name == m).Type).ToArray();
        var allTypesTrg = fieldsTrg.Select(m => trgHeaders.First(h => h.Name == m).Type).ToArray();

        string[]? srcKeys = null;
        string[]? trgKeys = null;
        if (s.AllMappings.Any(a => a.IsKey))
        {
            srcKeys = s.AllMappings.Where(a => a.IsKey).Select(m => m.Source).ToArray();
            trgKeys = s.AllMappings.Where(a => a.IsKey).Select(m => m.Target).ToArray();
        }


        var srcDataGetter = s.Source.GetQueryable(s.SourceRepository);//, srcKeys is not null ? srcKeys.ToDictionary(sk => sk, sk => srcHeaders.First(h => h.Name == sk).Type) : null);
        var trgDataGetter = s.Target.GetQueryable(s.TargetRepository);//, trgKeys is not null ? trgKeys.ToDictionary(sk => sk, sk => trgHeaders.First(h => h.Name == sk).Type) : null);
        if (s.IsOrdered)
        {
            if (srcKeys is not null && trgKeys is not null)
            {
                srcDataGetter = srcDataGetter.OrderBy(String.Join(",", srcHeaders.Select(h => h.Name).Intersect(srcKeys)));
                trgDataGetter = trgDataGetter.OrderBy(String.Join(",", trgHeaders.Select(h => h.Name).Intersect(trgKeys)));
            }
            else
            {
                srcDataGetter = srcDataGetter.OrderBy(String.Join(",", srcHeaders.Select(h => h.Name)));
                trgDataGetter = trgDataGetter.OrderBy(String.Join(",", trgHeaders.Select(h => h.Name)));
            }
        }

        Name = s.Name;
        SourceName = $"{s.Source.Name} ({s.SourceRepository})";
        TargetName = $"{s.Target.Name} ({s.TargetRepository})";
        SourceHeaders = fieldsSrc;
        TargetHeaders = fieldsTrg;
        SourceKeys = srcKeys;
        TargetKeys = trgKeys;
        Comparer = comparer ?? Comparer<T>.Default;

        if (!allTypesSrc.SequenceEqual(allTypesTrg))
        {
            ArgumentNullException.ThrowIfNull(converter);

            GetSourceData = () => converter(mapFunc(srcDataGetter, fieldsSrc), allTypesTrg);
            GetTargetData = () => converter(mapFunc(trgDataGetter, fieldsTrg), allTypesTrg);
        }
        else
        {
            GetSourceData = () => mapFunc(srcDataGetter, fieldsSrc);
            GetTargetData = () => mapFunc(trgDataGetter, fieldsTrg);
        }
        IsOrdered = s.IsOrdered;
    }
}
