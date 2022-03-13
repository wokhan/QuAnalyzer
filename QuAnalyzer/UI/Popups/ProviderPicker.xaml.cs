
using CommunityToolkit.Mvvm.Input;

using NuGet.Packaging.Core;

using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.UI.Pages;

[ObservableObject]
public partial class ProviderPicker : Page
{
    [ObservableProperty]
    private IEnumerable<dynamic> nugetPackages;

    [ObservableProperty]
    [AlsoNotifyCanExecuteFor(nameof(CreateProviderCommand))]
    private DataProviderDefinition selectedProviderDef;

    public ProviderPicker()
    {
        this.Loaded += ProviderPicker_Loaded;

        InitializeComponent();
    }

    private async void ProviderPicker_Loaded(object sender, RoutedEventArgs e)
    {
        NugetPackages = await App.Instance.ProvidersMan.GetNugetPackages();
    }

    [ICommand(CanExecute = nameof(CanExecuteCreateProvider))]
    private void CreateProvider()
    {
        var instanceName = $"{selectedProviderDef.Name}#{App.Instance.CurrentProject.CurrentProviders.Count}";

        this.NavigationService.Navigate(new ProviderEditor(selectedProviderDef.Name, instanceName));
    }

    private bool CanExecuteCreateProvider => SelectedProviderDef is not null;

    [ICommand]
    private void Cancel()
    {
        Window.GetWindow(this).Close();
    }

    [ICommand(AllowConcurrentExecutions = false)]
    private async Task InstallPackage(PackageIdentity packageId)
    {
        await App.Instance.ProvidersMan.InstallPackage(packageId);
    }
}
