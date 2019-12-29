namespace System.Windows.Markup
{
    using Uno.UI.Generic;

    public class NamespaceMapEntry : Proxy<global::Windows.UI.Xaml.Markup.NamespaceMapEntry>
    {
        public System.String XmlNamespace
        {
            get => __ProxyValue.XmlNamespace;
            set => __ProxyValue.XmlNamespace = value;
        }

        public System.String AssemblyName
        {
            get => __ProxyValue.AssemblyName;
            set => __ProxyValue.AssemblyName = value;
        }

        public System.String ClrNamespace
        {
            get => __ProxyValue.ClrNamespace;
            set => __ProxyValue.ClrNamespace = value;
        }

        public NamespaceMapEntry(): base()
        {
        }

        public NamespaceMapEntry(System.String @xmlNamespace, System.String @assemblyName, System.String @clrNamespace): base(@xmlNamespace, @assemblyName, @clrNamespace)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}