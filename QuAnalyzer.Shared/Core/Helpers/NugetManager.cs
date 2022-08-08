
using NuGet.Common;
using NuGet.Configuration;
using NuGet.Frameworks;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Packaging.Signing;
using NuGet.Protocol;

using NuGet.Protocol.Core.Types;
using NuGet.Resolver;

using System;
using System.Threading;

namespace QuAnalyzer.Core.Helpers;

/// <summary>
/// Nuget helper to search and install Nuget packages locally (specifying the target folder).
/// All credits go to https://gist.github.com/bjorkstromm/ad5776c36559410f45d5dcd0181a5c64
/// </summary>
internal static class NugetManager
{
    public static async Task<IEnumerable<NugetPackage>> SearchPackages(string filter, params string[] exclusions)
    {
        var repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        var resource = await repository.GetResourceAsync<PackageSearchResource>();

        var metadata = await resource.SearchAsync(filter, new SearchFilter(true, SearchFilterType.IsLatestVersion) { IncludeDelisted = true, OrderBy = SearchOrderBy.Id }, 0, 20, NullLogger.Instance, CancellationToken.None);

        return metadata.Where(package => !exclusions.Contains(package.Identity.Id))
                       .Select(package => new NugetPackage(package))
                       .ToList();
    }

    public static async Task Install(PackageIdentity identity, string framework, List<string> exclusions, string cachePath, string targetPath)
    {
        // Source: https://gist.github.com/bjorkstromm/ad5776c36559410f45d5dcd0181a5c64
        var nuGetFramework = NuGetFramework.ParseFolder(framework);

        var settings = Settings.LoadDefaultSettings(root: null);
        var sourceRepositoryProvider = new SourceRepositoryProvider(settings, Repository.Provider.GetCoreV3());
        var repositories = new[] { Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json") };

        var installDirectory = Directory.CreateDirectory(targetPath);

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
            var packagePathResolver = new PackagePathResolver(Path.GetFullPath(cachePath));
            var packageExtractionContext = new PackageExtractionContext(PackageSaveMode.Defaultv3, XmlDocFileSaveMode.None, ClientPolicyContext.GetClientPolicy(settings, NullLogger.Instance), NullLogger.Instance);
            var frameworkReducer = new FrameworkReducer();

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
                    var items = libItems[nearest].Where(item => item.EndsWith(".dll"));

                    foreach (var item in items)
                    {
                        var fileName = Path.GetFileName(item);
                        if (!exclusions.Contains(fileName))
                        {
                            File.Copy(Path.Combine(installedPath, item), Path.Combine(installDirectory.FullName, fileName), true);
                        }
                    }
                }
            }

        }
    }

    private static async Task GetPackageDependencies(PackageIdentity package,
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
