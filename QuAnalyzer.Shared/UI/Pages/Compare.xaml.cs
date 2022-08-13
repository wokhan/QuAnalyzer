using CommunityToolkit.Mvvm.Input;

using OfficeOpenXml;

using QuAnalyzer.Core.Extensions;
using QuAnalyzer.Core.Helpers;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Comparison.Comparers;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.UI.Popups;
using QuAnalyzer.UI.Windows;

using System.Linq.Dynamic.Core;

using Windows.Storage.Pickers;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Pages;

[ObservableObject]
public partial class Compare : Page
{

    private int cpdCount = 0;

    private readonly Dictionary<ComparerDefinition<object[]>, Window> openWindows = new();

    private readonly Dictionary<string, int> progressDC = new();

    [ObservableProperty]
    private int currentProgress = 0;

    public Compare()
    {
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
        //TODO: replace by CancelCommand.IsRunning on the corresponding button
        //src.IsEnabled = false;
        //TODO: replace by RunCommand.Cancel() once implemented in the Comparison class logic.
        r.TokenSource.Cancel(true);
    }

    private static IEnumerable<object[]> Convert(IEnumerable src, Type[] types)
    {
        return ((IEnumerable<IEnumerable<object>>)src).Select(c => c.Zip(types, (a, t) => a.SafeConvert(t)).ToArray());
    }

    [RelayCommand]
    private void CreateMapping()
    {
        GenericPopup.OpenNew<MappingsEditor>();
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

    private void dWin_Closed(object sender, WindowEventArgs e)
    {
        openWindows.Remove(openWindows.Single(o => o.Value.Equals(sender)).Key);
    }

    [RelayCommand]
    private void EditMapping(SourcesMapper mapping)
    {
        GenericPopup.OpenNew<MappingsEditor>(mapping);
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
        var (host, callback, cancelTokenSummary) = GlobalTask.AddTaskAndGetCallback("Exporting Summary");

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
            var (_, cb1, cb1CancelToken) = GlobalTask.AddTaskAndGetCallback($"Exporting Differences to {file.Name}");
            var (_, cb2, cb2CancelToken) = GlobalTask.AddTaskAndGetCallback($"Exporting Missing from source to {file.Name}");
            var (_, cb3, cb3CancelToken) = GlobalTask.AddTaskAndGetCallback($"Exporting Missing from target to {file.Name}");
            var (_, cb4, cb4CancelToken) = GlobalTask.AddTaskAndGetCallback($"Exporting Source duplicates to {file.Name}");
            var (_, cb5, cb5CancelToken) = GlobalTask.AddTaskAndGetCallback($"Exporting Target duplicates to {file.Name}");
            var (_, cb6, cb6CancelToken) = GlobalTask.AddTaskAndGetCallback($"Exporting Source clones to {file.Name}");
            var (_, cb7, cb7CancelToken) = GlobalTask.AddTaskAndGetCallback($"Exporting Target clones to {file.Name}");

            await Task.Run(() =>
            {
                using (var xl = new ExcelPackage(file))
                {
                    cmp.Results.InitDiff(cmp);
                    xl.AddWorksheet(cmp.Results.MergedDiff, cmp.Results.MergedHeaders.Prepend("Name").ToArray(), cmp.SourceKeys.Count, "Differences", (x, i, h, s) => { if (x.IsDiff[i]) { s.Font.Color.SetColor(System.Drawing.Color.Red); } return x.Values[i]; }, cb1);

                    //if (cmp.Results.Source.Missing is not null)
                    xl.AddWorksheet(cmp.Results.Source.Missing.Cast<object[]>(), cmp.SourceHeaders, cmp.SourceKeys.Count, "Missing from source", (x, i, h, s) => x[i], cb2);

                    //if (dgMissingTarget.ItemsSource is not null)
                    xl.AddWorksheet(cmp.Results.Target.Missing.Cast<object[]>(), cmp.TargetHeaders, 0, "Missing from target", (x, i, h, s) => x[i], cb3);

                    //if (dgSourceDups.ItemsSource is not null)
                    xl.AddWorksheet(cmp.Results.Source.Duplicates.Cast<object[]>(), cmp.SourceHeaders, 0, "Source duplicates", (x, i, h, s) => x[i], cb4);

                    //if (dgTargetDups.ItemsSource is not null)
                    xl.AddWorksheet(cmp.Results.Target.Duplicates.Cast<object[]>(), cmp.TargetHeaders, 0, "Target duplicates", (x, i, h, s) => x[i], cb5);

                    //if (dgSourcePerfectDups.ItemsSource is not null)
                    xl.AddWorksheet(cmp.Results.Source.PerfectDups.Cast<object[]>(), cmp.SourceHeaders, 0, "Source clones", (x, i, h, s) => x[i], cb6);

                    //if (dgTargetPerfectDups.ItemsSource is not null)
                    xl.AddWorksheet(cmp.Results.Target.PerfectDups.Cast<object[]>(), cmp.TargetHeaders, 0, "Target clones", (x, i, h, s) => x[i], cb7);

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

    private static IEnumerable<object[]> Map(IQueryable sourceQuery, List<string> fields)
    {
        return sourceQuery.AsObjectCollection(fields.ToArray());
    }

    [RelayCommand(AllowConcurrentExecutions = false, CanExecute = nameof(CanExecuteRun))]
    private async Task Run()
    {
        CurrentProgress = -1;

        var newInstances = new List<ComparerDefinition<object[]>>();
        var comparer = SequenceComparer<object>.Default;

        //TODO:check
        foreach (SourcesMapper mapper in App.Instance.CurrentProject.UseSingleMapping ? new[] { App.Instance.CurrentProject.SingleMapper } : lstMappings.SelectedItems)
        {
            var cp = await ComparerDefinition<object[]>.CreateAsync(mapper, comparer, Map, Convert).ConfigureAwait(true);

            cp.Name = $"[{cpdCount++}] {cp.Name}";

            ComparisonInstances.Add(cp);

            newInstances.Add(cp);
        }

        CurrentProgress = 100;
        
        var callback = new Progress<ComparerDefinition<object[]>>(Progress);
        await Task.Run(() => Comparison.Run(newInstances, progressCallback: callback, useParallelism: App.Instance.CurrentProject.UseParallelism));
    }

    private bool CanExecuteRun => true;//TODO: lstMappings?.SelectedItems.Count > 0;

    public void Progress(ComparerDefinition<object[]> comparer)
    {
        switch (comparer.Results.Progress)
        {
            case ProgressType.Failed:
            case ProgressType.Canceling:
                progressDC.Remove(comparer.Name);
                break;

            case ProgressType.Done:
            default:
                progressDC[comparer.Name] = comparer.Results.LocalProgress;

                CurrentProgress = (int)progressDC.Average(p => p.Value);

                //App.Instance.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
                //App.Instance.MainWindow.TaskbarItemInfo.ProgressValue = currentProgress / 100.0;

                //if (progressDC.Values.All(v => v == 100))
                //{
                //    App.Instance.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
                //}

                break;
        }
    }

    public ObservableCollection<ComparerDefinition<object[]>> ComparisonInstances { get; } = new();
}
