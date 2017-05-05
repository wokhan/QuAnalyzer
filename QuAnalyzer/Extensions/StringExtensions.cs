using MahApps.Metro.Controls;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuAnalyzer.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;
using LinqExpressions = System.Linq.Expressions;

namespace QuAnalyzer.Extensions
{
    public static class StringExtensions
    {
        public static int GreatestCommonDiv(this IEnumerable<int> src)
        {
            return src.OrderBy(a => a).Aggregate((a, b) => GreatestCommonDiv(a, b));
        }

        private static int GreatestCommonDiv(int a, int b)
        {
            int rem;

            while (b != 0)
            {
                rem = a % b;
                a = b;
                b = rem;
            }

            return a;
        }


        public static T AnonymousToKnownType<T>(this object o) where T : class
        {
            return (T)o;
        }

        public static dynamic ToObject(this object[] o, Type targetclass, string[] attributes)
        {
            var trg = Activator.CreateInstance(targetclass);

            var pr = attributes.Join(targetclass.GetProperties(), a => a, b => b.Name, (a, b) => b).ToList();
            for (int i = 0; i < pr.Count; i++)
            {
                if (o[i] != DBNull.Value && o[i] != null)
                {
                    pr[i].SetValue(trg, o[i]);
                }
            }

            return Convert.ChangeType(trg, targetclass);
        }

        public static T ToObject<T>(this object[] o, string[] attributes)
        {
            var trg = (T)Activator.CreateInstance(typeof(T));

            var pr = attributes.Join(typeof(T).GetProperties(), a => a, b => b.Name, (a, b) => b).ToList();
            for (int i = 0; i < pr.Count; i++)
            {
                if (o[i] != DBNull.Value && o[i] != null)
                {
                    pr[i].SetValue(trg, o[i]);
                }
            }

            return trg;
        }

        public static T ToObject<T>(this string[] o, string[] attributes)
        {
            var trg = (T)Activator.CreateInstance(typeof(T));

            var pr = attributes.Join(typeof(T).GetProperties(), a => a, b => b.Name, (a, b) => b).ToList();
            for (int i = 0; i < pr.Count; i++)
            {
                pr[i].SetValue(trg, o[i]);
            }

            return trg;
        }

        public static IEnumerable<object[]> AsObjectCollection(this IEnumerable src, params string[] attributes)
        {
            return AsObjectCollection<object>(src.Cast<object>(), attributes);
        }

        public static IEnumerable<object[]> AsObjectCollection<T>(this IEnumerable<T> src, params string[] attributes)
        {
            var innertype = src.GetInnerType();
            if (innertype.IsArray)
            {
                return ((IEnumerable<object[]>)src);
            }
            else
            {

                if (attributes == null)
                {
                    attributes = innertype.GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(a => a.Name).ToArray();
                }

                var param = LinqExpressions.Expression.Parameter(typeof(object));
                var expa = LinqExpressions.Expression.Parameter(typeof(Exception));
                var ide_cstr = typeof(InvalidDataException).GetConstructor(new[] { typeof(string), typeof(Exception) });

                var casted = LinqExpressions.Expression.Convert(param, innertype);

                var atrs = attributes.Select(a =>
                    LinqExpressions.TryExpression.TryCatch(
                        LinqExpressions.BlockExpression.Block(
                            LinqExpressions.Expression.Convert(LinqExpressions.Expression.Property(casted, a), typeof(object))
                        ),
                    LinqExpressions.TryExpression.Catch(expa,
                        LinqExpressions.Expression.Block(
                            LinqExpressions.Expression.Throw(LinqExpressions.NewExpression.New(ide_cstr, LinqExpressions.Expression.Constant(a), expa)),
                            LinqExpressions.Expression.Constant(null))))
                ).ToList();

                var attrExpr = LinqExpressions.Expression.Lambda<Func<T, object[]>>(LinqExpressions.Expression.NewArrayInit(typeof(object), atrs), param).Compile();

                return src.Select(x => { if (x == null) { throw new Exception("WTF????"); } return attrExpr(x); });
            }
        }

