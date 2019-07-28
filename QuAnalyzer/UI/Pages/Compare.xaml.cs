using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using OfficeOpenXml;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Generic.Extensions;
using QuAnalyzer.Helpers;
using QuAnalyzer.UI.Popups;
using QuAnalyzer.UI.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shell;
using Wokhan.Collections.Extensions;
using Wokhan.Data.Providers.Bases;
using Wokhan.Data.Providers.Contracts;
using WinForms = System.Windows.Forms;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Interaction logic for DataCompare.xaml
    /// </summary>
    public partial class Compare : Page
    {
        public ObservableCollection<object[]> real { get; } = new ObservableCollection<object[]>();

        private readonly List<CancellationTokenSource> tokensources = new List<CancellationTokenSource>();

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

            ListCollectionView cview = new ListCollectionView(real);
            cview.GroupDescriptions.Add(new PropertyGroupDescription("[0]"));
            allProgress.ItemsSource = cview;
        }

        private int cpdCount = 0;
        private readonly List<ComparerStruct<object[]>> cpd = new List<ComparerStruct<object[]>>();
        private async void btnRun_Click(object sender, RoutedEventArgs e)
        {
            prgGlobal.IsIndeterminate = true;

            var localcpd = new List<ComparerStruct<object[]>>();

            var x = await GetComparerStruct();
            foreach (var cp in x)
            {
                /*var idx = real.Count(r => Regex.IsMatch((string)r[0], Regex.Escape(cp.Name) + @"(?:\s\(\d+\))?$")) / 2;
                if (idx > 0)
                {*/
                cp.Name = String.Format("[{0}] {1}", cpdCount++, cp.Name);// (" + (idx + 1) + ")";
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
            });
        }

        private async Task<ComparerStruct<object[]>[]> GetComparerStruct()
        {
            // Case 1: Mappings
            if (tabMapping.IsSelected)
            {
                var mappers = lstMappings.SelectedItems.Cast<SourcesMapper>().ToList();
                return await Task.Run(() => mappers.Select(s => sourceMapperToCompStruct(s)).ToArray());
            }

            // Case 2: Custom mapping
            if (rdbCustomMapping.IsChecked.Value)
            {
                var mapper = (SourcesMapper)lstCustMappings.SelectedItem;
                return await Task.Run(() => new[] { sourceMapperToCompStruct(mapper) });
            }

            // Case 3: Automatic mapping (position)
            var srcPrv = (IDataProvider)lstSrc.SelectedItem;
            var srcRepo = (string)lstSrcRepo.SelectedItem;
            var trgPrv = (IDataProvider)lstTrg.SelectedItem;
            var trgRepo = (string)lstTrgRepo.SelectedItem;

            if (rdbAutoMapping.IsChecked.Value)
            {
                return await Task.Run(() =>
                {
                    IEnumerable<ColumnDescription> srcHeaders = srcPrv.GetColumns(srcRepo);
                    IEnumerable<ColumnDescription> trgHeaders = trgPrv.GetColumns(trgRepo);

                    if (trgHeaders.Count() > srcHeaders.Count())
                    {
                        trgHeaders = trgHeaders.Take(srcHeaders.Count());
                    }
                    else if (srcHeaders.Count() > trgHeaders.Count())
                    {
                        srcHeaders = srcHeaders.Take(trgHeaders.Count());
                    }

                    Func<IEnumerable<object[]>, Type[], IEnumerable<object[]>> fnc = srcHeaders.Select(h => h.Type).SequenceEqual(trgHeaders.Select(h => h.Type)) ? new Func<IEnumerable<object[]>, Type[], IEnumerable<object[]>>(KeepSame) : new Func<IEnumerable<object[]>, Type[], IEnumerable<object[]>>(ConvertType);

                    var srcKeys = srcHeaders.Select(h => h.Name).ToArray();
                    var trgKeys = trgHeaders.Select(h => h.Name).ToArray();

                    var srcDataGetter = srcPrv.GetData(srcRepo, srcKeys);
                    var trgDataGetter = srcPrv.GetData(trgRepo, trgKeys);

                    return new[] { new ComparerStruct<object[]>()
                                        {
                                            Name = "Automatic mapping (by position)",
                                            SourceName = srcPrv.Name + " " + srcRepo,
                                            TargetName = trgPrv.Name + " " + trgRepo,
                                            SourceHeaders = srcKeys,
                                            TargetHeaders = trgKeys,
                                            Comparer = new SequenceEqualityComparer(),
                                            GetSourceData = () => fnc(srcDataGetter.AsObjectCollection(srcKeys), trgHeaders.Select(h => h.Type).ToArray()),
                                            GetTargetData = () => fnc(trgDataGetter.AsObjectCollection(trgKeys), trgHeaders.Select(h => h.Type).ToArray())
                                        }
                    };
                });
            }

            // Case 4: Automatic mapping (name)
            return await Task.Run(() =>
            {
                var srcHeaders = srcPrv.GetColumns(srcRepo);
                var trgHeaders = trgPrv.GetColumns(trgRepo);

                var inter = srcHeaders.Select(h => h.Name).Intersect(trgHeaders.Select(h => h.Name), StringComparer.InvariantCultureIgnoreCase).ToList();

                //TODO: yurk
                var allTypesSrc = inter.Select(m => srcHeaders.First(h => h.Name == m).Type).ToArray();
                var allTypesTrg = inter.Select(m => trgHeaders.First(h => h.Name == m).Type).ToArray();

                Func<IEnumerable<object[]>, Type[], IEnumerable<object[]>> fncx = allTypesSrc.SequenceEqual(allTypesTrg) ? new Func<IEnumerable<object[]>, Type[], IEnumerable<object[]>>(KeepSame) : new Func<IEnumerable<object[]>, Type[], IEnumerable<object[]>>(ConvertType);

                return new[] { new ComparerStruct<object[]>()
                                       {
                                            Name = "Automatic mapping (by name)",
                                            SourceName = srcPrv.Name + " " + srcRepo,
                                            TargetName = trgPrv.Name + " " + trgRepo,
                                            SourceHeaders = inter,
                                            TargetHeaders = inter,
                                            Comparer = new SequenceEqualityComparer(),
                                            GetSourceData = () => fncx(srcPrv.GetData(srcRepo, inter).AsObjectCollection(srcHeaders.Select(h => h.Name).ToArray()), allTypesTrg),
                                            GetTargetData = () => fncx(trgPrv.GetData(trgRepo, inter).AsObjectCollection(trgHeaders.Select(h => h.Name).ToArray()), allTypesTrg)
                                        }
                };
            });
        }

        private static ComparerStruct<object[]> sourceMapperToCompStruct(SourcesMapper s)
        {
            var fieldsSrc = s.AllMappings.Select(m => m.Source).ToList();
            var fieldsTrg = s.AllMappings.Select(m => m.Target).ToList();

            var srcHeaders = s.Source.GetColumns(s.SourceRepository);
            var trgHeaders = s.Target.GetColumns(s.TargetRepository);

            var allTypesSrc = fieldsSrc.Select(m => srcHeaders.First(h => h.Name == m).Type).ToArray();
            var allTypesTrg = fieldsTrg.Select(m => trgHeaders.First(h => h.Name == m).Type).ToArray();

            string[] srcKeys = null;
            string[] trgKeys = null;
            if (s.AllMappings.Any(a => a.IsKey))
            {
                srcKeys = s.AllMappings.Where(a => a.IsKey).Select(m => m.Source).ToArray();
                trgKeys = s.AllMappings.Where(a => a.IsKey).Select(m => m.Target).ToArray();
            }

            Func<IEnumerable<IEnumerable<object>>, Type[], IEnumerable<object[]>> fnc = allTypesSrc.SequenceEqual(allTypesTrg) ? new Func<IEnumerable<IEnumerable<object>>, Type[], IEnumerable<object[]>>(KeepSame) : new Func<IEnumerable<IEnumerable<object>>, Type[], IEnumerable<object[]>>(ConvertType);

            var srcDataGetter = s.Source.GetData(s.SourceRepository, fieldsSrc, null, srcKeys != null ? srcKeys.ToDictionary(sk => sk, sk => srcHeaders.First(h => h.Name == sk).Type) : null);
            var trgDataGetter = s.Target.GetData(s.TargetRepository, fieldsTrg, null, trgKeys != null ? trgKeys.ToDictionary(sk => sk, sk => trgHeaders.First(h => h.Name == sk).Type) : null);
            if (s.IsOrdered)
            {
                if (srcKeys != null && trgKeys != null)
                {
                    srcDataGetter = srcDataGetter.OrderByMany(srcHeaders.Join(srcKeys, h => h.Name, k => k, (h, k) => new { h, k }).ToDictionary(x => x.k, x => x.h.Type));
                    trgDataGetter = trgDataGetter.OrderByMany(trgHeaders.Join(trgKeys, h => h.Name, k => k, (h, k) => new { h, k }).ToDictionary(x => x.k, x => x.h.Type));
                }
                else
                {
                    srcDataGetter = srcDataGetter.OrderByAll();
                    trgDataGetter = trgDataGetter.OrderByAll();
                }
            }
            return new ComparerStruct<object[]>()
            {
                Name = s.Name,
                SourceName = s.Source.Name + " (" + s.SourceRepository + ")",
                TargetName = s.Target.Name + " (" + s.TargetRepository + ")",
                SourceHeaders = fieldsSrc,
                TargetHeaders = fieldsTrg,
                SourceKeys = srcKeys,
                TargetKeys = trgKeys,
                Comparer = new SequenceEqualityComparer(),
                KeysComparer = (srcKeys != null ? new SequenceEqualityComparer(0, srcKeys.Length) : null),
                GetSourceData = () => fnc(srcDataGetter.AsObjectCollection(fieldsSrc.ToArray()), allTypesTrg), //.Select(r => allIdxSr.Select(i => r[i]).ToArray()),
                GetTargetData = () => fnc(trgDataGetter.AsObjectCollection(fieldsTrg.ToArray()), allTypesTrg),//.Select(r => allIdxTr.Select(i => r[i]).ToArray())
                IsOrdered = s.IsOrdered
            };
        }

        private static IEnumerable<object[]> KeepSame(IEnumerable<IEnumerable<object>> src, Type[] types)
        {
            if (false)
            {
#pragma warning disable CS0162 // Code inaccessible détecté
                return src.Select(c => c.Select(a => a is DBNull ? null : a is DateTime ? ((DateTime)a).Date : a).ToArray());
#pragma warning restore CS0162 // Code inaccessible détecté
            }
            else
            {
                return src.Select(c => c.ToArray());
            }
        }

        private static IEnumerable<object[]> ConvertType(IEnumerable<IEnumerable<object>> src, Type[] types)
        {
            return src.Select(c => c.Select((a, i) => SafeConvert(a, types[i])).ToArray());
        }

        private static object SafeConvert(object a, Type type)
        {
            if (a is DBNull || a == null || (a is string && String.IsNullOrEmpty((string)a)))
            {
                return null;
            }
            else
            {
                Type aType = a.GetType();
                Type t = Nullable.GetUnderlyingType(aType);

                object safeValue;
                if (t != null)
                {
                    safeValue = (a == null || a == DBNull.Value) ? null : Convert.ChangeType(a, t);
                }
                else
                {
                    safeValue = a;
                }

                return ChangeType(safeValue, type);
            }
        }

        public static object ChangeType(object value, Type conversionType)
        {
            if (conversionType == null)
            {
                throw new ArgumentNullException("conversionType");
            }

            if (conversionType.IsGenericType &&
              conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }

            return Convert.ChangeType(value, conversionType, CultureInfo.InvariantCulture);
        }

        private void lstSrc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //lstSrcRepo.DataContext = lstSrc.SelectedItem;

            if (lstSrcRepo.Items.Count < 2)
            {
                lstSrcTrgRepo_SelectionChanged(null, null);
            }
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
                var dWin = new Popup(new DetailsWindow(cmp));
                dWin.Closed += dWin_Closed;
                openWindows.Add(cmp, dWin);
            }

            openWindows[cmp].Show();
            openWindows[cmp].Activate();
        }

        void dWin_Closed(object sender, EventArgs e)
        {
            openWindows.Remove(openWindows.Single(o => o.Value == sender).Key);
        }

        private void lstTrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstTrgRepo.Items.Count < 2)
            {
                lstSrcTrgRepo_SelectionChanged(null, null);
            }
        }

        private void lstSrcTrgRepo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstTrgRepo.SelectedItem != null && lstSrcRepo.SelectedItem != null)
            {
                lstCustMappings.ItemsSource = ((App)App.Current).CurrentProject.SourceMapper.Where(c => c.Source == lstSrc.SelectedItem && c.SourceRepository == (string)lstSrcRepo.SelectedItem
                                                                                        && c.Target == lstTrg.SelectedItem && c.TargetRepository == (string)lstTrgRepo.SelectedItem);
            }
        }

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
            var dial = new WinForms.FolderBrowserDialog() { ShowNewFolderButton = true, Description = "Pick the folder all reports will be saved in. Existing files will be overwritten." };
            if (dial.ShowDialog() != WinForms.DialogResult.OK)
            {
                return;
            }

            StackPanel host = ((ModernMain)Window.GetWindow(this)).stackExports;
            ((ModernMain)Window.GetWindow(this)).flyExports.IsOpen = true;

            allProgress.ExportAsXLSX(dial.SelectedPath + "\\Summary.xlsx", "Summary", host, SharedCallback.GetCallBackForExport(host, "Summary", null));

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

                string p = dial.SelectedPath + "\\" + name + "_Details.xlsx";

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
                        xl.AddWorksheet(cmp.Results.MergedDiff, new[] { "Name" }.Concat(cmp.Results.MergedHeaders).ToArray(), cmp.SourceKeys.Count, "Differences", (x, i, h, s) => { if (x.IsDiff[i]) { s.Font.Color.SetColor(System.Drawing.Color.Red); } return x.Values[i]; }, cb1);

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


        private void btnNewPrv_Click(object sender, RoutedEventArgs e)
        {
            var editor = new Popup(new MappingsEditor());
            editor.Show();
            editor.Activate();
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
                    var map = allprv.Where(p => p != pr).Select(p => new { source = pr, target = p, matches = p.Repositories.Keys.Intersect(pr.Repositories.Keys).ToList() })
                                    .Where(rel => rel.matches.Count > 0)
                                    .SelectMany(rel => rel.matches.Select(m => new { source = rel.source, target = rel.target, repository = m, sourceheaders = rel.source.GetColumns(m).Select(h => h.Name), targetheaders = rel.target.GetColumns(m).Select(h => h.Name) }))
                                    .Select(m => new SourcesMapper()
                                    {
                                        Name = String.Format("{0} ({1}) / {2} ({1})", m.source.Name, m.repository, m.target.Name),
                                        Source = m.source,
                                        Target = m.target,
                                        SourceRepository = m.repository,
                                        TargetRepository = m.repository,
                                        AllMappings = m.sourceheaders.Where(k => m.targetheaders.Contains(k)).Select(k => new SourcesMapper.SimpleMap() { Source = k, Target = k }).ToList()
                                    });

                    mapper.AddAll(map);

                    done = done.Union(map.Select(m => m.Source)).Union(map.Select(m => m.Target));
                }
            }
        }

        private void btnEditMapping_Click(object sender, RoutedEventArgs e)
        {
            var editor = new Popup(new MappingsEditor((SourcesMapper)((Button)sender).Tag));
            editor.Show();
            editor.Activate();
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
