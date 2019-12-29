namespace System.Windows
{
    using Uno.UI.Generic;

    public class DpiScale : Proxy<global::Windows.UI.Xaml.DpiScale>
    {
        public System.Double DpiScaleX
        {
            get => __ProxyValue.DpiScaleX;
        }

        public System.Double DpiScaleY
        {
            get => __ProxyValue.DpiScaleY;
        }

        public System.Double PixelsPerDip
        {
            get => __ProxyValue.PixelsPerDip;
        }

        public System.Double PixelsPerInchX
        {
            get => __ProxyValue.PixelsPerInchX;
        }

        public System.Double PixelsPerInchY
        {
            get => __ProxyValue.PixelsPerInchY;
        }

        public DpiScale(System.Double @dpiScaleX, System.Double @dpiScaleY): base(@dpiScaleX, @dpiScaleY)
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}