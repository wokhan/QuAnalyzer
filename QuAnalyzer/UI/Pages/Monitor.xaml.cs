using De.TorstenMandelkow.MetroChart;
using QuAnalyzer.Features.Monitoring;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.UI.Popups;
using QuAnalyzer.UI.Windows;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        private static DateTime firstStart;
        readonly DispatcherTimer timer = new DispatcherTimer();

        public static ObservableCollection<ResultsClass> MonitorResults { get; } = new ObservableCollection<ResultsClass>();
        public ListCollectionView MonitorResultsView { get; } = new ListCollectionView(MonitorResults);

        public Monitor()
        {
            this.DataContext = this;

            //_monitorResultsView.GroupDescriptions.Add(new PropertyGroupDescription("Step"));

            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            graph.Series.Clear();

            if (btnEnable.IsChecked.Value)
            {
                var gcd = gridSteps.SelectedItems.Cast<MonitorItem>().Select(m => m.Interval).GreatestCommonDiv();
                // TODO: * 30 ??? Why?
                timer.Interval = TimeSpan.FromSeconds(gcd * 30);
                timer.Tick += timer_Tick;
                timer.Start();

                timer_Tick(null, null);
            }
            else
            {
                btnEnable.IsEnabled = false;
            }

            firstStart = DateTime.Now;

            foreach (var monitor in gridSteps.SelectedItems.Cast<MonitorItem>())
            {
                monitor.AttachEvent(monitor_OnAdd, monitor_OnResult);
                monitor.Start();
            }
        }

        void monitor_OnAdd(ResultsClass results)
        {
            MonitorResults.Add(results);
            gridResults.ScrollIntoView(results);
        }

        void monitor_OnResult(ResultsClass results)
        {
            if (btnEnable.IsChecked.Value)
            {
                var series = graph.Series.OrderByDescending(s => (DateTime)s.Tag).First(s => results.LastCheck >= ((DateTime)s.Tag));
                var p = series.Items.Cast<MultiValueDatePoint>().First(i => i.Name == results.Step.Name);
                p.Values = results.Duration;
                p.Y = results.ResultCount;

                series.BringIntoView();
            }
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

        private void btnStartAll_Click(object sender, RoutedEventArgs e)
        {
            graph.Series.Clear();

            var gcd = ((App)Application.Current).CurrentProject.MonitorItems.Select(m => m.Interval).GreatestCommonDiv();

            if (btnEnable.IsChecked.Value)
            {
                timer.Interval = TimeSpan.FromSeconds(gcd * 30);
                timer.Tick += timer_Tick;
                timer.Start();

                timer_Tick(null, null);
            }
            else
            {
                btnEnable.IsEnabled = false;
            }

            firstStart = DateTime.Now;

            foreach (var monitor in ((App)Application.Current).CurrentProject.MonitorItems)
            {
                monitor.AttachEvent(monitor_OnAdd, monitor_OnResult);
                monitor.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;

            var timeslice = timer.Interval.TotalSeconds / 30;
            var mis = ((App)Application.Current).CurrentProject.MonitorItems.ToList();
            for (int i = 0; i < 35; i++)
            {
                var x = now.AddSeconds(timeslice * i);
                var xname = x.ToString("dd/mm/yyyy HH:mm:ss");
                var uname = "Series_" + ((uint)xname.GetHashCode()).ToString();
                if (!graph.Series.Any(s => s.Name == uname))
                {
                    var series = new ChartSeries()
                    {
                        Name = uname,
                        SeriesTitle = xname,
                        ValueMember = nameof(MultiValueDatePoint.Y),
                        DisplayMember = nameof(MultiValueDatePoint.Name),
                        Tag = x
                    };

                    graph.Series.Add(series);

                    mis.ForEach(m => series.Items.Add(new MultiValueDatePoint() { Name = m.Name }));
                }
            }
            /*
            graph.Series.Add(new ChartSeries()
            {
                Name = "Duration_" + ((uint)xname.GetHashCode()).ToString(),
                SeriesTitle = xname,
                ValueMember = "Duration",
                DisplayMember = "Name",
                Tag = x
            });*/
        }

        private void btnStopAll_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            btnEnable.IsEnabled = true;

            foreach (var monitor in ((App)Application.Current).CurrentProject.MonitorItems)
            {
                monitor.Stop();
            }
        }

        private void btnGrHTML_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsHTML();

        private void btnGrCopy_Click(object sender, RoutedEventArgs e) => gridResults.CopyToClipboard();

        private void btnGrCSV_Click(object sender, RoutedEventArgs e) => gridResults.ExportAsXLSX();

    }
}
