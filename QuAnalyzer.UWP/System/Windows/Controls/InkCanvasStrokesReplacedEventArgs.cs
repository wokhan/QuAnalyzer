namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class InkCanvasStrokesReplacedEventArgs : Proxy<global::Windows.UI.Xaml.Controls.InkCanvasStrokesReplacedEventArgs>
    {
        public System.Windows.Ink.StrokeCollection NewStrokes
        {
            get => __ProxyValue.NewStrokes;
        }

        public System.Windows.Ink.StrokeCollection PreviousStrokes
        {
            get => __ProxyValue.PreviousStrokes;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}