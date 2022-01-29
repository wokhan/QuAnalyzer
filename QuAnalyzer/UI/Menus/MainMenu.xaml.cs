
using QuAnalyzer.UI.Windows;

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
        ((App)App.Instance).CurrentProject.Open((string)((MenuItem)sender).CommandParameter);
    }

    private void btnAbout_Click(object sender, RoutedEventArgs e)
    {
        ((MainWindow)Window.GetWindow(this)).ShowAbout();
    }
}
