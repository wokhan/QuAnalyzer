using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Navigation;

using QuAnalyzer.UI.Pages;
using QuAnalyzer.UI.Popups;

namespace QuAnalyzer.UI.Windows
{
    [ObservableObject]
    public partial class GenericPopup : Window
    {
        private bool isWizard;

        [ObservableProperty]
        private Visibility _buttonsBarVisibility;

        [ObservableProperty]
        public bool _isLastStep;

        [ObservableProperty]
        public IRelayCommand _nextButtonCommand;

        public static readonly DependencyProperty OwningWindowProperty = DependencyProperty.RegisterAttached(nameof(OwningWindowProperty), typeof(GenericPopup), typeof(Page), new PropertyMetadata(null));

        public GenericPopup(bool isWizard = false)
        {
            this.isWizard = isWizard;

            _buttonsBarVisibility = isWizard ? Visibility.Visible : Visibility.Collapsed;

            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(TitleBar);

            InitializeComponent();

            contents.SetValue(OwningWindowProperty, this);

            contents.Navigated += Contents_Navigated;
        }

        private void Contents_Navigated(object sender, NavigationEventArgs e)
        {
            GoBackCommand.NotifyCanExecuteChanged();
        }

        internal static GenericPopup OpenNew<T>(object? parameter = null, bool isWizard = false)
        {
            GenericPopup window = new(isWizard);
            window.contents.Navigate(typeof(T), parameter);
            window.Activate();

            return window;
        }

        [RelayCommand(CanExecute = nameof(CanExecuteGoBack))]
        internal void GoBack()
        {
            contents.GoBack();// Content = History.Last();
        }

        private bool CanExecuteGoBack => contents.CanGoBack;

        internal static GenericPopup FromPage(Page page)
        {
            return (GenericPopup)page.Frame.GetValue(OwningWindowProperty);
        }

        private void CloseMe(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public static void UpdateCurrent(Page page, IRelayCommand? nextButtonCommand = null, string? title = null, bool isLastStep = false)
        {
            var popup = (GenericPopup)page.Frame.GetValue(OwningWindowProperty);

            if (nextButtonCommand is not null)
            {
                popup.NextButtonCommand = nextButtonCommand;
            }

            if (title is not null)
            {
                popup.Title = title;
            }

            popup.IsLastStep = isLastStep;
        }
    }
}
