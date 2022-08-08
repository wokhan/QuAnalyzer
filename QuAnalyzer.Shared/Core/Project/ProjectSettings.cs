
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Media;
using Microsoft.Win32;

using Newtonsoft.Json;

using QuAnalyzer.Core.Helpers;
using QuAnalyzer.Core.Project.Exceptions;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Monitoring;

using System.ComponentModel.DataAnnotations;

using Windows.UI;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Core.Project;


public partial class ProjectSettings : ObservableValidator
{
    [ObservableProperty]
    [Required]
    private string name;

    [ObservableProperty]
    private string filePath;

    [ObservableProperty]
    private bool useParallelism = true;

    public byte[] AccentColorBrushSaved
    {
        get { return new byte[] { AccentColor.A, AccentColor.R, AccentColor.G, AccentColor.B }; }
        set { AccentColor = Color.FromArgb(value[0], value[1], value[2], value[3]); }
    }

    [JsonIgnore]
    public Color AccentColor
    {
        get => ((ColorPaletteResources)App.Instance.Resources["ColorPalette"]).Accent.Value;
        set => ((ColorPaletteResources)App.Instance.Resources["ColorPalette"]).Accent = value;
    }

    public ObservableCollection<IDataProvider> CurrentProviders { get; } = new();
    public ObservableCollection<TestDefinition> TestDefinitions { get; } = new();
    public ObservableCollection<SourcesMapper> SourceMapper { get; } = new();
    //public ObservableCollection<TestCasesCollection> PerformanceItems { get; } = new();


    [RelayCommand]
    private void PickFile()
    {
        var dial = new OpenFileDialog()
        {
            CheckFileExists = true,
            ValidateNames = true,
            AddExtension = true,
            Filter = "QuAnalyzer project file|*.qap"
        };

        if (dial.ShowDialog().Value)
        {
            Open(dial.FileName);
        }
    }

    [RelayCommand]
    public void Open(string p)
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

    [RelayCommand]
    public void Save(string p = null)
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

    [RelayCommand]
    public void CreateNew()
    {
        FilePath = String.Empty;
        Name = "Untitled project";

        CurrentProviders.Clear();
        SourceMapper.Clear();

        GC.Collect();
    }

    [RelayCommand]
    public void SaveAs()
    {
        var dial = new SaveFileDialog() { CheckFileExists = false, ValidateNames = true, AddExtension = true, Filter = "QuAnalyzer project file|*.qap" };
        if (dial.ShowDialog().Value)
        {
            this.Save(dial.FileName);
        }
    }
}
