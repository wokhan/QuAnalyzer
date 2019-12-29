namespace System.Windows.Markup.Localizer
{
    using Uno.UI.Generic;

    public class BamlLocalizationDictionaryEnumerator : Proxy<global::Windows.UI.Xaml.Markup.Localizer.BamlLocalizationDictionaryEnumerator>
    {
        public System.Collections.DictionaryEntry Entry
        {
            get => __ProxyValue.Entry;
        }

        public System.Windows.Markup.Localizer.BamlLocalizableResourceKey Key
        {
            get => __ProxyValue.Key;
        }

        public System.Windows.Markup.Localizer.BamlLocalizableResource Value
        {
            get => __ProxyValue.Value;
        }

        public System.Collections.DictionaryEntry Current
        {
            get => __ProxyValue.Current;
        }

        public System.Boolean MoveNext() => __ProxyValue.MoveNext();
        public void Reset() => __ProxyValue.Reset();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}