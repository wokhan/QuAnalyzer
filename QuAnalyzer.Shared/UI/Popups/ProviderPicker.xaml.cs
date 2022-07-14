
using CommunityToolkit.Mvvm.Input;

using NuGet.Packaging.Core;

using QuAnalyzer.Core.Helpers;
using QuAnalyzer.UI.Windows;

using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.UI.Pages;

[ObservableObject]
public partial class ProviderPicker : Page
{
    [ObservableProperty]
    private IEnumerable<NugetPackage> nugetPackages;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CreateProviderCommand))]
    private DataProviderDefinition selectedProviderDef;

    public ProviderPicker()
    {
        this.Loaded += ProviderPicker_Loaded;

        InitializeComponent();
    }

    private async void ProviderPicker_Loaded(object sender, RoutedEventArgs e)
    {
        GenericPopup.UpdateCurrent(this, CreateProviderCommand, "New provider");
        
        NugetPackages = await App.Instance.ProvidersMan.GetNugetPackages();
    }

    [RelayCommand(CanExecute = nameof(CanExecuteCreateProvider))]
    private void CreateProvider()
    {
        Frame.Navigate(typeof(ProviderEditor), selectedProviderDef.Name);
    }

    private bool CanExecuteCreateProvider => SelectedProviderDef is not null;

    [RelayCommand(AllowConcurrentExecutions = false)]
    private async Task InstallPackage(PackageIdentity packageId)
    {
        await App.Instance.ProvidersMan.InstallPackage(packageId);
    }
}
