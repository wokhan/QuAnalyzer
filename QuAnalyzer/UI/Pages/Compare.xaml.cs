using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using OfficeOpenXml;
using QuAnalyzer.Core.Helpers;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.UI.Popups;
using QuAnalyzer.UI.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
        public ObservableCollection<object[]> real { get; } = new ObservableCollection<object[]>();

        private readonly List<CancellationTokenSource> tokensources = new List<CancellationTokenSource>();

        public SourcesMapper SingleMap { get; } = new SourcesMapper();

        public class DiffClass
        {
            public object[] Values { get; set; }
            public bool[] IsDiff { get; set; }
        }

        public Compare()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                real.Add(new object[1] { "TEST" });
            }

            InitializeComponent();

            //ObservableCollection<object[]> real = new ObservableCollection<object[]>(cpd.Select(c => c.AsArray));

            var cview = new ListCollectionView(real);
            cview.GroupDescriptions.Add(new PropertyGroupDescription("[0]"));
            allProgress.ItemsSource = cview;
        }

        private int cpdCount = 0;
        private readonly List<ComparerStruct<object[]>> cpd = new List<ComparerStruct<object[]>>();
        private async void btnRun_Click(object sender, RoutedEventArgs e)
        {
            prgGlobal.IsIndeterminate = true;

            var localcpd = new List<ComparerStruct<object[]>>();

            var x = await GetComparerStruct().ConfigureAwait(false);
            foreach (var cp in x)
            {
                /*var idx = real.Count(r => Regex.IsMatch((string)r[0], Regex.Escape(cp.Name) + @"(?:\s\(\d+\))?$")) / 2;
                if (idx > 0)
                {*/
                cp.Name = $"[{cpdCount++}] {cp.Name}";
                //}

                localcpd.Add(cp);
                cpd.Add(cp);
                real.AddAll(cp.AsArray);
                tokensources.Add(cp.TokenSource);
                globalCount++;
            }

            prgGlobal.IsIndeterminate = false;

            await Task.Run(() =>
            {
                Comparison.Run(localcpd, 0, 0, Progress, ((App)App.Current).CurrentProject.UseParallelism);
            }).ConfigureAwait(false);
        }

        private async Task<ComparerStruct<object[]>[]> GetComparerStruct()
        {
            if ((bool)btnToggleMode.IsChecked)
            {
                return await Task.Run(() => new[] { new ComparerStruct<object[]>(SingleMap) }).ConfigureAwait(false);
            }

            var mappers = lstMappings.SelectedItems.Cast<SourcesMapper>().ToList();
            return await Task.Run(() => mappers.Select(s => new ComparerStruct<object[]>(s)).ToArray()).ConfigureAwait(false);

        }

        private int globalCount;
        private Dictionary<string, int> progressDC = new Dictionary<string, int>();
        public void Progress(ComparerStruct<object[]> name)
        {
            try
            {
                this.Dispatcher.Invoke(() => LocalProgress(name));
            }
#pragma warning disable CS0168 // La variable 'e' est déclarée, mais jamais utilisée
            catch (TaskCanceledException e)
#pragma warning restore CS0168 // La variable 'e' est déclarée, mais jamais utilisée
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

                    int currentProgress = (int)progressDC.Average(p => (int)p.Value);

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
            Button src = (Button)sender;
            var r = (ComparerStruct<object[]>)src.Tag;

            progressDC.Remove(r.Name);
            real.Remove(real.First(re => r.Name.Equals((string)re[0])));
            real.Remove(real.First(re => r.Name.Equals((string)re[0])));
        }

        public void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Button src = (Button)sender;
            var r = (ComparerStruct<object[]>)src.Tag;

            src.IsEnabled = false;

            // tokensources[r.Name];
            tokensources.Remove(r.TokenSource);
            r.TokenSource.Cancel(true);
            //ts.Cancel(true);
        }

        Dictionary<IDataComparer, Popup> openWindows = new Dictionary<IDataComparer, Popup>();
        public void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            Button src = (Button)sender;
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

        void dWin_Closed(object sender, EventArgs e)
        {
            openWindows.Remove(openWindows.Single(o => o.Value == sender).Key);
        }

        //private void lstTrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (lstTrgRepo.Items.Count < 2)
        //    {
        //        lstSrcTrgRepo_SelectionChanged(null, null);
        //    }
        //}

        //private void lstSrcTrgRepo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (lstTrgRepo.SelectedItem != null && lstSrcRepo.SelectedItem != null)
        //    {
        //        lstCustMappings.ItemsSource = ((App)App.Current).CurrentProject.SourceMapper.Where(c => c.Source == lstSrc.SelectedItem && c.SourceRepository == (string)lstSrcRepo.SelectedItem
        //                                                                                && c.Target == lstTrg.SelectedItem && c.TargetRepository == (string)lstTrgRepo.SelectedItem);
        //    }
        //}

        //private void spltResults_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    var h = gridMain.RowDefinitions.First();
        //    if (h.Height.Value == 0)
        //    {
        //        h.Height = GridLength.Auto;
        //    }
        //    else
        //    {
        //        h.Height = new GridLength(0);
        //    }
        //}

        private void GlobalExportCSV_Click(object sender, RoutedEventArgs e)
        {
            var dial = new SaveFileDialog() { CheckFileExists = false, ValidateNames = true, AddExtension = true, Filter = "Excel 2007 File|*.xlsx" };
            if (dial.ShowDialog().Value)
            {
                allProgress.ExportAsXLSX();
            }
        }

        private void GlobalExportHTML_Click(object sender, RoutedEventArgs e)
        {
            allProgress.ExportAsHTML();
        }


        private void GlobalCopy_Click(object sender, RoutedEventArgs e)
        {
            allProgress.CopyToClipboard();
        }

        private void GlobalReport_Click(object sender, RoutedEventArgs e)
        {
            var dial = new OpenFileDialog() { CheckFileExists = false, CheckPathExists = true, ValidateNames = false, FileName = "Pick a folder to save reports in. Existing files will be overwritten." };
            if (!(bool)dial.ShowDialog())
            {
                return;
            }


            var folderPath = Directory.GetParent(dial.FileName);
            StackPanel host = ((ModernMain)Window.GetWindow(this)).stackExports;
            ((ModernMain)Window.GetWindow(this)).flyExports.IsOpen = true;

            allProgress.ExportAsXLSX(folderPath + "\\Summary.xlsx", "Summary", host, SharedCallback.GetCallBackForExport(host, "Summary", null));

            foreach (var cmp in cpd.Where(c => c.Results.Progress == ProgressType.Done))
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

                string p = folderPath + "\\" + name + "_Details.xlsx";

                var file = new FileInfo(p);
                //if (cmp.Results.MergedDiff != null)
                var cb1 = SharedCallback.GetCallBackForExport(host, "Differences", file.Name);
                var cb2 = SharedCallback.GetCallBackForExport(host, "Missing from source", file.Name);
                var cb3 = SharedCallback.GetCallBackForExport(host, "Missing from target", file.Name);
                var cb4 = SharedCallback.GetCallBackForExport(host, "Source duplicates", file.Name);
                var cb5 = SharedCallback.GetCallBackForExport(host, "Target duplicates", file.Name);
                var cb6 = SharedCallback.GetCallBackForExport(host, "Source clones", file.Name);
                var cb7 = SharedCallback.GetCallBackForExport(host, "Target clones", file.Name);

                Task.Run(() =>
                {
                    using (var xl = new ExcelPackage(file))
                    {
                        cmp.Results.InitDiff(cmp);
                        xl.AddWorksheet(cmp.Results.MergedDiff, cmp.Results.MergedHeaders.Prepend("Name").ToArray(), cmp.SourceKeys.Count, "Differences", (x, i, h, s) => { if (x.IsDiff[i]) { s.Font.Color.SetColor(System.Drawing.Color.Red); } return x.Values[i]; }, cb1);

                        //if (cmp.Results.Source.Missing != null)
                        xl.AddWorksheet(cmp.Results.Source.Missing.Cast<object[]>(), cmp.SourceHeaders, cmp.SourceKeys.Count, "Missing from source", (x, i, h, s) => x[i], cb2);

                        //if (dgMissingTarget.ItemsSource != null)
                        xl.AddWorksheet(cmp.Results.Target.Missing.Cast<object[]>(), cmp.TargetHeaders, 0, "Missing from target", (x, i, h, s) => x[i], cb3);

                        //if (dgSourceDups.ItemsSource != null)
                        xl.AddWorksheet(cmp.Results.Source.Duplicates.Cast<object[]>(), cmp.SourceHeaders, 0, "Source duplicates", (x, i, h, s) => x[i], cb4);

                        //if (dgTargetDups.ItemsSource != null)
                        xl.AddWorksheet(cmp.Results.Target.Duplicates.Cast<object[]>(), cmp.TargetHeaders, 0, "Target duplicates", (x, i, h, s) => x[i], cb5);

                        //if (dgSourcePerfectDups.ItemsSource != null)
                        xl.AddWorksheet(cmp.Results.Source.PerfectDups.Cast<object[]>(), cmp.SourceHeaders, 0, "Source clones", (x, i, h, s) => x[i], cb6);

                        //if (dgTargetPerfectDups.ItemsSource != null)
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


        private void btnNewPrv_Click(object sender, RoutedEventArgs e) => Popup.OpenNew(new MappingsEditor());

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

        private void btnError_Click(object sender, RoutedEventArgs e)
        {
            ((ModernMain)Window.GetWindow(this)).ShowMessageAsync("Error details", (string)((Button)sender).Tag, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AnimateShow = true, AnimateHide = true });
        }
    }
}
