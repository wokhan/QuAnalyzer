using QuAnalyzer.Generic.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Wokhan.Data.Providers.Bases;
using Wokhan.Linq.Extensions;
using Wokhan.WPF.Extensions;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Logique d'interaction pour DataViewer.xaml
    /// </summary>
    public partial class Viewer : Page
    {
        public Viewer()
        {
            InitializeComponent();

            ((App)App.Current).CurrentSelection.CollectionChanged += CurrentSelection_CollectionChanged;

            CurrentSelection_CollectionChanged(null, null);
        }

        private void CurrentSelection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var (prov, repo) = ((App)App.Current).CurrentSelection.FirstOrDefault();
            if (prov != null && repo != null)
            {
                gridData.CustomHeaders = prov.GetColumns(repo);
                gridData.Source = prov.GetQueryable(repo);
            }
            else
            {
                gridData.Source = null;
            }
        }
    }
}
