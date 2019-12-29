namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class GlyphTypeface : Proxy<global::Windows.UI.Xaml.Media.GlyphTypeface>
    {
        public System.Uri FontUri
        {
            get => __ProxyValue.FontUri;
            set => __ProxyValue.FontUri = value;
        }

        public System.Collections.Generic.IDictionary<System.Globalization.CultureInfo, System.String> FamilyNames
        {
            get => __ProxyValue.FamilyNames;
        }

        public System.Collections.Generic.IDictionary<System.Globalization.CultureInfo, System.String> FaceNames
        {
            get => __ProxyValue.FaceNames;
        }

        public System.Collections.Generic.IDictionary<System.Globalization.CultureInfo, System.String> Win32FamilyNames
        {
            get => __ProxyValue.Win32FamilyNames;
        }

        public System.Collections.Generic.IDictionary<System.Globalization.CultureInfo, System.String> Win32FaceNames
        {
            get => __ProxyValue.Win32FaceNames;
        }

        public System.Collections.Generic.IDictionary<System.Globalization.CultureInfo, System.String> VersionStrings
        {
            get => __ProxyValue.VersionStrings;
        }

        public System.Collections.Generic.IDictionary<System.Globalization.CultureInfo, System.String> Copyrights
        {
            get => __ProxyValue.Copyrights;
        }

        public System.Collections.Generic.IDictionary<System.Globalization.CultureInfo, System.String> ManufacturerNames
        {
            get => __ProxyValue.ManufacturerNames;
        }

        public System.Collections.Generic.IDictionary<System.Globalization.CultureInfo, System.String> Trademarks
        {
            get => __ProxyValue.Trademarks;
        }

        public System.Collections.Generic.IDictionary<System.Globalization.CultureInfo, System.String> DesignerNames
        {
            get => __ProxyValue.DesignerNames;
        }

        public System.Collections.Generic.IDictionary<System.Globalization.CultureInfo, System.String> Descriptions
        {
            get => __ProxyValue.Descriptions;
        }

        public System.Collections.Generic.IDictionary<System.Globalization.CultureInfo, System.String> VendorUrls
        {
            get => __ProxyValue.VendorUrls;
        }

        public System.Collections.Generic.IDictionary<System.Globalization.CultureInfo, System.String> DesignerUrls
        {
            get => __ProxyValue.DesignerUrls;
        }

        public System.Collections.Generic.IDictionary<System.Globalization.CultureInfo, System.String> LicenseDescriptions
        {
            get => __ProxyValue.LicenseDescriptions;
        }

        public System.Collections.Generic.IDictionary<System.Globalization.CultureInfo, System.String> SampleTexts
        {
            get => __ProxyValue.SampleTexts;
        }

        public System.Windows.FontStyle Style
        {
            get => __ProxyValue.Style;
        }

        public System.Windows.FontWeight Weight
        {
            get => __ProxyValue.Weight;
        }

        public System.Windows.FontStretch Stretch
        {
            get => __ProxyValue.Stretch;
        }

        public System.Double Version
        {
            get => __ProxyValue.Version;
        }

        public System.Double Height
        {
            get => __ProxyValue.Height;
        }

        public System.Double Baseline
        {
            get => __ProxyValue.Baseline;
        }

        public System.Double CapsHeight
        {
            get => __ProxyValue.CapsHeight;
        }

        public System.Double XHeight
        {
            get => __ProxyValue.XHeight;
        }

        public System.Boolean Symbol
        {
            get => __ProxyValue.Symbol;
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

        public System.Windows.Media.FontEmbeddingRight EmbeddingRights
        {
            get => __ProxyValue.EmbeddingRights;
        }

        public System.Collections.Generic.IDictionary<System.UInt16, System.Double> AdvanceWidths
        {
            get => __ProxyValue.AdvanceWidths;
        }

        public System.Collections.Generic.IDictionary<System.UInt16, System.Double> AdvanceHeights
        {
            get => __ProxyValue.AdvanceHeights;
        }

        public System.Collections.Generic.IDictionary<System.UInt16, System.Double> LeftSideBearings
        {
            get => __ProxyValue.LeftSideBearings;
        }

        public System.Collections.Generic.IDictionary<System.UInt16, System.Double> RightSideBearings
        {
            get => __ProxyValue.RightSideBearings;
        }

        public System.Collections.Generic.IDictionary<System.UInt16, System.Double> TopSideBearings
        {
            get => __ProxyValue.TopSideBearings;
        }

        public System.Collections.Generic.IDictionary<System.UInt16, System.Double> BottomSideBearings
        {
            get => __ProxyValue.BottomSideBearings;
        }

        public System.Collections.Generic.IDictionary<System.UInt16, System.Double> DistancesFromHorizontalBaselineToBlackBoxBottom
        {
            get => __ProxyValue.DistancesFromHorizontalBaselineToBlackBoxBottom;
        }

        public System.Collections.Generic.IDictionary<System.Int32, System.UInt16> CharacterToGlyphMap
        {
            get => __ProxyValue.CharacterToGlyphMap;
        }

        public System.Windows.Media.StyleSimulations StyleSimulations
        {
            get => __ProxyValue.StyleSimulations;
            set => __ProxyValue.StyleSimulations = value;
        }

        public System.Int32 GlyphCount
        {
            get => __ProxyValue.GlyphCount;
        }

        public GlyphTypeface(): base()
        {
        }

        public GlyphTypeface(System.Uri @typefaceSource): base(@typefaceSource)
        {
        }

        public GlyphTypeface(System.Uri @typefaceSource, System.Windows.Media.StyleSimulations @styleSimulations): base(@typefaceSource, @styleSimulations)
        {
        }

        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Windows.Media.Geometry GetGlyphOutline(System.UInt16 glyphIndex, System.Double renderingEmSize, System.Double hintingEmSize) => __ProxyValue.GetGlyphOutline(@glyphIndex, @renderingEmSize, @hintingEmSize);
        public System.Byte[] ComputeSubset(System.Collections.Generic.ICollection<System.UInt16> glyphs) => __ProxyValue.ComputeSubset(@glyphs);
        public System.IO.Stream GetFontStream() => __ProxyValue.GetFontStream();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}