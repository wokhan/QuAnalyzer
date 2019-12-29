namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class ColumnDefinitionCollection : Proxy<global::Windows.UI.Xaml.Controls.ColumnDefinitionCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.Boolean IsSynchronized
        {
            get => __ProxyValue.IsSynchronized;
        }

        public System.Object SyncRoot
        {
            get => __ProxyValue.SyncRoot;
        }

        public System.Windows.Controls.ColumnDefinition Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public void CopyTo(System.Windows.Controls.ColumnDefinition[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public void Add(System.Windows.Controls.ColumnDefinition value) => __ProxyValue.Add(@value);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(System.Windows.Controls.ColumnDefinition value) => __ProxyValue.Contains(@value);
        public System.Int32 IndexOf(System.Windows.Controls.ColumnDefinition value) => __ProxyValue.IndexOf(@value);
        public void Insert(System.Int32 index, System.Windows.Controls.ColumnDefinition value) => __ProxyValue.Insert(@index, @value);
        public System.Boolean Remove(System.Windows.Controls.ColumnDefinition value) => __ProxyValue.Remove(@value);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public void RemoveRange(System.Int32 index, System.Int32 count) => __ProxyValue.RemoveRange(@index, @count);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}