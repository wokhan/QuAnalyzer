namespace QuAnalyzer.Features.Comparison.Results;

public record Diff(string Origin, object Value, bool IsTarget = false, bool IsDiff = false);
