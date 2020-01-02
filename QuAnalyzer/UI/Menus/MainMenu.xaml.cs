using Microsoft.Win32;
using QuAnalyzer.UI.Windows;
using System.Windows;
using System.Windows.Controls;

namespace QuAnalyzer.UI.Menus
{
    /// <summary>
    /// Logique d'interaction pour MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnMenuRecent_Click(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).CurrentProject.Open((string)((MenuItem)sender).CommandParameter);
        }

        private void btnEditTitle_Click(object sender, RoutedEventArgs e)
        {
            txtProjectTitle.Focus();
        }

        private void btnMenuSave_Click(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).CurrentProject.Save();

        }

        private void btnMenuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).CurrentProject.SaveAs();

        }

        private void btnMenuNew_Click(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).CurrentProject.CreateNew();
        }

        private void btnMenuOpen_Click(object sender, RoutedEventArgs e)
        {
            var dial = new OpenFileDialog() { CheckFileExists = true, ValidateNames = true, AddExtension = true, Filter = "QuAnalyzer project file|*.qap" };
            if (dial.ShowDialog().Value)
            {
                ((App)App.Current).CurrentProject.Open(dial.FileName);
            }
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            ((ModernMain)Window.GetWindow(this)).ShowAbout();
        }
    }
}
