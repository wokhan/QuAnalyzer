using QuAnalyzer.Features.Monitoring;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Popups;

/// <summary>
/// Interaction logic for MonitoringDetails.xaml
/// </summary>
public partial class MonitoringDetails : Page
{

    private readonly TestDefinition initialItem;
    public TestDefinition CurrentItem { get; set; }

    private Window _owner => Window.GetWindow(this);

    public MonitoringDetails(TestDefinition TestDefinition = null)
    {
        initialItem = TestDefinition ?? new TestDefinition() { Name = "Monitor #" + (App.Instance.CurrentProject.TestDefinitions.Count + 1) };
        CurrentItem = initialItem.Clone();

        InitializeComponent();

        if (CurrentItem.Provider is not null && !String.IsNullOrEmpty(CurrentItem.Repository))
        {
            lstAttributes.ItemsSource = CurrentItem.Provider.GetColumns(CurrentItem.Repository)
                                                            .ToDictionary(h => h.Name, h => CurrentItem.AttributesList.Contains(h.Name));
        }

    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        _owner.Close();
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        CurrentItem.PrecedingSteps.AddAll(lstPrec.SelectedItems.Cast<TestDefinition>().Select(_ => KeyValuePair.Create(_, false)));
        CurrentItem.Attributes = String.Join(",", lstAttributes.SelectedItems.Cast<KeyValuePair<string, bool>>().Select(s => s.Key));

        var projectMappers = App.Instance.CurrentProject.TestDefinitions;
        if (projectMappers.Contains(initialItem))
        {
            projectMappers[projectMappers.IndexOf(initialItem)] = CurrentItem;
        }
        else
        {
            projectMappers.Add(CurrentItem);
        }
        _owner.Close();
    }

    private void lstSrcRepo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (lstSrcRepo.SelectedItem is not null)
        {
            lstAttributes.ItemsSource = ((IDataProvider)lstSrc.SelectedItem).GetColumns((string)lstSrcRepo.SelectedItem)
                                                                            .ToDictionary(h => h.Name, h => CurrentItem.AttributesList.Contains(h.Name));
        }
    }

}
