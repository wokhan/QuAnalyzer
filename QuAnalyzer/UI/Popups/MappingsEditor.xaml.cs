using QuAnalyzer.Features.Comparison;

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace QuAnalyzer.UI.Popups
{
    public partial class MappingsEditor : Page
    {
        private SourcesMapper initialMap;
        private SourcesMapper currentMap;

        public MappingsEditor() : this(new SourcesMapper() { Name = "New mapping" })
        {

        }

        public MappingsEditor(SourcesMapper map)
        {
            initialMap = map;
            currentMap = new SourcesMapper()
            {
                Name = map.Name,
                Source = map.Source,
                SourceRepository = map.SourceRepository,
                Target = map.Target,
                TargetRepository = map.TargetRepository,
                AllMappings = new List<SimpleMap>(map.AllMappings)
            };

            this.DataContext = currentMap;
            
            InitializeComponent();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e) => closeParent();
        private void closeParent() => Window.GetWindow(this).Close();

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var projectMappers = ((App)App.Current).CurrentProject.SourceMapper;
            if (projectMappers.Contains(initialMap))
            {
                projectMappers[projectMappers.IndexOf(initialMap)] = currentMap;
            }
            else
            {
                projectMappers.Add(currentMap);
            }
            closeParent();
        }
    }
}
