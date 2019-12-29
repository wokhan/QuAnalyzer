namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class CompositeCollection : Proxy<global::Windows.UI.Xaml.Data.CompositeCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Object Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public CompositeCollection(): base()
        {
        }

        public CompositeCollection(System.Int32 @capacity): base(@capacity)
        {
        }

        public void CopyTo(System.Array array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Int32 Add(System.Object newItem) => __ProxyValue.Add(@newItem);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(System.Object containItem) => __ProxyValue.Contains(@containItem);
        public System.Int32 IndexOf(System.Object indexItem) => __ProxyValue.IndexOf(@indexItem);
        public void Insert(System.Int32 insertIndex, System.Object insertItem) => __ProxyValue.Insert(@insertIndex, @insertItem);
        public void Remove(System.Object removeItem) => __ProxyValue.Remove(@removeItem);
        public void RemoveAt(System.Int32 removeIndex) => __ProxyValue.RemoveAt(@removeIndex);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}