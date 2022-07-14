using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.Input;

using QuAnalyzer.UI.Pages;
using QuAnalyzer.UI.Windows;

using Windows.Devices.Input;
using Windows.Foundation;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Menus;

[ObservableObject]
public partial class SourcesMenu : UserControl
{
    private Point startPoint;

    public SourcesMenu()
    {
        InitializeComponent();
    }


    [RelayCommand]
    private void ProviderDelete(IDataProvider provider)
    {
        App.Instance.CurrentProject.CurrentProviders.Remove(provider);
    }

    //[RelayCommand]
    //private void ProviderImport()
    //{
    //    var dial = new OpenFileDialog() { CheckFileExists = true, ValidateNames = true, AddExtension = true, Filter = "QuAnalyzer Data Provider archive|*.qax" };
    //    if (dial.ShowDialog().Value)
    //    {
    //        App.Instance.ProvidersMan.AddProvider(dial.FileName);
    //    }
    //}

    [RelayCommand]
    private void ProviderEdit(IDataProvider provider)
    {
        GenericPopup.OpenNew<ProviderEditor>(provider, true);
    }

    [RelayCommand]
    private void SourceNew()
    {
        GenericPopup.OpenNew<ProviderPicker>(isWizard: true);
    }

    private void Repository_DataGrid_MouseMove(object sender, MouseEventArgs e)
    {
        //TODO: fix
        //Vector diff = startPoint - e.GetPosition(null);
        //if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed && (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
        //{
        //    var src = (FrameworkElement)sender;
        //    DragDrop.DoDragDrop(src, new DataObject(src.Tag), DragDropEffects.Link);
        //    e.Handled = true;
        //}
    }

    private void Repository_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        //TODO: fix
        //startPoint = e.GetPosition(null);
    }

    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var listview = (ListView)sender;

        //var container = listview.ContainerFromItem(listview.SelectedItem);
        //var group = listview.GroupHeaderContainerFromItemContainer(container);

        var item = (KeyValuePair<string, object>)listview.SelectedItem;

        // Ugly hack since I didn't figure out how to get the corresponding group from a ListViewItem...
        var provider = App.Instance.CurrentProject.CurrentProviders.First(provider => provider.Repositories.Contains(item));
        var repository = item.Key;

        App.Instance.CurrentSelection = (provider, repository);
    }
}