        //public static IEnumerable<object[]> AsObjectCollection(this IEnumerable src, params string[] attributes)
        //{
        //    var innertype = src.GetInnerType();
        //    if (innertype.IsArray)
        //    {
        //        return ((IEnumerable<object[]>)src);
        //    }
        //    else
        //    {
        //        var param = LinqExpressions.Expression.Parameter(typeof(object));
        //        var attrExpr = LinqExpressions.Expression.Lambda<Func<T, object[]>>(LinqExpressions.Expression.NewArrayInit(typeof(object), attributes.Select(a => LinqExpressions.Expression.Convert(LinqExpressions.Expression.Property(LinqExpressions.Expression.Convert(param, innertype), a), typeof(object)))), param).Compile();

        //        return ((IEnumerable<dynamic>)src).Select(attrExpr);
        //    }
        //}

        public static Type GetInnerType<T>(this IEnumerable<T> src)
        {
            return src.GetType().GenericTypeArguments.FirstOrDefault();
        }

        public static Type GetInnerType(this IEnumerable src)
        {
            return src.GetType().GenericTypeArguments.FirstOrDefault();
        }


        public static string Truncate(this string str, int maxLen)
        {
            return str.Length > maxLen ? str.Substring(0, maxLen) : str;
        }

        //public static Type GetInnerType<T>(this ICollection<T> src)
        //{
        //    return typeof(T);
        //}

        //public static Type GetInnerType<T>(this IEnumerable<T> src)
        //{
        //    return typeof(T);
        //}

        public static object GetDefault(this Type t)
        {
            return ((Func<object>)GetDefaultGeneric<object>).Method.GetGenericMethodDefinition().MakeGenericMethod(t).Invoke(null, null);
        }

        public static T GetDefaultGeneric<T>()
        {
            return default(T);
        }

        public static BitmapSource AsBitmapSource(this Icon src)
        {
            return null;
        }

        public static IOrderedEnumerable<T[]> OrderByMany<T>(this IEnumerable<T[]> obj, int[] indexes)
        {
            IOrderedEnumerable<T[]> ret = obj.OrderBy(a => a.Length > 0 ? a[indexes[0]] : default(T));
            for (int i = 1; i < indexes.Length; i++)
            {
                var ic = i;
                ret = ret.ThenBy(a => a.Length > ic ? a[ic] : default(T));
            }

            return ret;
        }

        public static IOrderedQueryable<dynamic> OrderByMany<T>(this IQueryable<T> src, Dictionary<string, Type> attributes)
        {
            var innertype = src.GetInnerType();
            var m = typeof(StringExtensions).GetMethod("OrderByManyTyped").MakeGenericMethod(innertype);
            return (IOrderedQueryable<dynamic>)m.Invoke(null, new object[] { src, attributes });
        }

        public static IOrderedQueryable<T> OrderByManyTyped<T>(IQueryable<T> src, Dictionary<string, Type> attributes)
        {
            var param = LinqExpressions.ParameterExpression.Parameter(typeof(T));

            var ret = src.OrderBy(LinqExpressions.Expression.Lambda<Func<T, dynamic>>(LinqExpressions.Expression.Property(param, attributes.First().Key), param));
            foreach (var attr in attributes.Skip(1))
            {
                ret = ret.ThenBy(LinqExpressions.Expression.Lambda<Func<T, dynamic>>(LinqExpressions.Expression.Property(param, attr.Key), param));
            }

            return ret;
        }

        public static IOrderedEnumerable<T[]> OrderByMany<T>(this IEnumerable<T[]> obj, int columnsToTake, int columnsToSkip = 0)
        {
            IOrderedEnumerable<T[]> ret = obj.OrderBy(a => a.Length > columnsToSkip ? a[columnsToSkip] : default(T));
            for (int i = columnsToSkip + 1; i < columnsToSkip + columnsToTake; i++)
            {
                var ic = i;
                ret = ret.ThenBy(a => a.Length > ic ? a[ic] : default(T));
            }

            return ret;
        }


        public static IOrderedQueryable<T[]> OrderByMany<T>(this IQueryable<T[]> obj, int columnsToTake, int columnsToSkip = 0)
        {
            IOrderedQueryable<T[]> ret = obj.OrderBy(a => a.Length > columnsToSkip ? a[columnsToSkip] : default(T));
            for (int i = columnsToSkip + 1; i < columnsToSkip + columnsToTake; i++)
            {
                var ic = i;
                ret = ret.ThenBy(a => a.Length > ic ? a[ic] : default(T));
            }

            return ret;
        }
        public static IOrderedEnumerable<T[]> OrderByAll<T>(this IEnumerable<IEnumerable<T>> obj, int skip = 0)
        {
            return obj.Select(o => o.ToArray()).OrderByAll(skip);
        }

