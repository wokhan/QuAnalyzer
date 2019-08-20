using QuAnalyzer.UI.Windows;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Wokhan.Data.Providers;
using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.UI.Pages
{
    public partial class ProviderPicker : Page
    {
        private Window _owner => Window.GetWindow(this);

        public ProviderPicker()
        {
            InitializeComponent();
        }

        private void btnNewPrv_Click(object sender, RoutedEventArgs e)
        {
            var providerName = ((DataProviderDefinition)lstProvidersTypes.SelectedItem).Name;
            var newprv = DataProviders.CreateInstance(providerName, new Dictionary<string, object>());
            //((App)Application.Current).CurrentProject.CurrentProviders.Add(newprv);

            newprv.Name = providerName + "#" + ((App)Application.Current).CurrentProject.CurrentProviders.Count;

            this.NavigationService.Navigate(new ProviderEditor(newprv));
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _owner.Close();
        }
    }
}
