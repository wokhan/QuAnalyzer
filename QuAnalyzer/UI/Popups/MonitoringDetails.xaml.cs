using QuAnalyzer.Features.Monitoring;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Wokhan.Collections.Generic.Extensions;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Popups
{
    /// <summary>
    /// Interaction logic for MonitoringDetails.xaml
    /// </summary>
    public partial class MonitoringDetails : Page
    {

        private readonly MonitorItem initialItem;
        public MonitorItem CurrentItem { get; set; }

        private Window _owner => Window.GetWindow(this);

        public MonitoringDetails(MonitorItem monitorItem = null)
        {
            initialItem = monitorItem ?? new MonitorItem() { Name = "Monitor #" + (((App)Application.Current).CurrentProject.MonitorItems.Count + 1) };
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
            CurrentItem.PrecedingSteps.AddAll(lstPrec.SelectedItems.Cast<MonitorItem>().Select(_ => KeyValuePair.Create(_, false)));
            CurrentItem.Attributes = String.Join(",", lstAttributes.SelectedItems.Cast<KeyValuePair<string, bool>>().Select(s => s.Key));

            var projectMappers = ((App)App.Current).CurrentProject.MonitorItems;
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
}
