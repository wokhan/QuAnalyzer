using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Comparison.Definition;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Controls;

public partial class MappingsEdit : UserControl
{
    public SourcesMapper Mapping
    {
        get => (SourcesMapper)GetValue(MappingProperty);
        set => SetValue(MappingProperty, value);
    }

    public static readonly DependencyProperty MappingProperty = DependencyProperty.Register(nameof(Mapping), typeof(SourcesMapper), typeof(MappingsEdit));

    public ObservableCollection<string> SourceAttributes { get; } = new();

    public ObservableCollection<string> TargetAttributes { get; } = new();

    public MappingsEdit()
    {
        InitializeComponent();

        ((DataGridComboBoxColumn)gridMappings.Columns[0]).ItemsSource = SourceAttributes;
        ((DataGridComboBoxColumn)gridMappings.Columns[1]).ItemsSource = TargetAttributes;
    }


    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
        Mapping.AllMappings.Add(new SimpleMap());
        gridMappings.Items.Refresh();
    }

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

        if (prov is not null && repo is not null)
        {
            attributes.AddAll(prov.GetColumns(repo).Select(a => a.Name));
        }
    }

    private void btnRm_Click(object sender, RoutedEventArgs e)
    {
        Mapping.AllMappings.Remove((SimpleMap)((Button)sender).Tag);
        // TODO: Use an observable collection?
        gridMappings.Items.Refresh();
    }

    private void btnRmAll_Click(object sender, RoutedEventArgs e)
    {
        Mapping.AllMappings.Clear();
        gridMappings.Items.Refresh();
    }


    private void btnMapName_Click(object sender, RoutedEventArgs e)
    {
        Mapping.AllMappings.ReplaceAll(SourceAttributes.Where(s => TargetAttributes.Contains(s)).Select(s => new SimpleMap(s, s)));
        gridMappings.Items.Refresh();

    }

    private void btnMapPos_Click(object sender, RoutedEventArgs e)
    {
        Mapping.AllMappings.ReplaceAll(SourceAttributes.Take(TargetAttributes.Count).Zip(TargetAttributes, (s, i) => new SimpleMap(s, i)));
        gridMappings.Items.Refresh();
    }
}

