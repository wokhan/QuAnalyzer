using QuAnalyzer.Helpers;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Wokhan.Data.Providers;

namespace QuAnalyzer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class App
    {
        public List<SolidColorBrush> AvailableColors { get; } = new List<SolidColorBrush> {
            new SolidColorBrush(Color.FromRgb(0x41, 0xB1, 0xE1)),
            new SolidColorBrush(Colors.LightCoral),
            new SolidColorBrush(Colors.LightSeaGreen),
            new SolidColorBrush(Colors.LightSlateGray),
            new SolidColorBrush(Colors.MediumPurple),
            new SolidColorBrush(Colors.PaleVioletRed)
        };

        public Project CurrentProject { get; } = new Project();
        public ResourcesWatcher Performance { get; }

        //public string ApplicationInfo { get { return String.Format("{0} {1} v{2}", _appBase.Info.CompanyName, _appBase.Info.ProductName, _appBase.Info.Version); } }
        public string ApplicationInfo { get { return String.Format("{0} {1} v{2}", "", "", ""); } }

        //public string Copyright { get { return _appBase.Info.Copyright; } }
        public string Copyright { get { return ""; } }

        public string HelpLink { get { return "https://www.wokhan.com"; } }

        public App()
        {
            Performance = new ResourcesWatcher();

            DataProviders.Init(AppDomain.CurrentDomain.BaseDirectory + "\\providers");

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
