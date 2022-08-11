using CommunityToolkit.Common.Collections;
using CommunityToolkit.WinUI;

using Microsoft.UI.Xaml.Data;

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
}

