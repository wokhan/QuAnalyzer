
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.WinUI.Connectivity;

using QuAnalyzer.Core.Helpers;
using QuAnalyzer.UI.Popups;

using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.UI.Pages;

[ObservableObject]
public partial class ProviderPicker : Page
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Providers))]
    private IEnumerable<NugetPackage> nugetPackages = Enumerable.Empty<NugetPackage>();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CreateProviderCommand))]
    private object selectedProviderDefinition;

    [ObservableProperty]
    private bool isNugetAccessible = true;

    private IEnumerable<object> Providers => ProvidersManager.Providers.Cast<object>().Concat(NugetPackages);

    public ProviderPicker()
    {
        this.Loaded += ProviderPicker_Loaded;

        //ProvidersManager.Providers.CollectionChanged += (_, _) => OnPropertyChanged(nameof(Providers));

        InitializeComponent();
    }

    private async void ProviderPicker_Loaded(object sender, RoutedEventArgs e)
    {
        GenericPopup.UpdateCurrent(this, CreateProviderCommand, "New provider");

        if (NetworkHelper.Instance.ConnectionInformation.IsInternetAvailable)
        {
            isNugetAccessible = true;
            NugetPackages = await NugetManager.SearchPackages("Wokhan.Data.Providers.", "Wokhan.Data.Providers");
        }
        else
        {
            IsNugetAccessible = false;
        }
    }

    [RelayCommand(CanExecute = nameof(CanExecuteCreateProvider))]
    private void CreateProvider()
    {
        Frame.Navigate(typeof(ProviderEditor), ((DataProviderDefinition)selectedProviderDefinition).Name);
    }

    private bool CanExecuteCreateProvider => SelectedProviderDefinition is DataProviderDefinition;

    [RelayCommand(AllowConcurrentExecutions = false)]
    private async Task InstallPackage(NugetPackage package)
    {
        var cachePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\providers\\packages";
        var installPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\providers\\{package.Identity.Id}";

        //TODO: make this framework agnostic        
        await ProvidersManager.InstallFromNuget(package, "netcoreapp3.1", cachePath, installPath);

        OnPropertyChanged(nameof(Providers));
    }

    [RelayCommand(AllowConcurrentExecutions = false)]
    private async Task UninstallPackage(NugetPackage package)
    {

    }
}
