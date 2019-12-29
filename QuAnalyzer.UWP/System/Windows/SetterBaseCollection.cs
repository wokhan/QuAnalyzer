namespace System.Windows
{
    using Uno.UI.Generic;

    public class SetterBaseCollection : Proxy<global::Windows.UI.Xaml.SetterBaseCollection>
    {
        public System.Boolean IsSealed
        {
            get => __ProxyValue.IsSealed;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Windows.SetterBase Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public SetterBaseCollection(): base()
        {
        }

        public void Add(System.Windows.SetterBase item) => __ProxyValue.Add(@item);
        public void Clear() => __ProxyValue.Clear();
        public void CopyTo(System.Windows.SetterBase[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Boolean Contains(System.Windows.SetterBase item) => __ProxyValue.Contains(@item);
        public System.Collections.Generic.IEnumerator<System.Windows.SetterBase> GetEnumerator() => __ProxyValue.GetEnumerator();
        public System.Int32 IndexOf(System.Windows.SetterBase item) => __ProxyValue.IndexOf(@item);
        public void Insert(System.Int32 index, System.Windows.SetterBase item) => __ProxyValue.Insert(@index, @item);
        public System.Boolean Remove(System.Windows.SetterBase item) => __ProxyValue.Remove(@item);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}