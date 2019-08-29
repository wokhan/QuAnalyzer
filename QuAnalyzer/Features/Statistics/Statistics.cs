using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Wokhan.Collections.Generic.Extensions;
using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.Features.Statistics
{
    internal class Statistics
    {
        static readonly Type[] numericTypes = new[] { typeof(int), typeof(int?), typeof(decimal), typeof(decimal?), typeof(double), typeof(double?), typeof(long), typeof(long?) };

        private static ResultsStruct.Stats GetTypedStats<T, TK>(IQueryable data, string key)
        {
            var param = Expression.Parameter(typeof(T));
            var fn = Expression.GetFuncType(typeof(T), typeof(TK));
            var group = Expression.Lambda<Func<T, TK>>(Expression.Property(param, key), param);

            var xx = ((IQueryable<T>)data).GroupBy(x => true, group)
                                          .Select(g => new { Min = g.Min(), Max = g.Max(), Count = g.Count(), /*Average = g.Average(), DistinctCount = g.Distinct().Count(),*/ EmptyCount = g.Count(x => x == null) })
                                          .First();

            return new ResultsStruct.Stats { Min = xx.Min, Max = xx.Max, Average = "Not available", DistinctCount = "Not available", EmptyCount = xx.EmptyCount };//, Average = xx.Average, Count = xx.Count, DistinctCount = xx.DistinctCount, EmptyCount = xx.EmptyCount };
        }

        private static IEnumerable<Values> GetTypedData<T, TK>(IQueryable data, string key)
        {
            var param = Expression.Parameter(typeof(T));
            var fn = Expression.GetFuncType(typeof(T), typeof(TK));
            var group = Expression.Lambda<Func<T, TK>>(Expression.Property(param, key), param);

            var xx = ((IQueryable<T>)data).GroupBy(group, group)// ((IQueryable<T>)data).GroupBy((dynamic)group)
                                        .Select(g => new { g.Key, Cnt = g.Count() })
                                        .OrderByDescending(x => x.Cnt)
                                        .Take(10)
                                        .ToList()
                                        .Select(x => new Values() { Category = (x.Key != null ? x.Key.ToString() : String.Empty), Frequency = x.Cnt })
                                        .ToList();

            return xx;
        }

        internal static IEnumerable<Values> GetData(IQueryable data, ColumnDescription groupKey)
        {
            var m = typeof(Statistics).GetMethod(nameof(GetTypedData), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                                              .MakeGenericMethod(data.GetInnerType(), groupKey.Type);
            return (IEnumerable<Values>)m.Invoke(null, new object[] { data, groupKey.Name });
        }

        internal static ResultsStruct.Stats GetStats(IQueryable data, ColumnDescription groupKey)
        {
            var mx = typeof(Statistics).GetMethod(nameof(GetTypedStats), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                                                           .MakeGenericMethod(data.GetInnerType(), groupKey.Type);
            return (ResultsStruct.Stats)mx.Invoke(null, new object[] { data, groupKey.Name });
        }
    }
}
