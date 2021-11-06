
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.Features.Statistics
{
    public struct OccurencesResult
    {
        public int CategoryIndex { get; set; }
        public string Category { get; set; }
        public int Frequency { get; set; }

        private static IEnumerable<OccurencesResult> GetTypedData<T, TK>(IQueryable data, string key)
        {
            var param = Expression.Parameter(typeof(T));
            var fn = Expression.GetFuncType(typeof(T), typeof(TK));
            var group = Expression.Lambda<Func<T, TK>>(Expression.Property(param, key), param);

            var xx = ((IQueryable<T>)data).GroupBy(group, group)// ((IQueryable<T>)data).GroupBy((dynamic)group)
                                        .Select(g => new { g.Key, Cnt = g.Count() })
                                        .OrderByDescending(x => x.Cnt)
                                        .Take(11)
                                        .ToList()
                                        .Select((x, i) => new OccurencesResult() { Category = x.Key?.ToString(), CategoryIndex = i, Frequency = x.Cnt })
                                        .ToList();

            return xx;
        }

        internal static IEnumerable<OccurencesResult> CountOccurences(IQueryable data, ColumnDescription groupKey)
        {
            var m = typeof(OccurencesResult).GetMethod(nameof(GetTypedData), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                                              .MakeGenericMethod(data.GetInnerType(), groupKey.Type);
            return (IEnumerable<OccurencesResult>)m.Invoke(null, new object[] { data, groupKey.Name });
        }
    }
}
