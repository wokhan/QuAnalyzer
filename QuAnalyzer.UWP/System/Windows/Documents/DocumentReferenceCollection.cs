namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class DocumentReferenceCollection : Proxy<global::Windows.UI.Xaml.Documents.DocumentReferenceCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Windows.Documents.DocumentReference Item
        {
            get => __ProxyValue.Item;
        }

        public System.Collections.Generic.IEnumerator<System.Windows.Documents.DocumentReference> GetEnumerator() => __ProxyValue.GetEnumerator();
        public void Add(System.Windows.Documents.DocumentReference item) => __ProxyValue.Add(@item);
        public void CopyTo(System.Windows.Documents.DocumentReference[] array, System.Int32 arrayIndex) => __ProxyValue.CopyTo(@array, @arrayIndex);
        public void add_CollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventHandler value) => __ProxyValue.add_CollectionChanged(@value);
        public void remove_CollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventHandler value) => __ProxyValue.remove_CollectionChanged(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}