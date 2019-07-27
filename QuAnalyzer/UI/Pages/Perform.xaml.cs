using De.TorstenMandelkow.MetroChart;
using QuAnalyzer.Features.Monitoring;
using QuAnalyzer.Features.Performance;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.UI.Popups;
using QuAnalyzer.UI.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using Wokhan.Collections.Extensions;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Interaction logic for DataMonitor.xaml
    /// </summary>
    public partial class Perform : Page
    {
        private static DateTime firstStart;

        public static ObservableCollection<ResultStruct> PerfResults { get; } = new ObservableCollection<ResultStruct>();
        public ListCollectionView PerfResultsView { get; } = new ListCollectionView(PerfResults);

        public Perform()
        {
            this.DataContext = this;

            //_monitorResultsView.GroupDescriptions.Add(new PropertyGroupDescription("Step"));

            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            graph.Series.Clear();


        }

        public void run(int ntests, TestCasesCollection ts, int parallel)
        {
            /*var p = Process.GetCurrentProcess();
            var dcThreads = new DumpContainer().Dump();
            new Timer((e) => { p.Refresh(); dcThreads.Content = $"Threads: {p.Threads.Count}"; }, null, 0, 250);
            */
            var data = new ObservableCollection<ResultStruct>();

            dcDic = Enumerable.Range(0, ntests).SelectMany(i => ts.TestCases.Select((t, ix) => new { t, ix = $"{i}.{ix}" })).ToDictionary(i => i.ix, i => new DumpContainer($"[{i.ix}::{i.t.Name}] Pending...") { Style = "color: gray;" }.Dump());

            Performance.Run(ts, ntests, parallel, data, runcallback);

            var dx = data.Where(d => d.Result != null).OrderBy(r => r.Index).ToList();
            var s1 = dx.ToMultiSeries(t => t.Name + " (Freq)", "X", t => t.Index, new[] { "Start", "End" }, t => new[] { t.Start + 1, Math.Max(t.End, 1) }, SeriesChartType.RangeColumn, true, true);
            var s2 = dx.ToMultiSeries(t => t.Name + " (Duration)", "X", t => t.Index, new[] { "Duration" }, t => new[] { (double)t.Duration }, ChartType.Line);

            for (int i = 0; i < 35; i++)
            {
                var x = now.AddSeconds(timeslice * i);
                var xname = x.ToString("dd/mm/yyyy HH:mm:ss");
                var uname = "Series_" + ((uint)xname.GetHashCode()).ToString();
                if (!graph.Series.Any(s => s.Name == uname))
                {
                    var series = new ChartSeries()
                    {
                        Name = uname,
                        SeriesTitle = xname,
                        ValueMember = "Y",
                        DisplayMember = "Name",
                        Tag = x
                    };

                    graph.Series.Add(series);

                    mis.ForEach(m => series.Items.Add(new DatePoint() { Name = m.Name }));
                }
            }
        }

        void runcallback(ResultStruct res, IList<Dictionary<string, string>> values)
        {
            switch (res.Status)
            {
                /*case Performance.Status.Pending:
                    dcDic[res.Id].Content = $"[{res.Id}::{res.Name}] Pending...";
                    break;
                */
                case Status.Loading:
                    dcDic[res.Id].Style = "color: black;";
                    dcDic[res.Id].Content = $"[{res.Id}::{res.Name}] [{DateTime.Now}] Loading...";
                    break;

                case Status.Success:
                    dcDic[res.Id].Content = Util.HorizontalRun(true, Util.RawHtml($"<span style='color:green'>[{res.Id}::{res.Name}]</span> [{DateTime.Now}] Done in {res.Duration}ms (status: {res.Status}, values: {values})"), Util.OnDemand("[details]", () => res.Result));
                    break;

                case Status.Failure:
                    dcDic[res.Id].Content = Util.HorizontalRun(true, Util.RawHtml($"<span style='color:red'>[{res.Id}::{res.Name}]</span> [{DateTime.Now}] Done in {res.Duration}ms (status: {res.Status}, values: {values})"), Util.OnDemand("[details]", () => res.Result));
                    break;

                case Status.Error:
                    dcDic[res.Id].Content = Util.HorizontalRun(true, Util.RawHtml($"<span style='color:orangered'>[{res.Id}::{res.Name}]</span> [{DateTime.Now}] Done in {res.Duration}ms (status: {res.Status}, values: {values})"), Util.OnDemand("[details]", () => res.Result));
                    break;

            }
        }

        void monitor_OnAdd(ResultStruct obj)
        {
            PerfResults.Add(obj);
            gridResults.ScrollIntoView(obj);
        }

        void monitor_OnResult(ResultStruct obj)
        {
            if (btnEnable.IsChecked.Value)
            {
                var series = graph.Series.OrderByDescending(s => (DateTime)s.Tag).First(s => obj.Start >= (double)s.Tag);
                var p = series.Items.Cast<DatePoint>().First(i => i.Name == obj.Name);
                p.Duration = obj.Duration.Values.Max();
                p.Y = obj.End;

                series.BringIntoView();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var editor = new Popup(new MonitoringDetails(new MonitorItem() { Name = "Monitor #" + (((App)Application.Current).CurrentProject.MonitorItems.Count + 1) }));
            editor.Show();
            editor.Activate();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).CurrentProject.MonitorItems.Clear();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var editor = new Popup(new MonitoringDetails((MonitorItem)((Button)sender).Tag));
            editor.Show();
            editor.Activate();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).CurrentProject.PerformanceItems.Remove((TestCasesCollection)((Button)sender).Tag);
        }

        private void btnGrHTML_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsHTML();

        private void btnGrCopy_Click(object sender, RoutedEventArgs e) => gridResults.CopyToClipboard();

        private void btnGrCSV_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsXLSX();

    }
}
