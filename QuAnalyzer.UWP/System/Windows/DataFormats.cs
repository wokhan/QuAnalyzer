namespace System.Windows
{
    using Uno.UI.Generic;

    public class DataFormats : Proxy<global::Windows.UI.Xaml.DataFormats>
    {
        public static System.Windows.DataFormat GetDataFormat(System.Int32 id) => Windows.UI.Xaml.DataFormats.GetDataFormat(@id);
        public static System.Windows.DataFormat GetDataFormat(System.String format) => Windows.UI.Xaml.DataFormats.GetDataFormat(@format);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}