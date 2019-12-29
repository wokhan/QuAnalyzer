namespace System.Windows.Navigation
{
    using Uno.UI.Generic;

    public class RequestNavigateEventArgs : Proxy<global::Windows.UI.Xaml.Navigation.RequestNavigateEventArgs>
    {
        public System.Uri Uri
        {
            get => __ProxyValue.Uri;
        }

        public System.String Target
        {
            get => __ProxyValue.Target;
        }

        public System.Windows.RoutedEvent RoutedEvent
        {
            get => __ProxyValue.RoutedEvent;
            set => __ProxyValue.RoutedEvent = value;
        }

        public System.Boolean Handled
        {
            get => __ProxyValue.Handled;
            set => __ProxyValue.Handled = value;
        }

        public System.Object Source
        {
            get => __ProxyValue.Source;
            set => __ProxyValue.Source = value;
        }

        public System.Object OriginalSource
        {
            get => __ProxyValue.OriginalSource;
        }

        public RequestNavigateEventArgs(System.Uri @uri, System.String @target): base(@uri, @target)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}