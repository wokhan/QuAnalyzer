using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuAnalyzer.Generic.Extensions
{
    public static class DataGridExtensions
    {
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

        /*public static void ExportAsXLSX<T>(this IEnumerable<T> src, string[] headers, int keysCount, string worksheetName, Func<T, int, string, ExcelStyle, object> GetValueSetStyle, string path = null, Action<double> callback = null)
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
        }*/

        public static void ExportAsXLSX(this DataGrid grid, string path = null, string worksheetName = null, Panel host = null, Action<double> callback = null)
        {
#pragma warning disable CS0219 // La variable 'canceled' est assignée, mais sa valeur n'est jamais utilisée
            var canceled = false;
#pragma warning restore CS0219 // La variable 'canceled' est assignée, mais sa valeur n'est jamais utilisée
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

        public static void CopyToClipboard(this DataGrid grid)
        {
            grid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            grid.SelectAllCells();
            ApplicationCommands.Copy.Execute(null, grid);
            grid.UnselectAllCells();
        }

    }

}
