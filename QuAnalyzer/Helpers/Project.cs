using Microsoft.Win32;
using Newtonsoft.Json;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Monitoring;
using QuAnalyzer.Features.Performance;
using QuAnalyzer.Generic;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media;
using Wokhan.Collections.Extensions;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Helpers
{
    public class Project : NotifierHelper
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(); }
        }

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; NotifyPropertyChanged(); }
        }

        private bool _useParallelism = true;
        public bool UseParallelism
        {
            get { return _useParallelism; }
            set { _useParallelism = value; NotifyPropertyChanged(); }
        }

        public byte[] AccentColorBrushSaved
        {
            get { return new byte[] { AccentColor.Color.A, AccentColor.Color.R, AccentColor.Color.G, AccentColor.Color.B }; }
            set { AccentColor = new SolidColorBrush(Color.FromArgb(value[0], value[1], value[2], value[3])); }
        }

        [JsonIgnore]
        public SolidColorBrush AccentColor
        {
            get { return (SolidColorBrush)App.Current.Resources["AccentColorBrush"]; }
            set { App.Current.Resources["AccentColorBrush"] = value; }
        }

        public ObservableCollection<IDataProvider> CurrentProviders { get; } = new ObservableCollection<IDataProvider>();

        public ObservableCollection<MonitorItem> MonitorItems { get; } = new ObservableCollection<MonitorItem>();
        public ObservableCollection<SourcesMapper> SourceMapper { get; } = new ObservableCollection<SourcesMapper>();
        public ObservableCollection<TestCasesCollection> PerformanceItems { get; } = new ObservableCollection<TestCasesCollection>();

        internal void Open(string p)
        {
            var ser = new JsonSerializer();
            ser.TypeNameHandling = TypeNameHandling.Auto;

            using var stream = new JsonTextReader(new StreamReader(p));

            var restProject = ser.Deserialize<Project>(stream);

            this.Name = restProject.Name;
            this.CurrentProviders.ReplaceAll(restProject.CurrentProviders);
            this.SourceMapper.ReplaceAll(restProject.SourceMapper);
            this.MonitorItems.ReplaceAll(restProject.MonitorItems);

            this.FilePath = p;

            MRUManager.AddRecentFile(this.FilePath);
        }

        internal void Save(string p = null)
        {
            if (string.IsNullOrEmpty(FilePath) && string.IsNullOrEmpty(p))
            {
                this.SaveAs();
                return;
            }

            var ser = new JsonSerializer();
            ser.TypeNameHandling = TypeNameHandling.Auto;

            if (p != null)
            {
                this.FilePath = p;
            }

            using var str = new JsonTextWriter(new StreamWriter(this.FilePath, false));

            ser.Serialize(str, this);
        }

        internal void CreateNew()
        {
            FilePath = String.Empty;
            Name = String.Empty;

            CurrentProviders.Clear();
            SourceMapper.Clear();

            GC.Collect();
        }

        internal void SaveAs()
        {
            var dial = new SaveFileDialog() { CheckFileExists = false, ValidateNames = true, AddExtension = true, Filter = "QuAnalyzer project file|*.qap" };
            if (dial.ShowDialog().Value)
            {
                this.Save(dial.FileName);
            }
        }
    }
}