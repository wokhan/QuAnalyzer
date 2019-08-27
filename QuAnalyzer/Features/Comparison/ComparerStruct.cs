using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using Wokhan.Collections.Generic.Extensions;
using Wokhan.Core.Extensions;

namespace QuAnalyzer.Features.Comparison
{
    public class ComparerStruct<T> : IDataComparer
    {
        public string Name { get; set; }
        public string SourceName { get; set; }
        public string TargetName { get; set; }
        public IList<string> SourceKeys { get; set; }
        public IList<string> TargetKeys { get; set; }
        public Func<IEnumerable<T>> GetSourceData { get; set; }
        public Func<IEnumerable<T>> GetTargetData { get; set; }
        public IList<string> SourceHeaders { get; set; }
        public IList<string> TargetHeaders { get; set; }
        public IEqualityComparer<T> Comparer { get; set; }
        public IEqualityComparer<T> KeysComparer { get; set; }
        public bool IsOrdered { get; set; }

        public CancellationTokenSource TokenSource { get; private set; }

        public ResultStruct<T> Results { get; } = new ResultStruct<T>();

        public object[][] AsArray
        {
            get
            {
                return new object[][]
                {
                    new object[] { Name, SourceName, Results, Results.Source, this },
                    new object[] { Name, TargetName, Results, Results.Target, this }
                };
            }
        }

        public ComparerStruct()
        {
            TokenSource = new CancellationTokenSource();
        }

        public ComparerStruct(SourcesMapper s)//, IEqualityComparer<T> comparer, Func<string[], IEqualityComparer<T>> getComparerForKeys, Func<IQueryable<dynamic>, List<string>, IEnumerable<object[]>> transform)
        {
            var fieldsSrc = s.AllMappings.Select(m => m.Source).ToList();
            var fieldsTrg = s.AllMappings.Select(m => m.Target).ToList();

            var srcHeaders = s.Source.GetColumns(s.SourceRepository);
            var trgHeaders = s.Target.GetColumns(s.TargetRepository);

            var allTypesSrc = fieldsSrc.Select(m => srcHeaders.First(h => h.Name == m).Type).ToArray();
            var allTypesTrg = fieldsTrg.Select(m => trgHeaders.First(h => h.Name == m).Type).ToArray();

            var normalizeTypes = allTypesSrc.SequenceEqual(allTypesTrg) ? (Func<IEnumerable<IEnumerable<object>>, Type[], IEnumerable<object[]>>)KeepSame : ConvertType;

            string[] srcKeys = null;
            string[] trgKeys = null;
            if (s.AllMappings.Any(a => a.IsKey))
            {
                srcKeys = s.AllMappings.Where(a => a.IsKey).Select(m => m.Source).ToArray();
                trgKeys = s.AllMappings.Where(a => a.IsKey).Select(m => m.Target).ToArray();
            }


            var srcDataGetter = s.Source.GetQueryable(s.SourceRepository).Select<dynamic>(fieldsSrc);//, srcKeys != null ? srcKeys.ToDictionary(sk => sk, sk => srcHeaders.First(h => h.Name == sk).Type) : null);
            var trgDataGetter = s.Target.GetQueryable(s.TargetRepository).Select<dynamic>(fieldsTrg);//, trgKeys != null ? trgKeys.ToDictionary(sk => sk, sk => trgHeaders.First(h => h.Name == sk).Type) : null);
            if (s.IsOrdered)
            {
                if (srcKeys != null && trgKeys != null)
                {
                    srcDataGetter = srcDataGetter.OrderByMany(srcHeaders.Join(srcKeys, h => h.Name, k => k, (h, k) => new { h, k }).ToDictionary(x => x.k, x => x.h.Type));
                    trgDataGetter = trgDataGetter.OrderByMany(trgHeaders.Join(trgKeys, h => h.Name, k => k, (h, k) => new { h, k }).ToDictionary(x => x.k, x => x.h.Type));
                }
                else
                {
                    srcDataGetter = srcDataGetter.OrderByAll();
                    trgDataGetter = trgDataGetter.OrderByAll();
                }
            }

            Name = s.Name;
            SourceName = s.Source.Name + " (" + s.SourceRepository + ")";
            TargetName = s.Target.Name + " (" + s.TargetRepository + ")";
            SourceHeaders = fieldsSrc;
            TargetHeaders = fieldsTrg;
            SourceKeys = srcKeys;
            TargetKeys = trgKeys;
            Comparer = (IEqualityComparer<T>)new SequenceEqualityComparer<object>();
            KeysComparer = (IEqualityComparer<T>)(srcKeys != null ? new SequenceEqualityComparer<object>(0, srcKeys.Length) : null);
            GetSourceData = () => (IEnumerable<T>)normalizeTypes(Transform(srcDataGetter, fieldsSrc), allTypesTrg); //.Select(r => allIdxSr.Select(i => r[i]).ToArray()),
            GetTargetData = () => (IEnumerable<T>)normalizeTypes(Transform(trgDataGetter, fieldsTrg), allTypesTrg);//.Select(r => allIdxTr.Select(i => r[i]).ToArray())
            IsOrdered = s.IsOrdered;
        }

        /*private static SequenceEqualityComparer<T> GetComparer(string[] fields)
        {
            return (fields != null ? new SequenceEqualityComparer<T>(0, fields.Length) : null);
        }

        private static SequenceEqualityComparer<IEnumerable<T>> GetComparer()
        {
            return new SequenceEqualityComparer<IEnumerable<T>>();
        }*/

        private static IEnumerable<object[]> Transform(IQueryable<dynamic> sourceQuery, List<string> fields)
        {
            return sourceQuery.AsObjectCollection(fields.ToArray());
        }

        //TODO: MOVE !

        private static IEnumerable<object[]> KeepSame(IEnumerable<IEnumerable<object>> src, Type[] types)
        {
            if (false)
            {
#pragma warning disable CS0162 // Code inaccessible détecté
                return src.Select(c => c.Select(a => a is DBNull ? null : a is DateTime ? ((DateTime)a).Date : a).ToArray());
#pragma warning restore CS0162 // Code inaccessible détecté
            }
            else
            {
                return src.Select(c => c.ToArray());
            }
        }

        private static IEnumerable<object[]> ConvertType(IEnumerable<IEnumerable<object>> src, Type[] types)
        {
            return src.Select(c => c.Select((a, i) => a.SafeConvert(types[i])).ToArray());
        }
    }
}
