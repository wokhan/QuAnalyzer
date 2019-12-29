namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class CleanUpVirtualizedItemEventArgs : Proxy<global::Windows.UI.Xaml.Controls.CleanUpVirtualizedItemEventArgs>
    {
        public System.Object Value
        {
            get => __ProxyValue.Value;
        }

        public System.Windows.UIElement UIElement
        {
            get => __ProxyValue.UIElement;
        }

        public System.Boolean Cancel
        {
            get => __ProxyValue.Cancel;
            set => __ProxyValue.Cancel = value;
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

        public CleanUpVirtualizedItemEventArgs(System.Object @value, System.Windows.UIElement @element): base(@value, @element)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}