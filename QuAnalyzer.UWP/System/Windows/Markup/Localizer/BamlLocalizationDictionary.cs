namespace System.Windows.Markup.Localizer
{
    using Uno.UI.Generic;

    public class BamlLocalizationDictionary : Proxy<global::Windows.UI.Xaml.Markup.Localizer.BamlLocalizationDictionary>
    {
        public System.Boolean IsFixedSize
        {
            get => __ProxyValue.IsFixedSize;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.Windows.Markup.Localizer.BamlLocalizableResourceKey RootElementKey
        {
            get => __ProxyValue.RootElementKey;
        }

        public System.Collections.ICollection Keys
        {
            get => __ProxyValue.Keys;
        }

        public System.Collections.ICollection Values
        {
            get => __ProxyValue.Values;
        }

        public System.Windows.Markup.Localizer.BamlLocalizableResource Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public BamlLocalizationDictionary(): base()
        {
        }

        public void Add(System.Windows.Markup.Localizer.BamlLocalizableResourceKey key, System.Windows.Markup.Localizer.BamlLocalizableResource value) => __ProxyValue.Add(@key, @value);
        public void Clear() => __ProxyValue.Clear();
        public void Remove(System.Windows.Markup.Localizer.BamlLocalizableResourceKey key) => __ProxyValue.Remove(@key);
        public System.Boolean Contains(System.Windows.Markup.Localizer.BamlLocalizableResourceKey key) => __ProxyValue.Contains(@key);
        public System.Windows.Markup.Localizer.BamlLocalizationDictionaryEnumerator GetEnumerator() => __ProxyValue.GetEnumerator();
        public void CopyTo(System.Collections.DictionaryEntry[] array, System.Int32 arrayIndex) => __ProxyValue.CopyTo(@array, @arrayIndex);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}