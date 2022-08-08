using NuGet.Packaging.Core;
using NuGet.Protocol.Core.Types;

namespace QuAnalyzer.Core.Helpers;

[ObservableObject]
public partial class NugetPackage
{
    public PackageIdentity Identity { get; init; }
    public string Name { get; init; }
    public Uri IconPath { get; init; }
    public string Copyright { get; init; }
    public string Description { get; init; }
    public string TypeTag { get; init; }


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotInstalled))]
    private bool isInstalled;

    public bool IsNotInstalled => !IsInstalled;

    [ObservableProperty]
    private bool isInstalling;

    public NugetPackage(IPackageSearchMetadata package)
    {
        Identity = package.Identity;
        Name = package.Title;
        IconPath = package.IconUrl;
        Copyright = package.Authors;
        Description = package.Description;

        TypeTag = GetTypeTag(package);

        isInstalled = CheckExists(package.Identity.Id);
    }

    private static string GetTypeTag(IPackageSearchMetadata package)
    {
        return package.Tags.Split(' ').ElementAtOrDefault(5);
    }
    private static bool CheckExists(string packageId)
    {
        return Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\providers\\" + packageId);
    }

}
