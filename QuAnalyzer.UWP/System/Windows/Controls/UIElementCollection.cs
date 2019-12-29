namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class UIElementCollection : Proxy<global::Windows.UI.Xaml.Controls.UIElementCollection>
    {
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

        public System.Int32 Capacity
        {
            get => __ProxyValue.Capacity;
            set => __ProxyValue.Capacity = value;
        }

        public System.Windows.UIElement Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public UIElementCollection(System.Windows.UIElement @visualParent, System.Windows.FrameworkElement @logicalParent): base(@visualParent, @logicalParent)
        {
        }

        public void CopyTo(System.Array array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public void CopyTo(System.Windows.UIElement[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Int32 Add(System.Windows.UIElement element) => __ProxyValue.Add(@element);
        public System.Int32 IndexOf(System.Windows.UIElement element) => __ProxyValue.IndexOf(@element);
        public void Remove(System.Windows.UIElement element) => __ProxyValue.Remove(@element);
        public System.Boolean Contains(System.Windows.UIElement element) => __ProxyValue.Contains(@element);
        public void Clear() => __ProxyValue.Clear();
        public void Insert(System.Int32 index, System.Windows.UIElement element) => __ProxyValue.Insert(@index, @element);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public void RemoveRange(System.Int32 index, System.Int32 count) => __ProxyValue.RemoveRange(@index, @count);
        public System.Collections.IEnumerator GetEnumerator() => __ProxyValue.GetEnumerator();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}