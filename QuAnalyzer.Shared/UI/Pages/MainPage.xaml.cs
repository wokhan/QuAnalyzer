using CommunityToolkit.Mvvm.Input;

using Microsoft.UI;
using Microsoft.UI.Windowing;

using QuAnalyzer.Core.Project;
using QuAnalyzer.UI.Popups;

using Windows.ApplicationModel;

#if !HAS_UNO
using WinRT.Interop;
#endif

namespace QuAnalyzer.UI.Pages;

public partial class MainPage : Page
{
    /// <summary>
    /// This is to bypass a bug with Uno Platform where TwoWay static bindings through x:Bind don't seem to work. Weird since
    /// according to GitHub, it should...
    /// </summary>
    public ProjectSettings CurrentProject => App.Instance.CurrentProject;
    public Window MainWindow => App.Instance.MainWindow;

#if HAS_UNO
    //TODO: update to take this from another place (project properties? assembly name?)
    public string WindowTitle => "QuAnalyzer";
#else
    public string WindowTitle => App.Instance.MainWindow.Title;
#endif

    private About aboutPage;
    private ViewerPage viewerPage;
    private PatternsPage patternsPage;
    private StatisticsPage statisticsPage;
    private Duplicates duplicatesPages;
    private Compare comparePage;
    private Monitor monitorPage;

    public static MainPage Instance { get; private set; }

    public string AppName { get; } = $"QuAnalyzer {Assembly.GetExecutingAssembly().GetName().Version}";

    public ObservableCollection<dynamic> Messages { get; } = new ObservableCollection<dynamic>();

    public MainPage()
    {
        Instance = this;

        Loaded += MainPage_Loaded;

        InitializeComponent();

#if !HAS_UNO
        // Only works on Win 11 yet.
        if (AppWindowTitleBar.IsCustomizationSupported())
        {
            var window = App.Instance.MainWindow;

            window.ExtendsContentIntoTitleBar = true;
            window.SetTitleBar(AppTitleBar);
        }
#endif

        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        Application.Current.UnhandledException += CurrentApp_UnhandledException;

        NavView_ItemInvoked(NavView, null);
    }

    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
#if !HAS_UNO
        var windowId = Win32Interop.GetWindowIdFromWindow(WindowNative.GetWindowHandle(App.Instance.MainWindow));

        AppWindow.GetFromWindowId(windowId).SetIcon(Package.Current.InstalledLocation.Path + "\\IconNew.ico");
#endif
    }

    private void CurrentApp_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        Messages.Add(new { Content = e.Exception.Message, Title = "Unexpected error", Severity = InfoBarSeverity.Error });
        e.Handled = true;
    }

    private void CurrentDomain_UnhandledException(object sender, System.UnhandledExceptionEventArgs e)
    {
        Messages.Add(new { Content = ((Exception)e.ExceptionObject).Message, Title = "Unexpected error", Severity = InfoBarSeverity.Error });
    }

    private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args?.IsSettingsInvoked ?? false)
        {
            ContentFrame.Content = aboutPage ??= new About();
        }
        else
        {
            // find NavigationViewItem with Content that equals InvokedItem
            var item = args is not null ? sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem) : sender.MenuItems.OfType<NavigationViewItem>().First();
            NavView_Navigate(item);
            App.Instance.CurrentSelectionLinked = NavView.MenuItems.IndexOf(item) < 4;
        }
    }

    private void NavView_Navigate(NavigationViewItem item)
    {
        switch (item.Tag)
        {
            case "display":
                ContentFrame.Content = viewerPage ??= new ViewerPage();
                break;

            case "patterns":
                ContentFrame.Content = patternsPage ??= new PatternsPage();
                break;

            case "statistics":
                ContentFrame.Content = statisticsPage ??= new StatisticsPage();
                break;

            case "duplicates":
                ContentFrame.Content = duplicatesPages ??= new Duplicates();
                break;

            case "comparison":
                ContentFrame.Content = comparePage ??= new Compare();
                break;

            case "monitoring":
                ContentFrame.Content = monitorPage ??= new Monitor();
                break;
        }
    }

    [RelayCommand]
    public void CloseInfo(dynamic message)
    {
        Messages.Remove(message);
    }
}
