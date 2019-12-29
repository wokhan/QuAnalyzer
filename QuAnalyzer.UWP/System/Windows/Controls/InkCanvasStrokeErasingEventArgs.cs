namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class InkCanvasStrokeErasingEventArgs : Proxy<global::Windows.UI.Xaml.Controls.InkCanvasStrokeErasingEventArgs>
    {
        public System.Windows.Ink.Stroke Stroke
        {
            get => __ProxyValue.Stroke;
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