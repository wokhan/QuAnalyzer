namespace System.Windows
{
    using Uno.UI.Generic;

    public class SizeChangedEventArgs : Proxy<global::Windows.UI.Xaml.SizeChangedEventArgs>
    {
        public System.Windows.Size PreviousSize
        {
            get => __ProxyValue.PreviousSize;
        }

        public System.Windows.Size NewSize
        {
            get => __ProxyValue.NewSize;
        }

        public System.Boolean WidthChanged
        {
            get => __ProxyValue.WidthChanged;
        }

        public System.Boolean HeightChanged
        {
            get => __ProxyValue.HeightChanged;
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