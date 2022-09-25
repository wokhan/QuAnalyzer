using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Navigation;

using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Comparison.Definition;
using QuAnalyzer.UI.Windows;

namespace QuAnalyzer.UI.Popups;

[ObservableObject]
public partial class MappingsEditor : Page
{
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

    public IEnumerable<string> SourceAttributes => Mapping.Source?.GetColumns(Mapping.SourceRepository).Select(column => column.Name);

    public IEnumerable<string> TargetAttributes => Mapping.Target?.GetColumns(Mapping.SourceRepository).Select(column => column.Name);

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


    private void DefinitionSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.RemovedItems.Any())
        {
            Mapping.AllMappings.Clear();

            OnPropertyChanged(nameof(SourceAttributes));
            OnPropertyChanged(nameof(TargetAttributes));
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

    [RelayCommand]
    private void MapByName()
    {
        Mapping.AllMappings.ReplaceAll(SourceAttributes.Where(s => TargetAttributes.Contains(s)).Select(s => new SimpleMap(s, s)));

    }

    [RelayCommand]
    private void MapByPosition()
    {
        Mapping.AllMappings.ReplaceAll(SourceAttributes.Take(TargetAttributes.Count()).Zip(TargetAttributes, (s, i) => new SimpleMap(s, i)));
    }

    private void MappingsEditor_Loaded(object sender, RoutedEventArgs e)
    {
        IsPopup = GenericPopup.FromPage(this) is not null;
    }


    private void removeMapping_Click(object sender, RoutedEventArgs e)
    {
        var mapping = (SimpleMap)((Button)sender).CommandParameter;

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
}
