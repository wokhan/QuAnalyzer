﻿using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;

using QuAnalyzer.Core.Project;
using QuAnalyzer.UI.Pages;
using QuAnalyzer.UI.Popups;

using Windows.Devices.Input;
using Windows.Foundation;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Menus;

[ObservableObject]
public partial class SourcesMenu : UserControl
{
    /// <summary>
    /// This is to bypass a bug with Uno Platform where TwoWay static bindings through x:Bind don't seem to work. Weird since
    /// according to GitHub, it should...
    /// </summary>
    public ProjectSettings CurrentProject => App.Instance.CurrentProject;
    public bool CurrentSelectionLinked => App.Instance.CurrentSelectionLinked;

    private Point startPoint;

    public SourcesMenu()
    {
        InitializeComponent();
    }

    private void Provider_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        FlyoutBase.ShowAttachedFlyout((Grid)sender);
    }
    private void Provider_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        FlyoutBase.GetAttachedFlyout((Grid)sender).Hide();
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

    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var listview = (ListView)sender;

        //var container = listview.ContainerFromItem(listview.SelectedItem);
        //var group = listview.GroupHeaderContainerFromItemContainer(container);
        if (listview.SelectedItem is not null)
        {
            var item = (KeyValuePair<string, object>)listview.SelectedItem;

            // Ugly hack since I didn't figure out how to get the corresponding group from a ListViewItem...
            var provider = App.Instance.CurrentProject.CurrentProviders.First(provider => provider.Repositories.Contains(item));
            var repository = item.Key;

            App.Instance.CurrentSelection = (provider, repository);
        }
        else
        {
            App.Instance.CurrentSelection = (null, null);
        }
    }
}
