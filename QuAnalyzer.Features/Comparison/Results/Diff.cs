namespace QuAnalyzer.Features.Comparison.Results;

public record Diff<T>(string Source, T Values, bool[]? IsDiff = null);
