using QuAnalyzer.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Wokhan.Data.Providers;
using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.Helpers
{
    public class ProvidersManager : NotifierHelper
    {
        public IEnumerable<DataProviderStruct> Providers => DataProviders.AllProviders;

        public ProvidersManager()
        {
            Directory.EnumerateDirectories(AppDomain.CurrentDomain.BaseDirectory + "\\providers").ToList().ForEach(d => DataProviders.Init(d));
        }

        internal void TriggerUpdate()
        {
            NotifyPropertyChanged(nameof(Providers));
        }

        internal void AddProvider(string zipPath)
        {
            var path = @$"{AppDomain.CurrentDomain.BaseDirectory}\providers\{new FileInfo(zipPath).Name}";

            using (var fileStream = new FileStream(zipPath, FileMode.Open))
            {
                new ZipArchive(fileStream, ZipArchiveMode.Read, false).ExtractToDirectory(path);
                DataProviders.Init(path);
                NotifyPropertyChanged(nameof(Providers));
            }
        }
    }
}
