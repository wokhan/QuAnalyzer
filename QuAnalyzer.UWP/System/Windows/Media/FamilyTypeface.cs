namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class FamilyTypeface : Proxy<global::Windows.UI.Xaml.Media.FamilyTypeface>
    {
        public System.Windows.FontStyle Style
        {
            get => __ProxyValue.Style;
            set => __ProxyValue.Style = value;
        }

        public System.Windows.FontWeight Weight
        {
            get => __ProxyValue.Weight;
            set => __ProxyValue.Weight = value;
        }

        public System.Windows.FontStretch Stretch
        {
            get => __ProxyValue.Stretch;
            set => __ProxyValue.Stretch = value;
        }

        public System.Double UnderlinePosition
        {
            get => __ProxyValue.UnderlinePosition;
            set => __ProxyValue.UnderlinePosition = value;
        }

        public System.Double UnderlineThickness
        {
            get => __ProxyValue.UnderlineThickness;
            set => __ProxyValue.UnderlineThickness = value;
        }

        public System.Double StrikethroughPosition
        {
            get => __ProxyValue.StrikethroughPosition;
            set => __ProxyValue.StrikethroughPosition = value;
        }

        public System.Double StrikethroughThickness
        {
            get => __ProxyValue.StrikethroughThickness;
            set => __ProxyValue.StrikethroughThickness = value;
        }

        public System.Double CapsHeight
        {
            get => __ProxyValue.CapsHeight;
            set => __ProxyValue.CapsHeight = value;
        }

        public System.Double XHeight
        {
            get => __ProxyValue.XHeight;
            set => __ProxyValue.XHeight = value;
        }

        public System.Collections.Generic.IDictionary<System.Windows.Markup.XmlLanguage, System.String> AdjustedFaceNames
        {
            get => __ProxyValue.AdjustedFaceNames;
        }

        public System.String DeviceFontName
        {
            get => __ProxyValue.DeviceFontName;
            set => __ProxyValue.DeviceFontName = value;
        }

        public System.Windows.Media.CharacterMetricsDictionary DeviceFontCharacterMetrics
        {
            get => __ProxyValue.DeviceFontCharacterMetrics;
        }

        public FamilyTypeface(): base()
        {
        }

        public System.Boolean Equals(System.Windows.Media.FamilyTypeface typeface) => __ProxyValue.Equals(@typeface);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}