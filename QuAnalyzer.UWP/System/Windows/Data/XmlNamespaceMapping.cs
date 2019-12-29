namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class XmlNamespaceMapping : Proxy<global::Windows.UI.Xaml.Data.XmlNamespaceMapping>
    {
        public System.String Prefix
        {
            get => __ProxyValue.Prefix;
            set => __ProxyValue.Prefix = value;
        }

        public System.Uri Uri
        {
            get => __ProxyValue.Uri;
            set => __ProxyValue.Uri = value;
        }

        public XmlNamespaceMapping(): base()
        {
        }

        public XmlNamespaceMapping(System.String @prefix, System.Uri @uri): base(@prefix, @uri)
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public static System.Boolean op_Equality(System.Windows.Data.XmlNamespaceMapping mappingA, System.Windows.Data.XmlNamespaceMapping mappingB) => Windows.UI.Xaml.Data.XmlNamespaceMapping.op_Equality(@mappingA, @mappingB);
        public static System.Boolean op_Inequality(System.Windows.Data.XmlNamespaceMapping mappingA, System.Windows.Data.XmlNamespaceMapping mappingB) => Windows.UI.Xaml.Data.XmlNamespaceMapping.op_Inequality(@mappingA, @mappingB);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}