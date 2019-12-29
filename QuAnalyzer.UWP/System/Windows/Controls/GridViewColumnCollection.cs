namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class GridViewColumnCollection : Proxy<global::Windows.UI.Xaml.Controls.GridViewColumnCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Windows.Controls.GridViewColumn Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public GridViewColumnCollection(): base()
        {
        }

        public void Move(System.Int32 oldIndex, System.Int32 newIndex) => __ProxyValue.Move(@oldIndex, @newIndex);
        public void add_CollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventHandler value) => __ProxyValue.add_CollectionChanged(@value);
        public void remove_CollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventHandler value) => __ProxyValue.remove_CollectionChanged(@value);
        public void Add(System.Windows.Controls.GridViewColumn item) => __ProxyValue.Add(@item);
        public void Clear() => __ProxyValue.Clear();
        public void CopyTo(System.Windows.Controls.GridViewColumn[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Boolean Contains(System.Windows.Controls.GridViewColumn item) => __ProxyValue.Contains(@item);
        public System.Collections.Generic.IEnumerator<System.Windows.Controls.GridViewColumn> GetEnumerator() => __ProxyValue.GetEnumerator();
        public System.Int32 IndexOf(System.Windows.Controls.GridViewColumn item) => __ProxyValue.IndexOf(@item);
        public void Insert(System.Int32 index, System.Windows.Controls.GridViewColumn item) => __ProxyValue.Insert(@index, @item);
        public System.Boolean Remove(System.Windows.Controls.GridViewColumn item) => __ProxyValue.Remove(@item);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}