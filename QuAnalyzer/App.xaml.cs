using QuAnalyzer.Core.Helpers;
using QuAnalyzer.Core.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using Wokhan.Data.Providers.Contracts;
using Wokhan.UI.Diagnostics;

namespace QuAnalyzer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class App : INotifyPropertyChanged
    {

        public List<SolidColorBrush> AvailableColors { get; } = new List<SolidColorBrush> {
            new SolidColorBrush(Color.FromRgb(0x41, 0xB1, 0xE1)),
            new SolidColorBrush(Colors.LightCoral),
            new SolidColorBrush(Colors.LightSeaGreen),
            new SolidColorBrush(Colors.LightSlateGray),
            new SolidColorBrush(Colors.MediumPurple),
            new SolidColorBrush(Colors.PaleVioletRed)
        };

        public ProjectSettings CurrentProject { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private KeyValuePair<IDataProvider, string> _currentSelection;
        public KeyValuePair<IDataProvider, string> CurrentSelection
        {
            get => _currentSelection;
            set { _currentSelection = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentSelection))); }
        }

        private bool _currentSelectionLinked;
        public bool CurrentSelectionLinked
        {
            get => _currentSelectionLinked;
            set { _currentSelectionLinked = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentSelectionLinked))); }
        }

        public ResourcesWatcher Performance { get; private set; }
        public ProvidersManager ProvidersMan { get; private set; }

        //public string ApplicationInfo { get { return String.Format("{0} {1} v{2}", _appBase.Info.CompanyName, _appBase.Info.ProductName, _appBase.Info.Version); } }
        public string ApplicationInfo { get; } = $"{Assembly.GetExecutingAssembly().GetName().Name} - v{Assembly.GetExecutingAssembly().GetName().Version}";

        //public string Copyright { get { return _appBase.Info.Copyright; } }
        public string Copyright { get; } = "";

        public string HelpLink { get; } = "https://www.wokhan.com";

        public App()
        {
            CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

            CurrentProject = new ProjectSettings() { Name = "Unamed project" };
            Performance = new ResourcesWatcher();
            ProvidersMan = new ProvidersManager();

            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
            this.Exit += App_Exit;
        }

        void App_Exit(object sender, ExitEventArgs e)
        {
            // Ensures all threads are killed as well.
            Environment.Exit(0);
        }
    }
}
