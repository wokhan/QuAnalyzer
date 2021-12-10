using System.Linq.Dynamic.Core;

namespace QuAnalyzer.Features.Statistics;

public record StatsResult(object Min, object Max, object Average, object Count, object DistinctCount, object EmptyCount)
{
    //static readonly Type[] numericTypes = new[] { typeof(int), typeof(int?), typeof(decimal), typeof(decimal?), typeof(double), typeof(double?), typeof(long), typeof(long?) };

    //TODO: Check if using a typed method would help regarding perf (against DynamicLinq)
    //private static ResultsStruct.Stats GetTypedStats<T, TK>(IQueryable data, string key)
    //{
    //    var param = Expression.Parameter(typeof(T));
    //    var fn = Expression.GetFuncType(typeof(T), typeof(TK));
    //    var group = Expression.Lambda<Func<T, TK>>(Expression.Property(param, key), param);

    //    var xx = ((IQueryable<T>)data).GroupBy(x => true, group)
    //                                  .Select(g => new { Min = g.Min(), Max = g.Max(), Count = g.Count(), Average = GetAverage(g, key), DistinctCount = g.Distinct().Count(), EmptyCount = g.Count(x => x is null) })
    //                                  .First();
    //    return new ResultsStruct.Stats { Count = xx.Count, Min = xx.Min, Max = xx.Max, Average = xx.Average, DistinctCount = xx.DistinctCount, EmptyCount = xx.EmptyCount };
    //}

    public static StatsResult GetStats(IQueryable data, string attribute)
    {
        /*var mx = typeof(Statistics).GetMethod(nameof(GetTypedStats), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                                                       .MakeGenericMethod(data.GetInnerType(), groupKey.Type);
        return (ResultsStruct.Stats)mx.Invoke(null, new object[] { data, groupKey.Name });*/
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
