using CommunityToolkit.Common.Collections;
using CommunityToolkit.WinUI;

using System.Linq.Expressions;
using System.Threading;

namespace QuAnalyzer.Core.Extensions;

public static class QueryableExtensions
{

    private static Dictionary<Type, Type> cachedTypes = new Dictionary<Type, Type>();

    public static IEnumerable AsIncremental(this IQueryable query, int itemsPerPage = 20, Action onStartLoading = null, Action onEndLoading = null, Action<Exception> onError = null)
    {
        Type elementType = query.ElementType;
        if (!cachedTypes.TryGetValue(elementType, out var sourceGenericType))
        {
            sourceGenericType = typeof(IncrementalSource<>).MakeGenericType(elementType);
            cachedTypes.Add(elementType, sourceGenericType);
        }
        var source = Activator.CreateInstance(sourceGenericType, query);

        var collectionGenericType = typeof(IncrementalLoadingCollection<,>).MakeGenericType(sourceGenericType, elementType);

        return (IEnumerable)Activator.CreateInstance(collectionGenericType, source, itemsPerPage, onStartLoading, onEndLoading, onError);
    }

    public class IncrementalSource<T> : IIncrementalSource<T>
    {
        IQueryable<T> source;

        public IncrementalSource(IQueryable<T> query)
        {
            source = query;
        }

        public async Task<IEnumerable<T>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            return source.Skip(pageIndex * pageSize).Take(pageSize);
        }
    }

    /// <summary>
    /// Turns a generic <see cref="IEnumerable"/> into an object[] enumeration (each property being mapped into the array)
    /// </summary>
    /// <param name="src">Source enumeration</param>
    /// <param name="properties">Name of the properties to use to populate the array</param>
    /// <returns></returns>
    public static IEnumerable<object[]> AsObjectCollection(this IQueryable src, params string[] properties)
    {
        var innertype = src.ElementType;

        //TODO: rename the other method to get the right one directly
        var m = typeof(QueryableExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(method => method.IsGenericMethod && method.Name == nameof(AsObjectCollection)).First().MakeGenericMethod(innertype);
        return (IEnumerable<object[]>)m.Invoke(null, new object[] { src, properties });
    }

    /// <summary>
    /// Turns a generic <see cref="IEnumerable{T}"/> into an object[] enumeration (each property being mapped into the array)
    /// </summary>
    /// <param name="src">Source enumeration</param>
    /// <param name="properties">Name of the properties to use to populate the array</param>
    /// <returns></returns>
    public static IEnumerable<object[]> AsObjectCollection<T>(this IQueryable<T> src, params string[] properties)
    {
        ArgumentNullException.ThrowIfNull(src);

        //if (typeof(T).IsArray)
        //{
        //    return ((IEnumerable<object[]>)src);
        //}
        //else
        {
            if (properties is null)
            {
                properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => p.Name).ToArray();
            }

            var map = GetExpression<T>(properties);

            //TODO: Test with actual IQueryable implementation like LinqToSQL...
            return src.Select(x => map(x));

            //var param = LExpr.Expression.Parameter(typeof(object));
            //var expa = LExpr.Expression.Parameter(typeof(Exception));
            //var ide_cstr = typeof(InvalidDataException).GetConstructor(new[] { typeof(string), typeof(Exception) });

            //var casted = LExpr.Expression.Convert(param, innertype);

            //Func<string, LExpr.Expression> propertyGet = a => LExpr.Expression.Property(casted, a);
            //var atrs = properties.Select(a =>
            //    LExpr.Expression.TryCatch(
            //        LExpr.Expression.Block(
            //            LExpr.Expression.Convert(propertyGet(a), typeof(object))
            //        ),
            //    LExpr.Expression.Catch(expa,
            //        LExpr.Expression.Block(
            //            LExpr.Expression.Throw(LExpr.Expression.New(ide_cstr, LExpr.Expression.Constant(a), expa)),
            //            LExpr.Expression.Constant(null))))
            //).ToList();

            //var attrExpr = LExpr.Expression.Lambda<Func<T, object[]>>(LExpr.Expression.NewArrayInit(typeof(object), atrs), param).Compile();

            ////return src.Select(x => { if (x is null) { throw new Exception("Should never get there."); } return attrExpr(x); });
            //return src.Select(x => attrExpr(x));
        }
    }

    private static Func<T, object[]> GetExpression<T>(params string[] properties)
    {
        var param = Expression.Parameter(typeof(T));
        var propertyGetExpression = properties.Select(property => Expression.Convert(Expression.Property(param, property), typeof(object))).ToArray();
        return Expression.Lambda<Func<T, object[]>>(Expression.NewArrayInit(typeof(object), propertyGetExpression), param).Compile();
    }
}

