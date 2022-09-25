using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Navigation;

using QuAnalyzer.Features.Monitoring;
using QuAnalyzer.UI.Windows;

using Windows.UI.Popups;

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
        if (CurrentItem.Type == MonitoringModes.CHECKVAL && !lstAttributes.SelectedItems.Any())
        {
            _ = new ContentDialog() { Content = "The selected monitoring type requires at least one attribute to be selected.", Title = "Missing attributes", CloseButtonText = "OK", XamlRoot = this.XamlRoot }.ShowAsync();
            return;
        }

        //TODO: Why a dictionary?
        CurrentItem.PrecedingSteps.AddAll(lstPrec.SelectedItems.Cast<TestDefinition>().Select(_ => KeyValuePair.Create(_, false)));
        CurrentItem.Attributes = String.Join(",", lstAttributes.SelectedItems.Cast<KeyValuePair<string, bool>>().Select(s => s.Key));

        var definitions = App.Instance.CurrentProject.TestDefinitions;
        var index = definitions.IndexOf(initialItem);
        if (index != -1)
        {
            // Cannot use definitions[index] assignation as it breaks community Toolkit's DataGrid for some reason
            definitions.RemoveAt(index);
            definitions.Insert(index, CurrentItem);
        }
        else
        {
            definitions.Add(CurrentItem);
        }

        GenericPopup.FromPage(this).Close();
    }

    private void lstSrcRepo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateAttributes();
    }

}
