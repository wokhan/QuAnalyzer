using QuAnalyzer.Features.Comparison;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Wokhan.Collections.Generic.Extensions;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Controls
{
    /// <summary>
    /// Logique d'interaction pour MappingsEdit.xaml
    /// </summary>
    public partial class MappingsEdit : UserControl
    {
        public string MappingName
        {
            get => (string)GetValue(MappingNameProperty);
            set => SetValue(MappingNameProperty, value);
        }

        public static DependencyProperty MappingNameProperty = DependencyProperty.Register(nameof(MappingName), typeof(string), typeof(MappingsEdit), new PropertyMetadata(null));

        public SourcesMapper Mapping
        {
            get => (SourcesMapper)GetValue(MappingProperty);
            set => SetValue(MappingProperty, value);
        }

        public static DependencyProperty MappingProperty = DependencyProperty.Register(nameof(Mapping), typeof(SourcesMapper), typeof(MappingsEdit), new PropertyMetadata(mappingPropertyChanged));

        private static void mappingPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MappingsEdit)d).UpdateMapping();
        }

        private void UpdateMapping()
        {
            CurrentMaps.ReplaceAll(Mapping.AllMappings);
            CurrentMaps.CollectionChanged += CurrentMaps_CollectionChanged;
        }

        private void CurrentMaps_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Mapping.AllMappings = CurrentMaps.ToList();
        }

        public ObservableCollection<SimpleMap> CurrentMaps { get; private set; } = new ObservableCollection<SimpleMap>();

        public ObservableCollection<string> SourceAttributes { get; } = new ObservableCollection<string>();

        public ObservableCollection<string> TargetAttributes { get; } = new ObservableCollection<string>();

        public MappingsEdit()
        {
            InitializeComponent();

            ((DataGridComboBoxColumn)gridMappings.Columns[0]).ItemsSource = SourceAttributes;
            ((DataGridComboBoxColumn)gridMappings.Columns[1]).ItemsSource = TargetAttributes;
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e) => CurrentMaps.Add(new SimpleMap());

        private void lstSrcRepo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetAttributes((IDataProvider)lstSrc.SelectedItem, (string)lstSrcRepo.SelectedItem, SourceAttributes);
        }

        private void lstTrgRepo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetAttributes((IDataProvider)lstTrg.SelectedItem, (string)lstTrgRepo.SelectedItem, TargetAttributes);
        }

        private void SetAttributes(IDataProvider prov, string repo, ObservableCollection<string> attributes)
        {
            attributes.Clear();

            if (prov != null && repo != null)
            {
                attributes.AddRange(prov.GetColumns(repo).Select(a => a.Name));
            }
        }

        private void btnRm_Click(object sender, RoutedEventArgs e) => CurrentMaps.Remove((SimpleMap)((Button)sender).Tag);

        private void btnRmAll_Click(object sender, RoutedEventArgs e) => CurrentMaps.Clear();


        private void btnMapName_Click(object sender, RoutedEventArgs e)
        {
            CurrentMaps.ReplaceAll(SourceAttributes.Where(s => TargetAttributes.Contains(s)).Select(s => new SimpleMap(s, s)));
        }

        private void btnMapPos_Click(object sender, RoutedEventArgs e)
        {
            CurrentMaps.ReplaceAll(SourceAttributes.Take(TargetAttributes.Count).Select((s, i) => new SimpleMap(s, TargetAttributes[i])));
        }

        private void DataGridComboBoxColumn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentMaps_CollectionChanged(null, null);
        }
    }
}

