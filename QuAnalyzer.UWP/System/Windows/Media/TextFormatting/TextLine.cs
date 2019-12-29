namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextLine : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextLine>
    {
        public System.Double PixelsPerDip
        {
            get => __ProxyValue.PixelsPerDip;
            set => __ProxyValue.PixelsPerDip = value;
        }

        public System.Boolean HasOverflowed
        {
            get => __ProxyValue.HasOverflowed;
        }

        public System.Boolean HasCollapsed
        {
            get => __ProxyValue.HasCollapsed;
        }

        public System.Boolean IsTruncated
        {
            get => __ProxyValue.IsTruncated;
        }

        public System.Int32 Length
        {
            get => __ProxyValue.Length;
        }

        public System.Int32 TrailingWhitespaceLength
        {
            get => __ProxyValue.TrailingWhitespaceLength;
        }

        public System.Int32 DependentLength
        {
            get => __ProxyValue.DependentLength;
        }

        public System.Int32 NewlineLength
        {
            get => __ProxyValue.NewlineLength;
        }

        public System.Double Start
        {
            get => __ProxyValue.Start;
        }

        public System.Double Width
        {
            get => __ProxyValue.Width;
        }

        public System.Double WidthIncludingTrailingWhitespace
        {
            get => __ProxyValue.WidthIncludingTrailingWhitespace;
        }

        public System.Double Height
        {
            get => __ProxyValue.Height;
        }

        public System.Double TextHeight
        {
            get => __ProxyValue.TextHeight;
        }

        public System.Double Extent
        {
            get => __ProxyValue.Extent;
        }

        public System.Double Baseline
        {
            get => __ProxyValue.Baseline;
        }

        public System.Double TextBaseline
        {
            get => __ProxyValue.TextBaseline;
        }

        public System.Double MarkerBaseline
        {
            get => __ProxyValue.MarkerBaseline;
        }

        public System.Double MarkerHeight
        {
            get => __ProxyValue.MarkerHeight;
        }

        public System.Double OverhangLeading
        {
            get => __ProxyValue.OverhangLeading;
        }

        public System.Double OverhangTrailing
        {
            get => __ProxyValue.OverhangTrailing;
        }

        public System.Double OverhangAfter
        {
            get => __ProxyValue.OverhangAfter;
        }

        public void Dispose() => __ProxyValue.Dispose();
        public void Draw(System.Windows.Media.DrawingContext drawingContext, System.Windows.Point origin, System.Windows.Media.TextFormatting.InvertAxes inversion) => __ProxyValue.Draw(@drawingContext, @origin, @inversion);
        public System.Windows.Media.TextFormatting.TextLine Collapse(System.Windows.Media.TextFormatting.TextCollapsingProperties[] collapsingPropertiesList) => __ProxyValue.Collapse(@collapsingPropertiesList);
        public System.Collections.Generic.IList<System.Windows.Media.TextFormatting.TextCollapsedRange> GetTextCollapsedRanges() => __ProxyValue.GetTextCollapsedRanges();
        public System.Windows.Media.TextFormatting.CharacterHit GetCharacterHitFromDistance(System.Double distance) => __ProxyValue.GetCharacterHitFromDistance(@distance);
        public System.Double GetDistanceFromCharacterHit(System.Windows.Media.TextFormatting.CharacterHit characterHit) => __ProxyValue.GetDistanceFromCharacterHit(@characterHit);
        public System.Windows.Media.TextFormatting.CharacterHit GetNextCaretCharacterHit(System.Windows.Media.TextFormatting.CharacterHit characterHit) => __ProxyValue.GetNextCaretCharacterHit(@characterHit);
        public System.Windows.Media.TextFormatting.CharacterHit GetPreviousCaretCharacterHit(System.Windows.Media.TextFormatting.CharacterHit characterHit) => __ProxyValue.GetPreviousCaretCharacterHit(@characterHit);
        public System.Windows.Media.TextFormatting.CharacterHit GetBackspaceCaretCharacterHit(System.Windows.Media.TextFormatting.CharacterHit characterHit) => __ProxyValue.GetBackspaceCaretCharacterHit(@characterHit);
        public System.Collections.Generic.IList<System.Windows.Media.TextFormatting.TextBounds> GetTextBounds(System.Int32 firstTextSourceCharacterIndex, System.Int32 textLength) => __ProxyValue.GetTextBounds(@firstTextSourceCharacterIndex, @textLength);
        public System.Collections.Generic.IList<System.Windows.Media.TextFormatting.TextSpan<System.Windows.Media.TextFormatting.TextRun>> GetTextRunSpans() => __ProxyValue.GetTextRunSpans();
        public System.Collections.Generic.IEnumerable<System.Windows.Media.TextFormatting.IndexedGlyphRun> GetIndexedGlyphRuns() => __ProxyValue.GetIndexedGlyphRuns();
        public System.Windows.Media.TextFormatting.TextLineBreak GetTextLineBreak() => __ProxyValue.GetTextLineBreak();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}