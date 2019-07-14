using MahApps.Metro.Controls;
using QuAnalyzer.Helpers;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Wokhan.Collections.Extensions;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Windows
{
    /// <summary>
    /// Interaction logic for MappingsEditor.xaml
    /// </summary>
    public partial class MappingsEditor : MetroWindow
    {
        SourcesMapper currentMap = null;

        bool isNew = false;

        private readonly ObservableCollection<SourcesMapper.SimpleMap> currentMaps = new ObservableCollection<SourcesMapper.SimpleMap>();

        private readonly ObservableCollection<string> SourceAttributes = new ObservableCollection<string>();

        private readonly ObservableCollection<string> TargetAttributes = new ObservableCollection<string>();

        public MappingsEditor() : this(null) { }

        public MappingsEditor(SourcesMapper map)
        {
            InitializeComponent();

            ((DataGridComboBoxColumn)gridMappings.Columns[0]).ItemsSource = SourceAttributes;
            ((DataGridComboBoxColumn)gridMappings.Columns[1]).ItemsSource = TargetAttributes;

            if (map == null)
            {
                isNew = true;
            }
            else
            {
                this.DataContext = map;
                currentMaps.ReplaceAll(map.AllMappings);
            }

            currentMap = map;

            gridMappings.ItemsSource = currentMaps;
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            currentMaps.Add(new SourcesMapper.SimpleMap());
        }

        private void lstSrcRepo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SourceAttributes.Clear();

            if (lstSrc.SelectedItem != null && lstSrcRepo.SelectedItem != null)
            {
                ((IDataProvider)lstSrc.SelectedItem).GetColumns((string)lstSrcRepo.SelectedItem)
                                                    .Select(a => a.Name)
                                                    .ToList()
                                                    .ForEach(SourceAttributes.Add);
            }
        }

        private void btnRm_Click(object sender, RoutedEventArgs e)
        {
            SourcesMapper.SimpleMap sm = (SourcesMapper.SimpleMap)((Button)sender).Tag;
            currentMaps.Remove(sm);
        }

        private void btnRmAll_Click(object sender, RoutedEventArgs e)
        {
            currentMaps.Clear();
        }

        private void lstTrgRepo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TargetAttributes.Clear();

            if (lstTrg.SelectedItem != null && lstTrgRepo.SelectedItem != null)
            {
                ((IDataProvider)lstTrg.SelectedItem).GetColumns((string)lstTrgRepo.SelectedItem)
                                                    .Select(a => a.Name)
                                                    .ToList()
                                                    .ForEach(TargetAttributes.Add);
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var saved = new SourcesMapper()
            {
                Name = lstMappings.Text,
                Source = (IDataProvider)lstSrc.SelectedItem,
                SourceRepository = (string)lstSrcRepo.SelectedItem,
                Target = (IDataProvider)lstTrg.SelectedItem,
                TargetRepository = (string)lstTrgRepo.SelectedItem,
                AllMappings = currentMaps.OrderByDescending(a => a.IsKey).ToList()
            };

            if (isNew)
            {
                ((App)App.Current).CurrentProject.SourceMapper.Add(saved);
            }
            else
            {
                ((App)App.Current).CurrentProject.SourceMapper[((App)App.Current).CurrentProject.SourceMapper.IndexOf(currentMap)] = saved;
            }

            closeParent();
        }

        private void closeParent()
        {
            Window.GetWindow(this).Close();
        }


        private void btnMapName_Click(object sender, RoutedEventArgs e)
        {
            currentMaps.ReplaceAll(SourceAttributes.Where(s => TargetAttributes.Contains(s)).Select(s => new SourcesMapper.SimpleMap(s, s)));
        }

        private void btnMapPos_Click(object sender, RoutedEventArgs e)
        {
            currentMaps.ReplaceAll(SourceAttributes.Take(TargetAttributes.Count).Select((s, i) => new SourcesMapper.SimpleMap(s, TargetAttributes[i])));
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            closeParent();
        }
    }
}
