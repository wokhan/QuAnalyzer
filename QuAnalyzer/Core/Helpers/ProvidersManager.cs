using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;

using System.IO.Compression;

using Wokhan.Core.ComponentModel;
using Wokhan.Data.Providers;

namespace QuAnalyzer.Core.Helpers;

public class ProvidersManager : NotifierHelper
{
    public ObservableCollection<dynamic> Providers => new ObservableCollection<dynamic>(DataProviders.AllProviders);

    public ProvidersManager()
    {
        Directory.EnumerateDirectories(AppDomain.CurrentDomain.BaseDirectory + "\\providers")
                 .ToList()
                 .ForEach(d => DataProviders.AddPath(d));
    }

    //internal async Task AddFromNuget()
    //{
    //    var repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
    //    var resource = await repository.GetResourceAsync<PackageSearchResource>();

    //    var metadata = await resource.SearchAsync("Wokhan.Data.Providers", new SearchFilter(true, SearchFilterType.IsLatestVersion), 0, 20, NullLogger.Instance, CancellationToken.None);

    //    Providers.AddAll(metadata.Select(package => new { Category = "NuGet", Name = package.Title, IconPath = package.IconUrl, Copyright = package.Authors, Description = package.Description }));
    //}

    internal void AddProvider(string zipPath)
    {
        /*var repository = new NuGet.Repositories.NuGetv3LocalRepository($@"{AppDomain.CurrentDomain.BaseDirectory }\providers\sources\");
        var packageIdentity = new PackageIdentity(match.Library.Name, match.Library.Version);

        var versionFolderPathResolver = new VersionFolderPathResolver($@"{AppDomain.CurrentDomain.BaseDirectory }\providers\sources\");

        await PackageExtractor.InstallFromSourceAsync(
            packageIdentity,
            stream => match.Provider.CopyToAsync(match.Library, stream, CancellationToken.None),
            versionFolderPathResolver,
            new PackageExtractionContext(PackageSaveMode.Nupkg, XmlDocFileSaveMode.None, new ClientPolicyContext(), null),
            CancellationToken.None);

*/
        var path = $@"{AppDomain.CurrentDomain.BaseDirectory}\providers\{new FileInfo(zipPath).Name}";

        using (var fileStream = new FileStream(zipPath, FileMode.Open))
        {
            using (var zip = new ZipArchive(fileStream, ZipArchiveMode.Read, false))
            {
                zip.ExtractToDirectory(path);
            }
            DataProviders.AddPath(path);
            NotifyPropertyChanged(nameof(Providers));
        }
    }
}
