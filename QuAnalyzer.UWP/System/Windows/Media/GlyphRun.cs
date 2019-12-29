namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class GlyphRun : Proxy<global::Windows.UI.Xaml.Media.GlyphRun>
    {
        public System.Single PixelsPerDip
        {
            get => __ProxyValue.PixelsPerDip;
            set => __ProxyValue.PixelsPerDip = value;
        }

        public System.Windows.Point BaselineOrigin
        {
            get => __ProxyValue.BaselineOrigin;
            set => __ProxyValue.BaselineOrigin = value;
        }

        public System.Double FontRenderingEmSize
        {
            get => __ProxyValue.FontRenderingEmSize;
            set => __ProxyValue.FontRenderingEmSize = value;
        }

        public System.Windows.Media.GlyphTypeface GlyphTypeface
        {
            get => __ProxyValue.GlyphTypeface;
            set => __ProxyValue.GlyphTypeface = value;
        }

        public System.Int32 BidiLevel
        {
            get => __ProxyValue.BidiLevel;
            set => __ProxyValue.BidiLevel = value;
        }

        public System.Boolean IsSideways
        {
            get => __ProxyValue.IsSideways;
            set => __ProxyValue.IsSideways = value;
        }

        public System.Collections.Generic.IList<System.Boolean> CaretStops
        {
            get => __ProxyValue.CaretStops;
            set => __ProxyValue.CaretStops = value;
        }

        public System.Boolean IsHitTestable
        {
            get => __ProxyValue.IsHitTestable;
        }

        public System.Collections.Generic.IList<System.UInt16> ClusterMap
        {
            get => __ProxyValue.ClusterMap;
            set => __ProxyValue.ClusterMap = value;
        }

        public System.Collections.Generic.IList<System.Char> Characters
        {
            get => __ProxyValue.Characters;
            set => __ProxyValue.Characters = value;
        }

        public System.Collections.Generic.IList<System.UInt16> GlyphIndices
        {
            get => __ProxyValue.GlyphIndices;
            set => __ProxyValue.GlyphIndices = value;
        }

        public System.Collections.Generic.IList<System.Double> AdvanceWidths
        {
            get => __ProxyValue.AdvanceWidths;
            set => __ProxyValue.AdvanceWidths = value;
        }

        public System.Collections.Generic.IList<System.Windows.Point> GlyphOffsets
        {
            get => __ProxyValue.GlyphOffsets;
            set => __ProxyValue.GlyphOffsets = value;
        }

        public System.Windows.Markup.XmlLanguage Language
        {
            get => __ProxyValue.Language;
            set => __ProxyValue.Language = value;
        }

        public System.String DeviceFontName
        {
            get => __ProxyValue.DeviceFontName;
            set => __ProxyValue.DeviceFontName = value;
        }

        public GlyphRun(): base()
        {
        }

        public GlyphRun(System.Single @pixelsPerDip): base(@pixelsPerDip)
        {
        }

        public GlyphRun(System.Windows.Media.GlyphTypeface @glyphTypeface, System.Int32 @bidiLevel, System.Boolean @isSideways, System.Double @renderingEmSize, System.Single @pixelsPerDip, System.Collections.Generic.IList<System.UInt16> @glyphIndices, System.Windows.Point @baselineOrigin, System.Collections.Generic.IList<System.Double> @advanceWidths, System.Collections.Generic.IList<System.Windows.Point> @glyphOffsets, System.Collections.Generic.IList<System.Char> @characters, System.String @deviceFontName, System.Collections.Generic.IList<System.UInt16> @clusterMap, System.Collections.Generic.IList<System.Boolean> @caretStops, System.Windows.Markup.XmlLanguage @language): base(@glyphTypeface, @bidiLevel, @isSideways, @renderingEmSize, @pixelsPerDip, @glyphIndices, @baselineOrigin, @advanceWidths, @glyphOffsets, @characters, @deviceFontName, @clusterMap, @caretStops, @language)
        {
        }

        public GlyphRun(System.Windows.Media.GlyphTypeface @glyphTypeface, System.Int32 @bidiLevel, System.Boolean @isSideways, System.Double @renderingEmSize, System.Collections.Generic.IList<System.UInt16> @glyphIndices, System.Windows.Point @baselineOrigin, System.Collections.Generic.IList<System.Double> @advanceWidths, System.Collections.Generic.IList<System.Windows.Point> @glyphOffsets, System.Collections.Generic.IList<System.Char> @characters, System.String @deviceFontName, System.Collections.Generic.IList<System.UInt16> @clusterMap, System.Collections.Generic.IList<System.Boolean> @caretStops, System.Windows.Markup.XmlLanguage @language): base(@glyphTypeface, @bidiLevel, @isSideways, @renderingEmSize, @glyphIndices, @baselineOrigin, @advanceWidths, @glyphOffsets, @characters, @deviceFontName, @clusterMap, @caretStops, @language)
        {
        }

        public System.Double GetDistanceFromCaretCharacterHit(System.Windows.Media.TextFormatting.CharacterHit characterHit) => __ProxyValue.GetDistanceFromCaretCharacterHit(@characterHit);
        public System.Windows.Media.TextFormatting.CharacterHit GetCaretCharacterHitFromDistance(System.Double distance, out System.Boolean isInside) => __ProxyValue.GetCaretCharacterHitFromDistance(@distance, @isInside);
        public System.Windows.Media.TextFormatting.CharacterHit GetNextCaretCharacterHit(System.Windows.Media.TextFormatting.CharacterHit characterHit) => __ProxyValue.GetNextCaretCharacterHit(@characterHit);
        public System.Windows.Media.TextFormatting.CharacterHit GetPreviousCaretCharacterHit(System.Windows.Media.TextFormatting.CharacterHit characterHit) => __ProxyValue.GetPreviousCaretCharacterHit(@characterHit);
        public System.Windows.Rect ComputeInkBoundingBox() => __ProxyValue.ComputeInkBoundingBox();
        public System.Windows.Media.Geometry BuildGeometry() => __ProxyValue.BuildGeometry();
        public System.Windows.Rect ComputeAlignmentBox() => __ProxyValue.ComputeAlignmentBox();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}