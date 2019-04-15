﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Wokhan.Data.Providers.Attributes;
using Wokhan.Data.Providers.Bases;
using Wokhan.Data.Providers.Contracts;

namespace Wokhan.Data.Providers
{
    [DataContract]
    [DataProvider(Category = "Files", Name = "File Collection", Copyright = "Developed by Wokhan Solutions")]
    class FileCollectionProvider : DataProvider, IDataProvider//, IExposedDataProvider
    {
        [ProviderParameter("Files")]
        public List<string> files = new List<string>();

        private static string[] columns = new[] { "FullName", "Name", "CreationTime", "WriteTime", "Length" };

        public new string GetFormatKey(List<object> srcAttributesCollection, object srcAttribute)
        {
            return null;
        }

        public new Dictionary<string, Type> GetHeaders(string repository = null)
        {
            return columns.ToDictionary(c => c, c => typeof(string));
        }

       
        public new IQueryable<dynamic> GetData(string repository = null, IEnumerable<string> attributes = null)
        {
            return files.Select(f => new FileInfo(f))
                        .Select(fi => new[] { fi.FullName, fi.Name, GetFormattedValue(fi.CreationTimeUtc, "CreationTime"), GetFormattedValue(fi.LastWriteTimeUtc, "WriteTime"), GetFormattedValue(fi.Length, "Length") })
                        .AsQueryable();
        }
    }
}
