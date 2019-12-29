using System.Windows;
using System.Windows.Controls;

namespace QuAnalyzer.UI.Controls
{

    /// <summary>
    /// Interaction logic for DataCompareProgressControl.xaml
    /// </summary>
    public partial class DataCompareProgress : UserControl
    {
        public event RoutedEventHandler DetailsHandler;
        public event RoutedEventHandler CancelHandler;

        public DataCompareProgress()
        {
            InitializeComponent();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            if (DetailsHandler != null)
            {
                DetailsHandler(sender, e);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CancelHandler != null)
            {
                CancelHandler(sender, e);
            }
        }

    }
}
