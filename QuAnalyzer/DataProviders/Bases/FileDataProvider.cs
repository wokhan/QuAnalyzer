using Microsoft.Win32;
using QuAnalyzer.DataProviders.Attributes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuAnalyzer.DataProviders.Bases
{
    public class FileDataProvider : DataProvider
    {
        protected Encoding _encoding = UTF8Encoding.UTF8;
        [ProviderParameter("Encoding", false, typeof(FileDataProvider), "GetEncoding")]
        public string Encoding
        {
            get { return _encoding.WebName.ToString(); }
            set { _encoding = UTF8Encoding.GetEncoding(value); }
        }

        public string FileFilter
        {
            get { return "All files|*.*"; }
            set { }
        }

        public new string[] RepositoriesColumnNames
        {
            get { return new[] { "Identifier", "Full path" }; }
            set { }
        }
        public new Dictionary<string, object> GetDefaultRepositories()
        {
            // Change for an interface implementing Filter
            var filepicker = new OpenFileDialog() { Filter = ((dynamic)this).FileFilter, Multiselect = true };
            if (filepicker.ShowDialog().Value)
            {
                return filepicker.FileNames.ToDictionary(f => f, f => (object)f);
            }
            else
            {
                return null;
            }
        }

        public static Dictionary<string, string> GetEncoding()
        {
            return new Dictionary<string, string> {
                { System.Text.Encoding.UTF8.WebName, System.Text.Encoding.UTF8.EncodingName },
                { System.Text.Encoding.ASCII.WebName, System.Text.Encoding.ASCII.EncodingName },
                { System.Text.Encoding.BigEndianUnicode.WebName, System.Text.Encoding.BigEndianUnicode.EncodingName },
                { System.Text.Encoding.Unicode.WebName, System.Text.Encoding.Unicode.EncodingName },
                { System.Text.Encoding.Default.WebName, System.Text.Encoding.Default.EncodingName }
            };
        }

        public new bool Test(out string details)
        {
            details = "OK";
            return true;
        }
    }
}
