namespace System.Windows
{
    using Uno.UI.Generic;

    public class TriggerActionCollection : Proxy<global::Windows.UI.Xaml.TriggerActionCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.Windows.TriggerAction Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public TriggerActionCollection(): base()
        {
        }

        public TriggerActionCollection(System.Int32 @initialSize): base(@initialSize)
        {
        }

        public void Clear() => __ProxyValue.Clear();
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public void Add(System.Windows.TriggerAction value) => __ProxyValue.Add(@value);
        public System.Boolean Contains(System.Windows.TriggerAction value) => __ProxyValue.Contains(@value);
        public void CopyTo(System.Windows.TriggerAction[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Int32 IndexOf(System.Windows.TriggerAction value) => __ProxyValue.IndexOf(@value);
        public void Insert(System.Int32 index, System.Windows.TriggerAction value) => __ProxyValue.Insert(@index, @value);
        public System.Boolean Remove(System.Windows.TriggerAction value) => __ProxyValue.Remove(@value);
        public System.Collections.Generic.IEnumerator<System.Windows.TriggerAction> GetEnumerator() => __ProxyValue.GetEnumerator();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}