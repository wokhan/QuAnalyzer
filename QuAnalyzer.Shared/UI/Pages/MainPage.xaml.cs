using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Controls;

namespace QuAnalyzer.UI.Pages;

/// <summary>
/// Interaction logic for ModernMain.xaml
/// </summary>
public partial class MainPage
{
    private bool showMessageInProgress;

    public static MainPage Instance { get; private set; }

    public string AppName { get; } = $"QuAnalyzer {Assembly.GetExecutingAssembly().GetName().Version}";

    public MainPage()
    {
        Instance = this;

        InitializeComponent();

        App.Instance.Tasks.CollectionChanged += Tasks_CollectionChanged;

        Window window = App.Instance.MainWindow;
        window.ExtendsContentIntoTitleBar = true;  // enable custom titlebar
        window.SetTitleBar(AppTitleBar);

        //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        //Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
    }

    private void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        btnTasks.IsChecked = true;
    }

    private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        ForceDialog(e.Exception.Message, "Unexpected error");
        e.Handled = true;
    }

    ContentDialog dial;

    private async void ForceDialog(string message, string title)
    {
        //var dial = await new CustomDialog().show.GetCurrentDialogAsync<BaseMetroDialog>().ConfigureAwait(true);
        if (dial is not null)
        {
            dial.Title = title;
            dial.Content = message;
        }
        //TODO: might get useless (added when we encounter a bugged loop, inducing multiple error messages being spawned too fast)
        else if (!showMessageInProgress)
        {
            showMessageInProgress = true;

            dial = new ContentDialog() { Title = title, Content = message };
            await dial.ShowAsync();
            
            showMessageInProgress = false;
        }
    }

    private void CurrentDomain_UnhandledException(object sender, System.UnhandledExceptionEventArgs e)
    {
        ForceDialog(((Exception)e.ExceptionObject).Message, "Unexpected error");
        //this.ShowMessageAsync("Unexpected error", ((Exception)e.ExceptionObject).Message, MessageDialogStyle.Affirmative);
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

    public void ShowAbout()
    {
        flyAbout.Visibility = Visibility.Visible;
    }

    internal Task ShowProgress(string v1, string v2, bool v3)
    {
        throw new NotImplementedException();
    }

    private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.IsSettingsInvoked)
        {
            //ContentFrame.Navigate(typeof(SettingsPage));
        }
        else
        {
            // find NavigationViewItem with Content that equals InvokedItem
            var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
            NavView_Navigate(item as NavigationViewItem);
            App.Instance.CurrentSelectionLinked = NavView.TabIndex < 4;
        }
    }

    internal void ShowError(string message)
    {
        gridMain.Children.Add(new InfoBar() { IsOpen = true, Message = message, Severity = InfoBarSeverity.Error });
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
}
