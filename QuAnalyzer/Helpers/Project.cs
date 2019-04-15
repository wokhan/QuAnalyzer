using Microsoft.Win32;
using Wokhan.Data.Providers.Bases;
using Wokhan.Data.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Media;

namespace QuAnalyzer.Helpers
{

    public class Project : NotifierHelper
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
        }

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; NotifyPropertyChanged("FilePath"); }
        }

        private bool _useParallelism = true;
        public bool UseParallelism
        {
            get { return _useParallelism; }
            set { _useParallelism = value; NotifyPropertyChanged("UseParallelism"); }
        }

        public byte[] AccentColorBrushSaved
        {
            get { return new byte[] { AccentColor.Color.A, AccentColor.Color.R, AccentColor.Color.G, AccentColor.Color.B }; }
            set { AccentColor = new SolidColorBrush(Color.FromArgb(value[0], value[1], value[2], value[3])); }
        }

        [IgnoreDataMember]
        public SolidColorBrush AccentColor
        {
            get { return (SolidColorBrush)App.Current.Resources["AccentColorBrush"]; }
            set { App.Current.Resources["AccentColorBrush"] = value; }
        }

        private readonly ObservableCollection<IDataProvider> _currentProviders = new ObservableCollection<IDataProvider>();
        public ObservableCollection<IDataProvider> CurrentProviders { get { return _currentProviders; } }

        private readonly ObservableCollection<MonitorItem> _monitorItems = new ObservableCollection<MonitorItem>();
        public ObservableCollection<MonitorItem> MonitorItems { get { return _monitorItems; } }

        private readonly ObservableCollection<SourcesMapper> _sourcemapper = new ObservableCollection<SourcesMapper>();
        public ObservableCollection<SourcesMapper> SourceMapper { get { return _sourcemapper; } }

        internal void Open(string p)
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(Project), DataProvider.AllProviders.Select(a => a.Type).Concat(new[] { typeof(Dictionary<string, object>), typeof(IDataProvider), typeof(DataProvider), typeof(DBDataProvider), typeof(FileDataProvider), typeof(ObservableCollection<IDataProvider>), typeof(SourcesMapper), typeof(MonitorItem) }));
            FileStream stream = null;
            try
            {
                stream = new FileStream(p, FileMode.Open, FileAccess.Read);
                
                var restProject = (Project)ser.ReadObject(stream);

                this.Name = restProject.Name;

                this.CurrentProviders.Clear();
                foreach (var prv in restProject.CurrentProviders)
                {
                    this.CurrentProviders.Add(prv);
                }

                this.SourceMapper.Clear();
                foreach (var sm in restProject.SourceMapper)
                {
                    this.SourceMapper.Add(sm);
                }

                this.MonitorItems.Clear();
                foreach (var mi in restProject.MonitorItems)
                {
                    this.MonitorItems.Add(mi);
                }

                this.FilePath = p;

                MRUManager.AddRecentFile(this.FilePath);

            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        internal void Save(string p = null)
        {
            if (String.IsNullOrEmpty(this.FilePath) && String.IsNullOrEmpty(p))
            {
                this.SaveAs();
                return;
            }

            DataContractSerializer ser = new DataContractSerializer(typeof(Project), DataProvider.AllProviders.Select(a => a.Type).Concat(new[] { typeof(Dictionary<string, object>), typeof(IDataProvider), typeof(DataProvider), typeof(DBDataProvider), typeof(FileDataProvider), typeof(ObservableCollection<IDataProvider>), typeof(SourcesMapper), typeof(MonitorItem) }));
            
            if (p != null)
            {
                this.FilePath = p;
            }

            var str = new FileStream(this.FilePath, FileMode.Create, FileAccess.Write);

            ser.WriteObject(str, this);

            str.Close();
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