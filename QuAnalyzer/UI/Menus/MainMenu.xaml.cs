using MahApps.Metro;
using Microsoft.Win32;
using QuAnalyzer.DataProviders.Bases;
using QuAnalyzer.DataProviders.Contracts;
using QuAnalyzer.UI.Windows;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuAnalyzer.UI.Menus
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public string ApplicationName
        {
            get { return "QuAnalyzer v" + Assembly.GetExecutingAssembly().GetName().Version; }
        }

        [Category("Behavior")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event RoutedEventHandler Close;

        public MainMenu()
        {
            InitializeComponent();
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

            if (Close != null)
            {
                ctxRecentFiles.IsOpen = false;
                ctxSaveAs.IsOpen = false;
                Close(this, null);
            }
        }

        private void btnMenuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).CurrentProject.SaveAs();

            if (Close != null)
            {
                ctxRecentFiles.IsOpen = false;
                ctxSaveAs.IsOpen = false;
                Close(this, null);
            }
        }

        private void btnMenuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void setTheme(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.Accents.First(), ThemeManager.AppThemes.First());

            if (Close != null)
            {
                ctxRecentFiles.IsOpen = false;
                ctxSaveAs.IsOpen = false;
                Close(this, null);
            }
        }
        
        private void lstRecentFiles_Click(object sender, RoutedEventArgs e)
        {
            ctxRecentFiles.IsOpen = true;
        }
        
        public void ctxRecentFiles_Click(object sender, RoutedEventArgs e)
        {
            ctxRecentFiles.IsOpen = false;
            ((App)App.Current).CurrentProject.Open((string)((ICommandSource)e.Source).CommandParameter);
        }

        private void btnSaveAs_Click(object sender, RoutedEventArgs e)
        {
            ctxSaveAs.IsOpen = true;
        }

        private void btnEditProvider_Click(object sender, RoutedEventArgs e)
        {
            ((IDataProvider)((Button)sender).Tag).OpenEditor();
        }

        private void btnDeleteProvider_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).CurrentProject.CurrentProviders.Remove((IDataProvider)((Button)sender).Tag);
        }

        private void btnNewPrv_Click(object sender, RoutedEventArgs e)
        {
            var newprv = (IDataProvider)Activator.CreateInstance(((DataProviderStruct)((Button)sender).Tag).Type);
            //((App)Application.Current).CurrentProject.CurrentProviders.Add(newprv);
            
            newprv.Name = ((DataProviderStruct)((Button)sender).Tag).Name + "#" + ((App)Application.Current).CurrentProject.CurrentProviders.Count;

            newprv.OpenEditor();
        }
    }

}
