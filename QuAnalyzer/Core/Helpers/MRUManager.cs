namespace QuAnalyzer.Core.Helpers;

public static class MRUManager
{
    public static Dictionary<string, bool> RecentFiles
    {
        get { return GetRecentFiles().ToDictionary(f => f, f => File.Exists(f)); }
    }

    private static string RecentFilesStore
    {
        get
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Wokhan", "QuAnalyzer");
            Directory.CreateDirectory(path);
            return Path.Combine(path, "RecentFiles.txt");
        }
    }

    internal static List<string> GetRecentFiles()
    {
        try
        {
            return new List<string>(File.ReadAllLines(RecentFilesStore));
        }
        catch
        {
            return new List<string>();
        }
    }

    internal static void AddRecentFile(string path)
    {
        List<string> recfiles = GetRecentFiles();
        recfiles.Remove(path);
        recfiles.Insert(0, path);

        File.WriteAllLines(RecentFilesStore, recfiles.Take(8));
    }
}
