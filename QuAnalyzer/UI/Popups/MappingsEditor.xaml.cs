using QuAnalyzer.Features.Comparison;

using System.Windows;
using System.Windows.Controls;

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


    private void btnCancel_Click(object sender, RoutedEventArgs e) => closeParent();
    private void closeParent() => Window.GetWindow(this).Close();

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        var projectMappers = ((App)App.Current).CurrentProject.SourceMapper;
        if (projectMappers.Contains(initialMap))
        {
            projectMappers[projectMappers.IndexOf(initialMap)] = CurrentMap;
        }
        else
        {
            projectMappers.Add(CurrentMap);
        }
        closeParent();
    }
}
