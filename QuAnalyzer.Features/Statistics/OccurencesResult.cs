using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.Features.Statistics;


/// Cannot use record (see https://github.com/microsoft/microsoft-ui-xaml/issues/5315)
public readonly struct OccurencesResult
{
    public readonly string? Category;
    public readonly int CategoryIndex;
    public readonly int Frequency;

    public OccurencesResult(string? category, int categoryIndex, int frequency)
    {
        Category = category;
        CategoryIndex = categoryIndex;
        Frequency = frequency;
    }

    private static IEnumerable<OccurencesResult> GetTypedData<T, TK>(IQueryable data, string key)
    {
        var param = Expression.Parameter(typeof(T));
        //var fn = Expression.GetFuncType(typeof(T), typeof(TK));
        var group = Expression.Lambda<Func<T, TK>>(Expression.Property(param, key), param);

        var xx = ((IQueryable<T>)data).GroupBy(group, group)// ((IQueryable<T>)data).GroupBy((dynamic)group)
                                    //.Select(g => new { g.Key, Cnt = g.Count() })
                                    //.OrderByDescending(x => x.Cnt)
                                    //.Take(11)
                                    //.ToList()
                                    //.Select((x, i) => new OccurencesResult(Category: x.Key.ToString(), CategoryIndex: i, Frequency: x.Cnt))
                                    //.ToList();
                                    .Select((g, i) => new OccurencesResult(g.Key != null ? g.Key.ToString() : null, i, g.Count()))
                                    .OrderByDescending(x => x.Frequency)
                                    .Take(11)
                                    .ToList();

        return xx;
    }

    public static IEnumerable<OccurencesResult> CountOccurences(IQueryable data, ColumnDescription groupKey)
    {
        var m = typeof(OccurencesResult).GetMethod(nameof(GetTypedData), BindingFlags.NonPublic | BindingFlags.Static)
                                          .MakeGenericMethod(data.GetInnerType(), groupKey.Type);

        return (IEnumerable<OccurencesResult>)m.Invoke(null, new object[] { data, groupKey.Name });
    }

    
    public static IEnumerable<OccurencesResult> CountOccurences(IQueryable data, string attribute)
    {
        return data.GroupBy(attribute)
                   .Select("new { Key, Count() as Count }")
                   .OrderBy("Count desc")
                   .ToDynamicList()
                   .Select((g, i) => new OccurencesResult(g.Key.ToString(), i, g.Count)).ToList();
    }
}
