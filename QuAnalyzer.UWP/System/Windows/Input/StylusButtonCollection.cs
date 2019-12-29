namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class StylusButtonCollection : Proxy<global::Windows.UI.Xaml.Input.StylusButtonCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Windows.Input.StylusButton Item
        {
            get => __ProxyValue.Item;
        }

        public System.Windows.Input.StylusButton GetStylusButtonByGuid(System.Guid guid) => __ProxyValue.GetStylusButtonByGuid(@guid);
        public System.Boolean Contains(System.Windows.Input.StylusButton value) => __ProxyValue.Contains(@value);
        public void CopyTo(System.Windows.Input.StylusButton[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Collections.Generic.IEnumerator<System.Windows.Input.StylusButton> GetEnumerator() => __ProxyValue.GetEnumerator();
        public System.Int32 IndexOf(System.Windows.Input.StylusButton value) => __ProxyValue.IndexOf(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}