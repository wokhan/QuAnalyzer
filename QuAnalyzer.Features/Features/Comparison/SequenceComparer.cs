namespace QuAnalyzer.Features.Comparison;

public class SequenceComparer : IComparer<IEnumerable<object>>
{
    private static readonly SequenceEqualityComparer<object> seqComparer = new();
    private readonly string[]? keys;

    public SequenceComparer()
    {
        keys = null;
    }

    public SequenceComparer(params string[] keys)
    {
        this.keys = keys;
    }

    public int Compare(IEnumerable<object>? x, IEnumerable<object>? y)
    {
        if (seqComparer.Equals(x, y))
        {
            return 0;
        }

        if (seqComparer.Equals(keys.Zip(x, (_, x) => x), keys.Zip(x, (_, x) => x)))
        {
            return int.MaxValue;
        }

        /*
        var id = keys.Select((k, i) => i)
                   .SkipWhile(i => x.ElementAt(i).Equals(y.ElementAt(i)))
                   .First();

        var xi = x.ElementAt(id);
        var yi = y.ElementAt(id);
        */
        var (_, xi, yi) = keys.Zip(x, y)
                              .First(xy => !xy.Second.Equals(xy.Third));

        if (xi is string sxi)
        {
            return string.CompareOrdinal(sxi, (string)yi);
        }

        return ((IComparable)xi).CompareTo((IComparable)yi);
    }
}
