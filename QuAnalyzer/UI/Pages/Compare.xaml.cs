
using Microsoft.Win32;

using OfficeOpenXml;

using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.UI.Popups;
using QuAnalyzer.UI.Windows;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shell;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Pages;

/// <summary>
/// Interaction logic for DataCompare.xaml
/// </summary>
public partial class Compare : Page
{
    public SourcesMapper SingleMap { get; } = new();

    private int cpdCount = 0;
    public ObservableCollection<ComparerDefinition<object[]>> ComparisonInstancesView { get; } = new();

    public Compare()
    {
        InitializeComponent();
    }

    private async void btnRun_Click(object sender, RoutedEventArgs e)
    {
        if (lstMappings.SelectedItems.Count == 0)
        {
            return;
        }

        prgGlobal.IsIndeterminate = true;

        var newInstances = new List<ComparerDefinition<object[]>>();

        foreach (SourcesMapper mapper in btnToggleMode.IsChecked is true ? new[] { SingleMap } : lstMappings.SelectedItems)
        {
            var cp = await ComparerDefinition<object[]>.CreateAsync(mapper).ConfigureAwait(true);

            cp.Name = $"[{cpdCount++}] {cp.Name}";

            // Adding it twice... because we need two rows in the table (...)
            ComparisonInstancesView.Add(cp);
            ComparisonInstancesView.Add(cp);

            newInstances.Add(cp);
        }
        
        prgGlobal.IsIndeterminate = false;

        var callback = new Progress<ComparerDefinition<object[]>>(Progress);
        await Task.Run(() => Comparison.Run(newInstances, 0, 0, callback, App.Instance.CurrentProject.UseParallelism));
    }

    private readonly Dictionary<string, int> progressDC = new();

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

                Application.Current.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
                Application.Current.MainWindow.TaskbarItemInfo.ProgressValue = currentProgress / 100.0;

                if (progressDC.Values.All(v => v == 100))
                {
                    Application.Current.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
                }

                break;
        }
    }

    public void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        var src = (Button)sender;
        var r = (ComparerDefinition<object[]>)src.Tag;

        progressDC.Remove(r.Name);
        ComparisonInstancesView.RemoveRange(ComparisonInstancesView.Where(re => r.Name.Equals((string)re.Name)).ToList());
    }

    public void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        var src = (Button)sender;
        var r = (ComparerDefinition<object[]>)src.Tag;

        src.IsEnabled = false;
        r.TokenSource.Cancel(true);
    }

    private readonly Dictionary<ComparerDefinition<object[]>, Popup> openWindows = new();
    public void btnDetails_Click(object sender, RoutedEventArgs e)
    {
        var src = (Button)sender;
        var cmp = (ComparerDefinition<object[]>)src.Tag;
        if (!openWindows.ContainsKey(cmp))
        {
            var dWin = Popup.OpenNew(new DetailsWindow(cmp));
            dWin.Closed += dWin_Closed;
            openWindows.Add(cmp, dWin);
        }

        //openWindows[cmp].Show();
        openWindows[cmp].Activate();
    }

    private void dWin_Closed(object sender, EventArgs e)
    {
        openWindows.Remove(openWindows.Single(o => o.Value == sender).Key);
    }


    private void GlobalReport_Click(object sender, RoutedEventArgs e)
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


    private void btnNewPrv_Click(object sender, RoutedEventArgs e)
    {
        Popup.OpenNew(new MappingsEditor());
    }

    private void btnAuto_Click(object sender, RoutedEventArgs e)
    {
        var allprv = App.Instance.CurrentProject.CurrentProviders;

        var mapper = App.Instance.CurrentProject.SourceMapper;

        mapper.Clear();

        IEnumerable<IDataProvider> done = new List<IDataProvider>();
        foreach (var pr in allprv)
        {
            if (!done.Contains(pr))
            {
                var map = allprv.Where(p => p != pr)
                                .Select(p => new
                                {
                                    source = pr,
                                    target = p,
                                    matches = p.Repositories.Keys.Intersect(pr.Repositories.Keys).ToList()
                                })
                                .Where(rel => rel.matches.Count > 0)
                                .SelectMany(rel => rel.matches.Select(m => new { source = rel.source, target = rel.target, repository = m, sourceheaders = rel.source.GetColumns(m).Select(h => h.Name), targetheaders = rel.target.GetColumns(m).Select(h => h.Name) }))
                                .Select(m => new SourcesMapper()
                                {
                                    Name = $"{m.source.Name} ({m.repository}) / {m.target.Name} ({m.repository})",
                                    Source = m.source,
                                    Target = m.target,
                                    SourceRepository = m.repository,
                                    TargetRepository = m.repository,
                                    AllMappings = m.sourceheaders.Where(k => m.targetheaders.Contains(k)).Select(k => new SimpleMap(k, k)).ToList()
                                });

                mapper.AddAll(map);

                done = done.Union(map.Select(m => m.Source)).Union(map.Select(m => m.Target)).ToList();
            }
        }
    }

    private void btnEditMapping_Click(object sender, RoutedEventArgs e)
    {
        Popup.OpenNew(new MappingsEditor((SourcesMapper)((Button)sender).Tag));
    }

    private void btnDeleteMapping_Click(object sender, RoutedEventArgs e)
    {
        App.Instance.CurrentProject.SourceMapper.Remove((SourcesMapper)((Button)sender).Tag);
    }

    private void btnSelectAll_Click(object sender, RoutedEventArgs e)
    {
        lstMappings.SelectAll();
    }

    private void btnUnSel_Click(object sender, RoutedEventArgs e)
    {
        lstMappings.UnselectAll();
    }

}
