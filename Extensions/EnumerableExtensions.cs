using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Wokhan.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static int GreatestCommonDiv(this IEnumerable<int> src)
        {
            return src.OrderBy(a => a).Aggregate((a, b) => GreatestCommonDiv(a, b));
        }

        private static int GreatestCommonDiv(int a, int b)
        {
            int rem;

            while (b != 0)
            {
                rem = a % b;
                a = b;
                b = rem;
            }

            return a;
        }


        public static IEnumerable<object[]> AsObjectCollection(this IEnumerable src, params string[] attributes)
        {
            return AsObjectCollection<object>(src.Cast<object>(), attributes);
        }

        public static IEnumerable<object[]> AsObjectCollection<T>(this IEnumerable<T> src, params string[] attributes)
        {
            var innertype = src.GetInnerType();
            if (innertype.IsArray)
            {
                return ((IEnumerable<object[]>)src);
            }
            else
            {

                if (attributes == null)
                {
                    attributes = innertype.GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(a => a.Name).ToArray();
                }

                var param = Expression.Parameter(typeof(object));
                var expa = Expression.Parameter(typeof(Exception));
                var ide_cstr = typeof(InvalidDataException).GetConstructor(new[] { typeof(string), typeof(Exception) });

                var casted = Expression.Convert(param, innertype);

                var atrs = attributes.Select(a =>
                    TryExpression.TryCatch(
                        BlockExpression.Block(
                            Expression.Convert(Expression.Property(casted, a), typeof(object))
                        ),
                    TryExpression.Catch(expa,
                        Expression.Block(
                            Expression.Throw(NewExpression.New(ide_cstr, Expression.Constant(a), expa)),
                            Expression.Constant(null))))
                ).ToList();

                var attrExpr = Expression.Lambda<Func<T, object[]>>(Expression.NewArrayInit(typeof(object), atrs), param).Compile();

                return src.Select(x => { if (x == null) { throw new Exception("WTF????"); } return attrExpr(x); });
            }
        }

        //public static IEnumerable<object[]> AsObjectCollection(this IEnumerable src, params string[] attributes)
        //{
        //    var innertype = src.GetInnerType();
        //    if (innertype.IsArray)
        //    {
        //        return ((IEnumerable<object[]>)src);
        //    }
        //    else
        //    {
        //        var param = Expression.Parameter(typeof(object));
        //        var attrExpr = Expression.Lambda<Func<T, object[]>>(Expression.NewArrayInit(typeof(object), attributes.Select(a => Expression.Convert(Expression.Property(Expression.Convert(param, innertype), a), typeof(object)))), param).Compile();

        //        return ((IEnumerable<dynamic>)src).Select(attrExpr);
        //    }
        //}

        public static Type GetInnerType<T>(this IEnumerable<T> src)
        {
            return src.GetType().GenericTypeArguments.FirstOrDefault();
        }

        public static Type GetInnerType(this IEnumerable src)
        {
            return src.GetType().GenericTypeArguments.FirstOrDefault();
        }


        public static IOrderedEnumerable<T[]> OrderByMany<T>(this IEnumerable<T[]> obj, int[] indexes)
        {
            IOrderedEnumerable<T[]> ret = obj.OrderBy(a => a.Length > 0 ? a[indexes[0]] : default(T));
            for (int i = 1; i < indexes.Length; i++)
            {
                var ic = i;
                ret = ret.ThenBy(a => a.Length > ic ? a[ic] : default(T));
            }

            return ret;
        }

        public static IOrderedQueryable<dynamic> OrderByMany<T>(this IQueryable<T> src, Dictionary<string, Type> attributes)
        {
            var innertype = src.GetInnerType();
            var m = typeof(EnumerableExtensions).GetMethod("OrderByManyTyped").MakeGenericMethod(innertype);
            return (IOrderedQueryable<dynamic>)m.Invoke(null, new object[] { src, attributes });
        }

        public static IOrderedQueryable<T> OrderByManyTyped<T>(IQueryable<T> src, Dictionary<string, Type> attributes)
        {
            var param = ParameterExpression.Parameter(typeof(T));

            var ret = src.OrderBy(Expression.Lambda<Func<T, dynamic>>(Expression.Property(param, attributes.First().Key), param));
            foreach (var attr in attributes.Skip(1))
            {
                ret = ret.ThenBy(Expression.Lambda<Func<T, dynamic>>(Expression.Property(param, attr.Key), param));
            }

            return ret;
        }

        public static IOrderedEnumerable<T[]> OrderByMany<T>(this IEnumerable<T[]> obj, int columnsToTake, int columnsToSkip = 0)
        {
            IOrderedEnumerable<T[]> ret = obj.OrderBy(a => a.Length > columnsToSkip ? a[columnsToSkip] : default(T));
            for (int i = columnsToSkip + 1; i < columnsToSkip + columnsToTake; i++)
            {
                var ic = i;
                ret = ret.ThenBy(a => a.Length > ic ? a[ic] : default(T));
            }

            return ret;
        }


        public static IOrderedQueryable<T[]> OrderByMany<T>(this IQueryable<T[]> obj, int columnsToTake, int columnsToSkip = 0)
        {
            IOrderedQueryable<T[]> ret = obj.OrderBy(a => a.Length > columnsToSkip ? a[columnsToSkip] : default(T));
            for (int i = columnsToSkip + 1; i < columnsToSkip + columnsToTake; i++)
            {
                var ic = i;
                ret = ret.ThenBy(a => a.Length > ic ? a[ic] : default(T));
            }

            return ret;
        }
        public static IOrderedEnumerable<T[]> OrderByAll<T>(this IEnumerable<IEnumerable<T>> obj, int skip = 0)
        {
            return obj.Select(o => o.ToArray()).OrderByAll(skip);
        }

        public static IOrderedEnumerable<T> OrderByAll<T>(this IEnumerable<T> obj, int skip = 0)
        {
            var allmembers = typeof(T).GetFields().Where(m => typeof(IComparable).IsAssignableFrom(m.FieldType)).ToArray();
            IOrderedEnumerable<T> ret = obj.OrderBy(m => allmembers[skip].GetValue(m));
            for (int i = 1 + skip; i < allmembers.Length - 1; i++)
            {
                var ic = i;
                ret = ret.ThenBy(a => allmembers[ic].GetValue(a));
            }

            return ret;
        }

        public static IOrderedQueryable<dynamic> OrderByAll<T>(this IQueryable<T> src)
        {
            var innertype = src.GetInnerType();
            var m = typeof(EnumerableExtensions).GetMethod("OrderByAllTyped").MakeGenericMethod(innertype);
            return (IOrderedQueryable<dynamic>)m.Invoke(null, new object[] { src, 0 });
        }

        public static IOrderedQueryable<T> OrderByAllTyped<T>(this IQueryable<T> obj, int skip = 0)
        {
            var allmembers = typeof(T).GetProperties().Where(m => m.PropertyType.IsGenericType || typeof(IComparable).IsAssignableFrom(m.PropertyType)).ToArray();

            IOrderedQueryable<T> ret = obj.OrderBy(m => allmembers[skip].GetValue(m));
            for (int i = skip; i < allmembers.Length; i++)
            {
                var ic = i;
                ret = ret.ThenBy(a => allmembers[ic].GetValue(a));
            }

            return ret;
        }

        public static void ReplaceAll<T>(this ObservableCollection<T> src, IEnumerable<T> all)
        {
            src.Clear();

            src.AddAll(all);
        }


        public static ParallelQuery<T> AsParallel<T>(this IEnumerable<T> source, bool useParallelism)
        {
            var ret = source.AsParallel();
            return (useParallelism ? ret : ret.WithDegreeOfParallelism(1));
        }

        public static void AddAll<T>(this ICollection<T> src, IEnumerable<T> all)
        {
            foreach (var x in all)
            {
                src.Add(x);
            }
        }



        public static object AverageChecked<T>(this IEnumerable<T> src, bool ignoreErrors = false)
        {
            try
            {
                var converter = new DoubleConverter();
                var s = src;
                if (ignoreErrors)
                {
                    s = s.Where(c => converter.IsValid(c));
                }
                return src.Average(x => (double)converter.ConvertFrom(x));
            }
            catch
            {
                return "N/A";
            }
        }

        public static DataTable AsDataTable(this IEnumerable<object[]> collection, string name, DataColumn[] cols)
        {
            DataTable ret = new DataTable(name);
            ret.Columns.AddRange(cols);

            ret.BeginLoadData();

            foreach (var o in collection)
            {
                ret.Rows.Add(o);
            }

            ret.EndLoadData();
            //ret.AcceptChanges();

            return ret;
        }
    }
}
