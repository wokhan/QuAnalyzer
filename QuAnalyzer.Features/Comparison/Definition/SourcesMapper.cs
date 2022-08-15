using CommunityToolkit.Mvvm.ComponentModel;

using QuAnalyzer.Features.Comparison.Definition;

using System.Collections.ObjectModel;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Features.Comparison;

public partial class SourcesMapper : ObservableObject
{
    public string Name { get; set; }

    [ObservableProperty]
    private IDataProvider? source;

    public string? SourceRepository { get; set; }

    [ObservableProperty]
    private IDataProvider? target;

    public string? TargetRepository { get; set; }

    [ObservableProperty]
    private bool _isOrdered = false;

    public ObservableCollection<SimpleMap> AllMappings { get; } = new();

    public SourcesMapper(string? name = null)
    {
        Name = name ?? "New mapping";
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
