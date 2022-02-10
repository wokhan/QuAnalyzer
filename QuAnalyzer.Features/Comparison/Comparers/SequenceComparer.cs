namespace QuAnalyzer.Features.Comparison.Comparers;

public class SequenceComparer<TItem> : IComparer<IEnumerable<TItem>> //where TItem : IComparable<TItem>
{
    public static SequenceComparer<TItem> Default { get; } = new();

    public SequenceComparer()
    {
        
    }

    public int Compare(IEnumerable<TItem>? x, IEnumerable<TItem>? y)
    {
        if (x is null || y is null)
        {
            throw new ArgumentException("Both arguments must implement IEnumerable<T>");
        }

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
                    internalResult = (e1.Current as IComparable).CompareTo(e2.Current);
                }
            }
        }

        return internalResult != 0 ? Math.Sign(internalResult) * index : 0;
    }
}
