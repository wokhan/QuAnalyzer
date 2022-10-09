using CommunityToolkit.Mvvm.Input;

using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;

using QuAnalyzer.Core.Project;
using QuAnalyzer.Features.Monitoring;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.UI.Popups;

using Windows.System.Threading;

namespace QuAnalyzer.UI.Pages;

[ObservableObject]
public partial class Monitor : Page
{
    /// <summary>
    /// This is to bypass a bug with Uno Platform where TwoWay static bindings through x:Bind don't seem to work. Weird since
    /// according to GitHub, it should...
    /// </summary>
    public App App => App.Instance;

    private TimeSpan chartTimeSpanSeconds = TimeSpan.FromSeconds(30);

    private ThreadPoolTimer panningDelayTimer;
    private ThreadPoolTimer globalTimer;
    private List<ThreadPoolTimer> timers = new();
    private Dictionary<TestDefinition, (TestCase Item, int Index)> instances;

    public ObservableCollection<TestResults> MonitorResultsView { get; } = new();
    public ObservableCollection<ISeries> MonitorResultsSeries { get; } = new();

    private readonly Dictionary<string, (LineSeries<ObservablePoint> DurationSeries, ColumnSeries<ObservablePoint> ResultSseries)> resultSeriesMappings = new();
    public double Occurences { get; set; } = 10;
    public double MaxParallel { get; set; } = 1;

    [ObservableProperty]
    private bool useComparisonMode;

