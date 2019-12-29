using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            var dial = await this.GetCurrentDialogAsync<BaseMetroDialog>().ConfigureAwait(true);
            if (dial != null)
            {
                dial.Title = p2;
                dial.Content = p1;
                //await this.HideMetroDialogAsync(dial);
            }
            else
            {
                await this.ShowMessageAsync(p2, p1, MessageDialogStyle.Affirmative).ConfigureAwait(false);
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

        private void btnMenuRecent_Click(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).CurrentProject.Open((string)((MenuItem)sender).CommandParameter);
        }

        private void btnAccentColor_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).CurrentProject.AccentColor = (SolidColorBrush)((MenuItem)sender).Tag;
        }

        private void btnEditTitle_Click(object sender, RoutedEventArgs e)
        {
            txtProjectTitle.Focus();
        }

        private void tabMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var useBouba = tabMenu.SelectedIndex < 4;
            ((App)Application.Current).CurrentSelectionLinked = useBouba;
        }
    }
}
