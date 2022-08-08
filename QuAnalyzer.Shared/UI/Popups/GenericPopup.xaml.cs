using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml.Navigation;

namespace QuAnalyzer.UI.Windows
{
    [ObservableObject]
    public partial class GenericPopup : Window
    {
        private bool isWizard;

        [ObservableProperty]
        private Visibility _buttonsBarVisibility;

        [ObservableProperty]
        private bool _isLastStep;

        [ObservableProperty]
        private string _windowTitle;

        [ObservableProperty]
        private IRelayCommand _nextButtonCommand;

        public static readonly DependencyProperty OwningWindowProperty = DependencyProperty.RegisterAttached(nameof(OwningWindowProperty), typeof(GenericPopup), typeof(Page), new PropertyMetadata(null));

        public GenericPopup(bool isWizard = false)
        {
            this.isWizard = isWizard;

            _buttonsBarVisibility = isWizard ? Visibility.Visible : Visibility.Collapsed;

            InitializeComponent();
            
            if (AppWindowTitleBar.IsCustomizationSupported())
            {
                this.ExtendsContentIntoTitleBar = true;
                this.SetTitleBar(TitleBar);
            }

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
            return (GenericPopup)page.Frame?.GetValue(OwningWindowProperty);
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
                popup.WindowTitle = title;
            }

            popup.IsLastStep = isLastStep;
            popup.NextButton.Content = isLastStep ? "Apply !" : "Next >";
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsLastStep)
            {
                Close();
            }
        }
    }
}
