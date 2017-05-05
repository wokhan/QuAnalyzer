using Excel;
using QuAnalyzer.DataProviders.Attributes;
using QuAnalyzer.DataProviders.Bases;
using QuAnalyzer.DataProviders.Contracts;
using QuAnalyzer.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace QuAnalyzer.DataProviders
{
    [DataProvider(Category = "Files", Name = "Excel Workbook", Copyright = "Developed by Wokhan Solutions", Icon = "pack://application:,,,/ExcelDataProvider;component/Resources/Excel.png")]
    public class ExcelDataProvider : DataProvider, IDataProvider, IExposedDataProvider
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

        public ExcelDataProvider() : base() { }

        public new void RemoveCachedHeaders(string repository)
        {
            if (cachedHeaders.ContainsKey(repository))
            {
                cachedHeaders.Remove(repository);
            }
        }

        private Dictionary<string, Dictionary<string, Type>> cachedHeaders = new Dictionary<string, Dictionary<string, Type>>();
        public new Dictionary<string, Type> GetHeaders(string repository = null)
        {
            if (!cachedHeaders.ContainsKey(repository))
            {
                var rep = (string)GetDefaultRepositories()[repository];

                using (var reader = getReader())
                {
                    while (reader.Name != rep)
                    {
                        reader.NextResult();
                    }

                    cachedHeaders.Add(repository, reader.AsDataSet().Tables[rep].Columns.Cast<DataColumn>()
                                                          .ToDictionary(c => c.ColumnName, c => c.DataType));
                }
            }

            return cachedHeaders[repository];
        }

        public new Dictionary<string, object> GetDefaultRepositories()
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();
            using (var reader = getReader())
            {
                var res = reader.ResultsCount;
                for (int i = 0; i < res; i++)
                {
                    ret.Add(reader.Name + "[#" + (i + 1) + "]", reader.Name);
                }
            }

            return ret;
        }


        //public new IEnumerable GetDataDirect(string repository = null, IEnumerable<string> attributes = null)
        //{
        //    using (var reader = getReader())
        //    {
        //        if (attributes != null)
        //        {
        //            return reader.AsDataSet().Tables[repository].AsEnumerable().Select(r => attributes.Select(a => r[a]));
        //        }
        //        else
        //        {
        //            return reader.AsDataSet().Tables[repository].AsEnumerable().Select(r => r.ItemArray);
        //        }
        //    }
        //}

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

        private IExcelDataReader getReader()
        {
            IExcelDataReader ret;
            if (File.EndsWith("xlsx"))
            {
                ret = ExcelReaderFactory.CreateOpenXmlReader(new FileStream(File, FileMode.Open, FileAccess.Read));
            }
            else
            {
                ret = ExcelReaderFactory.CreateBinaryReader(new FileStream(File, FileMode.Open, FileAccess.Read));
            }

            ret.IsFirstRowAsColumnNames = HasHeader;

            return ret;
        }

        public new IQueryable<T> GetTypedData<T, TK>(string repository, IEnumerable<string> attributes) where T : class
        {
            return _getdata<T>(repository, attributes.ToArray()).AsQueryable();
        }

        private IEnumerable<T> _getdata<T>(string repository, string[] attributes)
        {
            var attrlst = GetHeaders(repository).Keys.ToList();
            var rep = (string)GetDefaultRepositories()[repository];

            using (var reader = getReader())
            {
                while (reader.Name != rep)
                {
                    reader.NextResult();
                }

                if (attributes != null)
                {
                    var attrIdx = attributes.Select(a => attrlst.IndexOf(a)).ToArray();
                    while (reader.Read())
                    {
                        yield return attrIdx.Select(i => reader.GetValue(i)).ToArray().ToObject<T>(attributes);
                    }
                }
                else
                {
                    while (reader.Read())
                    {
                        yield return Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetValue(i)).ToArray().ToObject<T>(attrlst.ToArray());
                    }
                }
            }
        }


        //public virtual DbSet<T> CATALOG { get; set; }
    }
}

