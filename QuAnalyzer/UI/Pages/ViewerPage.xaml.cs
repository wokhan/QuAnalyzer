using System.Linq;
using System.Linq.Dynamic.Core;
using System.Windows.Controls;

namespace QuAnalyzer.UI.Pages
{
    /// <summary>
    /// Logique d'interaction pour DataViewer.xaml
    /// </summary>
    public partial class ViewerPage : Page
    {
        public ViewerPage()
        {
            InitializeComponent();

            ((App)App.Current).PropertyChanged += (s, e) => { if (e.PropertyName == nameof(App.CurrentSelection)) { UpdateSelection(); } };

            UpdateSelection();
        }

        private void UpdateSelection()
        {
            var (prov, repo) = ((App)App.Current).CurrentSelection;
            if (prov is not null && repo is not null)
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
