namespace System.Windows.Input.StylusPlugIns
{
    using Uno.UI.Generic;

    public class DynamicRenderer : Proxy<global::Windows.UI.Xaml.Input.StylusPlugIns.DynamicRenderer>
    {
        public System.Windows.Media.Visual RootVisual
        {
            get => __ProxyValue.RootVisual;
        }

        public System.Windows.Ink.DrawingAttributes DrawingAttributes
        {
            get => __ProxyValue.DrawingAttributes;
            set => __ProxyValue.DrawingAttributes = value;
        }

        public System.Windows.UIElement Element
        {
            get => __ProxyValue.Element;
        }

        public System.Windows.Rect ElementBounds
        {
            get => __ProxyValue.ElementBounds;
        }

        public System.Boolean Enabled
        {
            get => __ProxyValue.Enabled;
            set => __ProxyValue.Enabled = value;
        }

        public System.Boolean IsActiveForInput
        {
            get => __ProxyValue.IsActiveForInput;
        }

        public DynamicRenderer(): base()
        {
        }

        public void Reset(System.Windows.Input.StylusDevice stylusDevice, System.Windows.Input.StylusPointCollection stylusPoints) => __ProxyValue.Reset(@stylusDevice, @stylusPoints);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}