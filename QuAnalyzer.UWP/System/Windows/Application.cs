namespace System.Windows
{
    using Uno.UI.Generic;

    public class Application : Proxy<global::Windows.UI.Xaml.Application>
    {
        public static System.Windows.Application Current
        {
            get => __ProxyValue.Current;
        }

        public System.Windows.WindowCollection Windows
        {
            get => __ProxyValue.Windows;
        }

        public System.Windows.Window MainWindow
        {
            get => __ProxyValue.MainWindow;
            set => __ProxyValue.MainWindow = value;
        }

        public System.Windows.ShutdownMode ShutdownMode
        {
            get => __ProxyValue.ShutdownMode;
            set => __ProxyValue.ShutdownMode = value;
        }

        public System.Windows.ResourceDictionary Resources
        {
            get => __ProxyValue.Resources;
            set => __ProxyValue.Resources = value;
        }

        public System.Uri StartupUri
        {
            get => __ProxyValue.StartupUri;
            set => __ProxyValue.StartupUri = value;
        }

        public System.Collections.IDictionary Properties
        {
            get => __ProxyValue.Properties;
        }

        public static System.Reflection.Assembly ResourceAssembly
        {
            get => __ProxyValue.ResourceAssembly;
            set => __ProxyValue.ResourceAssembly = value;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public Application(): base()
        {
        }

        public System.Int32 Run() => __ProxyValue.Run();
        public System.Int32 Run(System.Windows.Window window) => __ProxyValue.Run(@window);
        public void Shutdown() => __ProxyValue.Shutdown();
        public void Shutdown(System.Int32 exitCode) => __ProxyValue.Shutdown(@exitCode);
        public System.Object FindResource(System.Object resourceKey) => __ProxyValue.FindResource(@resourceKey);
        public System.Object TryFindResource(System.Object resourceKey) => __ProxyValue.TryFindResource(@resourceKey);
        public static void LoadComponent(System.Object component, System.Uri resourceLocator) => Windows.UI.Xaml.Application.LoadComponent(@component, @resourceLocator);
        public static System.Object LoadComponent(System.Uri resourceLocator) => Windows.UI.Xaml.Application.LoadComponent(@resourceLocator);
        public static System.Windows.Resources.StreamResourceInfo GetResourceStream(System.Uri uriResource) => Windows.UI.Xaml.Application.GetResourceStream(@uriResource);
        public static System.Windows.Resources.StreamResourceInfo GetContentStream(System.Uri uriContent) => Windows.UI.Xaml.Application.GetContentStream(@uriContent);
        public static System.Windows.Resources.StreamResourceInfo GetRemoteStream(System.Uri uriRemote) => Windows.UI.Xaml.Application.GetRemoteStream(@uriRemote);
        public static System.String GetCookie(System.Uri uri) => Windows.UI.Xaml.Application.GetCookie(@uri);
        public static void SetCookie(System.Uri uri, System.String value) => Windows.UI.Xaml.Application.SetCookie(@uri, @value);
        public void add_Startup(System.Windows.StartupEventHandler value) => __ProxyValue.add_Startup(@value);
        public void remove_Startup(System.Windows.StartupEventHandler value) => __ProxyValue.remove_Startup(@value);
        public void add_Exit(System.Windows.ExitEventHandler value) => __ProxyValue.add_Exit(@value);
        public void remove_Exit(System.Windows.ExitEventHandler value) => __ProxyValue.remove_Exit(@value);
        public void add_Activated(System.EventHandler value) => __ProxyValue.add_Activated(@value);
        public void remove_Activated(System.EventHandler value) => __ProxyValue.remove_Activated(@value);
        public void add_Deactivated(System.EventHandler value) => __ProxyValue.add_Deactivated(@value);
        public void remove_Deactivated(System.EventHandler value) => __ProxyValue.remove_Deactivated(@value);
        public void add_SessionEnding(System.Windows.SessionEndingCancelEventHandler value) => __ProxyValue.add_SessionEnding(@value);
        public void remove_SessionEnding(System.Windows.SessionEndingCancelEventHandler value) => __ProxyValue.remove_SessionEnding(@value);
        public void add_DispatcherUnhandledException(System.Windows.Threading.DispatcherUnhandledExceptionEventHandler value) => __ProxyValue.add_DispatcherUnhandledException(@value);
        public void remove_DispatcherUnhandledException(System.Windows.Threading.DispatcherUnhandledExceptionEventHandler value) => __ProxyValue.remove_DispatcherUnhandledException(@value);
        public void add_Navigating(System.Windows.Navigation.NavigatingCancelEventHandler value) => __ProxyValue.add_Navigating(@value);
        public void remove_Navigating(System.Windows.Navigation.NavigatingCancelEventHandler value) => __ProxyValue.remove_Navigating(@value);
        public void add_Navigated(System.Windows.Navigation.NavigatedEventHandler value) => __ProxyValue.add_Navigated(@value);
        public void remove_Navigated(System.Windows.Navigation.NavigatedEventHandler value) => __ProxyValue.remove_Navigated(@value);
        public void add_NavigationProgress(System.Windows.Navigation.NavigationProgressEventHandler value) => __ProxyValue.add_NavigationProgress(@value);
        public void remove_NavigationProgress(System.Windows.Navigation.NavigationProgressEventHandler value) => __ProxyValue.remove_NavigationProgress(@value);
        public void add_NavigationFailed(System.Windows.Navigation.NavigationFailedEventHandler value) => __ProxyValue.add_NavigationFailed(@value);
        public void remove_NavigationFailed(System.Windows.Navigation.NavigationFailedEventHandler value) => __ProxyValue.remove_NavigationFailed(@value);
        public void add_LoadCompleted(System.Windows.Navigation.LoadCompletedEventHandler value) => __ProxyValue.add_LoadCompleted(@value);
        public void remove_LoadCompleted(System.Windows.Navigation.LoadCompletedEventHandler value) => __ProxyValue.remove_LoadCompleted(@value);
        public void add_NavigationStopped(System.Windows.Navigation.NavigationStoppedEventHandler value) => __ProxyValue.add_NavigationStopped(@value);
        public void remove_NavigationStopped(System.Windows.Navigation.NavigationStoppedEventHandler value) => __ProxyValue.remove_NavigationStopped(@value);
        public void add_FragmentNavigation(System.Windows.Navigation.FragmentNavigationEventHandler value) => __ProxyValue.add_FragmentNavigation(@value);
        public void remove_FragmentNavigation(System.Windows.Navigation.FragmentNavigationEventHandler value) => __ProxyValue.remove_FragmentNavigation(@value);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}