namespace System.Windows
{
    using Uno.UI.Generic;

    public class WindowCollection : Proxy<global::Windows.UI.Xaml.WindowCollection>
    {
        public System.Windows.Window Item
        {
            get => __ProxyValue.Item;
        }

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

        public WindowCollection(): base()
        {
        }

        public System.Collections.IEnumerator GetEnumerator() => __ProxyValue.GetEnumerator();
        public void CopyTo(System.Windows.Window[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}