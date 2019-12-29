namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class VisualCollection : Proxy<global::Windows.UI.Xaml.Media.VisualCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.Boolean IsSynchronized
        {
            get => __ProxyValue.IsSynchronized;
        }

        public System.Object SyncRoot
        {
            get => __ProxyValue.SyncRoot;
        }

        public System.Int32 Capacity
        {
            get => __ProxyValue.Capacity;
            set => __ProxyValue.Capacity = value;
        }

        public System.Windows.Media.Visual Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public VisualCollection(System.Windows.Media.Visual @parent): base(@parent)
        {
        }

        public void CopyTo(System.Array array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public void CopyTo(System.Windows.Media.Visual[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Int32 Add(System.Windows.Media.Visual visual) => __ProxyValue.Add(@visual);
        public System.Int32 IndexOf(System.Windows.Media.Visual visual) => __ProxyValue.IndexOf(@visual);
        public void Remove(System.Windows.Media.Visual visual) => __ProxyValue.Remove(@visual);
        public System.Boolean Contains(System.Windows.Media.Visual visual) => __ProxyValue.Contains(@visual);
        public void Clear() => __ProxyValue.Clear();
        public void Insert(System.Int32 index, System.Windows.Media.Visual visual) => __ProxyValue.Insert(@index, @visual);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public void RemoveRange(System.Int32 index, System.Int32 count) => __ProxyValue.RemoveRange(@index, @count);
        public System.Windows.Media.Enumerator GetEnumerator() => __ProxyValue.GetEnumerator();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}