        public static IOrderedEnumerable<T> OrderByAll<T>(this IEnumerable<T> obj, int skip = 0)
        {
            var allmembers = typeof(T).GetFields().Where(m => typeof(IComparable).IsAssignableFrom(m.FieldType)).ToArray();
            IOrderedEnumerable<T> ret = obj.OrderBy(m => allmembers[skip].GetValue(m));
            for (int i = 1 + skip; i < allmembers.Length - 1; i++)
            {
                var ic = i;
                ret = ret.ThenBy(a => allmembers[ic].GetValue(a));
            }

            return ret;
        }

        public static IOrderedQueryable<dynamic> OrderByAll<T>(this IQueryable<T> src)
        {
            var innertype = src.GetInnerType();
            var m = typeof(StringExtensions).GetMethod("OrderByAllTyped").MakeGenericMethod(innertype);
            return (IOrderedQueryable<dynamic>)m.Invoke(null, new object[] { src, 0 });
        }

        public static IOrderedQueryable<T> OrderByAllTyped<T>(this IQueryable<T> obj, int skip = 0)
        {
            var allmembers = typeof(T).GetProperties().Where(m => m.PropertyType.IsGenericType || typeof(IComparable).IsAssignableFrom(m.PropertyType)).ToArray();

            IOrderedQueryable<T> ret = obj.OrderBy(m => allmembers[skip].GetValue(m));
            for (int i = skip; i < allmembers.Length; i++)
            {
                var ic = i;
                ret = ret.ThenBy(a => allmembers[ic].GetValue(a));
            }

            return ret;
        }

        public static void ReplaceAll<T>(this ObservableCollection<T> src, IEnumerable<T> all)
        {
            src.Clear();

            src.AddAll(all);
        }


        public static ParallelQuery<T> AsParallel<T>(this IEnumerable<T> source, bool useParallelism)
        {
            var ret = source.AsParallel();
            return (useParallelism ? ret : ret.WithDegreeOfParallelism(1));
        }

        public static void AddAll<T>(this IList<T> src, IEnumerable<T> all)
        {
            foreach (var x in all)
            {
                src.Add(x);
            }
        }

        /*public static void ProgressBar(string name, string txt, int max, int val, Thread assocThread, List<Util.ProgressBar> list)
        {
            Util.ProgressBar pb = list.SingleOrDefault(p => p.Caption == name);
            if (pb == null)
            {
                pb = new Util.ProgressBar(name);
                list.Add(pb);
                pb.Dump();
            }

            pb.Fraction = (double)val / (double)max;
        }*/

        public static void ExportAsHTML(this DataGrid grid, string path = null)
        {
            path = ExportAs(grid, path, "HTML File|*.htm", DataFormats.Html);
        }

        private static string ExportAs(DataGrid grid, string path, string p1, string p2)
        {
            grid.CopyToClipboard();

            if (path == null)
            {
                var dial = new SaveFileDialog() { CheckFileExists = false, ValidateNames = true, AddExtension = true, Filter = p1 };
                if (dial.ShowDialog().Value)
                {
                    path = dial.FileName;
                }
            }

            if (path != null)
            {
                var str = new StreamWriter(path);

                str.Write((string)Clipboard.GetData(p2));

                str.Close();

                Clipboard.Clear();
            }
            return path;
        }

        public static void ExportAsXLSX<T>(this IEnumerable<T> src, string[] headers, int keysCount, string worksheetName, Func<T, int, string, ExcelStyle, object> GetValueSetStyle, string path = null, Action<double> callback = null)
        {
            if (path == null)
            {
                var dial = new SaveFileDialog() { CheckFileExists = false, ValidateNames = true, AddExtension = true, Filter = "Excel 2007 File|*.xlsx" };
                if (dial.ShowDialog().Value)
                {
                    path = dial.FileName;
                }
                else
                {
                    return;
                }
            }

            //Dispatcher.CurrentDispatcher.Invoke(() => { }, DispatcherPriority.Render);

            using (var xl = new ExcelPackage(new FileInfo(path)))
            {
                xl.AddWorksheet(src, headers, keysCount, worksheetName, GetValueSetStyle, callback);
                xl.Save();
            }
        }

