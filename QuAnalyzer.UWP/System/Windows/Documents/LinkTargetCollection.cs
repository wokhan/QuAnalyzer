namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class LinkTargetCollection : Proxy<global::Windows.UI.Xaml.Documents.LinkTargetCollection>
    {
        public System.Windows.Documents.LinkTarget Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public System.Int32 Capacity
        {
            get => __ProxyValue.Capacity;
            set => __ProxyValue.Capacity = value;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public LinkTargetCollection(): base()
        {
        }

        public System.Int32 Add(System.Windows.Documents.LinkTarget value) => __ProxyValue.Add(@value);
        public void Remove(System.Windows.Documents.LinkTarget value) => __ProxyValue.Remove(@value);
        public System.Boolean Contains(System.Windows.Documents.LinkTarget value) => __ProxyValue.Contains(@value);
        public void CopyTo(System.Windows.Documents.LinkTarget[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Int32 IndexOf(System.Windows.Documents.LinkTarget value) => __ProxyValue.IndexOf(@value);
        public void Insert(System.Int32 index, System.Windows.Documents.LinkTarget value) => __ProxyValue.Insert(@index, @value);
        public void Clear() => __ProxyValue.Clear();
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public System.Collections.IEnumerator GetEnumerator() => __ProxyValue.GetEnumerator();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}