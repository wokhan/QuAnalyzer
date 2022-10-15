using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Navigation;

using Windows.Foundation;

namespace QuAnalyzer.UI.Popups
{
    [ObservableObject]
    public partial class GenericPopup : Page
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

        private Window host;

#if HAS_UNO
        public event WindowClosedEventHandler Closed
        {
            add { host.Closed += value; }
            remove { host.Closed -= value; }
        }
#else
        public event TypedEventHandler<object, WindowEventArgs> Closed
        {
            add { host.Closed += value; }
            remove { host.Closed -= value; }
        }
#endif
        private GenericPopup(Window host, bool isWizard = false)
        {
            this.isWizard = isWizard;
            this.host = host;

            host.Content = new Frame { Content = this };

            _buttonsBarVisibility = isWizard ? Visibility.Visible : Visibility.Collapsed;

            InitializeComponent();

#if !HAS_UNO
            if (AppWindowTitleBar.IsCustomizationSupported())
            {
                host.ExtendsContentIntoTitleBar = true;
                host.SetTitleBar(TitleBar);
            }
#endif

            contents.SetValue(OwningWindowProperty, this);

            contents.Navigated += Contents_Navigated;
        }

        private void Contents_Navigated(object sender, NavigationEventArgs e)
        {
            Activate();

            GoBackCommand.NotifyCanExecuteChanged();
        }

        internal static GenericPopup OpenNew<T>(object? parameter = null, bool isWizard = false)
        {
            var host = new Window();

            GenericPopup window = new(host, isWizard);

            window.contents.Navigate(typeof(T), parameter);

            host.Activate();

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

        public void Close()
        {
            host.Close();
        }

        private void CloseMe(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Activate()
        {
            host.Activate();
        }

        public static void UpdateCurrent(Page page, IRelayCommand? nextButtonCommand = null, string? title = null, bool? isLastStep = null)
        {
            var popup = (GenericPopup)page.Frame.GetValue(OwningWindowProperty);

            if (nextButtonCommand is not null)
            {
                popup.NextButtonCommand = nextButtonCommand;
            }

#if !HAS_UNO
            if (title is not null)
            {
                popup.WindowTitle = title;
                popup.host.Title = title;
            }
#endif

            if (isLastStep is not null)
            {
                popup.IsLastStep = isLastStep.Value;
                popup.NextButton.Content = isLastStep.Value ? "Apply !" : "Next >";
            }
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
