namespace System.Windows
{
    using Uno.UI.Generic;

    public class LostFocusEventManager : Proxy<global::Windows.UI.Xaml.LostFocusEventManager>
    {
        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public static void AddListener(System.Windows.DependencyObject source, System.Windows.IWeakEventListener listener) => Windows.UI.Xaml.LostFocusEventManager.AddListener(@source, @listener);
        public static void RemoveListener(System.Windows.DependencyObject source, System.Windows.IWeakEventListener listener) => Windows.UI.Xaml.LostFocusEventManager.RemoveListener(@source, @listener);
        public static void AddHandler(System.Windows.DependencyObject source, System.EventHandler<System.Windows.RoutedEventArgs> handler) => Windows.UI.Xaml.LostFocusEventManager.AddHandler(@source, @handler);
        public static void RemoveHandler(System.Windows.DependencyObject source, System.EventHandler<System.Windows.RoutedEventArgs> handler) => Windows.UI.Xaml.LostFocusEventManager.RemoveHandler(@source, @handler);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}