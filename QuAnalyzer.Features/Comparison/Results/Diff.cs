namespace QuAnalyzer.Features.Comparison.Results;

public record Diff(string Source, object[] Values, bool[]? IsDiff = null);
