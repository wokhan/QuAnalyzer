namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class ScrollChangedEventArgs : Proxy<global::Windows.UI.Xaml.Controls.ScrollChangedEventArgs>
    {
        public System.Double HorizontalOffset
        {
            get => __ProxyValue.HorizontalOffset;
        }

        public System.Double VerticalOffset
        {
            get => __ProxyValue.VerticalOffset;
        }

        public System.Double HorizontalChange
        {
            get => __ProxyValue.HorizontalChange;
        }

        public System.Double VerticalChange
        {
            get => __ProxyValue.VerticalChange;
        }

        public System.Double ViewportWidth
        {
            get => __ProxyValue.ViewportWidth;
        }

        public System.Double ViewportHeight
        {
            get => __ProxyValue.ViewportHeight;
        }

        public System.Double ViewportWidthChange
        {
            get => __ProxyValue.ViewportWidthChange;
        }

        public System.Double ViewportHeightChange
        {
            get => __ProxyValue.ViewportHeightChange;
        }

        public System.Double ExtentWidth
        {
            get => __ProxyValue.ExtentWidth;
        }

        public System.Double ExtentHeight
        {
            get => __ProxyValue.ExtentHeight;
        }

        public System.Double ExtentWidthChange
        {
            get => __ProxyValue.ExtentWidthChange;
        }

        public System.Double ExtentHeightChange
        {
            get => __ProxyValue.ExtentHeightChange;
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