using QuAnalyzer.Core.Helpers;
using QuAnalyzer.UI.Pages;

namespace QuAnalyzer.UI.Popups;

[ObservableObject]
public partial class About : Page
{
#if !HAS_UNO
    public int BackgroundMode
    {
        get => (int)MicaBackground.CurrentMode;
        set => MicaBackground.TrySetBackdrop(App.Instance.MainWindow, (MicaBackground.BackgroundMode)value);
    }
#else
    public int BackgroundMode
    {
        get => 0;
        set { }
    }
#endif
    public int SelectedTheme
    {
        get => (int)MainPage.Instance.RequestedTheme;
        set => MainPage.Instance.RequestedTheme = (ElementTheme)value;
    }

    public About()
    {
        InitializeComponent();

        settingsContent.Content = settings.Tag;
    }

    private void NavSettings_Invoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        settingsContent.Content = args.InvokedItemContainer.Tag;
    }
}
