
using CommunityToolkit.Mvvm.Input;

using Newtonsoft.Json;

using QuAnalyzer.Core.Helpers;
using QuAnalyzer.Core.Project.Exceptions;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Monitoring;

using System.ComponentModel.DataAnnotations;

using Windows.Storage.Pickers;
using Windows.UI;

using WinRT.Interop;

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

    [ObservableProperty]
    private bool useSingleMapping;

    public SourcesMapper SingleMapper { get; set; } = new();

    [RelayCommand]
    private async void PickFile()
    {
        var filePicker = new FileOpenPicker()
        {
            SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
        };

#if WINDOWS
        var hwnd = WindowNative.GetWindowHandle(App.Instance.MainWindow);
        InitializeWithWindow.Initialize(filePicker, hwnd);
#endif

        filePicker.FileTypeFilter.Add(".qap");

        var file = await filePicker.PickSingleFileAsync();
        if (file is not null)
        {
            Open(file.Path);
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
            this.SingleMapper = restProject.SingleMapper;
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
    public async void SaveAs()
    {
        var filePicker = new FileSavePicker()
        {
            SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            SuggestedFileName = App.Instance.CurrentProject.Name + ".qap"
        };

#if WINDOWS
        var hwnd = WindowNative.GetWindowHandle(App.Instance.MainWindow);
        InitializeWithWindow.Initialize(filePicker, hwnd);
#endif

        filePicker.FileTypeChoices.Add("QuAnalyzer project file", new[] { ".qap" });
        
        var file = await filePicker.PickSaveFileAsync();
        if (file is not null)
        {
            this.Save(file.Path);
        }
    }
}
