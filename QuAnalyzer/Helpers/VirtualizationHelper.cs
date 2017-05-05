﻿using AlphaChiTech.Virtualization;
using QuAnalyzer.DataProviders.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Windows.Threading;

namespace QuAnalyzer.Helpers
{
    public class VirtualizationHelper
    {
        private static Dictionary<Type, Type> cachedTypes = new Dictionary<Type, Type>();
        //public static IEnumerable GetVirtualizedSource(IDataProvider provider, string repository)
        //{
        //    var gt = CreateDynamicType(provider, repository);

        //    return (IEnumerable)Activator.CreateInstance(gt, provider, repository);
        //}

        private static Type CreateDynamicType(IDataProvider provider, string repository)
        {
            Type t = provider.GetTypedClass(repository);
            Type gt;
            if (!cachedTypes.TryGetValue(t, out gt))
            {
                gt = typeof(VirtualizationHelper).GetNestedType("TypedVirtualSource`1").MakeGenericType(t);

                cachedTypes.Add(t, gt);
            }

            return gt;
        }

        public static IEnumerable GetVirtualizedSource(IQueryable query)
        {
            Type t = query.ElementType;
            Type gt;
            if (!cachedTypes.TryGetValue(t, out gt))
            {
                gt = typeof(VirtualizationHelper).GetNestedType("TypedVirtualSource`1").MakeGenericType(t);

                cachedTypes.Add(t, gt);
            }

            return (IEnumerable)Activator.CreateInstance(gt, query);
        }

        public class TypedVirtualSource<T> : VirtualizingObservableCollection<T>
        {
            public TypedVirtualSource(IDataProvider provider, string repository)
                : base(new PaginationManager<T>(new Source(provider, repository)))
            {

            }

            public TypedVirtualSource(IOrderedQueryable query)
                : base(new PaginationManager<T>(new Source((IOrderedQueryable<T>)query)))
            {

            }


            public class Source : IPagedSourceProvider<T>
            {
                IDataProvider prv;
                string src;
                IOrderedQueryable<T> basequery;

                public Source(IOrderedQueryable<T> query)
                {
                    this.basequery = query;
                }

                public Source(IDataProvider provider, string repository)
                {
                    prv = provider;
                    src = repository;
                }

                public PagedSourceItemsPacket<T> GetItemsAt(int pageoffset, int count, bool usePlaceholder)
                {
                    var ret = new PagedSourceItemsPacket<T>();

                    ret.LoadedAt = DateTime.Now;
                    ret.Items = (basequery ?? ((IQueryable<T>)prv.GetData(src).OrderBy(prv.GetHeaders(src).First().Key))).Skip(pageoffset).Take(count).AsEnumerable();

                    return ret;
                }

                public int Count
                {
                    get { return (basequery ?? ((IQueryable<T>)prv.GetData(src))).Count(); }
                }

                public int IndexOf(T item)
                {
                    return (basequery ?? ((IQueryable<T>)prv.GetData(src))).ToList().IndexOf(item);
                }

                public void OnReset(int count)
                {
                }

                public async Task<int> GetCountAsync()
                {
                    return await Task.Run(() => Count);
                }

                public async Task<PagedSourceItemsPacket<T>> GetItemsAtAsync(int pageoffset, int count, bool usePlaceholder)
                {
                    return await Task.Run(() => GetItemsAt(pageoffset, count, usePlaceholder));
                }

                public T GetPlaceHolder(int index, int page, int offset)
                {
                    return GetItemsAt(0, 1, false).Items.First();
                }

                public async Task<int> IndexOfAsync(T item)
                {
                    return await Task.Run(() => IndexOf(item));
                }
            }
        }

        internal static void Init(Dispatcher dispatcher)
        {
            if (!VirtualizationManager.IsInitialized)
            {
                VirtualizationManager.Instance.UIThreadExcecuteAction = (a) => dispatcher.Invoke(a);
                new DispatcherTimer(TimeSpan.FromSeconds(1),
                                    DispatcherPriority.Background,
                                    (s, a) => VirtualizationManager.Instance.ProcessActions(),
                                    dispatcher).Start();
            }
        }
    }
}
