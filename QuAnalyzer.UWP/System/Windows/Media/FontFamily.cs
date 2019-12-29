namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class FontFamily : Proxy<global::Windows.UI.Xaml.Media.FontFamily>
    {
        public System.Windows.Media.LanguageSpecificStringDictionary FamilyNames
        {
            get => __ProxyValue.FamilyNames;
        }

        public System.Windows.Media.FamilyTypefaceCollection FamilyTypefaces
        {
            get => __ProxyValue.FamilyTypefaces;
        }

        public System.Windows.Media.FontFamilyMapCollection FamilyMaps
        {
            get => __ProxyValue.FamilyMaps;
        }

        public System.String Source
        {
            get => __ProxyValue.Source;
        }

        public System.Uri BaseUri
        {
            get => __ProxyValue.BaseUri;
        }

        public System.Double Baseline
        {
            get => __ProxyValue.Baseline;
            set => __ProxyValue.Baseline = value;
        }

        public System.Double LineSpacing
        {
            get => __ProxyValue.LineSpacing;
            set => __ProxyValue.LineSpacing = value;
        }

        public FontFamily(System.String @familyName): base(@familyName)
        {
        }

        public FontFamily(System.Uri @baseUri, System.String @familyName): base(@baseUri, @familyName)
        {
        }

        public FontFamily(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public System.Collections.Generic.ICollection<System.Windows.Media.Typeface> GetTypefaces() => __ProxyValue.GetTypefaces();
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
    }
}