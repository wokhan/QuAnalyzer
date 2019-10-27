using QuAnalyzer.Core.Extensions;
using QuAnalyzer.Features.Monitoring;
using QuAnalyzer.Features.Performance;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.UI.Popups;
using QuAnalyzer.UI.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Threading;
using Wokhan.Collections.Generic.Extensions;
using static QuAnalyzer.Features.Performance.Performance;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Interaction logic for DataMonitor.xaml
    /// </summary>
    public partial class Performance : Page
    {
        Dictionary<string, ContentControl> dcDic;
        ObservableCollection<ResultsClass> MonitorResultsView = new ObservableCollection<ResultsClass>();

        public Performance()
        {
            this.DataContext = this;

            InitializeComponent();
        }

        public void run(int ntests, TestCasesCollection ts, int parallel)
        {
            Run(ts, ntests, parallel, MonitorResultsView);

            var dx = MonitorResultsView.Where(d => d.Data != null).OrderBy(r => r.Index).ToList();
            var s1 = dx.ToMultiSeries(t => t.Name + " (Freq)", "X", t => t.Index, new[] { "Start", "End" }, t => new[] { (double)t.LastCheck.Ticks + 1, Math.Max(t.End.Ticks, 1) }, SeriesChartType.RangeColumn, true, true);
            var s2 = dx.ToMultiSeries(t => t.Name + " (Duration)", "X", t => t.Index, new[] { "Duration" }, t => new[] { (double)t.Duration.Values.Sum() }, SeriesChartType.Line);

            graph.AddSeries(s1.Values.Concat(s2.Values).ToArray());
        }

        /*void runcallback(ResultsClass res, IList<Dictionary<string, string>> values)
        {
            switch (res.Status)
            {
                case Status.Loading:
                    dcDic[res.Id].Style = "color: black;";
                    dcDic[res.Id].Content = $"[{res.Id}::{res.Name}] [{DateTime.Now}] Loading...";
                    break;

                case Status.Success:
                    dcDic[res.Id].Content = Util.HorizontalRun(true, Util.RawHtml($"<span style='color:green'>[{res.Id}::{res.Name}]</span> [{DateTime.Now}] Done in {res.Duration}ms (status: {res.Status}, values: {values})"), Util.OnDemand("[details]", () => res.Data));
                    break;

                case Status.Failure:
                    dcDic[res.Id].Content = Util.HorizontalRun(true, Util.RawHtml($"<span style='color:red'>[{res.Id}::{res.Name}]</span> [{DateTime.Now}] Done in {res.Duration}ms (status: {res.Status}, values: {values})"), Util.OnDemand("[details]", () => res.Data));
                    break;

                case Status.Error:
                    dcDic[res.Id].Content = Util.HorizontalRun(true, Util.RawHtml($"<span style='color:orangered'>[{res.Id}::{res.Name}]</span> [{DateTime.Now}] Done in {res.Duration}ms (status: {res.Status}, values: {values})"), Util.OnDemand("[details]", () => res.Data));
                    break;

            }
        }*/

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //var tests = lst{ new TestCase() { GetData = (values, stats) => item.Provider.GetQueryable(item.Repository, values, stats)  } };
            //var tc = new TestCasesCollection() { TestCases = tests };
            //run(10, tc, 10);
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e) => Popup.OpenNew(new MonitoringDetails((MonitorItem)((Button)sender).Tag));

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
        }

       
        private void btnGrHTML_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsHTML();

        private void btnGrCopy_Click(object sender, RoutedEventArgs e) => gridResults.CopyToClipboard();

        private void btnGrCSV_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsXLSX();

        private void btnStopAll_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
