using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Core.ComponentModel;
using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.Features.Statistics
{
    public class StatisticsHolder : NotifierHelper
    {
        public IQueryable Source { get; set; }
        public string Name { get; set; }
        public ObservableCollection<OccurencesResult> Occurences { get; } = new ObservableCollection<OccurencesResult>();

        private StatsResult _statistics;
        public StatsResult Statistics
        {
            get { return _statistics; }
            internal set { _statistics = value; NotifyPropertyChanged(); }
        }

        private void UpdateStats(string attribute)
        {
            Statistics = StatsResult.GetStats(Source, attribute);
        }

        private async void UpdateOccurences(ColumnDescription column, Dispatcher dispatcher)
        {
            var occurences = OccurencesResult.CountOccurences(Source, column);
            await dispatcher.InvokeAsync(() => Occurences.AddAll(occurences));
        }

        internal void Update(ColumnDescription h, Dispatcher dispatcher)
        {
            UpdateStats(h.Name);
            UpdateOccurences(h, dispatcher);
        }
    }
}
