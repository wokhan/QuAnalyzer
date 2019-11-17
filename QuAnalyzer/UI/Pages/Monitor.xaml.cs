using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using QuAnalyzer.Features.Monitoring;
using QuAnalyzer.Features.Performance;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.UI.Popups;
using QuAnalyzer.UI.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using Wokhan.Collections.Generic.Extensions;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Interaction logic for DataMonitor.xaml
    /// </summary>
    public partial class Monitor : Page
    {
        private static DateTime firstStart;
        private long startDate;
        private int cnt;

        readonly DispatcherTimer timer = new DispatcherTimer();

        //TODO: use a static reference instead
        public Dictionary<string, string> MonitoringTypes { get; } = MonitoringModes.MonitoringTypes;
        public static ObservableCollection<ResultsClass> MonitorResultsView { get; } = new ObservableCollection<ResultsClass>();
        //public ListCollectionView MonitorResultsView { get; } = new ListCollectionView(MonitorResults);
        public SeriesCollection ResultSeries { get; } = new SeriesCollection(Mappers.Xy<DateTimePoint>().X(d => d.DateTime.Ticks).Y(d => d.Value));
        public Dictionary<string, Series[]> ResultSeriesMappings { get; private set; }

        public Monitor()
        {
            this.DataContext = this;

            MonitorResultsView.CollectionChanged += MonitorResultsView_CollectionChanged;

            //_monitorResultsView.GroupDescriptions.Add(new PropertyGroupDescription("Step"));

            InitializeComponent();
        }

        private void MonitorResultsView_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var results = e.NewItems.Cast<ResultsClass>().ToList();
                results.ForEach(t =>
                {
                    var serie = ResultSeriesMappings[t.Name][0];
                    var serie2 = ResultSeriesMappings[t.Name][1];

                    serie.Values.Add(new DateTimePoint(t.LastCheck.DateTime, (double)t.LastCheck.Ticks - startDate + 1));
                    var d = new DateTimePoint(t.LastCheck.DateTime, 0);
                    serie2.Values.Add(d);
                    t.Duration.CollectionChanged += (s, e) => { if (t.Duration.ContainsKey("_TOTAL_DEFAULT")) { d.Value = t.Duration["_TOTAL_DEFAULT"]; } };
                });
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var ntests = int.Parse(txtNbOccur.Text, NumberFormatInfo.CurrentInfo);
            var parallel = int.Parse(txtNbPara.Text, NumberFormatInfo.CurrentInfo);

            MonitorResultsView.Clear();

            var mitems = gridSteps.SelectedItems.Cast<MonitorItem>();

            InitChart(mitems);

            startDate = DateTimeOffset.Now.Ticks;
            BindingOperations.EnableCollectionSynchronization(MonitorResultsView, MonitorResultsView);

            var gcd = mitems.Select(m => m.Interval).GreatestCommonDiv();
            // TODO: * 30 ??? Why?
            timer.Interval = TimeSpan.FromSeconds(gcd * 30);
            timer.Tick += timer_Tick;
            timer.Start();

            timer_Tick(null, null);

            firstStart = DateTime.Now;

            if ((bool)btnBurstMode.IsChecked)
            {
                
            }
            else
            {
                foreach (var monitor in gridSteps.SelectedItems.Cast<MonitorItem>())
                {
                    monitor.OnAdd += monitor_OnAdd;
                    monitor.Start();
                }
            }
        }

        private void InitChart(IEnumerable<MonitorItem> mitems)
        {
            ResultSeries.Clear();

            var tests = mitems.Select(mitem => new TestCase() { Name = mitem.Name, GetData = (values, statsBag) => mitem.Provider.GetQueryable(mitem.Repository, values, statsBag), Repository = mitem.Repository }).ToList();
            ResultSeriesMappings = tests.ToDictionary(t => t.Name, t => new Series[] {
                    new StepLineSeries() { ScalesYAt = 1, Title = t.Name + " (Freq)", Values = new ChartValues<DateTimePoint>() },
                    new LineSeries() { Title = t.Name + " (Duration)", Values = new ChartValues<DateTimePoint>() }
                });
            ResultSeries.AddRange(ResultSeriesMappings.SelectMany(_ => _.Value));
        }

        void monitor_OnAdd(ResultsClass results)
        {
            MonitorResultsView.Add(results);
            gridResults.ScrollIntoView(results);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).CurrentProject.MonitorItems.Add(new MonitorItem() { Name = "Monitor #" + (((App)Application.Current).CurrentProject.MonitorItems.Count + 1) });
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).CurrentProject.MonitorItems.Clear();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e) => Popup.OpenNew(new MonitoringDetails((MonitorItem)((Button)sender).Tag));

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var mtoremove = (MonitorItem)((Button)sender).Tag;
            foreach (var m in ((App)Application.Current).CurrentProject.MonitorItems.Where(m => m.PrecedingSteps.Any()))
            {
                m.PrecedingSteps.Remove(mtoremove);
            }
            ((App)Application.Current).CurrentProject.MonitorItems.Remove(mtoremove);
        }

        /*private void btnStartAll_Click(object sender, RoutedEventArgs e)
        {
            var gcd = ((App)Application.Current).CurrentProject.MonitorItems.Select(m => m.Interval).GreatestCommonDiv();

            timer.Interval = TimeSpan.FromSeconds(gcd * 30);
            timer.Tick += timer_Tick;
            timer.Start();

            timer_Tick(null, null);

            firstStart = DateTime.Now;

            /*foreach (var monitor in ((App)Application.Current).CurrentProject.MonitorItems)
            {
                monitor.AttachEvent(monitor_OnAdd, monitor_OnResult);
                monitor.Start();
            }
        }*/

        private void timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void btnStopAll_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            foreach (var monitor in ((App)Application.Current).CurrentProject.MonitorItems)
            {
                monitor.Stop();
            }
        }

        private void btnGrHTML_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsHTML();

        private void btnGrCopy_Click(object sender, RoutedEventArgs e) => gridResults.CopyToClipboard();

        private void btnGrCSV_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsXLSX();

    }
}
