using QuAnalyzer.Core.Helpers;
using QuAnalyzer.UI.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Wokhan.Data.Providers;
using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.UI.Pages
{
    public partial class ProviderPicker : Page, INotifyPropertyChanged
    {
        private Window _owner => Window.GetWindow(this);

        public CollectionView ProvidersView { get; private set; }

        public ProviderPicker()
        {
            InitializeComponent();

            var providersLst = (CollectionView)CollectionViewSource.GetDefaultView(((App)App.Current).ProvidersMan.Providers);
            providersLst.GroupDescriptions.Add(new PropertyGroupDescription(nameof(DataProviderDefinition.Category)));
            ((App)Application.Current).ProvidersMan.PropertyChanged += ProvidersMan_PropertyChanged;
            lstProvidersTypes.ItemsSource = providersLst;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ProvidersMan_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ProvidersManager.Providers))
            {
                PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(nameof(ProvidersView)));
            }
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
