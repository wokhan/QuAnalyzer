using CommunityToolkit.WinUI.UI.Controls;

using OfficeOpenXml;

using System.Threading;

using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.Pickers;

using WinRT.Interop;

namespace QuAnalyzer.Generic.Extensions;

public static class DataGridExtensions
{
    public async static void ExportAsHTML(this DataGrid grid, string path = null)
    {
        path = await ExportAs(grid, path, "HTML File|*.htm", "Html");
    }

    private async static Task<string> ExportAs(DataGrid grid, string path, string p1, string p2)
    {
        grid.CopyToClipboard();

        if (path is null)
        {
            var filePicker = new FileSavePicker();

#if WINDOWS
            var hwnd = WindowNative.GetWindowHandle(App.Instance.MainWindow);
            InitializeWithWindow.Initialize(filePicker, hwnd);
#endif

            filePicker.FileTypeChoices.Add(p1, new[] { p1 });

            var file = await filePicker.PickSaveFileAsync();
            if (file is not null)
            {
                path = file.Path;
            }
        }

        if (path is not null)
        {
            var str = new StreamWriter(path);

            str.Write(await Clipboard.GetContent().GetTextAsync());

            str.Close();

            Clipboard.Clear();
        }
        return path;
    }

    /*public static void ExportAsXLSX<T>(this IEnumerable<T> src, string[] headers, int keysCount, string worksheetName, Func<T, int, string, ExcelStyle, object> GetValueSetStyle, string path = null, Action<double> callback = null)
    {
        if (path is null)
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

    public static async void ExportAsXLSX(this DataGrid grid, string path = null, string worksheetName = null, Panel host = null, IProgress<double> progress = null, CancellationTokenSource cancellationToken = null)
    {
        //var canceled = false;
        //try
        {
            if (path is null)
            {
                var filePicker = new FileSavePicker();

#if WINDOWS
                var hwnd = WindowNative.GetWindowHandle(App.Instance.MainWindow);
                InitializeWithWindow.Initialize(filePicker, hwnd);
#endif

                filePicker.FileTypeChoices.Add("Excel 2007", new[] { ".xlsx" });

                var file = await filePicker.PickSaveFileAsync();
                if (file is not null)
                {
                    path = file.Path;
                }
                else
                {
                    return;
                }
            }

            //Dispatcher.CurrentDispatcher.Invoke(() => { }, DispatcherPriority.Render);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var xl = new ExcelPackage(new FileInfo(path)))
            {
                if (xl.AddWorksheetFromDataGrid(grid, worksheetName, host, progress, cancellationToken))
                {
                    xl.Save();
                }
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
        //grid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
        //grid.SelectAllCells();
        //ApplicationCommands.Copy.Execute(null, grid);
        //grid.UnselectAllCells();
    }
}
