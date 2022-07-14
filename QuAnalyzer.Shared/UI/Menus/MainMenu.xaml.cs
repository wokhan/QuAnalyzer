
using CommunityToolkit.Mvvm.Input;

using QuAnalyzer.Core.Helpers;

namespace QuAnalyzer.UI.Menus;

public partial class MainMenu : UserControl
{
    public MainMenu()
    {
        InitializeComponent();

        recentProjects.Items.AddAll(MRUManager.RecentFiles.Select(file => new MenuFlyoutItem() { Text = file.Key, Command = OpenRecentCommand, CommandParameter = file.Key, IsEnabled = file.Value, Icon = new SymbolIcon(Symbol.OpenFile) }));
    }

    [RelayCommand]
    private void OpenRecent(string fileName)
    {
        App.Instance.CurrentProject.Open(fileName);
    }
}
