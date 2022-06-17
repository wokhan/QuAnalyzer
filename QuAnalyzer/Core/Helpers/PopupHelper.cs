namespace QuAnalyzer.UI.Windows
{
    public class Popup : ContentDialog
    {
        internal async static Task<Popup> OpenNew(Page content, XamlRoot owner)
        {
            var dialog = new Popup() { XamlRoot = owner, Content = content };
            await dialog.ShowAsync();
            return dialog;
        }

        internal async void Activate()
        {
            await this.ShowAsync();
        }
    }
}
