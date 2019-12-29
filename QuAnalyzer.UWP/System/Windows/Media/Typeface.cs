namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class Typeface : Proxy<global::Windows.UI.Xaml.Media.Typeface>
    {
        public System.Windows.Media.FontFamily FontFamily
        {
            get => __ProxyValue.FontFamily;
        }

        public System.Windows.FontWeight Weight
        {
            get => __ProxyValue.Weight;
        }

        public System.Windows.FontStyle Style
        {
            get => __ProxyValue.Style;
        }

        public System.Windows.FontStretch Stretch
        {
            get => __ProxyValue.Stretch;
        }

        public System.Boolean IsObliqueSimulated
        {
            get => __ProxyValue.IsObliqueSimulated;
        }

        public System.Boolean IsBoldSimulated
        {
            get => __ProxyValue.IsBoldSimulated;
        }

        public System.Double XHeight
        {
            get => __ProxyValue.XHeight;
        }

        public System.Double CapsHeight
        {
            get => __ProxyValue.CapsHeight;
        }

        public System.Double UnderlinePosition
        {
            get => __ProxyValue.UnderlinePosition;
        }

        public System.Double UnderlineThickness
        {
            get => __ProxyValue.UnderlineThickness;
        }

        public System.Double StrikethroughPosition
        {
            get => __ProxyValue.StrikethroughPosition;
        }

        public System.Double StrikethroughThickness
        {
            get => __ProxyValue.StrikethroughThickness;
        }

        public System.Windows.Media.LanguageSpecificStringDictionary FaceNames
        {
            get => __ProxyValue.FaceNames;
        }

        public Typeface(System.String @typefaceName): base(@typefaceName)
        {
        }

        public Typeface(System.Windows.Media.FontFamily @fontFamily, System.Windows.FontStyle @style, System.Windows.FontWeight @weight, System.Windows.FontStretch @stretch): base(@fontFamily, @style, @weight, @stretch)
        {
        }

        public Typeface(System.Windows.Media.FontFamily @fontFamily, System.Windows.FontStyle @style, System.Windows.FontWeight @weight, System.Windows.FontStretch @stretch, System.Windows.Media.FontFamily @fallbackFontFamily): base(@fontFamily, @style, @weight, @stretch, @fallbackFontFamily)
        {
        }

        public System.Boolean TryGetGlyphTypeface(out System.Windows.Media.GlyphTypeface glyphTypeface) => __ProxyValue.TryGetGlyphTypeface(@glyphTypeface);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}