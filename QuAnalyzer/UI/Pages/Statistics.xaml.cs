using Wokhan.Data.Providers.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System;
using System.ComponentModel;
using QuAnalyzer.Helpers;
using System.Linq.Expressions;
using Wokhan.Collections.Extensions;
using Wokhan.Core.Extensions;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Page, INotifyPropertyChanged
    {
        public string[] ChartTypes { get { return new[] { "Pie", "Bar", "Doughnut" }; } }

        private string _chartType = "Bar";
        public string ChartType
        {
            get { return _chartType; }
            set { _chartType = value; NotifyPropertyChanged("ChartType"); ComputedStats.Refresh(); }
        }

        private int _progress;
        public int Progress
        {
            get { return _progress; }
            set { _progress = value; NotifyPropertyChanged("Progress"); }
        }

        public ObservableDictionary<string, ResultsStruct> ComputedStats { get; } = new ObservableDictionary<string, ResultsStruct>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class Values
        {
            public string FrequencyStr { get { return Category + " [" + Frequency + "]"; } }
            public object SelectedItem { get; set; }
            public string Category { get; set; }
            public int Frequency { get; set; }
        }

        public Statistics()
        {
            //ComputedStats = new Dictionary<string, ResultsStruct>();

            InitializeComponent();
        }

        private void lstDataSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstDataSources.SelectedItem != null && btnAuto.IsChecked.Value)
            {
                Computedata();
            }
        }

        private async void Computedata()
        {
            Progress = 0;
            ComputedStats.Clear();

            var prv = (IDataProvider)lstDataProviders.SelectedItem;
            var repo = (string)lstDataSources.SelectedItem;

            var headers = prv.GetColumns(repo);

            foreach (var h in headers)
            {
                ComputedStats.Add(h.Name, new ResultsStruct());
            }

            await System.Threading.Tasks.Task.Run(() =>
            {
                Progress = -1;
                var defaults = headers.Select(h => h.Type.GetDefault()).ToList();

                var data = prv.GetData(repo);

                headers.AsParallel(false).ForAll((h) =>
                {
                    var m = typeof(Statistics).GetMethod("GetTypedData", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                                              .MakeGenericMethod(data.GetInnerType(), h.Type);
                    var test = (IEnumerable<Values>)m.Invoke(null, new object[] { data, h.Name });

                    foreach (var x in test)
                    {
                        UpdateFrequencies(h.Name, x);
                    }

                    var mx = typeof(Statistics).GetMethod("GetTypedStats", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                                               .MakeGenericMethod(data.GetInnerType(), h.Type);
                    var bobby = (ResultsStruct.Stats)mx.Invoke(null, new object[] { data, h.Name });

                    UpdateMinMaxAvg(h.Name, bobby);
                });
            });
        }

        static readonly Type[] numericTypes = new[] { typeof(int), typeof(int?), typeof(decimal), typeof(decimal?), typeof(double), typeof(double?), typeof(long), typeof(long?) };

        private static ResultsStruct.Stats GetTypedStats<T, TK>(IQueryable data, string key)
        {
            var param = Expression.Parameter(typeof(T));
            var fn = Expression.GetFuncType(typeof(T), typeof(TK));
            var group = Expression.Lambda<Func<T, TK>>(Expression.Property(param, key), param);

            var xx = ((IQueryable<T>)data).GroupBy(x => true, group)
                                          .Select(g => new { Min = g.Min(), Max = g.Max(), Count = g.Count(), /*Average = g.Average(), DistinctCount = g.Distinct().Count(),*/ EmptyCount = g.Count(x => x == null) })
                                          .First();

            return new ResultsStruct.Stats { Min = xx.Min, Max = xx.Max, Average = "Not available", DistinctCount = "Not available", EmptyCount = xx.EmptyCount };//, Average = xx.Average, Count = xx.Count, DistinctCount = xx.DistinctCount, EmptyCount = xx.EmptyCount };
        }

        private static IEnumerable<Values> GetTypedData<T, TK>(IQueryable data, string key)
        {
            var param = Expression.Parameter(typeof(T));
            var fn = Expression.GetFuncType(typeof(T), typeof(TK));
            var group = Expression.Lambda<Func<T, TK>>(Expression.Property(param, key), param);

            var xx = ((IQueryable<T>)data).GroupBy(group, group)// ((IQueryable<T>)data).GroupBy((dynamic)group)
                                        .Select(g => new { g.Key, Cnt = g.Count() })
                                        .OrderByDescending(x => x.Cnt)
                                        .Take(10)
                                        .ToList()
                                        .Select(x => new Values() { Category = (x.Key != null ? x.Key.ToString() : String.Empty), Frequency = x.Cnt })
                                        .ToList();

            return xx;
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

        public class ResultsStruct : NotifierHelper
        {
            public ObservableCollection<Values> Frequencies { get; } = new ObservableCollection<Values>();

            private Stats _statistics;
            public Stats Statistics
            {
                get { return _statistics; }
                internal set { _statistics = value; NotifyPropertyChanged("Statistics"); }
            }

            public class Stats
            {
                public object Min { get; set; }
                public object Max { get; set; }
                public object Average { get; set; }
                public object Count { get; set; }
                public object DistinctCount { get; set; }
                public object EmptyCount { get; set; }
            }
        }

        private void btnCompute_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Computedata();
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