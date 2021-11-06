using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;

using QuAnalyzer.Features.Statistics;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Core.Extensions;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Pages
{

    public partial class StatisticsPage : Page, INotifyPropertyChanged
    {
        public string[] ChartTypes { get; } = new[] { "Pie", "Bar", "Doughnut" };

        private string _chartType = "Pie";
        public string ChartType
        {
            get { return _chartType; }
            set { _chartType = value; NotifyPropertyChanged(nameof(ChartType)); }
        }

        private bool _ignoreEmptyInChart = true;
        public bool IgnoreEmptyInChart
        {
            get { return _ignoreEmptyInChart; }
            set { _ignoreEmptyInChart = value; NotifyPropertyChanged(nameof(IgnoreEmptyInChart)); }
        }

        private int _progress;

        public int Progress
        {
            get { return _progress; }
            set { _progress = value; NotifyPropertyChanged(nameof(Progress)); }
        }


        //      public ObservableDictionary<string, Series> ComputedStatsForGraph { get; } = new ObservableDictionary<string, Series>();
        public ObservableCollection<StatisticsHolder> ComputedStats { get; } = new ObservableCollection<StatisticsHolder>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public StatisticsPage()
        {
            //ComputedStats = new Dictionary<string, ResultsStruct>();

            InitializeComponent();

            //LiveCharts.HasMapFor<Values>((v, point) => { point.PrimaryValue = v.Frequency; });

            //ComputedStats.CollectionChanged += ComputedStats_CollectionChanged;
            ((App)App.Current).PropertyChanged += (s, e) => { if (e.PropertyName == nameof(App.CurrentSelection)) { UpdateSelection(); } };
        }

        private void ComputedStats_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //((ResultsStruct)e.NewItems[0]).Frequencies.CollectionChanged += null;
            //            ComputedStatsForGraph.AddAll(e.NewItems.Cast<ResultsStruct>().Select(x => new PieSeries(Mappers.Pie<ResultsStruct>().Value(data => data))));
        }

        private void UpdateSelection()
        {
            var (prov, repo) = ((App)App.Current).CurrentSelection;
            if (prov is not null && btnAuto.IsChecked.Value)
            {
                Computedata(prov, repo);
            }
        }

        private void btnCompute_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var (prov, repo) = ((App)App.Current).CurrentSelection;
            Computedata(prov, repo);
        }

        private async void Computedata(IDataProvider prv, string repo)
        {
            Progress = 0;
            ComputedStats.Clear();
            
            await Task.Run(async () =>
            {
                Progress = -1;

                var headers = prv.GetColumns(repo);
                
                var data = prv.GetQueryable(repo);

                var results = headers.ToDictionary(h => h, h => new StatisticsHolder() { Name = h.Name, Source = data });
                await Dispatcher.InvokeAsync(() => ComputedStats.AddAll(results.Values));

                headers.AsParallel().ForAll(h => results[h].Update(h, Dispatcher));
            }).ConfigureAwait(false);
        }
    }
}