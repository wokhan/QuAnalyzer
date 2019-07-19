using NuGet.Configuration;
using NuGet.DependencyResolver;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Packaging.Signing;
using NuGet.Protocol.Core.Types;
using QuAnalyzer.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using Wokhan.Data.Providers;
using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.Helpers
{
    public class ProvidersManager : NotifierHelper
    {
        public IEnumerable<DataProviderStruct> Providers => DataProviders.AllProviders;

        public ProvidersManager()
        {
            Directory.EnumerateDirectories(AppDomain.CurrentDomain.BaseDirectory + "\\providers").ToList().ForEach(d => DataProviders.Init(d));
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
            var path = @$"{AppDomain.CurrentDomain.BaseDirectory}\providers\{new FileInfo(zipPath).Name}";
            
            using (var fileStream = new FileStream(zipPath, FileMode.Open))
            {
                new ZipArchive(fileStream, ZipArchiveMode.Read, false).ExtractToDirectory(path);
                DataProviders.Init(path);
                NotifyPropertyChanged(nameof(Providers));
            }
        }
    }
}
