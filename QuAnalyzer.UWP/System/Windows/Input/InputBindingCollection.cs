namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InputBindingCollection : Proxy<global::Windows.UI.Xaml.Input.InputBindingCollection>
    {
        public System.Windows.Input.InputBinding Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public System.Boolean IsSynchronized
        {
            get => __ProxyValue.IsSynchronized;
        }

        public System.Boolean IsFixedSize
        {
            get => __ProxyValue.IsFixedSize;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Object SyncRoot
        {
            get => __ProxyValue.SyncRoot;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public InputBindingCollection(): base()
        {
        }

        public InputBindingCollection(System.Collections.IList @inputBindings): base(@inputBindings)
        {
        }

        public System.Int32 Add(System.Windows.Input.InputBinding inputBinding) => __ProxyValue.Add(@inputBinding);
        public System.Int32 IndexOf(System.Windows.Input.InputBinding value) => __ProxyValue.IndexOf(@value);
        public void AddRange(System.Collections.ICollection collection) => __ProxyValue.AddRange(@collection);
        public void Insert(System.Int32 index, System.Windows.Input.InputBinding inputBinding) => __ProxyValue.Insert(@index, @inputBinding);
        public void Remove(System.Windows.Input.InputBinding inputBinding) => __ProxyValue.Remove(@inputBinding);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public void Clear() => __ProxyValue.Clear();
        public System.Collections.IEnumerator GetEnumerator() => __ProxyValue.GetEnumerator();
        public System.Boolean Contains(System.Windows.Input.InputBinding key) => __ProxyValue.Contains(@key);
        public void CopyTo(System.Windows.Input.InputBinding[] inputBindings, System.Int32 index) => __ProxyValue.CopyTo(@inputBindings, @index);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}