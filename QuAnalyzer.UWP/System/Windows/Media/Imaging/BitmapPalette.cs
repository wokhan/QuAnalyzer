namespace System.Windows.Media.Imaging
{
    using Uno.UI.Generic;

    public class BitmapPalette : Proxy<global::Windows.UI.Xaml.Media.Imaging.BitmapPalette>
    {
        public System.Collections.Generic.IList<System.Windows.Media.Color> Colors
        {
            get => __ProxyValue.Colors;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public BitmapPalette(System.Collections.Generic.IList<System.Windows.Media.Color> @colors): base(@colors)
        {
        }

        public BitmapPalette(System.Windows.Media.Imaging.BitmapSource @bitmapSource, System.Int32 @maxColorCount): base(@bitmapSource, @maxColorCount)
        {
        }

        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}