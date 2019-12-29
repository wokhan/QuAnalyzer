namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class SelectedDatesCollection : Proxy<global::Windows.UI.Xaml.Controls.SelectedDatesCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.DateTime Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public SelectedDatesCollection(System.Windows.Controls.Calendar @owner): base(@owner)
        {
        }

        public void AddRange(System.DateTime start, System.DateTime end) => __ProxyValue.AddRange(@start, @end);
        public void Move(System.Int32 oldIndex, System.Int32 newIndex) => __ProxyValue.Move(@oldIndex, @newIndex);
        public void add_CollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventHandler value) => __ProxyValue.add_CollectionChanged(@value);
        public void remove_CollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventHandler value) => __ProxyValue.remove_CollectionChanged(@value);
        public void Add(System.DateTime item) => __ProxyValue.Add(@item);
        public void Clear() => __ProxyValue.Clear();
        public void CopyTo(System.DateTime[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Boolean Contains(System.DateTime item) => __ProxyValue.Contains(@item);
        public System.Collections.Generic.IEnumerator<System.DateTime> GetEnumerator() => __ProxyValue.GetEnumerator();
        public System.Int32 IndexOf(System.DateTime item) => __ProxyValue.IndexOf(@item);
        public void Insert(System.Int32 index, System.DateTime item) => __ProxyValue.Insert(@index, @item);
        public System.Boolean Remove(System.DateTime item) => __ProxyValue.Remove(@item);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}