namespace QuAnalyzer.Features.Comparison;

public record Diff(string Source, object[] Values, bool[]? IsDiff = null);
