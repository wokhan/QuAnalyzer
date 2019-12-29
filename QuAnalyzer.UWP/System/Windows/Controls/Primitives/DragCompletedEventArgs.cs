namespace System.Windows.Controls.Primitives
{
    using Uno.UI.Generic;

    public class DragCompletedEventArgs : Proxy<global::Windows.UI.Xaml.Controls.Primitives.DragCompletedEventArgs>
    {
        public System.Double HorizontalChange
        {
            get => __ProxyValue.HorizontalChange;
        }

        public System.Double VerticalChange
        {
            get => __ProxyValue.VerticalChange;
        }

        public System.Boolean Canceled
        {
            get => __ProxyValue.Canceled;
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

        public DragCompletedEventArgs(System.Double @horizontalChange, System.Double @verticalChange, System.Boolean @canceled): base(@horizontalChange, @verticalChange, @canceled)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}