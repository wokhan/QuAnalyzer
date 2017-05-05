using HttpProvider;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace QuAnalyzer.DataProviders.HttpProvider
{
    /// <summary>
    /// Interaction logic for Browser.xaml
    /// </summary>
    public partial class Browser : MetroWindow
    {
        private Dictionary<uint, string> _docModes = new Dictionary<uint, string>
        {
            {0, "Default"},
            {11001, "IE11 (forced)"},
            {11000, "IE11"},
            {10001, "IE10 (forced)"},
            {10000, "IE10"},
            {9999, "IE9 (forced)"},
            {9000, "IE9"},
            {8888, "IE8 (forced)"},
            {8000, "IE8"},
            {7000, "IE7"}
        };

        public Dictionary<uint, string> DocModes { get { return _docModes; } }
        public uint DocMode { get; set; }

        public HttpProvider CurrentProvider { get; set; }

        private ObservableCollection<Session> _sessions = new ObservableCollection<Session>();
        public ObservableCollection<Session> Sessions { get { return _sessions; } }

        string exProxy;
        public Browser(HttpProvider prov)
        {
            this.CurrentProvider = prov;

            InitializeComponent();

            SetBrowserEmulationMode();

            this.Closed += Browser_Closed;
            Fiddler.FiddlerApplication.SetAppDisplayName("FiddlerCore>QuAnalyzer");
            Fiddler.FiddlerApplication.Startup(0, Fiddler.FiddlerCoreStartupFlags.CaptureLocalhostTraffic | Fiddler.FiddlerCoreStartupFlags.ChainToUpstreamGateway | Fiddler.FiddlerCoreStartupFlags.OptimizeThreadPool | Fiddler.FiddlerCoreStartupFlags.MonitorAllConnections);
            Fiddler.CONFIG.QuietMode = true;
            exProxy = Fiddler.URLMonInterop.GetProxyInProcess();
            Fiddler.URLMonInterop.SetProxyInProcess("localhost:" + Fiddler.FiddlerApplication.oProxy.ListenPort, "");
            Fiddler.FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;
        }

        void Browser_Closed(object sender, EventArgs e)
        {
            Fiddler.URLMonInterop.SetProxyInProcess(exProxy, "");
            Fiddler.FiddlerApplication.Shutdown();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            if (!Uri.IsWellFormedUriString(txtAddress.Text, UriKind.Absolute))
            {
                MessageBox.Show("Unexpected URL format. Please ensure you entered a correct value.");
            }
            else
            {
                wbMain.Navigate(new Uri(txtAddress.Text));
            }
        }

        void FiddlerApplication_BeforeRequest(Fiddler.Session oSession)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var s = new Session() { Id = oSession.id, Url = oSession.fullUrl, RawHeaders = oSession.RequestHeaders.ToDictionary(h => h.Name, g => g.Value), RawBody = oSession.RequestBody, RawMethod = oSession.RequestMethod, Raw = oSession };
                oSession.OnCompleteTransaction += s.Complete;

                Sessions.Add(s);
            });
        }

        public Dictionary<string, object> SelectedSession { get { return Sessions.Where(s => s.Selected).ToDictionary(s => "#" + s.Id + " - " + s.Url, s => (object)s); } }

        private void btnRepoClear_Click(object sender, RoutedEventArgs e)
        {
            Sessions.Clear();
        }

        private void btnRepoSel_Click(object sender, RoutedEventArgs e)
        {
            Sessions.ToList().ForEach(s => s.Selected = true);
        }

        private void btnRepoUnSel_Click(object sender, RoutedEventArgs e)
        {
            Sessions.ToList().ForEach(s => s.Selected = false);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        public void SetBrowserEmulationMode()
        {
            var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            if (fileName != "devenv.exe" && fileName != "XDesProc.exe")
            {
                using (var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    if (DocMode == 0)
                    {
                        key.DeleteValue(fileName, false);
                    }
                    else
                    {
                        key.SetValue(fileName, DocMode, RegistryValueKind.DWord);
                    }
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SetBrowserEmulationMode();
        }
    }
}
