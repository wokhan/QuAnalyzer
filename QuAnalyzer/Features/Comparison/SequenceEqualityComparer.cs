using System;
using System.Collections.Generic;
using System.Linq;

namespace QuAnalyzer.Features.Comparison
{
    public class SequenceEqualityComparer : IEqualityComparer<IEnumerable<object>>
    {
        private static IEqualityComparer<object> cmp = new SmartEqualityComparer();// EqualityComparer<object>.Default;

        private int startFrom;
        private int maxCount;

        public SequenceEqualityComparer(int startFrom = 0, int maxCount = int.MaxValue)
        {
            this.startFrom = startFrom;
            this.maxCount = maxCount;
        }

        public bool Equals(IEnumerable<object> x, IEnumerable<object> y)
        {
            return x.Skip(startFrom).Take(maxCount).SequenceEqual(y.Skip(startFrom).Take(maxCount), cmp);
        }

        // Computes an aggregated Hash Code to speed up comparison process.
        // If two hashcodes are different, then it means that the object are different. Calling Equals is only required
        // if two hashcodes are equal (meaning that equality will be checked at a deeper level).
        // To ensure that Equals is always called, you can return 0.
        public int GetHashCode(IEnumerable<object> obj)
        {
            return obj.Skip(startFrom).Take(maxCount).Aggregate(17, (a, i) => a * 23 + (i == null || i is DBNull ? 0 : i.GetHashCode()));
        }
    }
}
