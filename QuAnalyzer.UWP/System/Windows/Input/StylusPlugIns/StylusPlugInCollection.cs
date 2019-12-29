namespace System.Windows.Input.StylusPlugIns
{
    using Uno.UI.Generic;

    public class StylusPlugInCollection : Proxy<global::Windows.UI.Xaml.Input.StylusPlugIns.StylusPlugInCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Windows.Input.StylusPlugIns.StylusPlugIn Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public void Add(System.Windows.Input.StylusPlugIns.StylusPlugIn item) => __ProxyValue.Add(@item);
        public void Clear() => __ProxyValue.Clear();
        public void CopyTo(System.Windows.Input.StylusPlugIns.StylusPlugIn[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Boolean Contains(System.Windows.Input.StylusPlugIns.StylusPlugIn item) => __ProxyValue.Contains(@item);
        public System.Collections.Generic.IEnumerator<System.Windows.Input.StylusPlugIns.StylusPlugIn> GetEnumerator() => __ProxyValue.GetEnumerator();
        public System.Int32 IndexOf(System.Windows.Input.StylusPlugIns.StylusPlugIn item) => __ProxyValue.IndexOf(@item);
        public void Insert(System.Int32 index, System.Windows.Input.StylusPlugIns.StylusPlugIn item) => __ProxyValue.Insert(@index, @item);
        public System.Boolean Remove(System.Windows.Input.StylusPlugIns.StylusPlugIn item) => __ProxyValue.Remove(@item);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}