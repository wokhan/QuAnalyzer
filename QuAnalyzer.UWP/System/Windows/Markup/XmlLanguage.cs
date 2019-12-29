namespace System.Windows.Markup
{
    using Uno.UI.Generic;

    public class XmlLanguage : Proxy<global::Windows.UI.Xaml.Markup.XmlLanguage>
    {
        public static System.Windows.Markup.XmlLanguage Empty
        {
            get => __ProxyValue.Empty;
        }

        public System.String IetfLanguageTag
        {
            get => __ProxyValue.IetfLanguageTag;
        }

        public static System.Windows.Markup.XmlLanguage GetLanguage(System.String ietfLanguageTag) => Windows.UI.Xaml.Markup.XmlLanguage.GetLanguage(@ietfLanguageTag);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.Globalization.CultureInfo GetEquivalentCulture() => __ProxyValue.GetEquivalentCulture();
        public System.Globalization.CultureInfo GetSpecificCulture() => __ProxyValue.GetSpecificCulture();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}