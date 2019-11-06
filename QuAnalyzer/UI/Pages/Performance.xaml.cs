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
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Interaction logic for DataMonitor.xaml
    /// </summary>
    public partial class Performance : Page
    {
        private long startDate;

        public ObservableCollection<ResultsClass> MonitorResultsView { get; } = new ObservableCollection<ResultsClass>();

        public TestCasesCollection SelectedTestsCollection { get; set; }

        public SeriesCollection ResultSeries { get; } = new SeriesCollection(Mappers.Xy<DateTimePoint>().X(d => d.DateTime.Ticks).Y(d => d.Value));

        public Performance()
        {
            this.DataContext = this;

            //MonitorResultsView.CollectionChanged += MonitorResultsView_CollectionChanged;

            InitializeComponent();
        }

        private void MonitorResultsView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var results = e.NewItems.Cast<ResultsClass>().ToList();
            results.ForEach(t =>
            {
                var serie = ResultSeries.Cast<Series>().First(r => r.Title == t.Name + " (Freq)");
                serie.Values.Add(new DateTimePoint(t.LastCheck.DateTime, (double)t.LastCheck.Ticks - startDate + 1));

                if (t.Duration.ContainsKey("_TOTAL_DEFAULT"))
                {
                    var serie2 = ResultSeries.Cast<Series>().First(r => r.Title == t.Name + " (Duration)");
                    serie2.Values.Add(new DateTimePoint(t.LastCheck.DateTime, t.Duration["_TOTAL_DEFAULT"]));
                }
            });
        }

        public void run()
        {
            var ntests = int.Parse(txtNbOccur.Text);
            var parallel = int.Parse(txtNbPara.Text);

            ResultSeries.Clear();

            ResultSeries.AddRange(SelectedTestsCollection.TestCases.SelectMany(t => new Series[] {
                new LineSeries() { Title = t.Name + " (Freq)", Values = new ChartValues<DateTimePoint>() },
                new StepLineSeries() { Title = t.Name + " (Duration)", Values = new ChartValues<DateTimePoint>() }
            }));

            startDate = DateTimeOffset.Now.Ticks;
            Features.Performance.Performance.Run(SelectedTestsCollection, ntests, parallel, MonitorResultsView, addRes);
        }

        private void addRes(ResultsClass t, IList<Dictionary<string, string>> values)
        {
            Dispatcher.Invoke(() =>
            {
                if (t.Status != Status.Loading)
                {
                    var serie = ResultSeries.Cast<Series>().First(r => r.Title == t.Name + " (Freq)");
                    serie.Values.Add(new DateTimePoint(t.LastCheck.DateTime, (double)t.LastCheck.Ticks + 1));

                    var serie2 = ResultSeries.Cast<Series>().First(r => r.Title == t.Name + " (Duration)");
                    serie2.Values.Add(new DateTimePoint(t.LastCheck.DateTime, t.Duration["_TOTAL_DEFAULT"]));
                }
            });
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
