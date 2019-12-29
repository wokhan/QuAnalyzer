namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class CharacterMetricsDictionary : Proxy<global::Windows.UI.Xaml.Media.CharacterMetricsDictionary>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.Windows.Media.CharacterMetrics Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public System.Collections.Generic.ICollection<System.Int32> Keys
        {
            get => __ProxyValue.Keys;
        }

        public System.Collections.Generic.ICollection<System.Windows.Media.CharacterMetrics> Values
        {
            get => __ProxyValue.Values;
        }

        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<System.Int32, System.Windows.Media.CharacterMetrics>> GetEnumerator() => __ProxyValue.GetEnumerator();
        public System.Boolean TryGetValue(System.Int32 key, out System.Windows.Media.CharacterMetrics value) => __ProxyValue.TryGetValue(@key, @value);
        public void Add(System.Collections.Generic.KeyValuePair<System.Int32, System.Windows.Media.CharacterMetrics> item) => __ProxyValue.Add(@item);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(System.Collections.Generic.KeyValuePair<System.Int32, System.Windows.Media.CharacterMetrics> item) => __ProxyValue.Contains(@item);
        public void CopyTo(System.Collections.Generic.KeyValuePair<System.Int32, System.Windows.Media.CharacterMetrics> array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Boolean Remove(System.Collections.Generic.KeyValuePair<System.Int32, System.Windows.Media.CharacterMetrics> item) => __ProxyValue.Remove(@item);
        public void Add(System.Int32 key, System.Windows.Media.CharacterMetrics value) => __ProxyValue.Add(@key, @value);
        public System.Boolean ContainsKey(System.Int32 key) => __ProxyValue.ContainsKey(@key);
        public System.Boolean Remove(System.Int32 key) => __ProxyValue.Remove(@key);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}