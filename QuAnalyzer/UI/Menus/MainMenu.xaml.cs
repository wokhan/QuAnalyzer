using Microsoft.Win32;

using QuAnalyzer.UI.Windows;

using System.Windows;
using System.Windows.Controls;

namespace QuAnalyzer.UI.Menus;

/// <summary>
/// Logique d'interaction pour MainMenu.xaml
/// </summary>
public partial class MainMenu : UserControl
{
    public MainMenu()
    {
        InitializeComponent();
    }

    private void btnMenuRecent_Click(object sender, RoutedEventArgs e)
    {
        ((App)App.Current).CurrentProject.Open((string)((MenuItem)sender).CommandParameter);
    }

    private void btnAbout_Click(object sender, RoutedEventArgs e)
    {
        ((MainWindow)Window.GetWindow(this)).ShowAbout();
    }
}
