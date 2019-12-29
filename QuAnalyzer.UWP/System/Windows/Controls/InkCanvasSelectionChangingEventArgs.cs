namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class InkCanvasSelectionChangingEventArgs : Proxy<global::Windows.UI.Xaml.Controls.InkCanvasSelectionChangingEventArgs>
    {
        public System.Boolean Cancel
        {
            get => __ProxyValue.Cancel;
            set => __ProxyValue.Cancel = value;
        }

        public void SetSelectedElements(System.Collections.Generic.IEnumerable<System.Windows.UIElement> selectedElements) => __ProxyValue.SetSelectedElements(@selectedElements);
        public System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.UIElement> GetSelectedElements() => __ProxyValue.GetSelectedElements();
        public void SetSelectedStrokes(System.Windows.Ink.StrokeCollection selectedStrokes) => __ProxyValue.SetSelectedStrokes(@selectedStrokes);
        public System.Windows.Ink.StrokeCollection GetSelectedStrokes() => __ProxyValue.GetSelectedStrokes();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}