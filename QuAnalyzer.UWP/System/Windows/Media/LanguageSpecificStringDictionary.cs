namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class LanguageSpecificStringDictionary : Proxy<global::Windows.UI.Xaml.Media.LanguageSpecificStringDictionary>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.String Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public System.Collections.Generic.ICollection<System.Windows.Markup.XmlLanguage> Keys
        {
            get => __ProxyValue.Keys;
        }

        public System.Collections.Generic.ICollection<System.String> Values
        {
            get => __ProxyValue.Values;
        }

        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<System.Windows.Markup.XmlLanguage, System.String>> GetEnumerator() => __ProxyValue.GetEnumerator();
        public System.Boolean TryGetValue(System.Windows.Markup.XmlLanguage key, out System.String value) => __ProxyValue.TryGetValue(@key, @value);
        public void Add(System.Collections.Generic.KeyValuePair<System.Windows.Markup.XmlLanguage, System.String> item) => __ProxyValue.Add(@item);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(System.Collections.Generic.KeyValuePair<System.Windows.Markup.XmlLanguage, System.String> item) => __ProxyValue.Contains(@item);
        public void CopyTo(System.Collections.Generic.KeyValuePair<System.Windows.Markup.XmlLanguage, System.String> array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Boolean Remove(System.Collections.Generic.KeyValuePair<System.Windows.Markup.XmlLanguage, System.String> item) => __ProxyValue.Remove(@item);
        public void Add(System.Windows.Markup.XmlLanguage key, System.String value) => __ProxyValue.Add(@key, @value);
        public System.Boolean ContainsKey(System.Windows.Markup.XmlLanguage key) => __ProxyValue.ContainsKey(@key);
        public System.Boolean Remove(System.Windows.Markup.XmlLanguage key) => __ProxyValue.Remove(@key);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}