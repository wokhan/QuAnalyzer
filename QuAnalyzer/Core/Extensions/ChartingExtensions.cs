using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuAnalyzer.Core.Extensions
{
    public static class ChartingExtensions
    {

        public static Series ToSeries<T>(this IEnumerable<T> src, string name, SeriesChartType chartType, string xmember, string member)
        {
            Series s = new Series(name) { ChartType = chartType, IsVisibleInLegend = true, LegendText = "#SERIESNAME\nAvg = #AVG\nMax = #MAX\nMin = #MIN" };

            if (chartType == SeriesChartType.FastLine || chartType == SeriesChartType.Line || chartType == SeriesChartType.Spline || chartType == SeriesChartType.StepLine)
            {
                s.BorderWidth = 2;
                s.MarkerStyle = MarkerStyle.Circle;
                s.MarkerSize = 8;
            }

            Type t = typeof(T);

            string[] members = member.Split('|');
            int i = 1;
            s.ToolTip = "#SERIESNAME (#INDEX)\n" + xmember + " = #VALX\n" + String.Join("\n", members.Select(m => m + " = #VALY" + i++).ToArray());

            var yProperties = members.Select(m => t.GetField(m));
            var xProperty = t.GetField(xmember);

            foreach (T item in src.AsParallel())
            {
                s.Points.Add(new DataPoint(Convert.ToDouble(xProperty.GetValue(item)), yProperties.Select(yProp => Convert.ToDouble(yProp.GetValue(item))).ToArray()));
            }

            return s;
        }

        public static Dictionary<string, Series> ToMultiSeries<T>(this IEnumerable<T> src, Func<T, string> nameGetter, string xmemberName, Func<T, double> xmemberGetter, string[] ymembersNames, Func<T, double[]> ymembersGetter, SeriesChartType chartType, bool secondaryAxis = false, bool logScale = false)
        {
            return src.GroupBy(nameGetter)
                      .Select(srcx =>
                      {
                          Series s = new Series(srcx.Key) { ChartType = chartType, IsVisibleInLegend = true, LegendText = "#SERIESNAME\nAvg = #AVG\nMax = #MAX\nMin = #MIN" };

                          if (chartType == SeriesChartType.FastLine || chartType == SeriesChartType.Line || chartType == SeriesChartType.Spline || chartType == SeriesChartType.StepLine)
                          {
                              s.BorderWidth = 2;
                              s.MarkerStyle = MarkerStyle.Circle;
                              s.MarkerSize = 8;
                          //s.IsValueShownAsLabel = true;
                          //s.Label = s.Name;
                      }

                          s.YAxisType = secondaryAxis ? AxisType.Secondary : AxisType.Primary;
                          if (logScale)
                          {
                              s.SetCustomProperty("NeedsLog", "true");
                          }

                          int i = 1;
                          s.ToolTip = "#SERIESNAME (#INDEX)\n" + xmemberName + " = #VALX\n" + String.Join("\n", ymembersNames.Select(m => m + " = #VALY" + i++).ToArray());

                          foreach (T item in srcx.AsParallel())
                          {
                              s.Points.Add(new DataPoint(xmemberGetter(item), ymembersGetter(item)));
                          }

                          return s;
                      }).ToDictionary(s => s.Name, s => s);
        }


        public static Chart AddSeries(this Chart c, params Series[] series)
        {
            foreach (Series s in series)
            {
                c.Series.Add(s);
            }

            return c;
        }

        public static Chart With3D(this Chart c, int inclination)
        {
            c.ChartAreas[0].Area3DStyle = new ChartArea3DStyle() { Enable3D = true, Inclination = inclination };

            return c;
        }

        public static Chart ToChart(this IEnumerable<Series> series)
        {
            var c = new Chart();
            c.ChartAreas.Add(new ChartArea());
            //c.AutoSize = true;

            c.ChartAreas[0].AxisY.IsStartedFromZero = false;
            c.ChartAreas[0].AxisX.IsStartedFromZero = false;
            c.ChartAreas[0].AxisY2.IsStartedFromZero = false;
            c.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            c.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            c.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;

            if (series.Any(s => s.YAxisType == AxisType.Primary && s.GetCustomProperty("NeedsLog") != null))
            {
                c.ChartAreas[0].AxisY.IsLogarithmic = true;
            }
            if (series.Any(s => s.YAxisType == AxisType.Secondary && s.GetCustomProperty("NeedsLog") != null))
            {
                c.ChartAreas[0].AxisY2.IsLogarithmic = true;
            }

            //c.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            c.Legends.Add(new Legend() { Title = "Legend" });

            c.AddSeries(series.ToArray());


            return c;
        }

        public static Chart ToChart<T>(this IEnumerable<T> src, SeriesChartType chartType, string xValue, params string[] members)
        {
            return members.AsParallel().Select(m => src.ToSeries(m, chartType, xValue, m)).ToChart();
        }
    }
}
