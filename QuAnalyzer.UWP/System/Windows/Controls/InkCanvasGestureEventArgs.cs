namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class InkCanvasGestureEventArgs : Proxy<global::Windows.UI.Xaml.Controls.InkCanvasGestureEventArgs>
    {
        public System.Windows.Ink.StrokeCollection Strokes
        {
            get => __ProxyValue.Strokes;
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

        public InkCanvasGestureEventArgs(System.Windows.Ink.StrokeCollection @strokes, System.Collections.Generic.IEnumerable<System.Windows.Ink.GestureRecognitionResult> @gestureRecognitionResults): base(@strokes, @gestureRecognitionResults)
        {
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.Ink.GestureRecognitionResult> GetGestureRecognitionResults() => __ProxyValue.GetGestureRecognitionResults();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}