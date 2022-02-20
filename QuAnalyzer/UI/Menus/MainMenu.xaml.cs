
using CommunityToolkit.Mvvm.Input;

using QuAnalyzer.UI.Windows;

namespace QuAnalyzer.UI.Menus;

public partial class MainMenu : UserControl
{
    public MainMenu()
    {
        InitializeComponent();
    }

    [ICommand]
    private void OpenRecent(string fileName)
    {
        App.Instance.CurrentProject.Open(fileName);
    }

    [ICommand]
    private void About()
    {
        ((MainWindow)Window.GetWindow(this)).ShowAbout();
    }
}
