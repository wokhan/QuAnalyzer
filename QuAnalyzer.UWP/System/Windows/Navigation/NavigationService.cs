namespace System.Windows.Navigation
{
    using Uno.UI.Generic;

    public class NavigationService : Proxy<global::Windows.UI.Xaml.Navigation.NavigationService>
    {
        public System.Uri Source
        {
            get => __ProxyValue.Source;
            set => __ProxyValue.Source = value;
        }

        public System.Uri CurrentSource
        {
            get => __ProxyValue.CurrentSource;
        }

        public System.Object Content
        {
            get => __ProxyValue.Content;
            set => __ProxyValue.Content = value;
        }

        public System.Boolean CanGoForward
        {
            get => __ProxyValue.CanGoForward;
        }

        public System.Boolean CanGoBack
        {
            get => __ProxyValue.CanGoBack;
        }

        public static System.Windows.Navigation.NavigationService GetNavigationService(System.Windows.DependencyObject dependencyObject) => Windows.UI.Xaml.Navigation.NavigationService.GetNavigationService(@dependencyObject);
        public void AddBackEntry(System.Windows.Navigation.CustomContentState state) => __ProxyValue.AddBackEntry(@state);
        public System.Windows.Navigation.JournalEntry RemoveBackEntry() => __ProxyValue.RemoveBackEntry();
        public System.Boolean Navigate(System.Uri source) => __ProxyValue.Navigate(@source);
        public System.Boolean Navigate(System.Object root) => __ProxyValue.Navigate(@root);
        public System.Boolean Navigate(System.Uri source, System.Object navigationState) => __ProxyValue.Navigate(@source, @navigationState);
        public System.Boolean Navigate(System.Uri source, System.Object navigationState, System.Boolean sandboxExternalContent) => __ProxyValue.Navigate(@source, @navigationState, @sandboxExternalContent);
        public System.Boolean Navigate(System.Object root, System.Object navigationState) => __ProxyValue.Navigate(@root, @navigationState);
        public void GoForward() => __ProxyValue.GoForward();
        public void GoBack() => __ProxyValue.GoBack();
        public void StopLoading() => __ProxyValue.StopLoading();
        public void Refresh() => __ProxyValue.Refresh();
        public void add_NavigationFailed(System.Windows.Navigation.NavigationFailedEventHandler value) => __ProxyValue.add_NavigationFailed(@value);
        public void remove_NavigationFailed(System.Windows.Navigation.NavigationFailedEventHandler value) => __ProxyValue.remove_NavigationFailed(@value);
        public void add_Navigating(System.Windows.Navigation.NavigatingCancelEventHandler value) => __ProxyValue.add_Navigating(@value);
        public void remove_Navigating(System.Windows.Navigation.NavigatingCancelEventHandler value) => __ProxyValue.remove_Navigating(@value);
        public void add_Navigated(System.Windows.Navigation.NavigatedEventHandler value) => __ProxyValue.add_Navigated(@value);
        public void remove_Navigated(System.Windows.Navigation.NavigatedEventHandler value) => __ProxyValue.remove_Navigated(@value);
        public void add_NavigationProgress(System.Windows.Navigation.NavigationProgressEventHandler value) => __ProxyValue.add_NavigationProgress(@value);
        public void remove_NavigationProgress(System.Windows.Navigation.NavigationProgressEventHandler value) => __ProxyValue.remove_NavigationProgress(@value);
        public void add_LoadCompleted(System.Windows.Navigation.LoadCompletedEventHandler value) => __ProxyValue.add_LoadCompleted(@value);
        public void remove_LoadCompleted(System.Windows.Navigation.LoadCompletedEventHandler value) => __ProxyValue.remove_LoadCompleted(@value);
        public void add_FragmentNavigation(System.Windows.Navigation.FragmentNavigationEventHandler value) => __ProxyValue.add_FragmentNavigation(@value);
        public void remove_FragmentNavigation(System.Windows.Navigation.FragmentNavigationEventHandler value) => __ProxyValue.remove_FragmentNavigation(@value);
        public void add_NavigationStopped(System.Windows.Navigation.NavigationStoppedEventHandler value) => __ProxyValue.add_NavigationStopped(@value);
        public void remove_NavigationStopped(System.Windows.Navigation.NavigationStoppedEventHandler value) => __ProxyValue.remove_NavigationStopped(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}