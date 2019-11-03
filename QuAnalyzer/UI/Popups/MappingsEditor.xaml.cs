using QuAnalyzer.Features.Comparison;
using System.Windows;
using System.Windows.Controls;

namespace QuAnalyzer.UI.Popups
{
    /// <summary>
    /// Interaction logic for MappingsEditor.xaml
    /// </summary>
    public partial class MappingsEditor : Page
    {
        private SourcesMapper initialMap;
        public SourcesMapper CurrentMap { get; }

        public MappingsEditor() : this(new SourcesMapper() { Name = "New mapping" })
        {

        }

        public MappingsEditor(SourcesMapper map)
        {
            initialMap = map;
            CurrentMap = new SourcesMapper()
            {
                Name = map.Name,
                Source = map.Source,
                SourceRepository = map.SourceRepository,
                Target = map.Target,
                TargetRepository = map.TargetRepository,
                AllMappings = map.AllMappings
            };

            InitializeComponent();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e) => closeParent();
        private void closeParent() => Window.GetWindow(this).Close();

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var projectMappers = ((App)App.Current).CurrentProject.SourceMapper;
            if (projectMappers.Contains(initialMap))
            {
                projectMappers[projectMappers.IndexOf(initialMap)] = CurrentMap;
            }
            else
            {
                projectMappers.Add(CurrentMap);
            }
        }
    }
}
