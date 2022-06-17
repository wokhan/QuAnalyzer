using System.Diagnostics.CodeAnalysis;

namespace QuAnalyzer.Features.Exceptions;
internal partial class ExceptionsHelper
{
    internal partial class _ArgumentNullException
    {
        public static void ThrowIfNull([NotNull] object? argument, [CallerArgumentExpression("argument")] string? paramName = null)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
