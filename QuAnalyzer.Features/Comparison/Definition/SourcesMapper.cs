using CommunityToolkit.Mvvm.ComponentModel;

using Newtonsoft.Json;

using QuAnalyzer.Features.Comparison.Definition;

using System.Collections.ObjectModel;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Features.Comparison;

public partial class SourcesMapper : ObservableObject
{
    public static ObservableCollection<IDataProvider>? Providers { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    public IDataProvider? Source
    {
        get { return Providers?.FirstOrDefault(c => c.Name == SourceName); }
        set { SourceName = value is not null ? value.Name : String.Empty; }
    }

    public string? SourceName { get; set; }

    public string? SourceRepository { get; set; }

    [JsonIgnore]
    public IDataProvider? Target
    {
        get { return Providers?.FirstOrDefault(c => c.Name == TargetName); }
        set { TargetName = value is not null ? value.Name : String.Empty; }
    }

    public string? TargetName { get; set; }

    public string? TargetRepository { get; set; }

    public List<SimpleMap> AllMappings { get; set; } = new();

    [ObservableProperty]
    private bool _isOrdered = false;
    
#pragma warning disable CS8618 // Le propriété 'Name' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
    public SourcesMapper()
#pragma warning restore CS8618 // Le propriété 'Name' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
    {
    }

    public SourcesMapper Clone()
    {
        return new SourcesMapper()
        {
            Name = this.Name,
            Source = this.Source,
            SourceRepository = this.SourceRepository,
            Target = this.Target,
            TargetRepository = this.TargetRepository,
            AllMappings = new(this.AllMappings)
        };
    }

}
