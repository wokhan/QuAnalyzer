using CommunityToolkit.Mvvm.ComponentModel;

using Newtonsoft.Json;

using QuAnalyzer.Features.Comparison.Definition;

using System.Collections.ObjectModel;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Features.Comparison;

public partial class SourcesMapper : ObservableObject
{
    public static ObservableCollection<IDataProvider>? Providers { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    [ObservableProperty]
    private IDataProvider? source;

    private string? sourceName;
    public string? SourceName { get => source?.Name ?? sourceName; init => sourceName = value; }

    public string? SourceRepository { get; set; }

    [JsonIgnore]
    [ObservableProperty]
    private IDataProvider? target;

    private string? targetName;
    public string? TargetName { get => target?.Name ?? targetName; init => targetName = value; }

    public string? TargetRepository { get; set; }

    public ObservableCollection<SimpleMap> AllMappings { get; } = new();

    [ObservableProperty]
    private bool _isOrdered = false;

    public SourcesMapper(string? name = null)
    {
        Name = name ?? "New mapping";
    }

    [JsonConstructor]
    public SourcesMapper(string? name, string sourceName, string targetName) : this(name)
    {
        SourceName = sourceName;
        TargetName = targetName;

        Target = Providers?.FirstOrDefault(c => c.Name == TargetName);
        Source = Providers?.FirstOrDefault(c => c.Name == SourceName);
    }

    public SourcesMapper(IDataProvider source, string sourceRepository, IDataProvider target, string targetRepository, bool autoMapColumns = false, string? name = null, IEnumerable<SimpleMap>? allMappings = null)
    {
        Name = name ?? $"{source.Name} ({sourceRepository}) / {target.Name} ({targetRepository})";
        Source = source;
        Target = target;
        SourceRepository = sourceRepository;
        TargetRepository = targetRepository;

        if (autoMapColumns)
        {
            if (sourceRepository == targetRepository)
            {
                AllMappings.AddAll(source.GetColumns(sourceRepository).Select(h => h.Name).Intersect(target.GetColumns(targetRepository).Select(h => h.Name)).Select(k => new SimpleMap(k, k)));
            }
        }
        else if (allMappings is not null)
        {
            // TODO: check this as I guess it will have unwanted side effects on mappings update (as objects are reused and not duplicated...)
            AllMappings.AddAll(allMappings);
        }
    }

    public SourcesMapper Clone()
    {
        return new SourcesMapper(this.Source, this.SourceRepository, this.Target, this.TargetRepository, false, this.Name, this.AllMappings);
    }

}
