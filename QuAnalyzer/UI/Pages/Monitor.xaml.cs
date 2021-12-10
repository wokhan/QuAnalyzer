using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

using QuAnalyzer.Features.Monitoring;
using QuAnalyzer.Features.Performance;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.UI.Popups;
using QuAnalyzer.UI.Windows;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

using Wokhan.Collections.Generic.Extensions;

namespace QuAnalyzer.UI.Pages;

/// <summary>
/// Interaction logic for DataMonitor.xaml
/// </summary>
public partial class Monitor : Page
{
    private const int chartTimeSpanMinutes = 1;
    private long startDate;
    private DispatcherTimer globalTimer;
    private Dictionary<MonitorItem, DispatcherTimer> timers = new();
    private Dictionary<MonitorItem, (MonitoringItemInstance, int)> instances;

    public static ObservableCollection<ResultsClass> MonitorResultsView { get; } = new();

    public Dictionary<string, ISeries[]> ResultSeriesMappings { get; private set; }
    public double? Occurences { get; set; } = 10;
    public double? MaxParallel { get; set; } = 1;
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

                ((ObservableCollection<(DateTime, double)>)serie.Values).Add((t.LastCheck.DateTime, (double)t.LastCheck.Ticks - startDate + 1));

                var d = new ObservablePoint(t.LastCheck.DateTime.Ticks, 0);
                ((ObservableCollection<ObservablePoint>)serie2.Values).Add(d);
                t.Duration.CollectionChanged += (s, e) => { if (t.Duration.ContainsKey("_TOTAL_DEFAULT")) { d.Y = t.Duration["_TOTAL_DEFAULT"]; } };
            });
        }
    }

    private void btnStart_Click(object sender, RoutedEventArgs e)
    {
        if (gridSteps.SelectedItems.Count == 0)
        {
            return;
        }

        var mitems = gridSteps.SelectedItems.Cast<MonitorItem>();

        btnStart.IsEnabled = false;
        btnStop.IsEnabled = true;

        MonitorResultsView.Clear();

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

            instances = mitems.ToDictionary(m => m, m => (m.CreateInstance(), 1));
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

    private int globalPerfCounter;
    private async void globalCompTimer_Tick(object sender, EventArgs e)
    {
        var timer = (DispatcherTimer)sender;
        var monitors = (MonitorItem[])timer.Tag;

        var monitorInstances = monitors.Select(m => m.CreateInstance()).ToList();


        //TODO : Values !!!!
        await Task.Run(() => Performance.Run(new TestCasesCollection() { TestCases = monitorInstances }, globalPerfCounter++, (int)Occurences.Value, (int)MaxParallel.Value, monitor_OnAdd)).ConfigureAwait(false);

    }

    private async void Timer_Tick(object sender, EventArgs e)
    {
        var timer = (DispatcherTimer)sender;
        var monitor = (MonitorItem)timer.Tag;

        var monitorInstance = instances[monitor].Item1;
        var cnt = instances[monitor].Item2;
        if (monitorInstance.Status == MonitoringStatus.DONE)
        {
            monitorInstance = monitor.CreateInstance();
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
        var tests = mitems.Select(mitem => new TestCase() { Name = mitem.Name, GetData = (values, statsBag) => mitem.Provider.GetQueryable(mitem.Repository, values, statsBag), Repository = mitem.Repository }).ToList();
        ResultSeriesMappings = tests.ToDictionary(t => t.Name, t => new ISeries[] {
                    new StepLineSeries<(DateTime, int)>() { ScalesYAt = 1, Name = t.Name + " (Freq)", Values = new ObservableCollection<(DateTime, int)>() },
                    new LineSeries<ObservablePoint>() { Name = t.Name + " (Duration)", Values = new ObservableCollection<ObservablePoint>() }
                });
    }

    private void monitor_OnAdd(ResultsClass results)
    {
        MonitorResultsView.Add(results);
        gridResults.ScrollIntoView(results);
    }

    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
        Popup.OpenNew(new MonitoringDetails());
    }

    private void btnClear_Click(object sender, RoutedEventArgs e)
    {
        App.Instance.CurrentProject.MonitorItems.Clear();
    }

    private void btnCopy_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnEdit_Click(object sender, RoutedEventArgs e)
    {
        Popup.OpenNew(new MonitoringDetails((MonitorItem)((Button)sender).Tag));
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        var mtoremove = (MonitorItem)((Button)sender).Tag;
        foreach (var m in App.Instance.CurrentProject.MonitorItems.Where(m => m.PrecedingSteps.Any()))
        {
            m.PrecedingSteps.Remove(mtoremove);
        }
        App.Instance.CurrentProject.MonitorItems.Remove(mtoremove);
    }

    private void globalTimer_Tick(object sender, EventArgs e)
    {
        //chart.ScrollHorizontalFrom = DateTime.Now.Ticks;
        //chart.ScrollHorizontalTo = DateTime.Now.AddMinutes(chartTimeSpanMinutes).Ticks;
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
