namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class StylusDeviceCollection : Proxy<global::Windows.UI.Xaml.Input.StylusDeviceCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Windows.Input.StylusDevice Item
        {
            get => __ProxyValue.Item;
        }

        public System.Boolean Contains(System.Windows.Input.StylusDevice value) => __ProxyValue.Contains(@value);
        public void CopyTo(System.Windows.Input.StylusDevice[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Collections.Generic.IEnumerator<System.Windows.Input.StylusDevice> GetEnumerator() => __ProxyValue.GetEnumerator();
        public System.Int32 IndexOf(System.Windows.Input.StylusDevice value) => __ProxyValue.IndexOf(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}