using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

using Wokhan.Core.ComponentModel;
using Wokhan.Data.Providers;
using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.Core.Helpers;

public class ProvidersManager : NotifierHelper
{
    public IEnumerable<DataProviderDefinition> Providers => DataProviders.AllProviders;

    public ProvidersManager()
    {
        Directory.EnumerateDirectories(AppDomain.CurrentDomain.BaseDirectory + "\\providers")
                 .ToList()
                 .ForEach(d => DataProviders.AddPath(d));
    }

    internal void TriggerUpdate()
    {
        NotifyPropertyChanged(nameof(Providers));
    }

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
