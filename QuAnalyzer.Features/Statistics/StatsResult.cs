using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Core.Extensions;

namespace QuAnalyzer.Features.Statistics;

public record StatsResult(int Count, object? Min, object? Max, object? Average, int DistinctCount, int EmptyCount)
{
    //static readonly Type[] numericTypes = new[] { typeof(int), typeof(int?), typeof(decimal), typeof(decimal?), typeof(double), typeof(double?), typeof(long), typeof(long?) };

    //TODO: Check if using a typed method would help regarding perf (against DynamicLinq)
    private static StatsResult GetTypedStats<T, TK>(IQueryable<T> data, string key)
    {
        var param = Expression.Parameter(typeof(T));
        var attributeExpr = Expression.Lambda<Func<T, TK>>(Expression.Property(param, key), param);

        var sel = data.Select(attributeExpr);
        var results = new StatsResult(sel.Count(), sel.Min(), sel.Max(), GetAverage(sel), sel.Distinct().Count(), sel.Count(x => x == null));
        
        return results;
    }

    private static object? GetAverage<TK>(IQueryable<TK> sel)
    {
        //TODO: FIX (broken for null values)
        try
        {
            return sel.Average();
        }
        catch
        {
            return "N/A";
        }
    }

    public static StatsResult GetStats(IQueryable data, string attribute, Type type)
    {
        var mx = typeof(StatsResult).GetMethod(nameof(GetTypedStats), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                                                       .MakeGenericMethod(data.ElementType, type);
        return (StatsResult)mx.Invoke(null, new object[] { data, attribute });
    }

    public static StatsResult GetStats(IQueryable data, string attribute)
    {
        return new StatsResult(Min: data.Min(attribute), Max: data.Max(attribute), Average: GetAverage(data, attribute), Count: data.Count(), DistinctCount: data.Select(attribute).Distinct().Count(), EmptyCount: data.Count($"{attribute} == null"));// || {attribute} == \"\""));
    }

    private static object GetAverage(IQueryable data, string key)
    {
        //TODO: FIX (broken for null values)
        try
        {
            return data.Average(key);
        }
        catch
        {
            return "N/A";
        }
    }

}
