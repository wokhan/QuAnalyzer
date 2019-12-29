namespace System.Windows
{
    using Uno.UI.Generic;

    public class NameScope : Proxy<global::Windows.UI.Xaml.NameScope>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.Object Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public System.Collections.Generic.ICollection<System.String> Keys
        {
            get => __ProxyValue.Keys;
        }

        public System.Collections.Generic.ICollection<System.Object> Values
        {
            get => __ProxyValue.Values;
        }

        public NameScope(): base()
        {
        }

        public void RegisterName(System.String name, System.Object scopedElement) => __ProxyValue.RegisterName(@name, @scopedElement);
        public void UnregisterName(System.String name) => __ProxyValue.UnregisterName(@name);
        public System.Object FindName(System.String name) => __ProxyValue.FindName(@name);
        public static void SetNameScope(System.Windows.DependencyObject dependencyObject, System.Windows.Markup.INameScope value) => Windows.UI.Xaml.NameScope.SetNameScope(@dependencyObject, @value);
        public static System.Windows.Markup.INameScope GetNameScope(System.Windows.DependencyObject dependencyObject) => Windows.UI.Xaml.NameScope.GetNameScope(@dependencyObject);
        public void Clear() => __ProxyValue.Clear();
        public void CopyTo(System.Collections.Generic.KeyValuePair<System.String, System.Object> array, System.Int32 arrayIndex) => __ProxyValue.CopyTo(@array, @arrayIndex);
        public System.Boolean Remove(System.Collections.Generic.KeyValuePair<System.String, System.Object> item) => __ProxyValue.Remove(@item);
        public void Add(System.Collections.Generic.KeyValuePair<System.String, System.Object> item) => __ProxyValue.Add(@item);
        public System.Boolean Contains(System.Collections.Generic.KeyValuePair<System.String, System.Object> item) => __ProxyValue.Contains(@item);
        public void Add(System.String key, System.Object value) => __ProxyValue.Add(@key, @value);
        public System.Boolean ContainsKey(System.String key) => __ProxyValue.ContainsKey(@key);
        public System.Boolean Remove(System.String key) => __ProxyValue.Remove(@key);
        public System.Boolean TryGetValue(System.String key, out System.Object value) => __ProxyValue.TryGetValue(@key, @value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}