namespace QuAnalyzer.UI.Windows;

/// <summary>
/// Interaction logic for ProviderPage.xaml
/// </summary>
public partial class Popup : Window
{
    private Popup(Page content)
    {
        InitializeComponent();

        GoToPage(content);
    }

    private void Container_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
    {
        this.Title = ((Page)e.Content).Title;
    }

    public void GoToPage(Page content)
    {
        container.Navigate(content);
    }

    internal static Popup OpenNew(Page content)
    {
        var instance = new Popup(content);
        instance.Show();
        instance.Activate();

        return instance;
    }
}
