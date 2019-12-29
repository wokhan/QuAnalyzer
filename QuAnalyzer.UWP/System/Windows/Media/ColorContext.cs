namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class ColorContext : Proxy<global::Windows.UI.Xaml.Media.ColorContext>
    {
        public System.Uri ProfileUri
        {
            get => __ProxyValue.ProfileUri;
        }

        public ColorContext(System.Uri @profileUri): base(@profileUri)
        {
        }

        public ColorContext(System.Windows.Media.PixelFormat @pixelFormat): base(@pixelFormat)
        {
        }

        public System.IO.Stream OpenProfileStream() => __ProxyValue.OpenProfileStream();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Boolean op_Equality(System.Windows.Media.ColorContext context1, System.Windows.Media.ColorContext context2) => Windows.UI.Xaml.Media.ColorContext.op_Equality(@context1, @context2);
        public static System.Boolean op_Inequality(System.Windows.Media.ColorContext context1, System.Windows.Media.ColorContext context2) => Windows.UI.Xaml.Media.ColorContext.op_Inequality(@context1, @context2);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}