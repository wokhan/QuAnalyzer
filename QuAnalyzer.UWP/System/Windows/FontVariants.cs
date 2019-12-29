namespace System.Windows
{
    using Uno.UI.Generic;

    public class FontVariants : Proxy<global::Windows.UI.Xaml.FontVariants>
    {
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Boolean HasFlag(System.Enum flag) => __ProxyValue.HasFlag(@flag);
        public System.Int32 CompareTo(System.Object target) => __ProxyValue.CompareTo(@target);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.String format, System.IFormatProvider provider) => __ProxyValue.ToString(@format, @provider);
        public System.String ToString(System.String format) => __ProxyValue.ToString(@format);
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
        public System.TypeCode GetTypeCode() => __ProxyValue.GetTypeCode();
    }
}