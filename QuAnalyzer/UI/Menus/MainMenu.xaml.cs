using Microsoft.Win32;
using QuAnalyzer.UI.Pages;
using QuAnalyzer.UI.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Wokhan.Collections.Generic.Extensions;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Menus
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        
        private readonly ObservableCollection<KeyValuePair<IDataProvider, string>> Providers = new ObservableCollection<KeyValuePair<IDataProvider, string>>();
        private Point startPoint;

        private CollectionViewSource GroupedProviders { get; set; }

        public MainMenu()
        {
            var currentProviders = ((App)Application.Current).CurrentProject.CurrentProviders;
            Providers.AddAll(currentProviders.SelectMany(prov => prov.Repositories.Select(r => new KeyValuePair<IDataProvider, string>(prov, r.Key))));
            currentProviders.CollectionChanged += CurrentProviders_CollectionChanged;

            GroupedProviders = new CollectionViewSource()
            {
                Source = Providers
            };
            GroupedProviders.GroupDescriptions.Add(new PropertyGroupDescription("Key"));

            InitializeComponent();

            lstProviders.ItemsSource = GroupedProviders.View;
        }

        private void CurrentProviders_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            using (GroupedProviders.DeferRefresh())
            {
                if (e.OldItems != null)
                {
                    e.OldItems.Cast<IDataProvider>().ToList().ForEach(x => Providers.Remove(Providers.First(prov => prov.Key == x)));
                }
                if (e.NewItems != null)
                {
                    Providers.AddAll((e.NewItems.Cast<IDataProvider>().SelectMany(prov => prov.Repositories.Select(r => new KeyValuePair<IDataProvider, string>(prov, r.Key)))));
                }
            }
        }

        private void btnDeleteProvider_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).CurrentProject.CurrentProviders.Remove((IDataProvider)((Button)sender).Tag);
        }

        private void btnImportPrv_Click(object sender, RoutedEventArgs e)
        {
            var dial = new OpenFileDialog() { CheckFileExists = true, ValidateNames = true, AddExtension = true, Filter = "QuAnalyzer Data Provider archive|*.qax" };
            if (dial.ShowDialog().Value)
            {
                ((App)Application.Current).ProvidersMan.AddProvider(dial.FileName);
            }
        }

        private void btnEditProvider_Click(object sender, RoutedEventArgs e) => Popup.OpenNew(new ProviderEditor((IDataProvider)((Button)sender).Tag));

        private void btnNewSource_Click(object sender, RoutedEventArgs e) => Popup.OpenNew(new ProviderPicker());

        private void lstProviders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = ((App)App.Current).CurrentSelection;
            currentSelection.RemoveRange(e.RemovedItems.Cast<KeyValuePair<IDataProvider, string>>());
            currentSelection.AddRange(e.AddedItems.Cast<KeyValuePair<IDataProvider, string>>());
        }

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
    }
}
