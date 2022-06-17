using CommunityToolkit.Mvvm.Input;

using QuAnalyzer.Features.Monitoring;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Popups;

public partial class MonitoringDetails : Page
{

    private readonly TestDefinition initialItem;
    public TestDefinition CurrentItem { get; set; }

    private Window _owner => Window.Current;

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

    [ICommand]
    private void Cancel()
    {
        _owner.Close();
    }

    [ICommand]
    private void Save()
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
