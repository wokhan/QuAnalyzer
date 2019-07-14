using QuAnalyzer.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Helpers
{
    public class SourcesMapper : NotifierHelper
    {
        public class SimpleMap
        {
            public string Source { get; set; }
            public string Target { get; set; }

            public bool IsKey { get; set; }

            public SimpleMap()
            {
                Source = String.Empty;
                Target = String.Empty;
            }

            public SimpleMap(string s, string t)
            {
                this.Source = s;
                this.Target = t;
            }


        }

        public string Name { get; set; }

        [IgnoreDataMember()]
        public IDataProvider Source
        {
            get { return ((App)App.Current).CurrentProject.CurrentProviders.SingleOrDefault(c => c.Name == SourceName); }
            set { SourceName = value != null ? value.Name : String.Empty; }
        }

        public string SourceName { get; set; }

        public string SourceRepository { get; set; }

        [IgnoreDataMember()]
        public IDataProvider Target
        {
            get { return ((App)App.Current).CurrentProject.CurrentProviders.SingleOrDefault(c => c.Name == TargetName); }
            set { TargetName = value != null ? value.Name : String.Empty; }
        }

        public string TargetName { get; set; }

        public string TargetRepository { get; set; }

        public List<SimpleMap> AllMappings;

        private bool _isOrdered = false;
        public bool IsOrdered
        {
            get { return _isOrdered; }
            set { _isOrdered = value; NotifyPropertyChanged("IsOrdered"); }
        }

        public SourcesMapper()
        {
        }
    }
}
