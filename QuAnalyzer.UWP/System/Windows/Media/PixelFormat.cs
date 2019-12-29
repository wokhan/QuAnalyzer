namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class PixelFormat : Proxy<global::Windows.UI.Xaml.Media.PixelFormat>
    {
        public System.Int32 BitsPerPixel
        {
            get => __ProxyValue.BitsPerPixel;
        }

        public System.Collections.Generic.IList<System.Windows.Media.PixelFormatChannelMask> Masks
        {
            get => __ProxyValue.Masks;
        }

        public static System.Boolean op_Equality(System.Windows.Media.PixelFormat left, System.Windows.Media.PixelFormat right) => Windows.UI.Xaml.Media.PixelFormat.op_Equality(@left, @right);
        public static System.Boolean op_Inequality(System.Windows.Media.PixelFormat left, System.Windows.Media.PixelFormat right) => Windows.UI.Xaml.Media.PixelFormat.op_Inequality(@left, @right);
        public static System.Boolean Equals(System.Windows.Media.PixelFormat left, System.Windows.Media.PixelFormat right) => Windows.UI.Xaml.Media.PixelFormat.Equals(@left, @right);
        public System.Boolean Equals(System.Windows.Media.PixelFormat pixelFormat) => __ProxyValue.Equals(@pixelFormat);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}