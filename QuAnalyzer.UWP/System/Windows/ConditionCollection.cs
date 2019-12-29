namespace System.Windows
{
    using Uno.UI.Generic;

    public class ConditionCollection : Proxy<global::Windows.UI.Xaml.ConditionCollection>
    {
        public System.Boolean IsSealed
        {
            get => __ProxyValue.IsSealed;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Windows.Condition Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public ConditionCollection(): base()
        {
        }

        public void Add(System.Windows.Condition item) => __ProxyValue.Add(@item);
        public void Clear() => __ProxyValue.Clear();
        public void CopyTo(System.Windows.Condition[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Boolean Contains(System.Windows.Condition item) => __ProxyValue.Contains(@item);
        public System.Collections.Generic.IEnumerator<System.Windows.Condition> GetEnumerator() => __ProxyValue.GetEnumerator();
        public System.Int32 IndexOf(System.Windows.Condition item) => __ProxyValue.IndexOf(@item);
        public void Insert(System.Int32 index, System.Windows.Condition item) => __ProxyValue.Insert(@index, @item);
        public System.Boolean Remove(System.Windows.Condition item) => __ProxyValue.Remove(@item);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}