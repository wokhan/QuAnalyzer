
using CommunityToolkit.Mvvm.Input;

using QuAnalyzer.Core.Helpers;
using QuAnalyzer.Core.Project;

namespace QuAnalyzer.UI.Menus;

public partial class MainMenu : UserControl
{
    /// <summary>
    /// This is to bypass a bug with Uno Platform where TwoWay static bindings through x:Bind don't seem to work. Weird since
    /// according to GitHub, it should...
    /// </summary>
    public ProjectSettings CurrentProject => App.Instance.CurrentProject;

    public MainMenu()
    {
        InitializeComponent();

        recentProjects.Items.AddAll(MRUManager.RecentFiles.Select(file => new MenuFlyoutItem() { Text = file.Key, Command = App.Instance.CurrentProject.OpenCommand, CommandParameter = file.Key, IsEnabled = file.Value, Icon = new SymbolIcon(Symbol.OpenFile) }));
    }
}
