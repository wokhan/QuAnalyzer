using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace QuAnalyzer.UI.Windows
{
    /// <summary>
    /// Interaction logic for ModernMain.xaml
    /// </summary>
    public partial class ModernMain
    {
        public ModernMain()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            ForceDialog(e.Exception.Message, "Unexpected error");
            e.Handled = true;
        }

        private async void ForceDialog(string p1, string p2)
        {
            var dial = await this.GetCurrentDialogAsync<BaseMetroDialog>();
            if (dial != null)
            {
                dial.Title = p2;
                dial.Content = p1;
                //await this.HideMetroDialogAsync(dial);
            }
            else
            {
                await this.ShowMessageAsync(p2, p1, MessageDialogStyle.Affirmative);
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

        private void btnMenuNew_Click(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).CurrentProject.CreateNew();
        }

        private void btnMenuOpen_Click(object sender, RoutedEventArgs e)
        {
            var dial = new OpenFileDialog() { CheckFileExists = true, ValidateNames = true, AddExtension = true, Filter = "QuAnalyzer project file|*.qap" };
            if (dial.ShowDialog().Value)
            {
                ((App)App.Current).CurrentProject.Open(dial.FileName);
            }
        }

        private void btnMenuSave_Click(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).CurrentProject.Save();

        }

        private void btnMenuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).CurrentProject.SaveAs();

        }

        private void btnMenuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //private void setTheme(object sender, RoutedEventArgs e)
        //{
        //    ThemeManager.ChangeTheme(Application.Current, ThemeManager.Accents.First(), ThemeManager.AppThemes.First());

        //    if (Close != null)
        //    {
        //        ctxRecentFiles.IsOpen = false;
        //        ctxSaveAs.IsOpen = false;
        //        Close(this, null);
        //    }
        //}

        private void lstRecentFiles_Click(object sender, RoutedEventArgs e)
        {
            //ctxRecentFiles.IsOpen = true;
        }

        public void ctxRecentFiles_Click(object sender, RoutedEventArgs e)
        {
            //ctxRecentFiles.IsOpen = false;
            ((App)App.Current).CurrentProject.Open((string)((ICommandSource)e.Source).CommandParameter);
        }

        private void btnSaveAs_Click(object sender, RoutedEventArgs e)
        {
            //ctxSaveAs.IsOpen = true;
        }

        private void mainMenu_Close(object sender, RoutedEventArgs e)
        {

        }
    }
}
