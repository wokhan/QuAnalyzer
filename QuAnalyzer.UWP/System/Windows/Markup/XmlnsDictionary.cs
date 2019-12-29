namespace System.Windows.Markup
{
    using Uno.UI.Generic;

    public class XmlnsDictionary : Proxy<global::Windows.UI.Xaml.Markup.XmlnsDictionary>
    {
        public System.Boolean IsFixedSize
        {
            get => __ProxyValue.IsFixedSize;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.String Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public System.Collections.ICollection Keys
        {
            get => __ProxyValue.Keys;
        }

        public System.Collections.ICollection Values
        {
            get => __ProxyValue.Values;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsSynchronized
        {
            get => __ProxyValue.IsSynchronized;
        }

        public System.Object SyncRoot
        {
            get => __ProxyValue.SyncRoot;
        }

        public System.Boolean Sealed
        {
            get => __ProxyValue.Sealed;
        }

        public XmlnsDictionary(): base()
        {
        }

        public XmlnsDictionary(System.Windows.Markup.XmlnsDictionary @xmlnsDictionary): base(@xmlnsDictionary)
        {
        }

        public void Add(System.Object prefix, System.Object xmlNamespace) => __ProxyValue.Add(@prefix, @xmlNamespace);
        public void Add(System.String prefix, System.String xmlNamespace) => __ProxyValue.Add(@prefix, @xmlNamespace);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(System.Object key) => __ProxyValue.Contains(@key);
        public void Remove(System.String prefix) => __ProxyValue.Remove(@prefix);
        public void Remove(System.Object prefix) => __ProxyValue.Remove(@prefix);
        public void CopyTo(System.Collections.DictionaryEntry[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public void CopyTo(System.Array array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.String GetNamespace(System.String prefix) => __ProxyValue.GetNamespace(@prefix);
        public System.Collections.Generic.IEnumerable<System.Xaml.NamespaceDeclaration> GetNamespacePrefixes() => __ProxyValue.GetNamespacePrefixes();
        public void Seal() => __ProxyValue.Seal();
        public System.String LookupNamespace(System.String prefix) => __ProxyValue.LookupNamespace(@prefix);
        public System.String LookupPrefix(System.String xmlNamespace) => __ProxyValue.LookupPrefix(@xmlNamespace);
        public System.String DefaultNamespace() => __ProxyValue.DefaultNamespace();
        public void PushScope() => __ProxyValue.PushScope();
        public void PopScope() => __ProxyValue.PopScope();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}