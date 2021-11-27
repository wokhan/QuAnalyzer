using System.Windows.Controls;

namespace QuAnalyzer.UI.Popups;

/// <summary>
/// Interaction logic for About.xaml
/// </summary>
public partial class About : UserControl
{
    public About()
    {
        this.IsVisibleChanged += About_IsVisibleChanged;

        this.MouseDown += About_MouseDown;

        InitializeComponent();
    }

    private void About_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
    {
        if (this.IsVisible)
        {
            CaptureMouse();
        }
    }

    private void About_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        ReleaseMouseCapture();

        this.Visibility = System.Windows.Visibility.Collapsed;
    }
}
