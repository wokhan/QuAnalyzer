using MahApps.Metro.Controls.Dialogs;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace QuAnalyzer.UI.Windows
{
    /// <summary>
    /// Interaction logic for ModernMain.xaml
    /// </summary>
    public partial class ModernMain
    {
        private bool showMessageInProgress;

        public ModernMain()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            ForceDialog(e.Exception.Message, "Unexpected error");
            e.Handled = true;
        }

        private async void ForceDialog(string message, string title)
        {
            var dial = await this.GetCurrentDialogAsync<BaseMetroDialog>().ConfigureAwait(true);
            if (dial is not null)
            {
                dial.Title = title;
                dial.Content = message;
            }
            //TODO: might get useless (added when we encounter a bugged loop, inducing multiple error messages being spawned too fast)
            else if (!showMessageInProgress)
            {
                showMessageInProgress = true;
                await this.ShowMessageAsync(title, message, MessageDialogStyle.Affirmative).ConfigureAwait(false);
                showMessageInProgress = false;
            }
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ForceDialog(((Exception)e.ExceptionObject).Message, "Unexpected error");
            //this.ShowMessageAsync("Unexpected error", ((Exception)e.ExceptionObject).Message, MessageDialogStyle.Affirmative);
        }


        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "providers", args.Name.Split(',')[0] + ".dll");

            if (File.Exists(path))
            {
                return Assembly.LoadFrom(path);
            }

            return null;
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
            var useBouba = tabMenu.SelectedIndex < 4;
            ((App)Application.Current).CurrentSelectionLinked = useBouba;
        }

        public void ShowAbout()
        {
            flyAbout.IsOpen = true;
        }
    }
}
