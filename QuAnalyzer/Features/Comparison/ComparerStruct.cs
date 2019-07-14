using System;
using System.Collections.Generic;
using System.Threading;

namespace QuAnalyzer.Features.Comparison
{
    public class ComparerStruct<T> : IDataComparer
    {
        public string Name { get; set; }
        public string SourceName { get; set; }
        public string TargetName { get; set; }
        public IList<string> SourceKeys { get; set; }
        public IList<string> TargetKeys { get; set; }
        public Func<IEnumerable<T>> GetSourceData { get; set; }
        public Func<IEnumerable<T>> GetTargetData { get; set; }
        public IList<string> SourceHeaders { get; set; }
        public IList<string> TargetHeaders { get; set; }
        public IEqualityComparer<T> Comparer { get; set; }
        public IEqualityComparer<T> KeysComparer { get; set; }
        public bool IsOrdered { get; set; }

        public CancellationTokenSource TokenSource { get; private set; }

        public ResultStruct<T> Results { get; } = new ResultStruct<T>();

        public object[][] AsArray
        {
            get
            {
                return new object[][]
                {
                    new object[] { Name, SourceName, Results, Results.Source, this },
                    new object[] { Name, TargetName, Results, Results.Target, this }
                };
            }
        }

        public ComparerStruct()
        {
            TokenSource = new CancellationTokenSource();
        }
    }
}
