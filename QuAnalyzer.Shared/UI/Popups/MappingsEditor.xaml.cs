using CommunityToolkit.Mvvm.Input;

using QuAnalyzer.Features.Comparison;

namespace QuAnalyzer.UI.Popups;

public partial class MappingsEditor : Page
{
    private readonly SourcesMapper initialMap;
    public SourcesMapper CurrentMap { get; private set; }

    public MappingsEditor(SourcesMapper map = null)
    {
        initialMap = map ?? new SourcesMapper() { Name = "New mapping" };
        CurrentMap = initialMap.Clone();

        InitializeComponent();
    }
    
    [ICommand]
    private void Cancel() => Window.Current.Close();

    [ICommand]
    private void Save()
    {
        var projectMappers = ((App)App.Instance).CurrentProject.SourceMapper;
        if (projectMappers.Contains(initialMap))
        {
            projectMappers[projectMappers.IndexOf(initialMap)] = CurrentMap;
        }
        else
        {
            projectMappers.Add(CurrentMap);
        }
        Cancel();
    }
}
