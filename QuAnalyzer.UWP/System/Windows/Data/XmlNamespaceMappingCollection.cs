namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class XmlNamespaceMappingCollection : Proxy<global::Windows.UI.Xaml.Data.XmlNamespaceMappingCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.Xml.XmlNameTable NameTable
        {
            get => __ProxyValue.NameTable;
        }

        public System.String DefaultNamespace
        {
            get => __ProxyValue.DefaultNamespace;
        }

        public XmlNamespaceMappingCollection(): base()
        {
        }

        public void Add(System.Windows.Data.XmlNamespaceMapping mapping) => __ProxyValue.Add(@mapping);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(System.Windows.Data.XmlNamespaceMapping mapping) => __ProxyValue.Contains(@mapping);
        public void CopyTo(System.Windows.Data.XmlNamespaceMapping[] array, System.Int32 arrayIndex) => __ProxyValue.CopyTo(@array, @arrayIndex);
        public System.Boolean Remove(System.Windows.Data.XmlNamespaceMapping mapping) => __ProxyValue.Remove(@mapping);
        public System.Collections.IEnumerator GetEnumerator() => __ProxyValue.GetEnumerator();
        public void PushScope() => __ProxyValue.PushScope();
        public System.Boolean PopScope() => __ProxyValue.PopScope();
        public void AddNamespace(System.String prefix, System.String uri) => __ProxyValue.AddNamespace(@prefix, @uri);
        public void RemoveNamespace(System.String prefix, System.String uri) => __ProxyValue.RemoveNamespace(@prefix, @uri);
        public System.Collections.Generic.IDictionary<System.String, System.String> GetNamespacesInScope(System.Xml.XmlNamespaceScope scope) => __ProxyValue.GetNamespacesInScope(@scope);
        public System.String LookupNamespace(System.String prefix) => __ProxyValue.LookupNamespace(@prefix);
        public System.String LookupPrefix(System.String uri) => __ProxyValue.LookupPrefix(@uri);
        public System.Boolean HasNamespace(System.String prefix) => __ProxyValue.HasNamespace(@prefix);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}