        public static void ExportAsXLSX(this DataGrid grid, string path = null, string worksheetName = null, Panel host = null, Action<double> callback = null)
        {
            bool canceled = false;
            //try
            {
                if (path == null)
                {
                    var dial = new SaveFileDialog() { CheckFileExists = false, ValidateNames = true, AddExtension = true, Filter = "Excel 2007 File|*.xlsx" };
                    if (dial.ShowDialog().Value)
                    {
                        path = dial.FileName;
                    }
                    else
                    {
                        return;
                    }
                }

                //Dispatcher.CurrentDispatcher.Invoke(() => { }, DispatcherPriority.Render);

                using (var xl = new ExcelPackage(new FileInfo(path)))
                {
                    xl.AddWorksheet(grid, worksheetName, host, callback);
                    xl.Save();
                }
            }
            /*catch
            {
                if (!canceled)
                {
                    throw;
                }
            }*/
        }

        public static void AddWorksheet<T>(this ExcelPackage xl, IEnumerable<T> src, IList<string> headers, int keysCount, string worksheetName, Func<T, int, string, ExcelStyle, object> GetValueSetStyle, Action<double> callback = null)
        {
            var sheet = xl.Workbook.Worksheets[worksheetName ?? "Report"];
            if (sheet != null)
            {
                xl.Workbook.Worksheets.Delete(sheet);
            }

            sheet = xl.Workbook.Worksheets.Add(worksheetName ?? "Report");

            for (int i = 0; i < headers.Count; i++)
            {
                sheet.Cells[1, i + 1].Value = headers[i];
                sheet.Column(i + 1).BestFit = true;
                sheet.Column(i + 1).Style.Font.Bold = (i < keysCount);
            }

            //sheet.Row(1).Style.Font.Bold = true;

            var j = 1;
            var cnt = src.Count();
            foreach (var x in src)
            {
                j++;
                if (callback != null)
                {
                    callback((double)(j - 2) / cnt);
                }

                for (int k = 1; k <= headers.Count; k++)
                {
                    sheet.Cells[j, k].Value = GetValueSetStyle(x, k - 1, headers[k - 1], sheet.Cells[j, k].Style);
                }
            }

            if (callback != null)
            {
                callback(1);
            }
        }


        public static void AddWorksheet(this ExcelPackage xl, DataGrid grid, string worksheetName, Panel host = null, Action<double> callback = null)
        {
            var gridClone = new DataGrid()
            {
                AlternatingRowBackground = grid.AlternatingRowBackground,
                BindingGroup = grid.BindingGroup,
                ItemBindingGroup = grid.ItemBindingGroup,
                Background = grid.Background,
                CellStyle = grid.CellStyle,
                Foreground = grid.Foreground,
                //GroupStyleSelector = grid.GroupStyleSelector,
                HeadersVisibility = grid.HeadersVisibility,
                OverridesDefaultStyle = grid.OverridesDefaultStyle,
                RowBackground = grid.RowBackground,
                RowDetailsTemplate = grid.RowDetailsTemplate,
                RowDetailsTemplateSelector = grid.RowDetailsTemplateSelector,
                RowDetailsVisibilityMode = grid.RowDetailsVisibilityMode,
                RowHeaderStyle = grid.RowHeaderStyle,
                RowHeaderTemplate = grid.RowHeaderTemplate,
                RowHeaderTemplateSelector = grid.RowHeaderTemplateSelector,
                RowStyleSelector = grid.RowStyleSelector,
                RowStyle = grid.RowStyle,
                Style = grid.Style,

                ItemsSource = grid.ItemsSource,

                Visibility = Visibility.Hidden,

                AutoGenerateColumns = grid.AutoGenerateColumns,

                IsReadOnly = true,
                Width = 1,
                Height = 1
                //Margin = new Thickness(-10, 0, 0, 0)
            };

            //gridClone.GroupStyle.AddAll(grid.GroupStyle);
            gridClone.Triggers.AddAll(grid.Triggers);
            gridClone.Columns.AddAll(grid.Columns.Select(c => new DataGridTextColumn { CellStyle = c.CellStyle, Binding = ((DataGridTextColumn)c).Binding, Header = c.Header, HeaderStyle = c.HeaderStyle }));

            VirtualizingPanel.SetVirtualizationMode(grid, VirtualizationMode.Recycling);
            VirtualizingPanel.SetCacheLength(grid, new VirtualizationCacheLength(0, 100));
            VirtualizingPanel.SetCacheLengthUnit(grid, VirtualizationCacheLengthUnit.Item);

            host.Children.Add(gridClone);

            DoEvents();

            var sheet = xl.Workbook.Worksheets[worksheetName ?? "Report"];
            if (sheet != null)
            {
                xl.Workbook.Worksheets.Delete(sheet);
            }

            sheet = xl.Workbook.Worksheets.Add(worksheetName ?? "Report");

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                sheet.Cells[1, i + 1].Value = (string)grid.Columns[i].Header;
                sheet.Column(i + 1).BestFit = true;
                sheet.Column(i + 1).Style.Font.Bold = (((DataGridTextColumn)grid.Columns[i]).FontWeight != FontWeights.Normal);
            }

