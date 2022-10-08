using Microsoft.UI.Xaml.Navigation;

using QuAnalyzer.Features.Monitoring;

namespace QuAnalyzer.UI.Popups
{
    public sealed partial class MonitorResultsViewer : Page
    {
        public MonitorResultsViewer()
        {
            this.InitializeComponent();
        }

        public TestResults Results { get; private set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Results = e.Parameter as TestResults;

            GenericPopup.UpdateCurrent(this, title: $"{Results.Name} - Details");
        }
    }
}
