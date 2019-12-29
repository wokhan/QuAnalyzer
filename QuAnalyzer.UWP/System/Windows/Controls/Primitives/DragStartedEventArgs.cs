namespace System.Windows.Controls.Primitives
{
    using Uno.UI.Generic;

    public class DragStartedEventArgs : Proxy<global::Windows.UI.Xaml.Controls.Primitives.DragStartedEventArgs>
    {
        public System.Double HorizontalOffset
        {
            get => __ProxyValue.HorizontalOffset;
        }

        public System.Double VerticalOffset
        {
            get => __ProxyValue.VerticalOffset;
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

        public DragStartedEventArgs(System.Double @horizontalOffset, System.Double @verticalOffset): base(@horizontalOffset, @verticalOffset)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}