
using Microsoft.Win32;

using Newtonsoft.Json;

using QuAnalyzer.Core.Helpers;
using QuAnalyzer.Core.Project.Exceptions;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Monitoring;

using System.Windows.Media;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Core.Project;

public partial class ProjectSettings : ObservableObject
{
    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private string filePath;

    [ObservableProperty]
    private bool useParallelism = true;

    public byte[] AccentColorBrushSaved
    {
        get { return new byte[] { AccentColor.Color.A, AccentColor.Color.R, AccentColor.Color.G, AccentColor.Color.B }; }
        set { AccentColor = new SolidColorBrush(Color.FromArgb(value[0], value[1], value[2], value[3])); }
    }

    [JsonIgnore]
    public SolidColorBrush AccentColor
    {
        get { return (SolidColorBrush)App.Instance.Resources["AccentColorBrush"]; }
        set { App.Instance.Resources["AccentColorBrush"] = value; }
    }

    public ObservableCollection<IDataProvider> CurrentProviders { get; } = new();
    public ObservableCollection<TestDefinition> TestDefinitions { get; } = new();
    public ObservableCollection<SourcesMapper> SourceMapper { get; } = new();
    //public ObservableCollection<TestCasesCollection> PerformanceItems { get; } = new();

    internal void Open(string p)
    {
        try
        {
            var ser = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            using var stream = new JsonTextReader(new StreamReader(p));

            var restProject = ser.Deserialize<ProjectSettings>(stream);

            this.Name = restProject.Name;
            this.CurrentProviders.ReplaceAll(restProject.CurrentProviders);
            this.SourceMapper.ReplaceAll(restProject.SourceMapper);
            this.TestDefinitions.ReplaceAll(restProject.TestDefinitions);

            this.FilePath = p;

            MRUManager.AddRecentFile(this.FilePath);
        }
        catch (Exception e)
        {
            throw new ProjectLoadException(e);
        }
    }

    internal void Save(string p = null)
    {
        try
        {
            if (string.IsNullOrEmpty(FilePath) && string.IsNullOrEmpty(p))
            {
                this.SaveAs();
                return;
            }

            var ser = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            if (p is not null)
            {
                this.FilePath = p;
            }

            using var str = new JsonTextWriter(new StreamWriter(this.FilePath, false));

            ser.Serialize(str, this);
        }
        catch (Exception e)
        {
            throw new ProjectSaveException(e);
        }
    }

    internal void CreateNew()
    {
        FilePath = String.Empty;
        Name = "Untitled project";

        CurrentProviders.Clear();
        SourceMapper.Clear();

        GC.Collect();
    }

    internal void SaveAs()
    {
        var dial = new SaveFileDialog() { CheckFileExists = false, ValidateNames = true, AddExtension = true, Filter = "QuAnalyzer project file|*.qap" };
        if (dial.ShowDialog().Value)
        {
            this.Save(dial.FileName);
        }
    }
}
