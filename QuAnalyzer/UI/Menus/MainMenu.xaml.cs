using MahApps.Metro;
using Microsoft.Win32;
using QuAnalyzer.UI.Pages;
using QuAnalyzer.UI.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wokhan.Data.Providers;
using Wokhan.Data.Providers.Bases;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Menus
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public string ApplicationName { get; } = "QuAnalyzer v" + Assembly.GetExecutingAssembly().GetName().Version;


        [Category("Behavior")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event RoutedEventHandler Close;

        public MainMenu()
        {
            InitializeComponent();
        }

       
        
        private void btnDeleteProvider_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).CurrentProject.CurrentProviders.Remove((IDataProvider)((Button)sender).Tag);
        }

       
        private void btnImportPrv_Click(object sender, RoutedEventArgs e)
        {
            var dial = new OpenFileDialog() { CheckFileExists = true, ValidateNames = true, AddExtension = true, Filter = "QuAnalyzer Data Provider archive|*.qax" };
            if (dial.ShowDialog().Value)
            {
                ((App)Application.Current).ProvidersMan.AddProvider(dial.FileName);
            }
        }
        private void btnEditProvider_Click(object sender, RoutedEventArgs e) => Popup.OpenNew(new ProviderEditor((IDataProvider)((Button)sender).Tag));

        private void btnNewSource_Click(object sender, RoutedEventArgs e) => Popup.OpenNew(new ProviderPicker());
            
    }
}
