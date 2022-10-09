using CommunityToolkit.Mvvm.Input;

using OfficeOpenXml;

using QuAnalyzer.Core.Extensions;
using QuAnalyzer.Core.Helpers;
using QuAnalyzer.Core.Project;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Comparison.Comparers;
using QuAnalyzer.Features.Comparison.Results;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.UI.Popups;

using System.Linq.Dynamic.Core;

using Windows.Storage.Pickers;
using Windows.UI.Core;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Pages;

[ObservableObject]
public partial class Compare : Page
{
    /// <summary>
    /// This is to bypass a bug with Uno Platform where TwoWay static bindings through x:Bind don't seem to work. Weird since
    /// according to GitHub, it should...
    /// </summary>
    public App App => App.Instance;

    public ObservableCollection<LocalComparerDefinition> ComparisonInstances { get; } = new();

    private int cpdCount = 0;

    private readonly Dictionary<ComparerDefinition<object[]>, GenericPopup> openWindows = new();

    private readonly Dictionary<string, int> progressDC = new();

    [ObservableProperty]
    private int currentProgress = 0;

    public Compare()
    {
        ProgressCallback = new Progress<ComparerDefinition<object[]>>(HandleProgress);

        InitializeComponent();
    }

    [RelayCommand]
    private void AutoMap()
    {
        var allprv = App.Instance.CurrentProject.CurrentProviders;

        var mappers = App.Instance.CurrentProject.SourceMapper;

        mappers.Clear();

        var done = new List<IDataProvider>();
        foreach (var source in allprv)
        {
            if (!done.Contains(source))
            {
                var map = allprv.Where(target => target != source && target.Repositories.Keys.Intersect(source.Repositories.Keys).Any())
                                .SelectMany(target => target.Repositories.Keys.Intersect(source.Repositories.Keys).Select(repository => new SourcesMapper(source, repository, target, repository, true)));

                mappers.AddAll(map);

                done.AddRange(map.Select(m => m.Source));
                done.AddRange(map.Select(m => m.Target));
            }
        }
    }

    //TODO: Figure out what Command using instead 
    private void btnSelectAll_Click(object sender, RoutedEventArgs e)
    {
        //lstMappings.SelectAll();
    }

    //TODO: Figure out what Command using instead 
    private void btnUnSel_Click(object sender, RoutedEventArgs e)
    {
        //lstMappings.UnselectAll();
    }


    [RelayCommand]
    private void Cancel(ComparerDefinition<object[]> r)
    {
        r.TokenSource.Cancel(true);
    }


    [RelayCommand]
    private void CreateMapping()
    {
        GenericPopup.OpenNew<MappingsEditor>(isWizard: true);
    }

    [RelayCommand]
    private void Delete(ComparerDefinition<object[]> r)
    {
        progressDC.Remove(r.Name);
        ComparisonInstances.RemoveRange(ComparisonInstances.Where(re => r.Name.Equals((string)re.Name)).ToList());
    }

    [RelayCommand]
    private void DeleteMapping(SourcesMapper mapping)
    {
        App.Instance.CurrentProject.SourceMapper.Remove(mapping);
    }

    [RelayCommand]
    private void Details(ComparerDefinition<object[]> cmp)
    {
        if (!openWindows.ContainsKey(cmp))
        {
            var dWin = GenericPopup.OpenNew<DetailsWindow>(cmp);
            dWin.Closed += dWin_Closed;
            openWindows.Add(cmp, dWin);
        }

        //openWindows[cmp].Show();
        openWindows[cmp].Activate();
    }

#if HAS_UNO
    private void dWin_Closed(object sender, CoreWindowEventArgs e)
#else
    private void dWin_Closed(object sender, WindowEventArgs e)
#endif
    {
        openWindows.Remove(openWindows.Single(o => o.Value.Equals(sender)).Key);
    }

    [RelayCommand]
    private void EditMapping(SourcesMapper mapping)
    {
        GenericPopup.OpenNew<MappingsEditor>(mapping, true);
    }

