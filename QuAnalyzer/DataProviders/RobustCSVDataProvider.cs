using Microsoft.VisualBasic.FileIO;
using QuAnalyzer.DataProviders.Attributes;
using QuAnalyzer.DataProviders.Bases;
using QuAnalyzer.DataProviders.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using LINQtoCSV;
using System.IO;
using System.Collections;

namespace QuAnalyzer.DataProviders
{
    [DataProvider(Category = "Files", Name = "CSV", Icon = "ICON_CSVDATAPROVIDER")]
    public class Linq2CSVDataProvider : FileDataProvider, IDataProvider, IExposedDataProvider
    {
        private char? _delimiter = ';';
        [ProviderParameter("Delimiter")]
        public string Delimiter
        {
            get { return _delimiter.ToString(); }
            set { _delimiter = String.IsNullOrEmpty(value) ? (char?)null : value[0]; }
        }

        private bool _usequotes = true;
        [ProviderParameter("Use quotes to enclose fields")]
        public bool UseQuotes
        {
            get { return _usequotes; }
            set { _usequotes = value; }
        }

        private bool _hasheader = true;
        [ProviderParameter("Source file contains header")]
        public bool Hasheader
        {
            get { return _hasheader; }
            set { _hasheader = value; }
        }

        public new string FileFilter
        {
            get { return "CSV files|*.csv"; }
            set { }
        }

        public Linq2CSVDataProvider() : base() { }

        public static new string GetFormatKey(List<object> srcAttributesCollection, object srcAttribute)
        {
            return srcAttributesCollection.IndexOf(srcAttribute).ToString();
        }


        public new Dictionary<string, Type> GetHeaders(string repository = null)
        {
            Dictionary<string, Type> ret;
            var ctx = new LINQtoCSV.CsvContext();
            ctx.Read<object[]>((string)Repositories[repository], new CsvFileDescription() { UseFieldIndexForReadingData = true, FirstLineHasColumnNames = this._hasheader, QuoteAllFields = this._usequotes, TextEncoding = this._encoding, SeparatorChar = this._delimiter.HasValue ? this._delimiter.Value : ' ', NoSeparatorChar = !this._delimiter.HasValue });

            var csvl = new Net.Code.Csv.CsvLayout(_textqualifier, _delimiter, _escape, _commentchar, _hasheader);
            
            var r = CsvExtensions.ReadStringAsCsv(File.ReadLines(, this._encoding).First(), csvl, null, null);

            try
            {
                if (this._hasheader)
                {
                    object[] buffer = new object[r.FieldCount];
                    r.GetValues(buffer);

                    ret = buffer.ToDictionary(s => (string)s, s => typeof(string));
                }
                else
                {
                    ret = Enumerable.Range(0, r.FieldCount).ToDictionary(i => i.ToString(), i => typeof(string));
                }

                return ret;
            }
            finally
            {
                if (!r.IsClosed)
                {
                    r.Close();
                }
            }
        }

        public new IEnumerable<object[]> GetData(string repository = null, IEnumerable<string> attributes = null)
        {
            var csvl = new Net.Code.Csv.CsvLayout(_textqualifier, _delimiter, _escape, _commentchar, _hasheader);

            var r = CsvExtensions.ReadFileAsCsv((string)Repositories[repository], this._encoding, csvl, null, null);

            try
            {
                if (this.Hasheader)
                {
                    r.Read();
                }

                if (attributes != null && attributes.Any())
                {
                    var headers = this.GetHeaders(repository);
                    var idx = headers.Select((g, i) => new { g.Key, i }).ToDictionary(gg => gg.Key, gg => gg.i);

                    while (r.Read())
                    {
                        object[] buffer = new object[r.FieldCount];
                        r.GetValues(buffer);
                        yield return attributes.Select(a => buffer[idx[a]]).ToArray();
                    }
                }
                else
                {
                    while (r.Read())
                    {
                        object[] buffer = new object[r.FieldCount];
                        r.GetValues(buffer);
                        yield return buffer;
                    }
                }
            }
            finally
            {
                if (!r.IsClosed)
                {
                    r.Close();
                }
            }
        }
    }
}
