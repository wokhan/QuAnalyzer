
using CommunityToolkit.Mvvm.Input;

using Newtonsoft.Json;

using QuAnalyzer.Core.Helpers;
using QuAnalyzer.Core.Project.Exceptions;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Monitoring;

using System.ComponentModel.DataAnnotations;

using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI;

#if !HAS_UNO
using WinRT.Interop;
#endif

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Core.Project;


public partial class ProjectSettings : ObservableValidator
{
    [ObservableProperty]
    [Required]
    private string name = "Untitled project";

    [JsonIgnore]
    public string FilePath { get; private set; }

    [ObservableProperty]
    private bool useParallelism = true;

    //public Color AccentColor
    //{
    //    get => ((ColorPaletteResources)App.Instance.Resources["ColorPalette"]).Accent.Value;
    //    set => ((ColorPaletteResources)App.Instance.Resources["ColorPalette"]).Accent = value;
    //}

    [JsonProperty(ItemIsReference = true)]
    public ObservableCollection<IDataProvider> CurrentProviders { get; } = new();

    public ObservableCollection<TestDefinition> TestDefinitions { get; } = new();

    public ObservableCollection<SourcesMapper> SourceMapper { get; } = new();

    [ObservableProperty]
    private bool useSingleMapping;

    public SourcesMapper SingleMapper { get; } = new();

    [RelayCommand]
    private async void PickFile()
    {
        var filePicker = new FileOpenPicker()
        {
            SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
        };

#if !HAS_UNO
        var hwnd = WindowNative.GetWindowHandle(App.Instance.MainWindow);
        InitializeWithWindow.Initialize(filePicker, hwnd);
#endif

        filePicker.FileTypeFilter.Add(".qap");

        var file = await filePicker.PickSingleFileAsync();
        if (file is not null)
        {
            Open(file);
        }
    }

    [RelayCommand]
    public async void Open(string path)
    {
        Open(await StorageFile.GetFileFromPathAsync(path));
    }

    public async void Open(StorageFile file)
    {
        try
        {
            var ser = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };

            var contents = await FileIO.ReadTextAsync(file);

            using var jsonreader = new JsonTextReader(new StringReader(contents));

            var project = ser.Deserialize<ProjectSettings>(jsonreader);

            project.FilePath = file.Path;

            MRUManager.AddRecentFile(file.Path);

            App.Instance.CurrentProject = project;
        }
        catch (Exception e)
        {
            throw new ProjectLoadException(e);
        }
    }

    [RelayCommand]
    public void Save(string path = null)
    {
        try
        {
            if (string.IsNullOrEmpty(FilePath) && string.IsNullOrEmpty(path))
            {
                this.SaveAs();
                return;
            }

            var ser = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };

            if (path is not null)
            {
                this.FilePath = path;
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
        App.Instance.CurrentProject = new ProjectSettings();
    }

    [RelayCommand]
    public async void SaveAs()
    {
        var filePicker = new FileSavePicker()
        {
            SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            SuggestedFileName = App.Instance.CurrentProject.Name + ".qap"
        };

#if !HAS_UNO
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
