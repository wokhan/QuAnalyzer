﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Wokhan.Core.ComponentModel;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Features.Comparison
{
    public partial class SourcesMapper : NotifierHelper
    {

        public string Name { get; set; }

        [JsonIgnore]
        public IDataProvider Source
        {
            get { return ((App)App.Current).CurrentProject.CurrentProviders.SingleOrDefault(c => c.Name == SourceName); }
            set { SourceName = value != null ? value.Name : String.Empty; }
        }

        public string SourceName { get; set; }

        public string SourceRepository { get; set; }

        [JsonIgnore]
        public IDataProvider Target
        {
            get { return ((App)App.Current).CurrentProject.CurrentProviders.SingleOrDefault(c => c.Name == TargetName); }
            set { TargetName = value != null ? value.Name : String.Empty; }
        }

        public string TargetName { get; set; }

        public string TargetRepository { get; set; }

        public List<SimpleMap> AllMappings { get; set; } = new List<SimpleMap>();

        private bool _isOrdered = false;
        public bool IsOrdered
        {
            get { return _isOrdered; }
            set { _isOrdered = value; NotifyPropertyChanged(); }
        }

        public SourcesMapper()
        {
        }
    }
}