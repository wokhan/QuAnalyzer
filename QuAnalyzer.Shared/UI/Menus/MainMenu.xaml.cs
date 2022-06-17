
using CommunityToolkit.Mvvm.Input;

using QuAnalyzer.Core.Helpers;
using QuAnalyzer.UI.Pages;
using QuAnalyzer.UI.Windows;

namespace QuAnalyzer.UI.Menus;

public partial class MainMenu : UserControl
{
    public MainMenu()
    {
        InitializeComponent();

        recentProjects.Items.AddAll(MRUManager.RecentFiles.Select(file => new MenuFlyoutItem() { Text = file.Key, Tag = file.Value }));
    }

    [ICommand]
    private void OpenRecent(string fileName)
    {
        App.Instance.CurrentProject.Open(fileName);
    }

    [ICommand]
    private void About()
    {
        MainPage.Instance.ShowAbout();
    }
}
