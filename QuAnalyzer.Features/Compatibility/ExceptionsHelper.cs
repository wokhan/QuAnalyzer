using System.Diagnostics.CodeAnalysis;
#if !NET6_0_OR_GREATER

using System.Runtime.CompilerServices;

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

#endif