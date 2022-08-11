using CommunityToolkit.Mvvm.Input;

using Microsoft.UI;
using Microsoft.UI.Windowing;
using QuAnalyzer.UI.Popups;

using Windows.ApplicationModel;

using WinRT.Interop;

namespace QuAnalyzer.UI.Pages;

public partial class MainPage
{
    public static MainPage Instance { get; private set; }

    public string AppName { get; } = $"QuAnalyzer {Assembly.GetExecutingAssembly().GetName().Version}";

    public ObservableCollection<dynamic> Messages { get; } = new ObservableCollection<dynamic>();

    public MainPage()
    {
        Instance = this;

        Loaded += MainPage_Loaded;

        InitializeComponent();

        App.Instance.Tasks.CollectionChanged += Tasks_CollectionChanged;


        // Only works on Win 11 yet.
        if (AppWindowTitleBar.IsCustomizationSupported())
        {
            var window = App.Instance.MainWindow;

            window.ExtendsContentIntoTitleBar = true;
            window.SetTitleBar(AppTitleBar);
        }

        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        Application.Current.UnhandledException += CurrentApp_UnhandledException;

        NavView_ItemInvoked(NavView, null);
    }

    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        var windowId = Win32Interop.GetWindowIdFromWindow(WindowNative.GetWindowHandle(App.Instance.MainWindow));

        AppWindow.GetFromWindowId(windowId).SetIcon(Package.Current.InstalledLocation.Path + "\\IconNew.ico");
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

    private void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        btnTasks.IsChecked = true;
    }


    //private void setTheme(object sender, RoutedEventArgs e)
    //{
    //    ThemeManager.ChangeTheme(Application.Current, ThemeManager.Accents.First(), ThemeManager.AppThemes.First());

    //    if (Close is not null)
    //    {
    //        ctxRecentFiles.IsOpen = false;
    //        ctxSaveAs.IsOpen = false;
    //        Close(this, null);
    //    }
    //}

    private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args?.IsSettingsInvoked ?? false)
        {
            ContentFrame.Navigate(typeof(About));
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
                ContentFrame.Navigate(typeof(ViewerPage));
                break;

            case "patterns":
                ContentFrame.Navigate(typeof(PatternsPage));
                break;

            case "statistics":
                ContentFrame.Navigate(typeof(StatisticsPage));
                break;

            case "duplicates":
                ContentFrame.Navigate(typeof(Duplicates));
                break;

            case "comparison":
                ContentFrame.Navigate(typeof(Compare));
                break;

            case "monitoring":
                ContentFrame.Navigate(typeof(Monitor));
                break;
        }
    }

    [RelayCommand]
    public void CloseInfo(dynamic message)
    {
        Messages.Remove(message);
    }




}
