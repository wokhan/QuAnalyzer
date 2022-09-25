using QuAnalyzer.UI.Controls;

namespace QuAnalyzer.UI.Pages;

public partial class ViewerPage : Page
{
    public ViewerPage()
    {
        InitializeComponent();

        App.Instance.PropertyChanged += (s, e) => { if (e.PropertyName == nameof(App.CurrentSelection)) { UpdateSelection(); } };

        UpdateSelection();
    }

    private void UpdateSelection()
    {
        if (this.Parent is null)
        {
            return;
        }

        var (prov, repo) = App.Instance.CurrentSelection;
        if (prov is not null && repo is not null)
        {
            var grid = new ExtendedDataGridView()
            {
                ItemsSource = prov.GetQueryable(repo),
                EnableAdvancedFilters = true
            };

            var newTab = new TabViewItem()
            {
                IconSource = new SymbolIconSource() { Symbol = Symbol.List },
                Header = $"{repo} ({prov.Name})",
                Content = grid,
                IsSelected = true
            };

            tabs.TabItems.Add(newTab);
        }
    }

    private void tabs_TabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
    {
        sender.TabItems.Remove(args.Tab);
    }

    private void tabs_AddTabButtonClick(TabView sender, object e)
    {
        UpdateSelection();
    }
}
