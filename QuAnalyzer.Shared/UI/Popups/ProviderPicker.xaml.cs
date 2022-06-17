
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Media;

using NuGet.Packaging.Core;

using QuAnalyzer.Core.Helpers;

using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.UI.Pages;

[ObservableObject]
public partial class ProviderPicker : Page
{
    [ObservableProperty]
    private IEnumerable<NugetPackage> nugetPackages;

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
        var dialog = (ContentDialog)this.Parent;
        dialog.Title = "New provider";
        dialog.PrimaryButtonText = "Next";
        dialog.PrimaryButtonCommand = CreateProviderCommand;
        dialog.CloseButtonText = "Cancel";
        dialog.Width = 800;
        dialog.Height = 500;

        NugetPackages = await App.Instance.ProvidersMan.GetNugetPackages();
    }

    [ICommand(CanExecute = nameof(CanExecuteCreateProvider))]
    private void CreateProvider()
    {
        var instanceName = $"{selectedProviderDef.Name}#{App.Instance.CurrentProject.CurrentProviders.Count}";

        ((ContentDialog)this.Parent).Content = new ProviderEditor(selectedProviderDef.Name, instanceName);
    }

    private bool CanExecuteCreateProvider => SelectedProviderDef is not null;

    [ICommand(AllowConcurrentExecutions = false)]
    private async Task InstallPackage(PackageIdentity packageId)
    {
        await App.Instance.ProvidersMan.InstallPackage(packageId);
    }
}
