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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Interaction logic for DataMonitor.xaml
    /// </summary>
    public partial class PerformancePage : Page
    {
        private long startDate;

        public ObservableCollection<ResultsClass> MonitorResultsView { get; } = new ObservableCollection<ResultsClass>();
        public TestCasesCollection SelectedTestsCollection { get; set; }
        public SeriesCollection ResultSeries { get; } = new SeriesCollection(Mappers.Xy<DateTimePoint>().X(d => d.DateTime.Ticks).Y(d => d.Value));
        public Dictionary<string, Series[]> ResultSeriesMappings { get; private set; }

        public PerformancePage()
        {
            this.DataContext = this;

            MonitorResultsView.CollectionChanged += MonitorResultsView_CollectionChanged;

            InitializeComponent();
        }

        private void MonitorResultsView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
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

        public void run()
        {
            var ntests = int.Parse(txtNbOccur.Text, NumberFormatInfo.CurrentInfo);
            var parallel = int.Parse(txtNbPara.Text, NumberFormatInfo.CurrentInfo);

            MonitorResultsView.Clear();
            ResultSeries.Clear();

            ResultSeriesMappings = SelectedTestsCollection.TestCases.ToDictionary(t => t.Name, t => new Series[] {
                new StepLineSeries() { ScalesYAt = 1, Title = t.Name + " (Freq)", Values = new ChartValues<DateTimePoint>() },
                new LineSeries() { Title = t.Name + " (Duration)", Values = new ChartValues<DateTimePoint>() }
            });
            ResultSeries.AddRange(ResultSeriesMappings.SelectMany(_ => _.Value));

            startDate = DateTimeOffset.Now.Ticks;
            BindingOperations.EnableCollectionSynchronization(MonitorResultsView, MonitorResultsView);

            Task.Run(() => Performance.Run(SelectedTestsCollection, ntests, parallel, MonitorResultsView));
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            run();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e) => Popup.OpenNew(new MonitoringDetails((MonitorItem)((Button)sender).Tag));

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selection = (KeyValuePair<IDataProvider, string>)((Button)sender).Tag;

        }


        private void btnGrHTML_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsHTML();

        private void btnGrCopy_Click(object sender, RoutedEventArgs e) => gridResults.CopyToClipboard();

        private void btnGrCSV_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsXLSX();

        private void btnStopAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStartAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var perfItems = ((App)App.Current).CurrentProject.PerformanceItems;
            perfItems.Add(new TestCasesCollection() { Name = "Tests collection #" + (perfItems.Count + 1), TestCases = new ObservableCollection<TestCase>() });
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).CurrentProject.PerformanceItems.Clear();
        }

        private void lstTestCases_Drop(object sender, DragEventArgs e)
        {
            var collection = (TestCasesCollection)((ListView)sender).Tag;
            var (prov, repo) = (KeyValuePair<IDataProvider, string>)e.Data.GetData(typeof(KeyValuePair<IDataProvider, string>));

            collection.TestCases.Add(new TestCase() { Name = prov.Name, Repository = repo, GetData = (values, stats) => prov.GetQueryable(repo, values, stats) });
        }
    }
}
