using Microsoft.VisualBasic.FileIO;
using QuAnalyzer.DataProviders.Attributes;
using QuAnalyzer.DataProviders.Bases;
using QuAnalyzer.DataProviders.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using QuAnalyzer.Extensions;
using System.Text.RegularExpressions;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace QuAnalyzer.DataProviders
{
    [DataProvider(Category = "Files", Name = "Excel Workbook (NPOI)", Description = "Allows to load data from XLS or XLSX worksheets.", Copyright = "Developed by Wokhan Solutions", Icon = "/Resources/Providers/Excel.png")]
    public class NPOIXLSDataProvider : DataProvider, IDataProvider, IExposedDataProvider
    {
        [ProviderParameter("File", IsFile = true, FileFilter = "Excel workbook|*.xls;*.xlsx")]
        public string File
        {
            get;
            set;
        }

        [ProviderParameter("Use headers")]
        public bool HasHeader
        {
            get;
            set;
        }

        public NPOIXLSDataProvider() : base() { }

        public new void RemoveCachedHeaders(string repository)
        {
            if (cachedHeaders.ContainsKey(repository))
            {
                cachedHeaders.Remove(repository);
            }
        }

        private static object GetTypedValue(ICell c)
        {
            var targetType = c.CellType;
            if (targetType == CellType.Formula)
            {
                targetType = c.CachedFormulaResultType;
            }

            switch (targetType)
            {
                case CellType.Blank:
                case CellType.Error:
                    return null;

                case CellType.Boolean:
                    return c.BooleanCellValue;

                case CellType.Numeric:
                    if (HSSFDateUtil.IsCellDateFormatted(c))
                    {
                        return c.DateCellValue;
                    }
                    return c.NumericCellValue;

                case CellType.String:
                case CellType.Unknown:
                default:
                    return c.StringCellValue;
            }
        }

        private Dictionary<string, Dictionary<string, Type>> cachedHeaders = new Dictionary<string, Dictionary<string, Type>>();
        public new Dictionary<string, Type> GetHeaders(string repository = null)
        {
            if (!cachedHeaders.ContainsKey(repository))
            {
                Dictionary<string, Type> ret = new Dictionary<string, System.Type>();
            
                var rep = (string)GetDefaultRepositories()[repository];

                var wb = WorkbookFactory.Create(File);
                var sheet = wb.GetSheet(rep);
                var headerrow = sheet.GetRow(0);

                if (HasHeader)
                {
                    ret = headerrow.Cells.ToDictionary(c => c.StringCellValue, c => typeof(object));
                }
                else
                {
                    ret = headerrow.Cells.Select((c, i) => new { c, i })
                                         .ToDictionary(x => "Column" + (x.i + 1), x => typeof(object));
                }

                cachedHeaders.Add(repository, ret);
            }
            
            return cachedHeaders[repository];
        }

        private Dictionary<string, object> _defaultRepositories;
        public new Dictionary<string, object> GetDefaultRepositories()
        {
            if (_defaultRepositories == null)
            {
                _defaultRepositories = new Dictionary<string, object>();
                var wb = WorkbookFactory.Create(File);

                for (int i = 0; i < wb.NumberOfSheets; i++)
                {
                    var sheet = wb.GetSheetName(i);
                    _defaultRepositories.Add(sheet.Replace(" ", "_"), sheet);
                }
            }

            return _defaultRepositories;
        }


        public new bool IsDirectlyBindable
        {
            get { return true; }
        }

        public new bool Test(out string details)
        {
            if (!System.IO.File.Exists(File))
            {
                details = "File is not accessible.";
                return false;
            }

            details = "OK";
            return true;
        }

        public new IQueryable<T> GetTypedData<T, TK>(string repository, IEnumerable<string> attributes) where T : class
        {
            return _getdata<T>(repository, attributes.ToArray()).AsQueryable();
        }

        private IEnumerable<T> _getdata<T>(string repository, string[] attributes)
        {
            var attrlst = GetHeaders(repository).Keys.ToList();
            var rep = (string)GetDefaultRepositories()[repository];

            var wb = WorkbookFactory.Create(File);
            var sheet = wb.GetSheet(rep);

            var en = sheet.GetRowEnumerator();
            if (HasHeader)
            {
                en.MoveNext();
            }

            if (attributes != null)
            {
                var attrIdx = attributes.Select(a => attrlst.IndexOf(a)).ToArray();
                while (en.MoveNext())
                {
                    var cast = (IRow)en.Current;
                    yield return attrIdx.Select(i => GetTypedValue(cast.Cells[i])).ToArray().ToObject<T>(attributes);
                }
            }
            else
            {
                while (en.MoveNext())
                {
                    var cast = (IRow)en.Current;
                    yield return cast.Cells.Select(GetTypedValue).ToArray().ToObject<T>(attrlst.ToArray());
                }
            }
        }


        //public virtual DbSet<T> CATALOG { get; set; }
    }

}
