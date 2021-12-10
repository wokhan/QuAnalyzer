using Microsoft.Win32;

using QuAnalyzer.UI.Pages;
using QuAnalyzer.UI.Windows;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Menus;

/// <summary>
/// Interaction logic for MainMenu.xaml
/// </summary>
public partial class SourcesMenu : UserControl
{

    private Point startPoint;

    public SourcesMenu()
    {
        InitializeComponent();
    }

    private void btnDeleteProvider_Click(object sender, RoutedEventArgs e)
    {
        App.Instance.CurrentProject.CurrentProviders.Remove((IDataProvider)((Button)sender).Tag);
    }

    private void btnImportPrv_Click(object sender, RoutedEventArgs e)
    {
        var dial = new OpenFileDialog() { CheckFileExists = true, ValidateNames = true, AddExtension = true, Filter = "QuAnalyzer Data Provider archive|*.qax" };
        if (dial.ShowDialog().Value)
        {
            App.Instance.ProvidersMan.AddProvider(dial.FileName);
        }
    }

    private void btnEditProvider_Click(object sender, RoutedEventArgs e) => Popup.OpenNew(new ProviderEditor((IDataProvider)((Button)sender).Tag));

    private void btnNewSource_Click(object sender, RoutedEventArgs e) => Popup.OpenNew(new ProviderPicker());

    private void Repository_DataGrid_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
        Vector diff = startPoint - e.GetPosition(null);
        if (e.LeftButton == MouseButtonState.Pressed && (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
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
