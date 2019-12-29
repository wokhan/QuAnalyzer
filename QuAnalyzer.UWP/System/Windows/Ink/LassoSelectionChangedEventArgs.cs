namespace System.Windows.Ink
{
    using Uno.UI.Generic;

    public class LassoSelectionChangedEventArgs : Proxy<global::Windows.UI.Xaml.Ink.LassoSelectionChangedEventArgs>
    {
        public System.Windows.Ink.StrokeCollection SelectedStrokes
        {
            get => __ProxyValue.SelectedStrokes;
        }

        public System.Windows.Ink.StrokeCollection DeselectedStrokes
        {
            get => __ProxyValue.DeselectedStrokes;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}