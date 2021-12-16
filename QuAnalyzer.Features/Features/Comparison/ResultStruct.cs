
using Wokhan.Collections.Generic.Extensions;

namespace QuAnalyzer.Features.Comparison;

public partial class ResultStruct<T> : ResultStructBase
{
    public ItemResult<T> Source { get; } = new ItemResult<T>();
    public ItemResult<T> Target { get; } = new ItemResult<T>();

    public string[] MergedHeaders { get; private set; }

    public IEnumerable<DiffClass> MergedDiff { get; private set; } = null;

    public void InitDiff(IDataComparer r)
    {
        if (MergedDiff is null)
        {
            MergedHeaders = r.SourceHeaders.Zip(r.TargetHeaders, (src, trg) => src + (src != trg ? "/" + trg : String.Empty)).ToArray();

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

            var allFalse = new bool[MergedHeaders.Length];
            MergedDiff = ordered.ThenBy(t => t[0]).Select(x =>
            {
                var ret = new DiffClass()
                {
                    IsDiff = prev is null || 
                             prev[0].Equals(x[0]) /* same origin: ignoring */ || 
                             r.SourceKeys?.Count > 0 && !prev.Skip(1).Take(r.SourceKeys.Count).SequenceEqual(x.Skip(1).Take(r.SourceKeys.Count)) 
                             ? allFalse
                             : prev.Zip(x, (a, b) => !Equals(a, b)).ToArray(),
                    Values = x
                };

                prev = x;

                return ret;
            });
        }
    }

}
