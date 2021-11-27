using System;
using System.Collections.Generic;

namespace QuAnalyzer.Features.Comparison;

public class DBNullAwareEqualityComparer<T> : IEqualityComparer<T>
{
    public bool Equals(T x, T y)
    {
        return x is DBNull && y is null || y is DBNull && x is null || object.Equals(x, y);
    }

    public int GetHashCode(T obj)
    {
        return obj is null || obj is DBNull ? 0 : obj.GetHashCode();
    }
}
