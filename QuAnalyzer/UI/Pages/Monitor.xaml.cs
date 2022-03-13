using CommunityToolkit.Mvvm.Input;

using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

using QuAnalyzer.Features.Monitoring;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.UI.Popups;
using QuAnalyzer.UI.Windows;

using System.Windows.Data;
using System.Windows.Threading;

namespace QuAnalyzer.UI.Pages;

public partial class Monitor : Page
{
    private const int chartTimeSpanMinutes = 1;
    private long startDate;
    private DispatcherTimer globalTimer;
    private List<DispatcherTimer> timers = new();
    private Dictionary<TestDefinition, (TestCase Item, int Index)> instances;

    public static ObservableCollection<TestResults> MonitorResultsView { get; } = new();

    public ObservableDictionary<string, ISeries[]> ResultSeriesMappings { get; } = new();
    public double? Occurences { get; set; } = 10;
    public double? MaxParallel { get; set; } = 1;
    public bool UseComparisonMode { get; set; }

    public Monitor()
    {
        MonitorResultsView.CollectionChanged += MonitorResultsView_CollectionChanged;

        InitializeComponent();
    }

    private void MonitorResultsView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            var results = e.NewItems.Cast<TestResults>().ToList();
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

    [ICommand(CanExecute = nameof(CanExecuteRun))]
    private void Run()
    {
        var mitems = gridSteps.SelectedItems.Cast<TestDefinition>();

        MonitorResultsView.Clear();

        InitChart(mitems);

        startDate = DateTimeOffset.Now.Ticks;
        BindingOperations.EnableCollectionSynchronization(MonitorResultsView, MonitorResultsView);

        if (UseComparisonMode)
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

    private bool CanExecuteRun => gridSteps?.SelectedItems.Count > 0;

    private int globalPerfCounter;
    private async void globalCompTimer_Tick(object sender, EventArgs e)
    {
        var timer = (DispatcherTimer)sender;
        var monitors = (TestDefinition[])timer.Tag;

        var monitorInstances = monitors.Select(m => m.CreateInstance()).ToList();

        var progress = new Progress<TestResults>(monitor_OnAdd);

        //TODO : Values !!!!
        await Task.Run(() => Monitoring.Run(new TestCasesCollection() { TestCases = monitorInstances }, globalPerfCounter++, (int)Occurences.Value, (int)MaxParallel.Value, progress)).ConfigureAwait(false);
    }

    private async void Timer_Tick(object sender, EventArgs e)
    {
        var timer = (DispatcherTimer)sender;
        var monitor = (TestDefinition)timer.Tag;

        var (monitorInstance, cnt) = instances[monitor];
        if (monitorInstance.Status == TestCaseStatus.DONE)
        {
            monitorInstance.PropertyChanged -= UpdateStatus;
            monitorInstance = monitor.CreateInstance();
            monitorInstance.PropertyChanged += UpdateStatus;

            instances[monitor] = (monitorInstance, cnt++);
            monitorInstance.AttachPrecedingStepInstances(monitor.PrecedingSteps.Select(step => instances[step.Key].Item));
        }
        else if (monitorInstance.Status == TestCaseStatus.RUNNING)
        {
            return;
        }

        if (!monitorInstance.AllPrecedingStepsDone)
        {
            monitorInstance.Status = TestCaseStatus.WAITING;
            return;
        }

        monitorInstance.Status = TestCaseStatus.RUNNING;

        List<Dictionary<string, string>> values = null;

        var progress = new Progress<TestResults>(monitor_OnAdd);
        //TODO : Values !!!!
        await Task.Run(() => Monitoring.Run(new TestCasesCollection() { TestCases = { monitorInstance }, ValuesSet = values }, cnt++, 1, 1, progress)).ConfigureAwait(false);

        monitorInstance.Status = TestCaseStatus.DONE;
    }

    private void UpdateStatus(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(TestCase.Status))
        {
            var instance = (TestCase)sender;
            instance.Definition.Status = instance.Status;
        }
    }

    private void InitChart(IEnumerable<TestDefinition> mitems)
    {
        ResultSeriesMappings.AddAll(mitems.ToDictionary(t => t.Name, t => new ISeries[] {
                    new StepLineSeries<DateTimePoint>() { ScalesYAt = 1, Name = t.Name + " (Freq)", Values = new ObservableCollection<DateTimePoint>() },
                    new LineSeries<ObservablePoint>() { Name = t.Name + " (Duration)", Values = new ObservableCollection<ObservablePoint>() }
                }));
    }

    private void monitor_OnAdd(TestResults results)
    {
        MonitorResultsView.Add(results);
        gridResults.ScrollIntoView(results);
    }

    [ICommand]
    private void MonitorAdd()
    {
        Popup.OpenNew(new MonitoringDetails());
    }

    [ICommand(CanExecute = nameof(CanExecuteClearAll))]
    private void MonitorClearAll()
    {
        App.Instance.CurrentProject.TestDefinitions.Clear();
        MonitorClearAllCommand.NotifyCanExecuteChanged();
    }

    private bool CanExecuteClearAll => gridSteps?.Items.Count > 0;

    [ICommand]
    private void MonitorCopy(TestDefinition definition)
    {

    }

    [ICommand]
    private void MonitorEdit(TestDefinition definition)
    {
        Popup.OpenNew(new MonitoringDetails(definition));
    }

    [ICommand]
    private void MonitorDelete(TestDefinition mtoremove)
    {
        foreach (var m in App.Instance.CurrentProject.TestDefinitions)//.Where(m => m.PrecedingSteps.Any()))
        {
            m.PrecedingSteps.Remove(mtoremove);
        }
        App.Instance.CurrentProject.TestDefinitions.Remove(mtoremove);
    }

    private void globalTimer_Tick(object sender, EventArgs e)
    {
        var xAxis = chart.XAxes.First();
        xAxis.MinLimit = DateTime.Now.Ticks;
        xAxis.MaxLimit = DateTime.Now.AddMinutes(chartTimeSpanMinutes).Ticks;
        //chart.ScrollHorizontalFrom = DateTime.Now.Ticks;
        //chart.ScrollHorizontalTo = DateTime.Now.AddMinutes(chartTimeSpanMinutes).Ticks;
    }

    [ICommand]
    private void Stop()
    {
        globalTimer.Stop();

        timers.ForEach(timer => timer.Stop());
        timers.Clear();
    }

    private void btnGrHTML_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsHTML();

    private void btnGrCopy_Click(object sender, RoutedEventArgs e) => gridResults.CopyToClipboard();

    private void btnGrCSV_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsXLSX();

}
