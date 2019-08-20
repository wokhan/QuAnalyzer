using System;
using System.Collections.Generic;
using System.Linq;

namespace QuAnalyzer.Features.Comparison
{
    public class SequenceComparer : IComparer<IEnumerable<object>>
    {
        private static SequenceEqualityComparer<object> sec = new SequenceEqualityComparer<object>();
        private string[] keys;

        public SequenceComparer()
        {
            keys = null;
        }

        public SequenceComparer(params string[] keys)
        {
            this.keys = keys;
        }

        public int Compare(IEnumerable<object> x, IEnumerable<object> y)
        {
            if (sec.Equals(x, y))
            {
                return 0;
            }

            if (sec.Equals(keys.Select((k, i) => x.ElementAt(i)), keys.Select((k, i) => y.ElementAt(i))))
            {
                return int.MaxValue;
            }

            var id = keys.Select((k, i) => i)
                       .SkipWhile(i => x.ElementAt(i).Equals(y.ElementAt(i)))
                       .First();

            var xi = x.ElementAt(id);
            var yi = y.ElementAt(id);
            if (xi is string)
            {
                return string.CompareOrdinal((string)xi, (string)yi);
            }

            return ((IComparable)xi).CompareTo((IComparable)yi);
        }
    }
}
