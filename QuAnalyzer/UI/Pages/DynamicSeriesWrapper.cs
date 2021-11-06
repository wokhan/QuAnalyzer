using LiveChartsCore;
using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView;

using QuAnalyzer.Features.Statistics;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;

using Wokhan.Collections.Generic.Extensions;

namespace QuAnalyzer.UI.Pages
{
    public class DynamicSeriesWrapper : Freezable
    {
        string type;
        private static Axis xAxis;

        public string Type { set => type = value; }

        private int InnerRadius => type == "Pie" ? 0 : 20;

        // Never called ?! Hence using a property changed handler below...
        public StatisticsHolder Source
        {
            get => (StatisticsHolder)this.GetValue(SourceProperty);
            set { this.SetValue(SourceProperty, value); Init(); }
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(nameof(Source), typeof(StatisticsHolder), typeof(DynamicSeriesWrapper), new PropertyMetadata(null, sourcePropertyChanged));

        private static void sourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DynamicSeriesWrapper)d).Init();
        }

        public ObservableCollection<ISeries> Series { get; } = new();

        public IEnumerable<Axis> XAxes { get; } = new[] { xAxis = new Axis() { TextSize = 12, LabelsRotation = -45, MinStep = 1, ForceStepToMin = true, Labels = new ObservableCollection<string>() } };

        public IEnumerable<Axis> YAxes { get; } = new[] { new Axis() { MinStep = 1, TextSize = 12 } };

        public DynamicSeriesWrapper() : base() { }

        protected override Freezable CreateInstanceCore()
        {
            return new DynamicSeriesWrapper();
        }

        private void Init()
        {
            Series.Clear();
            xAxis.Labels.Clear();
            if (type == "Bar")
            {
                xAxis.Labels.AddAll(Source.Occurences.Select(f => f.Category));
                Series.Add(new ColumnSeries<OccurencesResult>() { Values = Source.Occurences, Mapping = MapColumnPoint, TooltipLabelFormatter = DefaultTooltipFormatter, DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top });
                Source.Occurences.CollectionChanged += Frequencies_CollectionChanged;
            }
            else
            {
                Series.AddAll(Source.Occurences.Select(f => new PieSeries<OccurencesResult>() { Name = f.Category, Values = new[] { f }, InnerRadius = InnerRadius, Mapping = MapPiePoint, TooltipLabelFormatter = DefaultTooltipFormatter, DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Start }));
                Source.Occurences.CollectionChanged += Frequencies_CollectionChanged;
            }
        }

        private string DefaultTooltipFormatter(ChartPoint p)
        {
            return $"{p.Context.Label} - {p.PrimaryValue} occurence(s)";
        }

        private void MapColumnPoint(OccurencesResult v, ChartPoint point)
        {
            point.PrimaryValue = v.Frequency;
            point.SecondaryValue = v.CategoryIndex;
        }

        private void MapPiePoint(OccurencesResult v, ChartPoint point)
        {
            point.PrimaryValue = v.Frequency;
        }

        private void Frequencies_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (type == "Bar")
                {
                    xAxis.Labels.AddAll(e.NewItems.Cast<OccurencesResult>().Select(f => f.Category));
                }
                else
                {
                    Series.AddAll(e.NewItems.Cast<OccurencesResult>().Select(value => new PieSeries<OccurencesResult>() { Name = value.Category, Values = new[] { value }, InnerRadius = InnerRadius, Mapping = MapPiePoint }));
                }
            }
        }
    }
}