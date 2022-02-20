
using QuAnalyzer.Core.Helpers;

using Wokhan.Data.Providers;
using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.UI.Pages;

public partial class ProviderPicker : Page
{
    public ProviderPicker()
    {
        //this.Loaded += ProviderPicker_Loaded;
        InitializeComponent();
    }

    //private async void ProviderPicker_Loaded(object sender, RoutedEventArgs e)
    //{
    //    await App.Instance.ProvidersMan.AddFromNuget();
    //}

    private void btnNewPrv_Click(object sender, RoutedEventArgs e)
    {
        var providerName = $"{((DataProviderDefinition)lstProvidersTypes.SelectedItem).Name}#{App.Instance.CurrentProject.CurrentProviders.Count}";

        this.NavigationService.Navigate(new ProviderEditor(providerName));
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        Window.GetWindow(this).Close();
    }
}
