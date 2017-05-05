using De.TorstenMandelkow.MetroChart;
using QuAnalyzer.DataProviders.Contracts;
using QuAnalyzer.Helpers;
using QuAnalyzer.Extensions;
using QuAnalyzer.UI.Windows;
using Sparrow.Chart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Interaction logic for DataMonitor.xaml
    /// </summary>
    public partial class Monitor : Page
    {
        private static DateTime firstStart;
        DispatcherTimer timer = new DispatcherTimer();

        private static ObservableCollection<ResultsClass> _monitorResults = new ObservableCollection<ResultsClass>();
        public static ObservableCollection<ResultsClass> MonitorResults
        {
            get { return _monitorResults; }
        }

        private ListCollectionView _monitorResultsView = new ListCollectionView(_monitorResults);
        public ListCollectionView MonitorResultsView
        {
            get { return _monitorResultsView; }
        }

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

        void monitor_OnAdd(ResultsClass obj)
        {
            MonitorResults.Add(obj);
            gridResults.ScrollIntoView(obj);
        }

        void monitor_OnResult(ResultsClass obj)
        {
            if (btnEnable.IsChecked.Value)
            {
                var series = graph.Series.OrderByDescending(s => (DateTime)s.Tag).First(s => obj.LastCheck >= ((DateTime)s.Tag));
                var p = series.Items.Cast<DatePoint>().First(i => i.Name == obj.Step.Name);
                p.Duration = obj.Duration;
                p.Y = obj.ResultCount;

                series.BringIntoView();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var editor = new MonitoringDetails(new MonitorItem() { Name = "Monitor #" + (((App)Application.Current).CurrentProject.MonitorItems.Count + 1) });
            editor.Show();
            editor.Activate();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).CurrentProject.MonitorItems.Clear();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var editor = new MonitoringDetails((MonitorItem)((Button)sender).Tag);
            editor.Show();
            editor.Activate();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var mtoremove = (MonitorItem)((Button)sender).Tag;
            foreach (var m in ((App)App.Current).CurrentProject.MonitorItems.Where(m => m.PrecedingSteps.Any()))
            {
                m.PrecedingSteps.Remove(mtoremove);
            }
            ((App)App.Current).CurrentProject.MonitorItems.Remove(mtoremove);
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
                        ValueMember = "Y",
                        DisplayMember = "Name",
                        Tag = x
                    };

                    graph.Series.Add(series);

                    mis.ForEach(m => series.Items.Add(new DatePoint() { Name = m.Name }));
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

        private void btnGrHTML_Click(object sender, RoutedEventArgs e)
        {
            gridResults.ExportAsHTML();
        }

        private void btnGrCopy_Click(object sender, RoutedEventArgs e)
        {
            gridResults.CopyToClipboard();
        }

        private void btnGrCSV_Click(object sender, RoutedEventArgs e)
        {
            gridResults.ExportAsXLSX();
        }

    }
}
