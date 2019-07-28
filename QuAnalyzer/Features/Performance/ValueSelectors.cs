using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuAnalyzer.Features.Performance
{
    public static class ValueSelectors
    {
        static Random rnd = new Random();

        public delegate IList<Dictionary<string, string>> Selector(IList<Dictionary<string, string>> src, int ix);

        public static Selector SequentialSelector = (src, ix) => new[] { src[ix % src.Count] };
        public static Selector RandomSelector = (src, ix) => new[] { src[rnd.Next(0, src.Count)] };

        public static Selector AsBulk(this Selector selector, int bulkSize) => (src, ix) => Enumerable.Range(0, bulkSize).SelectMany(i => selector(src, i + ix * bulkSize)).ToList();

        //static Dictionary<object, Dictionary<string, string>> markers = new Dictionary<object, Dictionary<string, string>>();
        //public static Selector Distinct(this Selector selector, object marker) => (src, ix) => { var ret = selector(src, ix); while (markers[marker].ContainsKey};

        //public static Selector CreateBulkSelector(int bulkSize, Selector selector) => (src, ix) => Enumerable.Range(0, bulkSize).SelectMany(i => selector(src, i + ix * bulkSize)).ToList();


    }
}
