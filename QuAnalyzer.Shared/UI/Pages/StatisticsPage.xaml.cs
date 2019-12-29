using QuAnalyzer.Features.Statistics;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using Wokhan.Collections;
using Wokhan.Collections.Generic.Extensions;
using Wokhan.Core.Extensions;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class StatisticsPage : Page, INotifyPropertyChanged
    {
        public string[] ChartTypes { get { return new[] { "Pie", "Bar", "Doughnut" }; } }

        private string _chartType = "Bar";
        public string ChartType
        {
            get { return _chartType; }
            set { _chartType = value; NotifyPropertyChanged(nameof(ChartType)); ComputedStats.Refresh(); }
        }

        private int _progress;
        public int Progress
        {
            get { return _progress; }
            set { _progress = value; NotifyPropertyChanged(nameof(Progress)); }
        }

        public ObservableDictionary<string, ResultsStruct> ComputedStats { get; } = new ObservableDictionary<string, ResultsStruct>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public StatisticsPage()
        {
            //ComputedStats = new Dictionary<string, ResultsStruct>();

            InitializeComponent();
            ((App)App.Current).PropertyChanged += (s, e) => { if (e.PropertyName == nameof(App.CurrentSelection)) { UpdateSelection(); } };
        }

        private void UpdateSelection()
        {
            var (prov, repo) = ((App)App.Current).CurrentSelection;
            if (prov != null && btnAuto.IsChecked.Value)
            {
                Computedata(prov, repo);
            }
        }


        private async void UpdateMinMaxAvg(string h, ResultsStruct.Stats stats)
        {
            await Dispatcher.InvokeAsync(() =>
            {
                var c = ComputedStats[h];
                c.Statistics = stats;
            });
        }

        private async void UpdateFrequencies(string h, Values stats)
        {
            await Dispatcher.InvokeAsync(() =>
            {
                ComputedStats[h].Frequencies.Add(stats);
            });
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

            var headers = prv.GetColumns(repo);

            foreach (var h in headers)
            {
                ComputedStats.Add(h.Name, new ResultsStruct());
            }

            await System.Threading.Tasks.Task.Run(() =>
            {
                Progress = -1;
                var defaults = headers.Select(h => h.Type.GetDefault()).ToList();

                var data = prv.GetQueryable(repo);

                headers.AsParallel(false).ForAll((h) =>
                {
                    var test = Features.Statistics.Statistics.GetData(data, h);

                    foreach (var x in test)
                    {
                        UpdateFrequencies(h.Name, x);
                    }

                    var bobby = Features.Statistics.Statistics.GetStats(data, h);

                    UpdateMinMaxAvg(h.Name, bobby);
                });
            }).ConfigureAwait(false);
        }
        //private async void UpdateResults(string key, string itkey, int itcnt)
        //{
        //    await Dispatcher.InvokeAsync(() =>
        //    {
        //        var sec = ComputedStats.Single(c => c.Key == key);
        //        sec.Value.Add(new Values() { Category = itkey, Frequency = itcnt });
        //    });
        //}
    }
}