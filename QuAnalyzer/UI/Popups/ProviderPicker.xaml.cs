using System.Windows;
using System.Windows.Controls;

using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.UI.Pages
{
    public partial class ProviderPicker : Page
    {
        public ProviderPicker()
        {
            InitializeComponent();
        }

        private void btnNewPrv_Click(object sender, RoutedEventArgs e)
        {
            var providerName = $"{((DataProviderDefinition)lstProvidersTypes.SelectedItem).Name}#{((App)Application.Current).CurrentProject.CurrentProviders.Count}";

            this.NavigationService.Navigate(new ProviderEditor(providerName));
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
