using System;
using System.Collections.Generic;

namespace QuAnalyzer.Features.Comparison
{
    public class SmartEqualityComparer : IEqualityComparer<object>
    {
        public new bool Equals(object x, object y)
        {
            return x is DBNull && y == null || y is DBNull && x == null || object.Equals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return obj == null || obj is DBNull ? 0 : obj.GetHashCode();
        }
    }
}
