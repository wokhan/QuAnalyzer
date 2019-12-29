namespace System.Windows.Input.StylusWisp
{
    using Uno.UI.Generic;

    public class WispTabletDeviceCollection : Proxy<global::Windows.UI.Xaml.Input.StylusWisp.WispTabletDeviceCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Windows.Input.TabletDevice Item
        {
            get => __ProxyValue.Item;
        }

        public System.Object SyncRoot
        {
            get => __ProxyValue.SyncRoot;
        }

        public System.Boolean IsSynchronized
        {
            get => __ProxyValue.IsSynchronized;
        }

        public void CopyTo(System.Windows.Input.TabletDevice[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}