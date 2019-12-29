namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class CommandBindingCollection : Proxy<global::Windows.UI.Xaml.Input.CommandBindingCollection>
    {
        public System.Windows.Input.CommandBinding Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public System.Boolean IsFixedSize
        {
            get => __ProxyValue.IsFixedSize;
        }

        public System.Boolean IsSynchronized
        {
            get => __ProxyValue.IsSynchronized;
        }

        public System.Object SyncRoot
        {
            get => __ProxyValue.SyncRoot;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public CommandBindingCollection(): base()
        {
        }

        public CommandBindingCollection(System.Collections.IList @commandBindings): base(@commandBindings)
        {
        }

        public System.Int32 Add(System.Windows.Input.CommandBinding commandBinding) => __ProxyValue.Add(@commandBinding);
        public void AddRange(System.Collections.ICollection collection) => __ProxyValue.AddRange(@collection);
        public void Insert(System.Int32 index, System.Windows.Input.CommandBinding commandBinding) => __ProxyValue.Insert(@index, @commandBinding);
        public void Remove(System.Windows.Input.CommandBinding commandBinding) => __ProxyValue.Remove(@commandBinding);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public void Clear() => __ProxyValue.Clear();
        public System.Int32 IndexOf(System.Windows.Input.CommandBinding value) => __ProxyValue.IndexOf(@value);
        public System.Boolean Contains(System.Windows.Input.CommandBinding commandBinding) => __ProxyValue.Contains(@commandBinding);
        public void CopyTo(System.Windows.Input.CommandBinding[] commandBindings, System.Int32 index) => __ProxyValue.CopyTo(@commandBindings, @index);
        public System.Collections.IEnumerator GetEnumerator() => __ProxyValue.GetEnumerator();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}