            //sheet.Row(1).Style.Font.Bold = true;

            var noColor = System.Windows.Media.Color.FromArgb(255, 255, 255, 255);

            for (int j = 2; j < gridClone.Items.Count + 2; j++)
            {
                var row = (DataGridRow)gridClone.ItemContainerGenerator.ContainerFromIndex(j - 2);

                if (row == null)
                {
                    gridClone.ScrollIntoView(gridClone.Items[j - 2]);
                    row = (DataGridRow)gridClone.ItemContainerGenerator.ContainerFromIndex(j - 2);
                }

                if (callback != null)
                {
                    callback(j - 1 / gridClone.Items.Count);
                }

                DoEvents();

                if (row.Background != null && ((SolidColorBrush)row.Background).Color != noColor)
                {
                    sheet.Row(j).Style.Fill.PatternType = ExcelFillStyle.Solid;
                    sheet.Row(j).Style.Fill.BackgroundColor.SetColor(((SolidColorBrush)row.Background).Color.AsDrawingColor());
                }

                if (((SolidColorBrush)row.Foreground).Color != noColor)
                {
                    sheet.Row(j).Style.Font.Color.SetColor(((SolidColorBrush)row.Foreground).Color.AsDrawingColor());
                }

                for (int k = 1; k < gridClone.Columns.Count + 1; k++)
                {
                    var txt = (TextBlock)gridClone.Columns[k - 1].GetCellContent(row);
                    if (txt != null)
                    {
                        sheet.Cells[j, k].Value = txt.Text;

                        var cell = (DataGridCell)txt.Parent;
                        if (((SolidColorBrush)cell.Foreground).Color != noColor)
                        {
                            sheet.Cells[j, k].Style.Font.Color.SetColor(((SolidColorBrush)cell.Foreground).Color.AsDrawingColor());
                        }
                        if (((SolidColorBrush)cell.Background).Color != noColor)
                        {
                            sheet.Cells[j, k].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            sheet.Cells[j, k].Style.Fill.BackgroundColor.SetColor(((SolidColorBrush)cell.Background).Color.AsDrawingColor());
                        }
                    }
                }

                if (callback != null)
                {
                    callback(1);
                    DoEvents();
                }

                // Free up some objects
                //host.Children.Remove(gridClone);
            }
        }

        public static void DoEvents()
        {
            if (Application.Current == null)
                return;
            Application.Current.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);
        }

        public static void CopyToClipboard(this DataGrid grid)
        {
            grid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            grid.SelectAllCells();
            ApplicationCommands.Copy.Execute(null, grid);
            grid.UnselectAllCells();
        }

        public static object AverageChecked<T>(this IEnumerable<T> src, bool ignoreErrors = false)
        {
            try
            {
                var converter = new DoubleConverter();
                var s = src;
                if (ignoreErrors)
                {
                    s = s.Where(c => converter.IsValid(c));
                }
                return src.Average(x => (double)converter.ConvertFrom(x));
            }
            catch
            {
                return "N/A";
            }
        }

        public static TV SafeRetrieve<T, TV>(this Dictionary<T, TV> src, T key) where TV : class
        {
            return src.ContainsKey(key) ? src[key] : null;
        }

        public static byte[] AsByteArray(this System.Windows.Media.Color src)
        {
            return new byte[] { src.R, src.G, src.B };
        }

        public static System.Drawing.Color AsDrawingColor(this System.Windows.Media.Color src)
        {
            return System.Drawing.Color.FromArgb(src.R, src.G, src.B);
        }
    }

}
