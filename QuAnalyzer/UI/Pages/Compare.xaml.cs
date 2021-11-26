﻿
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shell;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Interaction logic for DataCompare.xaml
    /// </summary>
    public partial class Compare : Page
    {
        public SourcesMapper SingleMap { get; } = new();

        private int cpdCount = 0;
        public ObservableCollection<ComparerStruct<object[]>> ComparisonInstances { get; } = new();

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

            var newInstances = new List<ComparerStruct<object[]>>();

            var x = await GetComparerStruct().ConfigureAwait(true);
            foreach (var cp in x)
            {
                cp.Name = $"[{cpdCount++}] {cp.Name}";

                newInstances.Add(cp);
                ComparisonInstances.Add(cp);
                ComparisonInstances.Add(cp);
            }

            prgGlobal.IsIndeterminate = false;

            await Task.Run(() => Comparison.Run(newInstances, 0, 0, Progress, ((App)App.Current).CurrentProject.UseParallelism)).ConfigureAwait(false);
        }

        private async Task<ComparerStruct<object[]>[]> GetComparerStruct()
        {
            if (btnToggleMode.IsChecked is true)
            {
                return await Task.Run(() => new[] { new ComparerStruct<object[]>(SingleMap) }).ConfigureAwait(false);
            }

            var mappers = lstMappings.SelectedItems.Cast<SourcesMapper>().ToList();
            return await Task.Run(() => mappers.Select(mapper => new ComparerStruct<object[]>(mapper)).ToArray()).ConfigureAwait(false);

        }

        private readonly Dictionary<string, int> progressDC = new();
        public void Progress(ComparerStruct<object[]> name)
        {
            try
            {
                this.Dispatcher.InvokeAsync(() => LocalProgress(name));
            }
            catch (TaskCanceledException)
            {

            }
        }

        public void LocalProgress(ComparerStruct<object[]> r)
        {
            switch (r.Results.Progress)
            {
                case ProgressType.Failed:
                case ProgressType.Canceling:
                    progressDC.Remove(r.Name);
                    break;

                case ProgressType.Done:
                default:
                    progressDC[r.Name] = r.Results.LocalProgress;

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
            var r = (ComparerStruct<object[]>)src.Tag;

            progressDC.Remove(r.Name);
            ComparisonInstances.RemoveRange(ComparisonInstances.Where(re => r.Name.Equals((string)re.Name)));
        }

        public void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var src = (Button)sender;
            var r = (ComparerStruct<object[]>)src.Tag;

            src.IsEnabled = false;
            r.TokenSource.Cancel(true);
        }

        private readonly Dictionary<IDataComparer, Popup> openWindows = new Dictionary<IDataComparer, Popup>();
        public void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            var src = (Button)sender;
            var cmp = (IDataComparer)src.Tag;
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

            var app = (App)Application.Current;
            var (host, callback, cancelTokenSummary) = app.AddTaskAndGetCallback("Exporting Summary");
            
            allProgress.ExportAsXLSX(folderPath + "\\Summary.xlsx", "Summary", host, callback, cancelTokenSummary);

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
            var allprv = ((App)App.Current).CurrentProject.CurrentProviders;

            var mapper = ((App)App.Current).CurrentProject.SourceMapper;

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
            ((App)App.Current).CurrentProject.SourceMapper.Remove((SourcesMapper)((Button)sender).Tag);
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
}
