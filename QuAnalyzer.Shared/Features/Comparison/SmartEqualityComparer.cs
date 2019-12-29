using System;
using System.Collections.Generic;

namespace QuAnalyzer.Features.Comparison
{
    public class SmartEqualityComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T x, T y)
        {
            return x is DBNull && y == null || y is DBNull && x == null || object.Equals(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj == null || obj is DBNull ? 0 : obj.GetHashCode();
        }
    }
}
