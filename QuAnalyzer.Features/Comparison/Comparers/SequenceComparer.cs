namespace QuAnalyzer.Features.Comparison.Comparers;

/// TODO: Review and improve, I don't like the current implementation
/// Maybe I should check the keys first, if equals, go on until it fails (or continue if not)
/// A perf test is required here to pick the best implementation.
public class SequenceComparer<T> : IComparer<IEnumerable<T>>
{
    public static SequenceComparer<T> Default { get; } = new();

    public SequenceComparer()
    {

    }

    public int Compare(IEnumerable<T>? x, IEnumerable<T>? y)
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

        int index = 0;
        int internalResult = 0;
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
        using (var e1 = x.GetEnumerator())
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
        using (var e2 = y.GetEnumerator())
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
        {
            while (internalResult == 0 && e1.MoveNext() && e2.MoveNext())
            {
                index++;
                // Null equality: keep moving
                if (e1.Current is DBNull && e2.Current is null || e1.Current is DBNull && e2.Current is null)
                {
                    continue;
                }

                if (e1.Current is string sxi)
                {
                    internalResult = string.CompareOrdinal(sxi, e2.Current as string);
                }
                else
                {
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
                    internalResult = ((IComparable)e1.Current).CompareTo((IComparable)e2.Current);
#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
                }
            }
        }

        return internalResult != 0 ? Math.Sign(internalResult) * index : 0;
    }
}
