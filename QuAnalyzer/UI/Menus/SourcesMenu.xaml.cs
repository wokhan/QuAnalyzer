using CommunityToolkit.Mvvm.Input;

using Microsoft.Win32;

using QuAnalyzer.UI.Pages;
using QuAnalyzer.UI.Windows;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Menus;

public partial class SourcesMenu : UserControl
{

    private Point startPoint;

    public SourcesMenu()
    {
        InitializeComponent();
    }

    [ICommand]
    private void ProviderDelete(IDataProvider provider)
    {
        App.Instance.CurrentProject.CurrentProviders.Remove(provider);
    }

    //[ICommand]
    //private void ProviderImport()
    //{
    //    var dial = new OpenFileDialog() { CheckFileExists = true, ValidateNames = true, AddExtension = true, Filter = "QuAnalyzer Data Provider archive|*.qax" };
    //    if (dial.ShowDialog().Value)
    //    {
    //        App.Instance.ProvidersMan.AddProvider(dial.FileName);
    //    }
    //}

    [ICommand]
    private void ProviderEdit(IDataProvider provider)
    {
        Popup.OpenNew(new ProviderEditor(provider));
    }

    [ICommand]
    private void SourceNew()
    {
        Popup.OpenNew(new ProviderPicker());
    }

    private void Repository_DataGrid_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
        Vector diff = startPoint - e.GetPosition(null);
        if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed && (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
        {
            var src = (FrameworkElement)sender;
            DragDrop.DoDragDrop(src, new DataObject(src.Tag), DragDropEffects.Link);
            e.Handled = true;
        }
    }

    private void Repository_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        startPoint = e.GetPosition(null);
    }

    private void TreeView_Selected(object sender, RoutedEventArgs e)
    {
        var treeViewItem = (TreeViewItem)e.OriginalSource;
        var provider = (IDataProvider)treeViewItem.Tag;
        var repository = (string)((TreeView)sender).SelectedValue;

        App.Instance.CurrentSelection = (provider, repository);

    }
}
