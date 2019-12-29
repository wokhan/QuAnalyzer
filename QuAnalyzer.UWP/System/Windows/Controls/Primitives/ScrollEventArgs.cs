namespace System.Windows.Controls.Primitives
{
    using Uno.UI.Generic;

    public class ScrollEventArgs : Proxy<global::Windows.UI.Xaml.Controls.Primitives.ScrollEventArgs>
    {
        public System.Windows.Controls.Primitives.ScrollEventType ScrollEventType
        {
            get => __ProxyValue.ScrollEventType;
        }

        public System.Double NewValue
        {
            get => __ProxyValue.NewValue;
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

        public ScrollEventArgs(System.Windows.Controls.Primitives.ScrollEventType @scrollEventType, System.Double @newValue): base(@scrollEventType, @newValue)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}