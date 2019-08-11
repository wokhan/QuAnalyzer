using MahApps.Metro.Controls.Dialogs;
using System;
using System.IO;
using System.Reflection;
using System.Windows;

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

        public void mainMenu_Close(object sender, RoutedEventArgs e)
        {
            btnMenu.IsChecked = false;
        }
    }
}
