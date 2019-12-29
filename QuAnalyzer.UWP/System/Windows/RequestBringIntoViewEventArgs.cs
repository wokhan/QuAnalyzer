namespace System.Windows
{
    using Uno.UI.Generic;

    public class RequestBringIntoViewEventArgs : Proxy<global::Windows.UI.Xaml.RequestBringIntoViewEventArgs>
    {
        public System.Windows.DependencyObject TargetObject
        {
            get => __ProxyValue.TargetObject;
        }

        public System.Windows.Rect TargetRect
        {
            get => __ProxyValue.TargetRect;
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

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}