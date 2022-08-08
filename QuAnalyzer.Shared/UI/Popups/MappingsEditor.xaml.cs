using CommunityToolkit.Mvvm.Input;

using LiveChartsCore.Geo;

using Microsoft.UI.Xaml.Navigation;

using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Comparison.Definition;
using QuAnalyzer.UI.Windows;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Popups;

[ObservableObject]
public partial class MappingsEditor : Page
{
    private SourcesMapper initialMap;

    [ObservableProperty]
    private bool isPopup;

    [ObservableProperty]
    private SourcesMapper mapping;

    public MappingsEditor()
    {
        this.Loaded += MappingsEditor_Loaded;

        InitializeComponent();
    }

    private static readonly DependencyProperty InitialMappingProperty = DependencyProperty.Register(nameof(InitialMapping), typeof(SourcesMapper), typeof(MappingsEditor), new PropertyMetadata(null));

    public SourcesMapper InitialMapping
    {
        get => (SourcesMapper)GetValue(InitialMappingProperty);
        set { SetValue(InitialMappingProperty, value); cloneMappingForEdit(); }
    }

    public ObservableCollection<string> SourceAttributes { get; } = new();

    public ObservableCollection<string> TargetAttributes { get; } = new();

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        InitialMapping = (SourcesMapper)e.Parameter;

        if (IsPopup)
        {
            gridMain.Margin = new Thickness(20);
            GenericPopup.UpdateCurrent(this, isLastStep: true, nextButtonCommand: SaveCommand);
            GenericPopup.UpdateCurrent(this, title: $"Edit mapping: {Mapping.Name}");
        }
    }

    private void cloneMappingForEdit()
    {
        InitialMapping ??= new SourcesMapper();
        Mapping = InitialMapping.Clone();
    }

    [RelayCommand]
    private void AddMapping()
    {
        Mapping.AllMappings.Add(new SimpleMap());
    }

    [RelayCommand]
    private void ClearAll()
    {
        Mapping.AllMappings.Clear();
    }

    private void lstSrcRepo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        SetAttributes((IDataProvider)lstSrc.SelectedItem, (string)lstSrcRepo.SelectedItem, SourceAttributes);
    }

    private void lstTrgRepo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        SetAttributes((IDataProvider)lstTrg.SelectedItem, (string)lstTrgRepo.SelectedItem, TargetAttributes);
    }

    [RelayCommand]
    private void MapByName()
    {
        Mapping.AllMappings.ReplaceAll(SourceAttributes.Where(s => TargetAttributes.Contains(s)).Select(s => new SimpleMap(s, s)));

    }

    [RelayCommand]
    private void MapByPosition()
    {
        Mapping.AllMappings.ReplaceAll(SourceAttributes.Take(TargetAttributes.Count).Zip(TargetAttributes, (s, i) => new SimpleMap(s, i)));
    }

    private void MappingsEditor_Loaded(object sender, RoutedEventArgs e)
    {
        IsPopup = GenericPopup.FromPage(this) is not null;
    }

    [RelayCommand]
    private void RemoveMapping(SimpleMap mapping)
    {
        Mapping.AllMappings.Remove(mapping);
    }

    [RelayCommand]
    private void Save()
    {
        var projectMappers = App.Instance.CurrentProject.SourceMapper;
        if (projectMappers.Contains(InitialMapping))
        {
            projectMappers[projectMappers.IndexOf(InitialMapping)] = Mapping;
        }
        else
        {
            projectMappers.Add(Mapping);
        }
    }

    private void SetAttributes(IDataProvider prov, string repo, ObservableCollection<string> attributes)
    {
        attributes.Clear();

        if (prov is not null && repo is not null)
        {
            attributes.AddAll(prov.GetColumns(repo).Select(a => a.Name));
        }
    }
}
