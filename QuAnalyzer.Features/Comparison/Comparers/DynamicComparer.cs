using System.Collections;
using System.Linq.Expressions;

using Wokhan.Core.Extensions;

namespace QuAnalyzer.Features.Comparison.Comparers;


public static class DynamicComparer
{
    public static IComparer Create(Type T, string[] properties)
    {
        return Create(T, T, properties, properties);
    }

    public static IComparer Create(Type TA, Type TB, string[] propertiesInA, string[] propertiesInB)
    {
        var dynType = typeof(DynamicComparer<,>).MakeGenericType(TA, TB);
        return (IComparer)Activator.CreateInstance(dynType, new object[] { propertiesInA, propertiesInB });
    }
}

public class DynamicComparer<TA, TB> : IComparer where TA : class where TB : class
{
    private Func<TA, object[]> PropertiesAsArrayA;
    private Func<TB, object[]> PropertiesAsArrayB;


    public DynamicComparer(string[] propertiesInA, string[] propertiesInB)
    {
        PropertiesAsArrayA = DynamicComparer<TA, TB>.GetExpression<TA>(propertiesInA);
        PropertiesAsArrayB = DynamicComparer<TA, TB>.GetExpression<TB>(propertiesInB);
    }

    private static Func<T, object[]> GetExpression<T>(params string[] properties)
    {
        var param = Expression.Parameter(typeof(T));
        var propertyGetExpression = properties.Select(property => Expression.Convert(Expression.Property(param, property), typeof(object))).ToArray();
        return Expression.Lambda<Func<T, object[]>>(Expression.NewArrayInit(typeof(object), propertyGetExpression), param).Compile();
    }

    public int Compare(object? x, object? y)
    {
        _ArgumentNullException.ThrowIfNull(x);
        _ArgumentNullException.ThrowIfNull(y);

        switch (x)
        {
            case null when y is null:
                return 0;
            case not null when y is null:
                return 1;
            case null when y is not null:
                return -1;
        }

        //TODO: Temporary test, might improve performance by caching the array...
        //var array = x.GetCustomProperty<object[]>("__Array");
        //if (array is null)
        //{
        //    array = PropertiesAsArrayA(x as TA);
        //    x.SetCustomProperty("__Array", array);
        //}

        //var arrayY = y.GetCustomProperty<object[]>("__Array");
        //if (arrayY is null)
        //{
        //    arrayY = PropertiesAsArrayB(y as TB);
        //    x.SetCustomProperty("__Array", arrayY);
        //}

        return SequenceComparer<object>.Default.Compare(PropertiesAsArrayA(x as TA), PropertiesAsArrayB(y as TB));
    }
}
