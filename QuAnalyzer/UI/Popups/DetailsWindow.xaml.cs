using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

using QuAnalyzer.Features.Comparison;
using QuAnalyzer.UI.Controls;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.UI.Popups
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Page
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /*private int _gridDiffExported;
        public int GridDiffExported
        {
            get { return _gridDiffExported; }
            set { _gridDiffExported = value; NotifyPropertyChanged("GridDiffExported"); }
        }*/

        public DetailsWindow(IDataComparer r)
        {
            InitializeComponent();

            this.DataContext = r;
            //mainGrid.DataContext = r;

            InitGrids(r);
            this.Loaded += DetailsWindow_Loaded;

        }

        private void InitGrids(IDataComparer r)
        {
            var results = (ResultStruct<object[]>)((dynamic)r).Results;

            results.InitDiff(r);

            displayDiffData(dgDiff, results.MergedDiff, results.MergedHeaders, r.SourceKeys.Count);

            displayData(dgMissingSource, results.Source.Missing, r.SourceHeaders.ToArray(), r.SourceKeys.Count);
            displayData(dgMissingTarget, results.Target.Missing, r.TargetHeaders.ToArray(), r.TargetKeys.Count);

            displayData(dgSourceDups, results.Source.Duplicates, r.SourceHeaders.ToArray(), r.SourceKeys.Count);
            displayData(dgTargetDups, results.Target.Duplicates, r.TargetHeaders.ToArray(), r.TargetKeys.Count);

            displayData(dgSourcePerfectDups, results.Source.PerfectDups, r.SourceHeaders.ToArray(), r.SourceKeys.Count);
            displayData(dgTargetPerfectDups, results.Target.PerfectDups, r.TargetHeaders.ToArray(), r.TargetKeys.Count);

        }

        void DetailsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var actTab = tabs.Items.Cast<TabItem>().FirstOrDefault(t => t.IsEnabled);
            if (actTab is not null)
            {
                tabs.SelectedItem = actTab;
            }
            else
            {
                //await MahApps.Metro.Controls.Dialogs.DialogManager.ShowMessageAsync((MetroWindow)Window.GetWindow(this), "", "Nothing to show.");
                ((MetroWindow)Window.GetWindow(this)).ShowMessageAsync("", "Nothing to show.");
            }
        }

        private void displayDiffData(ExtendedDataGridView gridData, IEnumerable<DiffClass> data, string[] headers, int keysCount)
        {
            gridData.Columns.Clear();

            gridData.AutoGenerateColumns = false;

            gridData.Columns.Add(new DataGridTextColumn() { Header = "Origin", Binding = new Binding("Values[0]") });

            if (data is not null && data.Any())
            {
                /*if (headers is null)
                {
                    headers = Enumerable.Range(0, data.First().Values.Count()).Select(h => "P" + h).ToArray();
                }*/

                for (int i = 0; i < headers.Length; i++)
                {
                    var col = new DataGridTextColumn()
                    {
                        Header = headers[i],
                        Binding = new Binding("Values[" + (i + 1) + "]"),
                        FontWeight = (i < keysCount ? FontWeights.Bold : FontWeights.Normal)
                    };

                    Style style = new Style();
                    style.TargetType = typeof(DataGridCell);
                    style.BasedOn = gridData.CellStyle;

                    DataTrigger trigger = new DataTrigger();
                    trigger.Value = true;
                    trigger.Binding = new Binding("IsDiff[" + (i + 1) + "]");
                    trigger.Setters.Add(new Setter(DataGridCell.ForegroundProperty, Brushes.Red));

                    style.Triggers.Add(trigger);

                    col.CellStyle = style;

                    gridData.Columns.Add(col);
                }
            }
            else
            {
                gridData.IsEnabled = false;
            }

            gridData.Source = data.AsQueryable();
        }

        private void displayData<T>(ExtendedDataGridView gridData, IEnumerable<T> data, string[] headers, int keysCount)
        {
            /*gridData.Columns.Clear();

            gridData.AutoGenerateColumns = false;

            if (data is not null && data.Any())
            {
                gridData.Columns.AddAll(headers.Select((h, i) => new DataGridTextColumn()
                {
                    Header = h,
                    Binding = new Binding("[" + i + "]"),
                    FontWeight = (i < keysCount ? FontWeights.Bold : FontWeights.Normal)
                }));

                gridData.ItemsSource = data;
            }
            else
            {
                gridData.IsEnabled = false;
            }*/
            if (data is not null && data.Any())
            {
                gridData.CustomHeaders = headers.Select((h, i) => new ColumnDescription() { Name = $"it[{i}]", DisplayName = h + (i < keysCount ? "*" : "") }).ToList();
                gridData.Source = data.AsQueryable();
            }
            else
            {
                gridData.IsEnabled = false;
            }
        }
    }
}
