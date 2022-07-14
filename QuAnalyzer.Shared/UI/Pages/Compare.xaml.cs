using CommunityToolkit.HighPerformance;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.Input;

using Microsoft.Win32;

using OfficeOpenXml;

using QuAnalyzer.Core.Extensions;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Comparison.Comparers;
using QuAnalyzer.Features.Comparison.Definition;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.UI.Popups;
using QuAnalyzer.UI.Windows;

using System.Linq.Dynamic.Core;
using System.Windows.Shell;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Pages;

public partial class Compare : Page
{

    private int cpdCount = 0;

    private readonly Dictionary<ComparerDefinition<object[]>, Window> openWindows = new();

    private readonly Dictionary<string, int> progressDC = new();

    public Compare()
    {
        InitializeComponent();

        lstMappings.SelectionChanged += LstMappings_SelectionChanged;

        GroupedComparisonInstancesView = ComparisonInstancesView.GroupBy(x => x.Name);
    }

    [RelayCommand]
    private void AutoMap()
    {
        var allprv = App.Instance.CurrentProject.CurrentProviders;

        var mapper = App.Instance.CurrentProject.SourceMapper;

        mapper.Clear();

        var done = new List<IDataProvider>();
        foreach (var source in allprv)
        {
            if (!done.Contains(source))
            {
                var map = allprv.Where(target => target != source && target.Repositories.Keys.Intersect(source.Repositories.Keys).Any())
                                .SelectMany(target => target.Repositories.Keys.Intersect(source.Repositories.Keys).Select(repository => new SourcesMapper()
                                {
                                    Name = $"{source.Name} ({repository}) / {target.Name} ({repository})",
                                    Source = source,
                                    Target = target,
                                    SourceRepository = repository,
                                    TargetRepository = repository,
                                    AllMappings = source.GetColumns(repository).Select(h => h.Name).Intersect(target.GetColumns(repository).Select(h => h.Name)).Select(k => new SimpleMap(k, k)).ToList()
                                }));

                mapper.AddAll(map);

                done.AddRange(map.Select(m => m.Source));
                done.AddRange(map.Select(m => m.Target));
            }
        }
    }

    //TODO: Use Command="{x:Static DataGrid.SelectAllCommand}" instead
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
        ComparisonInstancesView.RemoveRange(ComparisonInstancesView.Where(re => r.Name.Equals((string)re.Name)).ToList());
    }

    [RelayCommand]
    private void DeleteMapping(SourcesMapper mapping)
    {
        App.Instance.CurrentProject.SourceMapper.Remove(mapping);
    }

    [RelayCommand]
    private async void Details(ComparerDefinition<object[]> cmp)
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
    private void GlobalReport()
    {
        var dial = new OpenFileDialog() { CheckFileExists = false, CheckPathExists = true, ValidateNames = false, FileName = "Pick a folder to save reports in. Existing files will be overwritten." };
        if (dial.ShowDialog() is not true)
        {
            return;
        }

        var folderPath = Directory.GetParent(dial.FileName);

        var app = App.Instance;
        var (host, callback, cancelTokenSummary) = app.AddTaskAndGetCallback("Exporting Summary");

        allProgress.ExportAsXLSX(folderPath + "\\Summary.xlsx", "Summary", host, callback, cancelTokenSummary);

        foreach (var cmp in ComparisonInstancesView.Where(c => c.Results.Progress == ProgressType.Done))
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
            var (_, cb1, cb1CancelToken) = app.AddTaskAndGetCallback($"Exporting Differences to {file.Name}");
            var (_, cb2, cb2CancelToken) = app.AddTaskAndGetCallback($"Exporting Missing from source to {file.Name}");
            var (_, cb3, cb3CancelToken) = app.AddTaskAndGetCallback($"Exporting Missing from target to {file.Name}");
            var (_, cb4, cb4CancelToken) = app.AddTaskAndGetCallback($"Exporting Source duplicates to {file.Name}");
            var (_, cb5, cb5CancelToken) = app.AddTaskAndGetCallback($"Exporting Target duplicates to {file.Name}");
            var (_, cb6, cb6CancelToken) = app.AddTaskAndGetCallback($"Exporting Source clones to {file.Name}");
            var (_, cb7, cb7CancelToken) = app.AddTaskAndGetCallback($"Exporting Target clones to {file.Name}");

            Task.Run(() =>
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
        prgGlobal.IsIndeterminate = true;

        var newInstances = new List<ComparerDefinition<object[]>>();
        var comparer = SequenceComparer<object>.Default;

        foreach (SourcesMapper mapper in UseSingleMapping ? new[] { SingleMap } : lstMappings.SelectedItems)
        {
            var cp = await ComparerDefinition<object[]>.CreateAsync(mapper, comparer, Map, Convert).ConfigureAwait(true);
            // Using ObservableCollections to reflect any live modification in the UI
            cp.Results.InitCollections(() => new ObservableCollection<object[]>());

            cp.Name = $"[{cpdCount++}] {cp.Name}";

            // Adding it twice... because we need two rows in the table (...)
            ComparisonInstancesView.Add(cp);
            ComparisonInstancesView.Add(cp);

            newInstances.Add(cp);
        }

        prgGlobal.IsIndeterminate = false;

        var callback = new Progress<ComparerDefinition<object[]>>(Progress);
        await Task.Run(() => Comparison.Run(newInstances, progressCallback: callback, useParallelism: App.Instance.CurrentProject.UseParallelism));
    }

    private bool CanExecuteRun => lstMappings?.SelectedItems.Count > 0;

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

                int currentProgress = (int)progressDC.Average(p => p.Value);

                prgGlobal.Value = currentProgress;

                //App.Instance.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
                //App.Instance.MainWindow.TaskbarItemInfo.ProgressValue = currentProgress / 100.0;

                //if (progressDC.Values.All(v => v == 100))
                //{
                //    App.Instance.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
                //}

                break;
        }
    }

    public ObservableCollection<ComparerDefinition<object[]>> ComparisonInstancesView { get; } = new();

    public IEnumerable<IGrouping<string, ComparerDefinition<object[]>>> GroupedComparisonInstancesView { get; }
    public SourcesMapper SingleMap { get; } = new();

    public bool UseSingleMapping { get; set; }

}
