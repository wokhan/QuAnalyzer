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
            gridData.CustomHeaders = prov.GetColumns(repo);
            gridData.ItemsSource = prov.GetQueryable(repo);
        }
        else
        {
            gridData.ItemsSource = null;
        }
    }
}
