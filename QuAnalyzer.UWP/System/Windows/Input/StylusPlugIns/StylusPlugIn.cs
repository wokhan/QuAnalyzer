namespace System.Windows.Input.StylusPlugIns
{
    using Uno.UI.Generic;

    public class StylusPlugIn : Proxy<global::Windows.UI.Xaml.Input.StylusPlugIns.StylusPlugIn>
    {
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

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}