using System.Collections.Generic;

namespace QuAnalyzer.Features.Comparison.Comparers;

/// TODO: Review and improve, I don't like the current implementation
/// Maybe I should check the keys first, if equals, go on until it fails (or continue if not)
/// A perf test is required here to pick the best implementation.
public class SequenceComparer<T, TInner> : IComparer<T> where T : IEnumerable<TInner>
{
    private static readonly SequenceEqualityComparer<T, TInner> fullComparer = new();
    private readonly SequenceEqualityComparer<T, TInner> keysComparer;

    public SequenceComparer()
    {
        keysComparer = new();
    }

    public SequenceComparer(int? keyFieldsCount = null)
    {
        if (keyFieldsCount is null)
        {
            keysComparer = SequenceEqualityComparer<T, TInner>.Default;
        }
        else
        {
            keysComparer = new(0, (int)keyFieldsCount);
        }
    }

    public int Compare(T? x, T? y)
    {
        switch (x)
        {
            case null when y is null:
                return 0;
            case not null when y is null:
                return 1;
            case null when y is not null:
                return -1;
        }

        if (fullComparer.Equals(x, y))
        {
            return 0;
        }

        // If there is a difference, but not regarding the keys: values are different, so we check that first
        if (keysComparer is not null && keysComparer.Equals(x, y))
        {
            return int.MaxValue;
        }

        // Else if the keys are different (or if there are no keys), we check the first different item
        var (xi, yi, index) = x.Zip(y, Enumerable.Range(0, x.Count())).First(xy => !xy.First.Equals(xy.Second));

        int internalResult = 0;
        if (xi is string sxi)
        {
            internalResult = string.CompareOrdinal(sxi, yi as string);
        }
        else
        {
            internalResult = ((IComparable)xi).CompareTo((IComparable)yi);
        }

        return Math.Sign(internalResult) * (index + 1);
    }
}