    [ObservableProperty]
    private bool autoScrollResults = true;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(RunCommand))]
    [NotifyCanExecuteChangedFor(nameof(StopCommand))]
    private bool isRunning;

    private static Axis yLogAxis = new()
    {
        //MinStep = 1,
        MinLimit = 0,
        //Labeler = value => Math.Pow(10, value).ToString()
    };

    public ICartesianAxis[] YAxes { get; } = { new Axis(), yLogAxis };

    private static Axis xTimeAxis = new()
    {
        Labeler = value => new DateTime((long)value).ToLongTimeString()
    };

    public ICartesianAxis[] XAxes { get; } = { xTimeAxis };

    public Monitor()
    {
        ProgressCallback = new Progress<(TestCase, TestResults)>(HandleProgress);

        InitializeComponent();
    }

    private void gridSteps_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        RunCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand(CanExecute = nameof(CanExecuteRun))]
    private void Run()
    {
        IsRunning = true;

        MonitorResultsView.Clear();

        var selectedTests = gridSteps.SelectedItems.Cast<TestDefinition>().ToList();

        // https://github.com/beto-rodriguez/LiveCharts2/issues/579
        xTimeAxis.MinLimit = DateTime.Now.Ticks;
        xTimeAxis.MaxLimit = DateTime.Now.Add(TimeSpan.FromSeconds(60)).Ticks;

        InitSeries(selectedTests);

        if (UseComparisonMode)
        {
            globalTimer = ThreadPoolTimer.CreatePeriodicTimer(_ => RunPeriodicCompared(selectedTests), TimeSpan.FromSeconds(selectedTests.Max(m => m.Interval)));
        }
        else
        {
            var gcd = selectedTests.Select(m => m.Interval).GreatestCommonDiv();
            panningDelayTimer = ThreadPoolTimer.CreateTimer(_ => globalTimer = ThreadPoolTimer.CreatePeriodicTimer(setChartPanning, TimeSpan.FromSeconds(gcd)), chartTimeSpanSeconds);

            instances = selectedTests.ToDictionary(test => test, test => (test.CreateInstance(), 1));

            foreach (var instance in instances)
            {
                instance.Value.Item.AttachPrecedingStepInstances(instance.Key.PrecedingSteps.Select(step => instances[step.Key].Item));
            }

            timers = selectedTests.Select(test =>
            {
                if (test.RunWhenStarted)
                {
                    RunPeriodic(test);
                }
                return ThreadPoolTimer.CreatePeriodicTimer(_ => RunPeriodic(test), TimeSpan.FromSeconds(test.Interval));
            }).ToList();
        }
    }

    private bool CanExecuteRun => !IsRunning && gridSteps?.SelectedItems.Count > 0;

    private int globalPerfCounter;
    private async void RunPeriodicCompared(IEnumerable<TestDefinition> tests)
    {
        var testInstances = tests.Select(m => m.CreateInstance()).ToList();

        //TODO : Values !!!!
        await Task.Run(() => Monitoring.Run(testInstances, null, null, globalPerfCounter++, (int)Occurences, (int)MaxParallel, ProgressCallback)).ConfigureAwait(false);
    }

    private async void RunPeriodic(TestDefinition test)
    {
        var (testInstance, cnt) = instances[test];
        switch (testInstance.Status)
        {
            // Still running, ignoring this occurence
            case TestCaseStatus.RUNNING:
                return;

            // Creates a new instance as the preceding one is done running
            case TestCaseStatus.DONE:
                testInstance = test.CreateInstance();

                instances[test] = (testInstance, cnt++);
                testInstance.AttachPrecedingStepInstances(test.PrecedingSteps.Select(step => instances[step.Key].Item));
                break;
        }

        //TODO : Values !!!!
        await Task.Run(() => Monitoring.Run(new[] { testInstance }, null, null, cnt++, 1, 1, ProgressCallback)).ConfigureAwait(false);
    }

    void logmap(DateTimePoint logPoint, ChartPoint chartPoint)
    {
        chartPoint.PrimaryValue = logPoint.Value.HasValue ? Math.Log(logPoint.Value.Value, 10) : 0;
        chartPoint.SecondaryValue = logPoint.DateTime.Ticks;
    }

    private void InitSeries(IEnumerable<TestDefinition> tests)
    {
        foreach (var test in tests)
        {
            if (!resultSeriesMappings.ContainsKey(test.Name))
            {
                var durationSeries = new LineSeries<ObservablePoint>() { GeometrySize = 4, Name = test.Name + " (Duration)", Values = new ObservableCollection<ObservablePoint>() };
                var resultSeries = new ColumnSeries<ObservablePoint>() { Name = test.Name + " (Result)", Values = new ObservableCollection<ObservablePoint>() };

                MonitorResultsSeries.Add(durationSeries);
                MonitorResultsSeries.Add(resultSeries);

                resultSeriesMappings.Add(test.Name, (durationSeries, resultSeries));
            }
        }
    }

    IProgress<(TestCase, TestResults)> ProgressCallback;
    private void HandleProgress((TestCase test, TestResults results) testAndResults)
    {
        DispatcherQueue.TryEnqueue(() =>
        {
            if (!MonitorResultsView.Contains(testAndResults.results))
            {
                var lastCheck = testAndResults.results.LastCheck;

                MonitorResultsView.Add(testAndResults.results);
                gridResults.ScrollIntoView(testAndResults.results, null);

                var series = resultSeriesMappings[testAndResults.results.Name];

                var serieDurationValues = (ObservableCollection<ObservablePoint>)series.DurationSeries.Values;
                var serieResultValues = (ObservableCollection<ObservablePoint>)series.ResultSseries.Values;

                var durationPoint = new ObservablePoint(lastCheck.Ticks, testAndResults.results.Duration);
                serieDurationValues.Add(durationPoint);

                var resultPoint = new ObservablePoint(lastCheck.Ticks, testAndResults.results.ResultCount);
                serieResultValues.Add(resultPoint);

                if (testAndResults.results.Duration == -1)
                {
                    testAndResults.results.PropertyChanged += (s, e) =>
                    {
                        DispatcherQueue.TryEnqueue(() =>
                        {
                            switch (e.PropertyName)
                            {
                                case nameof(TestResults.ResultCount):
                                    resultPoint.Y = ((TestResults)s).ResultCount;
                                    break;

                                case nameof(TestResults.Duration):
                                    durationPoint.Y = ((TestResults)s).Duration;
                                    break;
                            }
                        });
                    };
                }
            }

            testAndResults.test.Definition.Status = testAndResults.test.Status;

            testAndResults.test.RaisePropertyChanged();
            testAndResults.results.RaisePropertyChanged();

        });
    }

    [RelayCommand]
    private void MonitorAdd()
    {
        GenericPopup.OpenNew<MonitoringDetails>(isWizard: true);
    }

    [RelayCommand]
    private async void MonitorClearAllResults()
    {
        if (await Confirm("Are you sure you want to clear all results? This cannot be undone."))
        {
            MonitorResultsSeries.Clear();
            MonitorResultsView.Clear();
        }
    }

    [RelayCommand(CanExecute = nameof(CanExecuteClearAll))]
    private async void MonitorClearAll()
    {
        if (await Confirm("Are you sure you want to remove all monitoring definitions?"))
        {
            App.Instance.CurrentProject.TestDefinitions.Clear();
            MonitorClearAllCommand.NotifyCanExecuteChanged();
        }
    }

    private async Task<bool> Confirm(string message)
    {
        var dialog = new ContentDialog()
        {
            Title = "Confirmation",
            Content = message,
            PrimaryButtonText = "Yes",
            SecondaryButtonText = "No",
            XamlRoot = this.XamlRoot
        };

        return await dialog.ShowAsync() == ContentDialogResult.Primary;
    }

    private bool CanExecuteClearAll => App.Instance.CurrentProject?.TestDefinitions?.Count > 0;

    [RelayCommand]
    private void MonitorCopy(TestDefinition definition)
    {

    }

    /// <summary>
    /// Have to use a click handler as an ICommand doesn't work in a DataGridTemplateColumn for some teason...
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void monitorEdit_Click(object sender, RoutedEventArgs e)
    {
        var editButton = (Button)sender;
        var target = (TestDefinition)editButton.CommandParameter;

        GenericPopup.OpenNew<MonitoringDetails>(target, true);
    }

    /// <summary>
    /// Have to use a click handler as an ICommand doesn't work in a DataGridTemplateColumn for some teason...
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void monitorDelete_Click(object sender, RoutedEventArgs e)
    {
        var editButton = (Button)sender;
        var target = (TestDefinition)editButton.CommandParameter;

        foreach (var m in App.Instance.CurrentProject.TestDefinitions)//.Where(m => m.PrecedingSteps.Any()))
        {
            m.PrecedingSteps.Remove(target);
        }
        App.Instance.CurrentProject.TestDefinitions.Remove(target);
    }

    /// <summary>
    /// Have to use a click handler as an ICommand doesn't work in a DataGridTemplateColumn for some teason...
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void resultsDetails_Click(object sender, RoutedEventArgs e)
    {
        GenericPopup.OpenNew<MonitorResultsViewer>(((Button)sender).CommandParameter);
    }

    private void setChartPanning(ThreadPoolTimer _)
    {
        DispatcherQueue.TryEnqueue(() =>
        {
            xTimeAxis.MinLimit = DateTime.Now.Subtract(chartTimeSpanSeconds).Ticks;
            xTimeAxis.MaxLimit = DateTime.Now.Add(chartTimeSpanSeconds).Ticks;
        });
    }

    [RelayCommand(CanExecute = nameof(IsRunning))]
    private void Stop()
    {
        panningDelayTimer?.Cancel();
        globalTimer?.Cancel();

        timers.ForEach(timer => timer.Cancel());
        timers.Clear();

        IsRunning = false;
    }

    private void btnGrHTML_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsHTML();

    private void btnGrCopy_Click(object sender, RoutedEventArgs e) => gridResults.CopyToClipboard();

    private void btnGrCSV_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsXLSX();

}
