namespace System.Windows
{
    using Uno.UI.Generic;

    public class FontStyle : Proxy<global::Windows.UI.Xaml.FontStyle>
    {
        public static System.Boolean op_Equality(System.Windows.FontStyle left, System.Windows.FontStyle right) => Windows.UI.Xaml.FontStyle.op_Equality(@left, @right);
        public static System.Boolean op_Inequality(System.Windows.FontStyle left, System.Windows.FontStyle right) => Windows.UI.Xaml.FontStyle.op_Inequality(@left, @right);
        public System.Boolean Equals(System.Windows.FontStyle obj) => __ProxyValue.Equals(@obj);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}