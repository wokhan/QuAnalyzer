namespace System.Windows.Controls.Primitives
{
    using Uno.UI.Generic;

    public class LayoutInformation : Proxy<global::Windows.UI.Xaml.Controls.Primitives.LayoutInformation>
    {
        public static System.Windows.Rect GetLayoutSlot(System.Windows.FrameworkElement element) => Windows.UI.Xaml.Controls.Primitives.LayoutInformation.GetLayoutSlot(@element);
        public static System.Windows.Media.Geometry GetLayoutClip(System.Windows.FrameworkElement element) => Windows.UI.Xaml.Controls.Primitives.LayoutInformation.GetLayoutClip(@element);
        public static System.Windows.UIElement GetLayoutExceptionElement(System.Windows.Threading.Dispatcher dispatcher) => Windows.UI.Xaml.Controls.Primitives.LayoutInformation.GetLayoutExceptionElement(@dispatcher);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}