using NuGet.Common;
using NuGet.Packaging.Core;
using NuGet.Packaging.Signing;
using NuGet.Packaging;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;

using System.IO.Compression;

using Wokhan.Core.ComponentModel;
using Wokhan.Data.Providers;
using Wokhan.Data.Providers.Bases;
using NuGet.Configuration;
using NuGet.Frameworks;
using NuGet.Resolver;
using System.Threading;

namespace QuAnalyzer.Core.Helpers;

public class ProvidersManager : NotifierHelper
{
    public IEnumerable<DataProviderDefinition> Providers => DataProviders.AllProviders.DistinctBy(provider => provider.Name);

    public ProvidersManager()
    {
        var assemblies = Directory.EnumerateDirectories(AppDomain.CurrentDomain.BaseDirectory + "\\providers")
                 .ToList()
                 .SelectMany(d => DirectLoad(d)) // DataProviders.AddPath(d));
                 .ToArray();

        // Ugly way since assemblies will be repeatedly added...
        DataProviders.AddAssemblies(assemblies);
    }

    private IEnumerable<Assembly> DirectLoad(string path)
    {
        var files = Directory.GetFiles(path).Where(f => f.EndsWith(".dll"));

        foreach (var file in files)
        {
            yield return Assembly.LoadFrom(file);
        }   
    }

    internal async Task<IEnumerable<NugetPackage>> GetNugetPackages()
    {
        var repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        var resource = await repository.GetResourceAsync<PackageSearchResource>();

        var metadata = await resource.SearchAsync("Wokhan.Data.Providers", new SearchFilter(true, SearchFilterType.IsLatestVersion) { IncludeDelisted = true }, 0, 20, NullLogger.Instance, CancellationToken.None);

        return metadata.Select(package => new NugetPackage(package.Identity, package.Title, package.IconUrl, package.Authors, package.Description)).ToList();
    }

    internal async Task InstallPackage(PackageIdentity identity)
    {
        // Source: https://gist.github.com/bjorkstromm/ad5776c36559410f45d5dcd0181a5c64
        var nuGetFramework = NuGetFramework.ParseFolder("netcoreapp3.1");
        var path = AppDomain.CurrentDomain.BaseDirectory + "\\providers\\packages";

        var settings = Settings.LoadDefaultSettings(root: null);
        var sourceRepositoryProvider = new SourceRepositoryProvider(settings, Repository.Provider.GetCoreV3());
        var repositories = new[] { Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json") };

        using (var cacheContext = new SourceCacheContext())
        {
            var availablePackages = new HashSet<SourcePackageDependencyInfo>(PackageIdentityComparer.Default);

            await GetPackageDependencies(identity, nuGetFramework, cacheContext, NullLogger.Instance, repositories, availablePackages);

            var resolverContext = new PackageResolverContext(
                DependencyBehavior.Lowest,
                new[] { identity.Id },
                Enumerable.Empty<string>(),
                Enumerable.Empty<PackageReference>(),
                Enumerable.Empty<PackageIdentity>(),
                availablePackages,
                new[] { new PackageSource("https://api.nuget.org/v3/index.json") },
                NullLogger.Instance);

            var resolver = new PackageResolver();
            var packagesToInstall = resolver.Resolve(resolverContext, CancellationToken.None).Select(package => availablePackages.First(avail => PackageIdentityComparer.Default.Equals(avail, package)));
            var packagePathResolver = new PackagePathResolver(Path.GetFullPath(path));
            var packageExtractionContext = new PackageExtractionContext(PackageSaveMode.Defaultv3, XmlDocFileSaveMode.None, ClientPolicyContext.GetClientPolicy(settings, NullLogger.Instance), NullLogger.Instance);
            var frameworkReducer = new FrameworkReducer();

            var dir = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\providers\\" + identity.Id);
            foreach (var packageToInstall in packagesToInstall)
            {
                PackageReaderBase packageReader;
                var installedPath = packagePathResolver.GetInstalledPath(packageToInstall);
                if (installedPath is null)
                {
                    var downloadResource = await packageToInstall.Source.GetResourceAsync<DownloadResource>(CancellationToken.None);
                    var downloadResult = await downloadResource.GetDownloadResourceResultAsync(packageToInstall, new PackageDownloadContext(cacheContext), SettingsUtility.GetGlobalPackagesFolder(settings), NullLogger.Instance, CancellationToken.None);

                    await PackageExtractor.ExtractPackageAsync(downloadResult.PackageSource, downloadResult.PackageStream, packagePathResolver, packageExtractionContext, CancellationToken.None);

                    packageReader = downloadResult.PackageReader;

                    installedPath = packagePathResolver.GetInstalledPath(packageToInstall);
                }
                else
                {
                    packageReader = new PackageFolderReader(installedPath);
                }

                var libItems = packageReader.GetLibItems().ToDictionary(lib => lib.TargetFramework, lib => lib.Items);
                var nearest = frameworkReducer.GetNearest(nuGetFramework, libItems.Keys);
                if (nearest is not null)
                {
                    var items = libItems[nearest];

                    foreach (var file in items.Where(item => item.EndsWith(".dll")))
                    {
                        File.Copy(Path.Combine(installedPath, file), Path.Combine(dir.FullName, Path.GetFileName(file)), true);
                    }
                }
            }

            //DataProviders.AddPath(dir.FullName);
            // Ugly way since assemblies will be repeatedly added...
            DataProviders.AddAssemblies(DirectLoad(dir.FullName).ToArray());

            NotifyPropertyChanged(nameof(Providers));
        }

        async Task GetPackageDependencies(PackageIdentity package,
            NuGetFramework framework,
            SourceCacheContext cacheContext,
            ILogger logger,
            IEnumerable<SourceRepository> repositories,
            ISet<SourcePackageDependencyInfo> availablePackages)
        {
            if (availablePackages.Contains(package))
            {
                return;
            }

            foreach (var sourceRepository in repositories)
            {
                var dependencyInfoResource = await sourceRepository.GetResourceAsync<DependencyInfoResource>();
                var dependencyInfo = await dependencyInfoResource.ResolvePackage(package, framework, cacheContext, logger, CancellationToken.None);

                if (dependencyInfo is null)
                {
                    continue;
                }

                availablePackages.Add(dependencyInfo);
                foreach (var dependency in dependencyInfo.Dependencies)
                {
                    await GetPackageDependencies(new PackageIdentity(dependency.Id, dependency.VersionRange.MinVersion), framework, cacheContext, logger, repositories, availablePackages);
                }
            }
        }
    }


    internal void AddProvider(string zipPath)
    {
        var path = $@"{AppDomain.CurrentDomain.BaseDirectory}\providers\{new FileInfo(zipPath).Name}";

        using var fileStream = new FileStream(zipPath, FileMode.Open);
        using var zip = new ZipArchive(fileStream, ZipArchiveMode.Read, false);

        zip.ExtractToDirectory(path);

        DataProviders.AddPath(path);

        NotifyPropertyChanged(nameof(Providers));
    }
}

public record NugetPackage(PackageIdentity Id, string Name, Uri IconPath, string Copyright, string Description);
