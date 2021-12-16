﻿using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

using QuAnalyzer.Features.Monitoring;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.UI.Popups;
using QuAnalyzer.UI.Windows;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

using Wokhan.Collections.Generic.Extensions;

namespace QuAnalyzer.UI.Pages;

public partial class Monitor : Page
{
    private const int chartTimeSpanMinutes = 1;
    private long startDate;
    private DispatcherTimer globalTimer;
    private List<DispatcherTimer> timers = new();
    private Dictionary<MonitorItem, (MonitoringItemInstance Item, int Index)> instances;

    public static ObservableCollection<ResultsClass> MonitorResultsView { get; } = new();

    public ObservableDictionary<string, ISeries[]> ResultSeriesMappings { get; } = new();
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

                ((ObservableCollection<DateTimePoint>)serie.Values).Add(new DateTimePoint(t.LastCheck.DateTime, t.LastCheck.Ticks - startDate + 1));

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

        if (btnCompareMode.IsChecked.GetValueOrDefault())
        {
            globalTimer = new DispatcherTimer(TimeSpan.FromSeconds(mitems.Max(m => m.Interval)), DispatcherPriority.Background, globalCompTimer_Tick, Dispatcher) { IsEnabled = true, Tag = mitems };
        }
        else
        {
            var gcd = mitems.Select(m => m.Interval).GreatestCommonDiv();
            // TODO: Used to be * 30... Why?
            globalTimer = new DispatcherTimer(TimeSpan.FromSeconds(gcd), DispatcherPriority.Background, globalTimer_Tick, Dispatcher) { IsEnabled = true };
            //globalTimer_Tick(null, null);

            instances = mitems.ToDictionary(m => m, m => (m.CreateInstance(), 1));
            foreach (var instance in instances)
            {
                instance.Value.Item.AttachPrecedingStepInstances(instance.Key.PrecedingSteps.Select(step => instances[step.Key].Item));
            }

            timers = mitems.Select(m => new DispatcherTimer(TimeSpan.FromSeconds(m.Interval), DispatcherPriority.Background, Timer_Tick, Dispatcher) { Tag = m, IsEnabled = true }).ToList();
        }
    }

    private int globalPerfCounter;
    private async void globalCompTimer_Tick(object sender, EventArgs e)
    {
        var timer = (DispatcherTimer)sender;
        var monitors = (MonitorItem[])timer.Tag;

        var monitorInstances = monitors.Select(m => m.CreateInstance()).ToList();

        var progress = new Progress<ResultsClass>(monitor_OnAdd);

        //TODO : Values !!!!
        await Task.Run(() => Monitoring.Run(new TestCasesCollection() { TestCases = monitorInstances }, globalPerfCounter++, (int)Occurences.Value, (int)MaxParallel.Value, progress)).ConfigureAwait(false);

    }

    private async void Timer_Tick(object sender, EventArgs e)
    {
        var timer = (DispatcherTimer)sender;
        var monitor = (MonitorItem)timer.Tag;

        var (monitorInstance, cnt) = instances[monitor];
        if (monitorInstance.Status == MonitoringStatus.DONE)
        {
            monitorInstance.PropertyChanged -= UpdateStatus;
            monitorInstance = monitor.CreateInstance();
            monitorInstance.PropertyChanged += UpdateStatus;

            instances[monitor] = (monitorInstance, cnt++);
            monitorInstance.AttachPrecedingStepInstances(monitor.PrecedingSteps.Select(step => instances[step.Key].Item));
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

        var progress = new Progress<ResultsClass>(monitor_OnAdd);
        //TODO : Values !!!!
        await Task.Run(() => Monitoring.Run(new TestCasesCollection() { TestCases = new[] { monitorInstance }, ValuesSet = values }, cnt++, 1, 1, progress)).ConfigureAwait(false);

        monitorInstance.Status = MonitoringStatus.DONE;
    }

    private void UpdateStatus(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(MonitoringItemInstance.Status))
        {
            var instance = (MonitoringItemInstance)sender;
            instance.MonitorItem.Status = instance.Status;
        }
    }

    private void InitChart(IEnumerable<MonitorItem> mitems)
    {
        ResultSeriesMappings.AddAll(mitems.ToDictionary(t => t.Name, t => new ISeries[] {
                    new StepLineSeries<DateTimePoint>() { ScalesYAt = 1, Name = t.Name + " (Freq)", Values = new ObservableCollection<DateTimePoint>() },
                    new LineSeries<ObservablePoint>() { Name = t.Name + " (Duration)", Values = new ObservableCollection<ObservablePoint>() }
                }));
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
        foreach (var m in App.Instance.CurrentProject.MonitorItems)//.Where(m => m.PrecedingSteps.Any()))
        {
            m.PrecedingSteps.Remove(mtoremove);
        }
        App.Instance.CurrentProject.MonitorItems.Remove(mtoremove);
    }

    private void globalTimer_Tick(object sender, EventArgs e)
    {
        var xAxis = chart.XAxes.First();
        xAxis.MinLimit = DateTime.Now.Ticks;
        xAxis.MaxLimit = DateTime.Now.AddMinutes(chartTimeSpanMinutes).Ticks;
        //chart.ScrollHorizontalFrom = DateTime.Now.Ticks;
        //chart.ScrollHorizontalTo = DateTime.Now.AddMinutes(chartTimeSpanMinutes).Ticks;
    }

    private void btnStopAll_Click(object sender, RoutedEventArgs e)
    {
        globalTimer.Stop();

        timers.ForEach(timer => timer.Stop());
        timers.Clear();
    }

    private void btnGrHTML_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsHTML();

    private void btnGrCopy_Click(object sender, RoutedEventArgs e) => gridResults.CopyToClipboard();

    private void btnGrCSV_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsXLSX();

}
