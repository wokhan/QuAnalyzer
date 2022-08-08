using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Navigation;

using QuAnalyzer.Features.Monitoring;
using QuAnalyzer.UI.Windows;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Popups;

[ObservableObject]
public partial class MonitoringDetails : Page
{

    private TestDefinition initialItem;

    [ObservableProperty]
    private TestDefinition _currentItem;

    public MonitoringDetails()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        var TestDefinition = e.Parameter as TestDefinition;

        initialItem = TestDefinition ?? new TestDefinition() { Name = "Monitor #" + (App.Instance.CurrentProject.TestDefinitions.Count + 1) };
        CurrentItem = initialItem.Clone();

        base.OnNavigatedTo(e);

        GenericPopup.UpdateCurrent(this, title: $"{CurrentItem.Name} - Edit");

        UpdateAttributes();
    }

    private void UpdateAttributes()
    {
        if (CurrentItem.Provider is not null && !String.IsNullOrEmpty(CurrentItem.Repository))
        {
            lstAttributes.ItemsSource = CurrentItem.Provider.GetColumns(CurrentItem.Repository)
                                                            .ToDictionary(h => h.Name, h => CurrentItem.AttributesList.Contains(h.Name));
        }
    }

    [RelayCommand]
    private void Cancel()
    {
        GenericPopup.FromPage(this).Close();
    }

    [RelayCommand]
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

        GenericPopup.FromPage(this).Close();
    }

    private void lstSrcRepo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateAttributes();
    }

}
