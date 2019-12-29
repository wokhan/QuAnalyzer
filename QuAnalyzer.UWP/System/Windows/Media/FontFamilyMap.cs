namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class FontFamilyMap : Proxy<global::Windows.UI.Xaml.Media.FontFamilyMap>
    {
        public System.String Unicode
        {
            get => __ProxyValue.Unicode;
            set => __ProxyValue.Unicode = value;
        }

        public System.String Target
        {
            get => __ProxyValue.Target;
            set => __ProxyValue.Target = value;
        }

        public System.Double Scale
        {
            get => __ProxyValue.Scale;
            set => __ProxyValue.Scale = value;
        }

        public System.Windows.Markup.XmlLanguage Language
        {
            get => __ProxyValue.Language;
            set => __ProxyValue.Language = value;
        }

        public FontFamilyMap(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}