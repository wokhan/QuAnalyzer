using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
#if __WPF__
using LiveCharts.Wpf;
#else 
using LiveCharts.Uwp;
#endif
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
using System.Threading.Tasks;
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
        private const int chartTimeSpanMinutes = 1;
        private long startDate;

        DispatcherTimer globalTimer;

        Dictionary<MonitorItem, DispatcherTimer> timers = new Dictionary<MonitorItem, DispatcherTimer>();
        Dictionary<MonitorItem, (MonitoringItemInstance, int)> instances;

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
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;

            var ntests = int.Parse(txtNbOccur.Text, NumberFormatInfo.CurrentInfo);
            var parallel = int.Parse(txtNbPara.Text, NumberFormatInfo.CurrentInfo);

            MonitorResultsView.Clear();

            var mitems = gridSteps.SelectedItems.Cast<MonitorItem>();

            InitChart(mitems);

            startDate = DateTimeOffset.Now.Ticks;
            BindingOperations.EnableCollectionSynchronization(MonitorResultsView, MonitorResultsView);

            if ((bool)btnCompareMode.IsChecked)
            {
                globalTimer = new DispatcherTimer() { IsEnabled = true, Interval = TimeSpan.FromSeconds(mitems.Max(m => m.Interval)), Tag = mitems };
                globalTimer.Tick += globalCompTimer_Tick;
                globalTimer.Start();
            }
            else
            {
                var gcd = mitems.Select(m => m.Interval).GreatestCommonDiv();
                // TODO: Used to be * 30... Why?
                globalTimer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(gcd) };
                globalTimer.Tick += globalTimer_Tick;
                globalTimer.Start();

                globalTimer_Tick(null, null);

                instances = mitems.ToDictionary(m => m, m => (m.GetInstance(), 1));
                instances.ToList().ForEach(i => i.Value.Item1.AttachPrecedingStepInstances(i.Key.PrecedingSteps.Select(step => instances[step.Key].Item1)));

                timers = mitems.ToDictionary(m => m, m =>
                {
                    var timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(m.Interval), Tag = m };
                    timer.Tick += Timer_Tick;
                    return timer;
                });

                //TODO: ..... not sure this is really useful
                timers.AsParallel().ForAll(mt =>
                {
                    mt.Value.Start();
                    if (mt.Key.RunWhenStarted)
                    {
                        Timer_Tick(mt.Value, null);
                    }
                });
            }

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        int globalPerfCounter ;
        private async void globalCompTimer_Tick(object sender, EventArgs e)
        {
            var timer = (DispatcherTimer)sender;
            var monitors = (MonitorItem[])timer.Tag;

            var nbOccur = int.Parse(txtNbOccur.Text, CultureInfo.CurrentCulture);
            var nbTreads = int.Parse(txtNbPara.Text, CultureInfo.CurrentCulture);

            var monitorInstances = monitors.Select(m => m.GetInstance()).ToList();


            //TODO : Values !!!!
            await Task.Run(() => Performance.Run(new TestCasesCollection() { TestCases = monitorInstances }, globalPerfCounter++, nbOccur, nbTreads, monitor_OnAdd)).ConfigureAwait(false);

        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            var timer = (DispatcherTimer)sender;
            var monitor = (MonitorItem)timer.Tag;

            var monitorInstance = instances[monitor].Item1;
            var cnt = instances[monitor].Item2;
            if (monitorInstance.Status == MonitoringStatus.DONE)
            {
                monitorInstance = monitor.GetInstance();
                instances[monitor] = (monitorInstance, cnt++);
                monitorInstance.AttachPrecedingStepInstances(monitor.PrecedingSteps.Select(step => instances[step.Key].Item1));
            }
            else if (monitorInstance.Status == MonitoringStatus.RUNNING)
            {
                return;
            }

            if (!monitorInstance.AllPrecedingStepsDone)
            {
                monitorInstance.Status = MonitoringStatus.WAITING;
                return;
            }

            monitorInstance.Status = MonitoringStatus.RUNNING;

            List<Dictionary<string, string>> values = null;

            //TODO : Values !!!!
            await Task.Run(() => Performance.Run(new TestCasesCollection() { TestCases = new[] { monitorInstance }, ValuesSet = values }, cnt++, 1, 1, monitor_OnAdd)).ConfigureAwait(false);

            monitorInstance.Status = MonitoringStatus.DONE;
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

        private void globalTimer_Tick(object sender, EventArgs e)
        {
            chart.ScrollHorizontalFrom = DateTime.Now.Ticks;
            chart.ScrollHorizontalTo = DateTime.Now.AddMinutes(chartTimeSpanMinutes).Ticks;
        }

        private void btnStopAll_Click(object sender, RoutedEventArgs e)
        {
            globalTimer.Stop();

            foreach (var timer in timers)
            {
                timer.Value.Stop();
            }

            timers.Clear();
        }

        private void btnGrHTML_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsHTML();

        private void btnGrCopy_Click(object sender, RoutedEventArgs e) => gridResults.CopyToClipboard();

        private void btnGrCSV_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsXLSX();

    }
}
