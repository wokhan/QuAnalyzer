namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class PixelFormatChannelMask : Proxy<global::Windows.UI.Xaml.Media.PixelFormatChannelMask>
    {
        public System.Collections.Generic.IList<System.Byte> Mask
        {
            get => __ProxyValue.Mask;
        }

        public static System.Boolean op_Equality(System.Windows.Media.PixelFormatChannelMask left, System.Windows.Media.PixelFormatChannelMask right) => Windows.UI.Xaml.Media.PixelFormatChannelMask.op_Equality(@left, @right);
        public static System.Boolean Equals(System.Windows.Media.PixelFormatChannelMask left, System.Windows.Media.PixelFormatChannelMask right) => Windows.UI.Xaml.Media.PixelFormatChannelMask.Equals(@left, @right);
        public static System.Boolean op_Inequality(System.Windows.Media.PixelFormatChannelMask left, System.Windows.Media.PixelFormatChannelMask right) => Windows.UI.Xaml.Media.PixelFormatChannelMask.op_Inequality(@left, @right);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}