using System.Windows;
using System.Windows.Controls;

namespace QuAnalyzer.UI.Controls
{
    public partial class DataCompareProgress : UserControl
    {
        public event RoutedEventHandler DetailsHandler;
        public event RoutedEventHandler CancelHandler;
        public event RoutedEventHandler DeleteHandler;

        public DataCompareProgress()
        {
            InitializeComponent();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            DetailsHandler?.Invoke(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CancelHandler?.Invoke(sender, e);
        }

        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteHandler?.Invoke(sender, e);
        }
    }
}
