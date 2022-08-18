using System.Collections;

#if !NET6_0_OR_GREATER
using ArgumentNullException = QuAnalyzer.Features.Exceptions.ExceptionsHelper._ArgumentNullException;
#endif

namespace QuAnalyzer.Features.Comparison.Comparers;

public class SequenceComparer<TItem> : IComparer<IEnumerable<TItem>>, IComparer //where TItem : IComparable<TItem>
{
    public static SequenceComparer<TItem> Default = new();

    public SequenceComparer()
    {

    }

    public int Compare(IEnumerable<TItem>? x, IEnumerable<TItem>? y)
    {
        ArgumentNullException.ThrowIfNull(x);
        ArgumentNullException.ThrowIfNull(y);

        switch (x)
        {
            case null when y is null:
                return 0;
            case not null when y is null:
                return 1;
            case null when y is not null:
                return -1;
        }

        int index = 0;
        int internalResult = 0;
        //using (var e1 = x.GetEnumerator())
        //using (var e2 = y.GetEnumerator())
        var e1 = x.GetEnumerator();
        var e2 = y.GetEnumerator();
        {
            while (internalResult == 0 && e1.MoveNext() && e2.MoveNext())
            {
                index++;
                // Null equality for both: keep moving as we consider them equal. It's a design choice, btw.
                if (e1.Current is DBNull or null && e2.Current is DBNull or null)
                {
                    continue;
                }

                if (e1.Current is string sxi)
                {
                    internalResult = string.CompareOrdinal(sxi, e2.Current as string);
                }
                else
                {
                    internalResult = (e1.Current as IComparable)?.CompareTo(e2.Current) ?? 1;
                }
            }
        }

        return internalResult != 0 ? Math.Sign(internalResult) * index : 0;
    }

    public int Compare(object? x, object? y)
    {
        return Compare(x as IEnumerable<TItem>, y as IEnumerable<TItem>);
    }
}