    [RelayCommand]
    private async void GlobalReport()
    {
        var dial = new FolderPicker();
        //{ FileName = "Pick a folder to save reports in. Existing files will be overwritten." };

        var folder = await dial.PickSingleFolderAsync();

        if (folder is null)
        {
            return;
        }

        var folderPath = Directory.GetParent(folder.Path);

        var app = App.Instance;
        var task = GlobalTask.AddNew("Exporting Summary");

        //TODO: check
        //allProgress.ExportAsXLSX(folderPath + "\\Summary.xlsx", "Summary", host, callback, cancelTokenSummary);

        foreach (var cmp in ComparisonInstances.Where(c => c.Results.Progress == ProgressType.Done))
        {
            /*if (!openWindows.ContainsKey(cmp))
            {
                var dWin = new DetailsWindow(cmp);
                dWin.Closed += dWin_Closed;
                openWindows.Add(cmp, dWin);
            }

            openWindows[cmp].Show();
            openWindows[cmp].Activate();
            */
            string name = String.Join("_", cmp.Name.Split(Path.GetInvalidFileNameChars(), StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');

            string p = Path.Combine(folderPath.FullName, $"{name}_Details.xlsx");

            var file = new FileInfo(p);
            //if (cmp.Results.MergedDiff is not null)
            var task1 = GlobalTask.AddNew($"Exporting Differences to {file.Name}");
            var task2 = GlobalTask.AddNew($"Exporting Missing from source to {file.Name}");
            var task3 = GlobalTask.AddNew($"Exporting Missing from target to {file.Name}");
            var task4 = GlobalTask.AddNew($"Exporting Source duplicates to {file.Name}");
            var task5 = GlobalTask.AddNew($"Exporting Target duplicates to {file.Name}");
            var task6 = GlobalTask.AddNew($"Exporting Source clones to {file.Name}");
            var task7 = GlobalTask.AddNew($"Exporting Target clones to {file.Name}");

            await Task.Run(() =>
            {
                using (var xl = new ExcelPackage(file))
                {
                    var sourceName = cmp.SourceName;
                    var targetName = cmp.TargetName;

                    //TODO: Review & test
                    var mergedHeaders = cmp.SourceHeaders.Zip(cmp.TargetHeaders, (src, trg) => src + (src != trg ? "/" + trg : String.Empty)).ToArray();

                    var mergedDiff = cmp.Results.Differences.SelectMany(x => new[] {
                                    x.Source.Select(fs => new Diff(Origin: sourceName, Value: fs)).ToArray(),
                                    x.Source.Zip(x.Target)
                                            .Select((fs, i) => new Diff(
                                        Origin: targetName,
                                        Value: fs.Second,
                                        IsDiff: i >= x.Index && !Equals(fs.First, fs.Second)
                                    )).ToArray()
                                });

                    xl.AddWorksheet(mergedDiff, mergedHeaders.Prepend("Name").ToArray(), cmp.SourceKeys.Count, "Differences", (x, i, h, s) => { if (x[i].IsDiff) { s.Font.Color.SetColor(System.Drawing.Color.Red); } return x[i].Value; }, task1.ProgressCallback);

                    //if (cmp.Results.Source.Missing is not null)
                    xl.AddWorksheet(cmp.Results.Source.Missing, cmp.SourceHeaders, cmp.SourceKeys.Count, "Missing from source", (x, i, h, s) => x[i], task2.ProgressCallback);

                    //if (dgMissingTarget.ItemsSource is not null)
                    xl.AddWorksheet(cmp.Results.Target.Missing, cmp.TargetHeaders, 0, "Missing from target", (x, i, h, s) => x[i], task3.ProgressCallback);

                    //if (dgSourceDups.ItemsSource is not null)
                    xl.AddWorksheet(cmp.Results.Source.Duplicates, cmp.SourceHeaders, 0, "Source duplicates", (x, i, h, s) => x[i], task4.ProgressCallback);

                    //if (dgTargetDups.ItemsSource is not null)
                    xl.AddWorksheet(cmp.Results.Target.Duplicates, cmp.TargetHeaders, 0, "Target duplicates", (x, i, h, s) => x[i], task5.ProgressCallback);

                    //if (dgSourcePerfectDups.ItemsSource is not null)
                    xl.AddWorksheet(cmp.Results.Source.PerfectDups, cmp.SourceHeaders, 0, "Source clones", (x, i, h, s) => x[i], task6.ProgressCallback);

                    //if (dgTargetPerfectDups.ItemsSource is not null)
                    xl.AddWorksheet(cmp.Results.Target.PerfectDups, cmp.TargetHeaders, 0, "Target clones", (x, i, h, s) => x[i], task7.ProgressCallback);

                    //xl.AddWorksheet(dgDiff, "Differences");
                    //xl.AddWorksheet(dgMissingSource, "Missing from source");
                    //xl.AddWorksheet(dgMissingTarget, "Missing from target");
                    //xl.AddWorksheet(dgSourceDups, "Source duplicates");
                    //xl.AddWorksheet(dgTargetDups, "Target duplicates");
                    //xl.AddWorksheet(dgSourcePerfectDups, "Source clones");
                    //xl.AddWorksheet(dgTargetPerfectDups, "Target clones");

                    xl.Save();
                }
            });
        }
    }

    private void LstMappings_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        RunCommand.NotifyCanExecuteChanged();
    }

    private static IEnumerable<object[]> Map(IQueryable src, string[] fields)
    {
        return QueryableExtensions.AsObjectCollection(src, fields);
    }

    private static object[] Convert(object src, Type[] types)
    {
        return ((object[])src).Zip(types, (a, t) => a.SafeConvert(t)).ToArray();
    }

    [RelayCommand(CanExecute = nameof(CanExecuteRun))]
    private async void Run()
    {
        CurrentProgress = -1;

        var newInstances = new List<ComparerDefinition<object[]>>();

        var comparer = SequenceComparer<object>.Default;

        //TODO:check
        foreach (SourcesMapper mapper in App.Instance.CurrentProject.UseSingleMapping ? new[] { App.Instance.CurrentProject.SingleMapper } : lstMappings.SelectedItems)
        {
            var cp = new LocalComparerDefinition(mapper, comparer, Map, Convert);

            cp.Name = $"[{cpdCount++}] {cp.Name}";

            ComparisonInstances.Add(cp);

            newInstances.Add(cp);
        }

        await Task.Run(() => Comparison.Run(newInstances, progressCallback: ProgressCallback, useParallelism: App.Instance.CurrentProject.UseParallelism)).ConfigureAwait(true);

        CurrentProgress = 100;
    }

    //TODO: fix for single mapper use
    private bool CanExecuteRun => true;// (App.Instance.CurrentProject.UseSingleMapping && App.Instance.CurrentProject.SingleMapper.AllMappings.Any()) || (!App.Instance.CurrentProject.UseSingleMapping && lstMappings?.SelectedItems.Count > 0);


    IProgress<ComparerDefinition<object[]>> ProgressCallback;

    public void HandleProgress(ComparerDefinition<object[]> comparer)
    {
        switch (comparer.Results.Progress)
        {
            case ProgressType.Failed:
            case ProgressType.Canceling:
                progressDC.Remove(comparer.Name);
                break;

            default:
                progressDC[comparer.Name] = (int)comparer.Results.Progress;

                CurrentProgress = (int)progressDC.Average(p => p.Value);

                //App.Instance.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
                //App.Instance.MainWindow.TaskbarItemInfo.ProgressValue = currentProgress / 100.0;

                //if (progressDC.Values.All(v => v == 100))
                //{
                //    App.Instance.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
                //}

                break;
        }

        // Since ObservableObjects cannot raise property change from another thread without calling DispatcherQueue.TryEnqueue,
        // I'm doing it the other way around: the UI component calls for the change notification itself.
        // For our purpose it should be OK since almost all properties are subject to change anyway.
        // Might be better to use a timed refresh though (every 200ms ?) to avoid raising for nothing.
        comparer.RaiseResultChanged();
    }

}
