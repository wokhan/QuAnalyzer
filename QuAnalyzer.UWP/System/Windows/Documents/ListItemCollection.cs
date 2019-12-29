namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class ListItemCollection : Proxy<global::Windows.UI.Xaml.Documents.ListItemCollection>
    {
        public System.Windows.Documents.ListItem FirstListItem
        {
            get => __ProxyValue.FirstListItem;
        }

        public System.Windows.Documents.ListItem LastListItem
        {
            get => __ProxyValue.LastListItem;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public void Add(System.Windows.Documents.ListItem item) => __ProxyValue.Add(@item);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(System.Windows.Documents.ListItem item) => __ProxyValue.Contains(@item);
        public void CopyTo(System.Windows.Documents.ListItem[] array, System.Int32 arrayIndex) => __ProxyValue.CopyTo(@array, @arrayIndex);
        public System.Boolean Remove(System.Windows.Documents.ListItem item) => __ProxyValue.Remove(@item);
        public void InsertAfter(System.Windows.Documents.ListItem previousSibling, System.Windows.Documents.ListItem newItem) => __ProxyValue.InsertAfter(@previousSibling, @newItem);
        public void InsertBefore(System.Windows.Documents.ListItem nextSibling, System.Windows.Documents.ListItem newItem) => __ProxyValue.InsertBefore(@nextSibling, @newItem);
        public void AddRange(System.Collections.IEnumerable range) => __ProxyValue.AddRange(@range);
        public System.Collections.Generic.IEnumerator<System.Windows.Documents.ListItem> GetEnumerator() => __ProxyValue.GetEnumerator();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}