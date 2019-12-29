namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class InkCanvasSelectionEditingEventArgs : Proxy<global::Windows.UI.Xaml.Controls.InkCanvasSelectionEditingEventArgs>
    {
        public System.Windows.Rect OldRectangle
        {
            get => __ProxyValue.OldRectangle;
        }

        public System.Windows.Rect NewRectangle
        {
            get => __ProxyValue.NewRectangle;
            set => __ProxyValue.NewRectangle = value;
        }

        public System.Boolean Cancel
        {
            get => __ProxyValue.Cancel;
            set => __ProxyValue.Cancel = value;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}