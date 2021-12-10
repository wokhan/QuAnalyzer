
using Wokhan.Collections.Generic.Extensions;

namespace QuAnalyzer.Features.Comparison;

public partial class ResultStruct<T> : ResultStructBase
{
    public ItemResult<T> Source { get; } = new ItemResult<T>();
    public ItemResult<T> Target { get; } = new ItemResult<T>();

    public IEnumerable<DiffClass> MergedDiff { get; private set; } = null;

    public void InitDiff(IDataComparer r)
    {
        if (MergedDiff is null)
        {
            MergedHeaders = r.SourceHeaders.Select((header, index) => (srcHeader: header, targetHeader: r.TargetHeaders[index]))
                                           .Select(x => x.srcHeader + (x.srcHeader != x.targetHeader ? "/" + x.targetHeader : string.Empty))
                                           .ToArray();

            IEnumerable<object[]> sortedMiss;
            if (Source.Differences is not null)
            {
                sortedMiss = Source.Differences.Cast<object[]>().Select(m => m.Prepend(r.SourceName).ToArray());
            }
            else
            {
                sortedMiss = new List<object[]>();
            }

            IEnumerable<object[]> sortedTrg;
            if (Target.Differences is not null)
            {
                sortedTrg = Target.Differences.Cast<object[]>().Select(m => m.Prepend(r.TargetName).ToArray());
            }
            else
            {
                sortedTrg = new List<object[]>();
            }

            object[] prev = null;
            var all = sortedMiss.Concat(sortedTrg);
            var ordered = r.SourceKeys?.Count > 0 ? all.OrderByMany(r.SourceKeys.Count, 1) : all.OrderByAll(1);

            MergedDiff = ordered.ThenBy(t => t[0]).Select(x =>
            {
                var ret = new DiffClass()
                {
                    //IsDiff = (prev is null || prev[0].Equals(x[0]) || (sortSrc is not null && sortSrc.Any(i => !Object.Equals(prev[i], x[i]))) ? new bool[x.Length] : prev.Select((y, i) => !Object.Equals(y, x[i])).ToArray()),
                    IsDiff = prev is null || prev[0].Equals(x[0]) || r.SourceKeys?.Count > 0 && !prev.Skip(1).Take(r.SourceKeys.Count).SequenceEqual(x.Skip(1).Take(r.SourceKeys.Count)) ? new bool[x.Length] : prev.Select((y, i) => !Equals(y, x[i])).ToArray(),
                    Values = x
                };

                prev = x;

                return ret;
            });
        }
    }

    public string[] MergedHeaders { get; private set; }
}
