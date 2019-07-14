using System;
using System.Windows;
using System.Windows.Controls;

namespace QuAnalyzer.Helpers
{
    public static class SharedCallback
    {
        public static Action<double> GetCallBackForExport(Panel innerhost, string worksheetName, string fileName)
        {
            var txtb = new TextBlock();
            if (worksheetName != null)
            {
                txtb.Text = "Exporting '" + worksheetName + "' data to " + fileName;
            }
            else
            {
                txtb.Text = "Exporting to " + fileName;
            }

            var pb = new ProgressBar();
            pb.Height = 20;
            pb.HorizontalAlignment = HorizontalAlignment.Stretch;
            pb.Maximum = 1;

            //var innerhost = new StackPanel();
            innerhost.Margin = new Thickness(20, 2, 20, 2);

            innerhost.Children.Add(txtb);
            innerhost.Children.Add(pb);

            return new Action<double>((i) => { pb.Dispatcher.Invoke(() => { if (pb.Value != i) { pb.Value = i; } }); });
        }
    }
}
