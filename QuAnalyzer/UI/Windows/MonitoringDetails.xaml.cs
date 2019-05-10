using MahApps.Metro.Controls;
using Wokhan.Data.Providers.Contracts;
using QuAnalyzer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace QuAnalyzer.UI.Windows
{
    /// <summary>
    /// Interaction logic for MonitoringDetails.xaml
    /// </summary>
    public partial class MonitoringDetails : MetroWindow
    {
        public MonitoringDetails(MonitorItem monitorItem)
        {
            InitializeComponent();

            CurrentItem = monitorItem;

            this.DataContext = CurrentItem;

            if (CurrentItem.Provider != null && !String.IsNullOrEmpty(CurrentItem.Repository))
            {
                lstAttributes.ItemsSource = CurrentItem.Provider.GetColumns(CurrentItem.Repository)
                                                                .ToDictionary(h => h.Name, h => CurrentItem.AttributesList.Contains(h.Name));
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CurrentItem.PrecedingSteps = lstPrec.SelectedItems.Cast<MonitorItem>().ToList();
            CurrentItem.Attributes = String.Join(",", lstAttributes.SelectedItems.Cast<KeyValuePair<string, bool>>().Select(s => s.Key));

            if (!((App)App.Current).CurrentProject.MonitorItems.Contains(CurrentItem))
            {
                ((App)App.Current).CurrentProject.MonitorItems.Add(CurrentItem);
            }

            Close();
        }

        private void lstSrcRepo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstSrcRepo.SelectedItem != null)
            {
                lstAttributes.ItemsSource = ((IDataProvider)lstSrc.SelectedItem).GetColumns((string)lstSrcRepo.SelectedItem)
                                                                                .ToDictionary(h => h.Name, h => CurrentItem.AttributesList.Contains(h.Name));
            }
        }


        public MonitorItem CurrentItem { get; set; }
    }
}
