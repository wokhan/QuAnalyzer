using System.Runtime.Loader;

using Wokhan.Data.Providers;
using Wokhan.Data.Providers.Bases;


namespace QuAnalyzer.Core.Helpers;

public static class ProvidersManager
{
    public static ObservableCollection<DataProviderDefinition> Providers { get; } = new();

    static ProvidersManager()
    {
        var paths = Directory.EnumerateDirectories(AppDomain.CurrentDomain.BaseDirectory + "\\providers")
                             .Where(d => !d.EndsWith("\\packages"));
        foreach (var path in paths)
        {
            try
            {
                // TODO: Add log

                DataProviders.AddPath(path);
            }
            catch
            {
                // TODO: Add a dummy DataProviderDef to make users aware that it won't work since it wasn't loaded?
                throw;
            }
        }

        Providers.AddAll(DataProviders.AllProviders.Except(Providers));
    }

    internal static async Task InstallFromNuget(NugetPackage package, string framework, string cachePath, string targetPath)
    {
        var identity = package.Identity;
        package.IsInstalling = true;

        // Excluding all DLL already loaded by QuAnalyzer (embedded only as we do not query the AppDomain assemblies list).
        // Might be a bit too extreme though.
        var exclusions = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(assembly => $"{assembly.Name}.dll").ToList();
        
        try
        {
            await NugetManager.Install(identity, framework, exclusions, cachePath, targetPath);
            package.IsInstalled = true;
        }
        catch
        {
            //TODO: add log and feedback to user
        }
        finally
        {
            package.IsInstalling = false;
        }

        DataProviders.AddPath(targetPath);

        Providers.AddAll(DataProviders.AllProviders.Except(Providers));
    }

}
