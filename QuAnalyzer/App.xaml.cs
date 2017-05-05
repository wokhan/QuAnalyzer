using Microsoft.VisualBasic.ApplicationServices;
using QuAnalyzer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace QuAnalyzer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class App
    {
        private readonly List<SolidColorBrush> _availableColors = new List<SolidColorBrush> {
            new SolidColorBrush(Color.FromRgb(0x41, 0xB1, 0xE1)),
            new SolidColorBrush(Colors.LightCoral),
            new SolidColorBrush(Colors.LightSeaGreen),
            new SolidColorBrush(Colors.LightSlateGray),
            new SolidColorBrush(Colors.MediumPurple),
            new SolidColorBrush(Colors.PaleVioletRed)
        };
        public List<SolidColorBrush> AvailableColors { get { return _availableColors; } }

        private readonly Project _currentProject = new Project();

        public Project CurrentProject { get { return _currentProject; } }

        private readonly ResourcesWatcher _perfs;
        public ResourcesWatcher Performance { get { return _perfs; } }

        private readonly ApplicationBase _appBase = new ApplicationBase();

        public string ApplicationInfo { get { return String.Format("{0} {1} v{2}", _appBase.Info.CompanyName, _appBase.Info.ProductName, _appBase.Info.Version); } }

        public string Copyright { get { return _appBase.Info.Copyright; } }

        public string HelpLink { get { return "http://wokhan.online.fr"; } }

        public App()
        {
            _perfs = new ResourcesWatcher();

            this.ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;
            this.Exit += App_Exit;
        }

        void App_Exit(object sender, ExitEventArgs e)
        {
            // Ensures all threads are killed as well.
            Environment.Exit(0);
        }
    }
}
