namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class BlockCollection : Proxy<global::Windows.UI.Xaml.Documents.BlockCollection>
    {
        public System.Windows.Documents.Block FirstBlock
        {
            get => __ProxyValue.FirstBlock;
        }

        public System.Windows.Documents.Block LastBlock
        {
            get => __ProxyValue.LastBlock;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public void Add(System.Windows.Documents.Block item) => __ProxyValue.Add(@item);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(System.Windows.Documents.Block item) => __ProxyValue.Contains(@item);
        public void CopyTo(System.Windows.Documents.Block[] array, System.Int32 arrayIndex) => __ProxyValue.CopyTo(@array, @arrayIndex);
        public System.Boolean Remove(System.Windows.Documents.Block item) => __ProxyValue.Remove(@item);
        public void InsertAfter(System.Windows.Documents.Block previousSibling, System.Windows.Documents.Block newItem) => __ProxyValue.InsertAfter(@previousSibling, @newItem);
        public void InsertBefore(System.Windows.Documents.Block nextSibling, System.Windows.Documents.Block newItem) => __ProxyValue.InsertBefore(@nextSibling, @newItem);
        public void AddRange(System.Collections.IEnumerable range) => __ProxyValue.AddRange(@range);
        public System.Collections.Generic.IEnumerator<System.Windows.Documents.Block> GetEnumerator() => __ProxyValue.GetEnumerator();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}