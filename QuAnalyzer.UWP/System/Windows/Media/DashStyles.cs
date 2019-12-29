namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class DashStyles : Proxy<global::Windows.UI.Xaml.Media.DashStyles>
    {
        public static System.Windows.Media.DashStyle Solid
        {
            get => __ProxyValue.Solid;
        }

        public static System.Windows.Media.DashStyle Dash
        {
            get => __ProxyValue.Dash;
        }

        public static System.Windows.Media.DashStyle Dot
        {
            get => __ProxyValue.Dot;
        }

        public static System.Windows.Media.DashStyle DashDot
        {
            get => __ProxyValue.DashDot;
        }

        public static System.Windows.Media.DashStyle DashDotDot
        {
            get => __ProxyValue.DashDotDot;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}