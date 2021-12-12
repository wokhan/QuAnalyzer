using Microsoft.CSharp.RuntimeBinder;

using System.Collections;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Core.Extensions;

namespace QuAnalyzer.Features.Comparison;

public class ComparerStruct<T> : IDataComparer
{
    public string Name { get; set; }
    public string SourceName { get; set; }
    public string TargetName { get; set; }
    public IList<string>? SourceKeys { get; set; }
    public IList<string>? TargetKeys { get; set; }
    public IList<string> SourceHeaders { get; set; }
    public IList<string> TargetHeaders { get; set; }
    public bool IsOrdered { get; set; }
    public CancellationTokenSource TokenSource { get; private set; }

    public IEqualityComparer<T> Comparer { get; set; }
    public IEqualityComparer<T> KeysComparer { get; set; }
    public Func<IEnumerable<T>> GetSourceData { get; set; }
    public Func<IEnumerable<T>> GetTargetData { get; set; }

    public ResultStruct<T> Results { get; } = new ResultStruct<T>();

    public ComparerStruct()
    {
        TokenSource = new CancellationTokenSource();
    }

    public static IEnumerable<object[]> ToObjectArrays(IEnumerable src, params string[] attributes)
    {
        var innertype = src.GetInnerType();
        if (innertype.IsArray)
        {
            return ((IEnumerable<object[]>)src);
        }
        else
        {

            if (attributes is null)
            {
                attributes = innertype.GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(a => a.Name).ToArray();
            }

            var param = Expression.Parameter(typeof(object));
            var expa = Expression.Parameter(typeof(Exception));
            var ide_cstr = typeof(InvalidDataException).GetConstructor(new[] { typeof(string), typeof(Exception) });

            var casted = Expression.Convert(param, innertype);

            Func<string, Expression> propertyGet;
            // Assuming dynamic...
            if (innertype == typeof(object))
            {
                propertyGet = a =>
                {
                    var binder = Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, a, innertype, new[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
                    return Expression.Dynamic(binder, innertype, casted);
                };
            }
            else
            {
                propertyGet = a => Expression.Property(casted, a);
            }
            var atrs = attributes.Select(a =>
                Expression.TryCatch(
                    Expression.Block(
                        Expression.Convert(propertyGet(a), typeof(object))
                    ),
                Expression.Catch(expa,
                    Expression.Block(
                        Expression.Throw(Expression.New(ide_cstr, Expression.Constant(a), expa)),
                        Expression.Constant(null))))
            ).ToList();

            var attrExpr = Expression.Lambda<Func<dynamic, object[]>>(Expression.NewArrayInit(typeof(object), atrs), param).Compile();

            return src.Cast<dynamic>().Select(attrExpr);
        }
    }


    public ComparerStruct(SourcesMapper s) : this()//, IEqualityComparer<T> comparer, Func<string[], IEqualityComparer<T>> getComparerForKeys, Func<IQueryable<dynamic>, List<string>, IEnumerable<object[]>> transform)
    {
        var fieldsSrc = s.AllMappings.Select(m => m.Source).ToList();
        var fieldsTrg = s.AllMappings.Select(m => m.Target).ToList();

        var srcHeaders = s.Source.GetColumns(s.SourceRepository);
        var trgHeaders = s.Target.GetColumns(s.TargetRepository);

        var allTypesSrc = fieldsSrc.Select(m => srcHeaders.First(h => h.Name == m).Type).ToArray();
        var allTypesTrg = fieldsTrg.Select(m => trgHeaders.First(h => h.Name == m).Type).ToArray();

        var normalizeTypes = allTypesSrc.SequenceEqual(allTypesTrg) ? (Func<IEnumerable<IEnumerable<object>>, Type[], IEnumerable<object[]>>)KeepSame : ConvertType;

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
        Comparer = (IEqualityComparer<T>)new SequenceEqualityComparer<object>();
        //KeysComparer = (IEqualityComparer<T>)(srcKeys is not null ? new SequenceEqualityComparer<object>(0, srcKeys.Length) : null);
        //KeysComparer = (IEqualityComparer<T>)new SequenceComparer(srcKeys is not null ? srcKeys.ToArray() : Enumerable.Range(0, fieldsSrc.Count).Select(i => i.ToString()).ToArray());
        GetSourceData = () => (IEnumerable<T>)normalizeTypes(Transform(srcDataGetter, fieldsSrc), allTypesTrg); //.Select(r => allIdxSr.Select(i => r[i]).ToArray()),
        GetTargetData = () => (IEnumerable<T>)normalizeTypes(Transform(trgDataGetter, fieldsTrg), allTypesTrg);//.Select(r => allIdxTr.Select(i => r[i]).ToArray())
        IsOrdered = s.IsOrdered;
    }

    /*private static SequenceEqualityComparer<T> GetComparer(string[] fields)
    {
        return (fields is not null ? new SequenceEqualityComparer<T>(0, fields.Length) : null);
    }

    private static SequenceEqualityComparer<IEnumerable<T>> GetComparer()
    {
        return new SequenceEqualityComparer<IEnumerable<T>>();
    }*/

    private static IEnumerable<object[]> Transform(IQueryable sourceQuery, List<string> fields)
    {
        //return sourceQuery.Select($"new({string.Join(",", fields)})");
        return ToObjectArrays(sourceQuery, fields.ToArray());
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
        return src.Select(c => c.Zip(types, (a, t) => a.SafeConvert(t)).ToArray());
    }
}
