using Microsoft.Win32;

using OfficeOpenXml;
using OfficeOpenXml.Style;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.UI.Extensions;

namespace QuAnalyzer.Generic.Extensions
{
    public static class ExcelPackageExtensions
    {

        public static void AddWorksheet<T>(this ExcelPackage xl, IEnumerable<T> src, IList<string> headers, int keysCount, string worksheetName, Func<T, int, string, ExcelStyle, object> GetValueSetStyle, Action<double> callback = null)
        {
            var sheet = xl.Workbook.Worksheets[worksheetName ?? "Report"];
            if (sheet is not null)
            {
                xl.Workbook.Worksheets.Delete(sheet);
            }

            sheet = xl.Workbook.Worksheets.Add(worksheetName ?? "Report");

            for (var i = 0; i < headers.Count; i++)
            {
                sheet.Cells[1, i + 1].Value = headers[i];
                sheet.Column(i + 1).BestFit = true;
                sheet.Column(i + 1).Style.Font.Bold = i < keysCount;
            }

            //sheet.Row(1).Style.Font.Bold = true;

            var j = 1;
            var cnt = src.Count();
            foreach (var x in src)
            {
                j++;
                callback?.Invoke((double)(j - 2) / cnt);

                for (var k = 1; k <= headers.Count; k++)
                {
                    sheet.Cells[j, k].Value = GetValueSetStyle(x, k - 1, headers[k - 1], sheet.Cells[j, k].Style);
                }
            }

            callback?.Invoke(1);
        }


        private static readonly Color NO_COLOR = Color.FromArgb(255, 255, 255, 255);

        public static bool AddWorksheetFromDataGrid(this ExcelPackage xl, DataGrid grid, string worksheetName, Panel host = null, Action<double> callback = null, System.Threading.CancellationTokenSource cancellationToken = null)
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

            try
            {

                DoEvents();

                host.Children.Remove(gridClone);
                //host.UpdateLayout();
                DoEvents();

                var sheet = xl.Workbook.Worksheets[worksheetName ?? "Report"];
                if (sheet is not null)
                {
                    xl.Workbook.Worksheets.Delete(sheet);
                }

                sheet = xl.Workbook.Worksheets.Add(worksheetName ?? "Report");

                for (var i = 0; i < grid.Columns.Count; i++)
                {
                    sheet.Cells[1, i + 1].Value = (string)grid.Columns[i].Header;
                    sheet.Column(i + 1).BestFit = true;
                    sheet.Column(i + 1).Style.Font.Bold = ((DataGridTextColumn)grid.Columns[i]).FontWeight != FontWeights.Normal;
                }

                //sheet.Row(1).Style.Font.Bold = true;

                for (var j = 2; j < gridClone.Items.Count + 2; j++)
                {
                    cancellationToken.Token.ThrowIfCancellationRequested();

                    var row = (DataGridRow)gridClone.ItemContainerGenerator.ContainerFromIndex(j - 2);

                    if (row is null)
                    {
                        gridClone.ScrollIntoView(gridClone.Items[j - 2]);
                        row = (DataGridRow)gridClone.ItemContainerGenerator.ContainerFromIndex(j - 2);
                    }

                    callback?.Invoke((j - 1.0) / gridClone.Items.Count);

                    DoEvents();

                    if (row.Background is not null && ((SolidColorBrush)row.Background).Color != NO_COLOR)
                    {
                        sheet.Row(j).Style.Fill.PatternType = ExcelFillStyle.Solid;
                        sheet.Row(j).Style.Fill.BackgroundColor.SetColor(((SolidColorBrush)row.Background).Color.AsDrawingColor());
                    }

                    if (((SolidColorBrush)row.Foreground).Color != NO_COLOR)
                    {
                        sheet.Row(j).Style.Font.Color.SetColor(((SolidColorBrush)row.Foreground).Color.AsDrawingColor());
                    }

                    for (var k = 1; k < gridClone.Columns.Count + 1; k++)
                    {
                        var txt = (TextBlock)gridClone.Columns[k - 1].GetCellContent(row);
                        if (txt is not null)
                        {
                            sheet.Cells[j, k].Value = txt.Text;

                            var cell = (DataGridCell)txt.Parent;
                            if (((SolidColorBrush)cell.Foreground).Color != NO_COLOR)
                            {
                                sheet.Cells[j, k].Style.Font.Color.SetColor(((SolidColorBrush)cell.Foreground).Color.AsDrawingColor());
                            }
                            if (((SolidColorBrush)cell.Background).Color != NO_COLOR)
                            {
                                sheet.Cells[j, k].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                sheet.Cells[j, k].Style.Fill.BackgroundColor.SetColor(((SolidColorBrush)cell.Background).Color.AsDrawingColor());
                            }
                        }
                    }

                }

                callback?.Invoke(1);
            }
            catch { }
            finally
            {
                host.Children.Remove(gridClone);
            }

            return false;
        }

        public static void ExportAsXLSX<T>(this IEnumerable<T> src, string[] headers, int keysCount, string worksheetName, Func<T, int, string, ExcelStyle, object> GetValueSetStyle, string path = null, Action<double> callback = null)
        {
            if (path is null)
            {
                var dial = new SaveFileDialog() { CheckFileExists = false, ValidateNames = true, AddExtension = true, Filter = "Excel 2007 File|*.xlsx" };
                if (dial.ShowDialog() is true)
                {
                    path = dial.FileName;
                }
                else
                {
                    return;
                }
            }

            using var xl = new ExcelPackage(new FileInfo(path));
            xl.AddWorksheet(src, headers, keysCount, worksheetName, GetValueSetStyle, callback);
            xl.Save();
        }

        public static void DoEvents()
        {
            Application.Current?.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);
        }

    }
}
