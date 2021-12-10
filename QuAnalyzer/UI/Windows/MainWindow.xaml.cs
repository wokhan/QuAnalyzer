using MahApps.Metro.Controls.Dialogs;

using System;
using System.Collections.Specialized;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QuAnalyzer.UI.Windows;

/// <summary>
/// Interaction logic for ModernMain.xaml
/// </summary>
public partial class MainWindow
{
    private bool showMessageInProgress;

    public string AppName { get; } = $"QuAnalyzer {Assembly.GetExecutingAssembly().GetName().Version}";

    public MainWindow()
    {
        InitializeComponent();

        App.Instance.Tasks.CollectionChanged += Tasks_CollectionChanged;

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

    CustomDialog dial;
    private void ForceDialog(string message, string title)
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
            dial = new CustomDialog() { Title = title, Content = message };
            dial.ShowModalDialogExternally(this);
            //await this.ShowMessageAsync(title, message, MessageDialogStyle.Affirmative).ConfigureAwait(false);
            showMessageInProgress = false;
        }
    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
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


    private void tabMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Determines if the current tab requires a source selection (otherwise it will be disabled in the menu)
        App.Instance.CurrentSelectionLinked = tabMenu.SelectedIndex < 4;
    }

    public void ShowAbout()
    {
        flyAbout.Visibility = Visibility.Visible;
    }

    private void btnMenuRecent_Click(object sender, RoutedEventArgs e)
    {
        App.Instance.CurrentProject.Open((string)((MenuItem)sender).CommandParameter);
    }

    internal Task ShowProgress(string v1, string v2, bool v3)
    {
        throw new NotImplementedException();
    }
}
