namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class InkCanvasStrokeCollectedEventArgs : Proxy<global::Windows.UI.Xaml.Controls.InkCanvasStrokeCollectedEventArgs>
    {
        public System.Windows.Ink.Stroke Stroke
        {
            get => __ProxyValue.Stroke;
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

        public InkCanvasStrokeCollectedEventArgs(System.Windows.Ink.Stroke @stroke): base(@stroke)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}