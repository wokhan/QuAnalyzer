namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class FormattedText : Proxy<global::Windows.UI.Xaml.Media.FormattedText>
    {
        public System.String Text
        {
            get => __ProxyValue.Text;
        }

        public System.Double PixelsPerDip
        {
            get => __ProxyValue.PixelsPerDip;
            set => __ProxyValue.PixelsPerDip = value;
        }

        public System.Windows.FlowDirection FlowDirection
        {
            get => __ProxyValue.FlowDirection;
            set => __ProxyValue.FlowDirection = value;
        }

        public System.Windows.TextAlignment TextAlignment
        {
            get => __ProxyValue.TextAlignment;
            set => __ProxyValue.TextAlignment = value;
        }

        public System.Double LineHeight
        {
            get => __ProxyValue.LineHeight;
            set => __ProxyValue.LineHeight = value;
        }

        public System.Double MaxTextWidth
        {
            get => __ProxyValue.MaxTextWidth;
            set => __ProxyValue.MaxTextWidth = value;
        }

        public System.Double MaxTextHeight
        {
            get => __ProxyValue.MaxTextHeight;
            set => __ProxyValue.MaxTextHeight = value;
        }

        public System.Int32 MaxLineCount
        {
            get => __ProxyValue.MaxLineCount;
            set => __ProxyValue.MaxLineCount = value;
        }

        public System.Windows.TextTrimming Trimming
        {
            get => __ProxyValue.Trimming;
            set => __ProxyValue.Trimming = value;
        }

        public System.Double Height
        {
            get => __ProxyValue.Height;
        }

        public System.Double Extent
        {
            get => __ProxyValue.Extent;
        }

        public System.Double Baseline
        {
            get => __ProxyValue.Baseline;
        }

        public System.Double OverhangAfter
        {
            get => __ProxyValue.OverhangAfter;
        }

        public System.Double OverhangLeading
        {
            get => __ProxyValue.OverhangLeading;
        }

        public System.Double OverhangTrailing
        {
            get => __ProxyValue.OverhangTrailing;
        }

        public System.Double Width
        {
            get => __ProxyValue.Width;
        }

        public System.Double WidthIncludingTrailingWhitespace
        {
            get => __ProxyValue.WidthIncludingTrailingWhitespace;
        }

        public System.Double MinWidth
        {
            get => __ProxyValue.MinWidth;
        }

        public FormattedText(System.String @textToFormat, System.Globalization.CultureInfo @culture, System.Windows.FlowDirection @flowDirection, System.Windows.Media.Typeface @typeface, System.Double @emSize, System.Windows.Media.Brush @foreground): base(@textToFormat, @culture, @flowDirection, @typeface, @emSize, @foreground)
        {
        }

        public FormattedText(System.String @textToFormat, System.Globalization.CultureInfo @culture, System.Windows.FlowDirection @flowDirection, System.Windows.Media.Typeface @typeface, System.Double @emSize, System.Windows.Media.Brush @foreground, System.Double @pixelsPerDip): base(@textToFormat, @culture, @flowDirection, @typeface, @emSize, @foreground, @pixelsPerDip)
        {
        }

        public FormattedText(System.String @textToFormat, System.Globalization.CultureInfo @culture, System.Windows.FlowDirection @flowDirection, System.Windows.Media.Typeface @typeface, System.Double @emSize, System.Windows.Media.Brush @foreground, System.Windows.Media.NumberSubstitution @numberSubstitution): base(@textToFormat, @culture, @flowDirection, @typeface, @emSize, @foreground, @numberSubstitution)
        {
        }

        public FormattedText(System.String @textToFormat, System.Globalization.CultureInfo @culture, System.Windows.FlowDirection @flowDirection, System.Windows.Media.Typeface @typeface, System.Double @emSize, System.Windows.Media.Brush @foreground, System.Windows.Media.NumberSubstitution @numberSubstitution, System.Double @pixelsPerDip): base(@textToFormat, @culture, @flowDirection, @typeface, @emSize, @foreground, @numberSubstitution, @pixelsPerDip)
        {
        }

        public FormattedText(System.String @textToFormat, System.Globalization.CultureInfo @culture, System.Windows.FlowDirection @flowDirection, System.Windows.Media.Typeface @typeface, System.Double @emSize, System.Windows.Media.Brush @foreground, System.Windows.Media.NumberSubstitution @numberSubstitution, System.Windows.Media.TextFormattingMode @textFormattingMode): base(@textToFormat, @culture, @flowDirection, @typeface, @emSize, @foreground, @numberSubstitution, @textFormattingMode)
        {
        }

        public FormattedText(System.String @textToFormat, System.Globalization.CultureInfo @culture, System.Windows.FlowDirection @flowDirection, System.Windows.Media.Typeface @typeface, System.Double @emSize, System.Windows.Media.Brush @foreground, System.Windows.Media.NumberSubstitution @numberSubstitution, System.Windows.Media.TextFormattingMode @textFormattingMode, System.Double @pixelsPerDip): base(@textToFormat, @culture, @flowDirection, @typeface, @emSize, @foreground, @numberSubstitution, @textFormattingMode, @pixelsPerDip)
        {
        }

        public void SetForegroundBrush(System.Windows.Media.Brush foregroundBrush) => __ProxyValue.SetForegroundBrush(@foregroundBrush);
        public void SetForegroundBrush(System.Windows.Media.Brush foregroundBrush, System.Int32 startIndex, System.Int32 count) => __ProxyValue.SetForegroundBrush(@foregroundBrush, @startIndex, @count);
        public void SetFontFamily(System.String fontFamily) => __ProxyValue.SetFontFamily(@fontFamily);
        public void SetFontFamily(System.String fontFamily, System.Int32 startIndex, System.Int32 count) => __ProxyValue.SetFontFamily(@fontFamily, @startIndex, @count);
        public void SetFontFamily(System.Windows.Media.FontFamily fontFamily) => __ProxyValue.SetFontFamily(@fontFamily);
        public void SetFontFamily(System.Windows.Media.FontFamily fontFamily, System.Int32 startIndex, System.Int32 count) => __ProxyValue.SetFontFamily(@fontFamily, @startIndex, @count);
        public void SetFontSize(System.Double emSize) => __ProxyValue.SetFontSize(@emSize);
        public void SetFontSize(System.Double emSize, System.Int32 startIndex, System.Int32 count) => __ProxyValue.SetFontSize(@emSize, @startIndex, @count);
        public void SetCulture(System.Globalization.CultureInfo culture) => __ProxyValue.SetCulture(@culture);
        public void SetCulture(System.Globalization.CultureInfo culture, System.Int32 startIndex, System.Int32 count) => __ProxyValue.SetCulture(@culture, @startIndex, @count);
        public void SetNumberSubstitution(System.Windows.Media.NumberSubstitution numberSubstitution) => __ProxyValue.SetNumberSubstitution(@numberSubstitution);
        public void SetNumberSubstitution(System.Windows.Media.NumberSubstitution numberSubstitution, System.Int32 startIndex, System.Int32 count) => __ProxyValue.SetNumberSubstitution(@numberSubstitution, @startIndex, @count);
        public void SetFontWeight(System.Windows.FontWeight weight) => __ProxyValue.SetFontWeight(@weight);
        public void SetFontWeight(System.Windows.FontWeight weight, System.Int32 startIndex, System.Int32 count) => __ProxyValue.SetFontWeight(@weight, @startIndex, @count);
        public void SetFontStyle(System.Windows.FontStyle style) => __ProxyValue.SetFontStyle(@style);
        public void SetFontStyle(System.Windows.FontStyle style, System.Int32 startIndex, System.Int32 count) => __ProxyValue.SetFontStyle(@style, @startIndex, @count);
        public void SetFontStretch(System.Windows.FontStretch stretch) => __ProxyValue.SetFontStretch(@stretch);
        public void SetFontStretch(System.Windows.FontStretch stretch, System.Int32 startIndex, System.Int32 count) => __ProxyValue.SetFontStretch(@stretch, @startIndex, @count);
        public void SetFontTypeface(System.Windows.Media.Typeface typeface) => __ProxyValue.SetFontTypeface(@typeface);
        public void SetFontTypeface(System.Windows.Media.Typeface typeface, System.Int32 startIndex, System.Int32 count) => __ProxyValue.SetFontTypeface(@typeface, @startIndex, @count);
        public void SetTextDecorations(System.Windows.TextDecorationCollection textDecorations) => __ProxyValue.SetTextDecorations(@textDecorations);
        public void SetTextDecorations(System.Windows.TextDecorationCollection textDecorations, System.Int32 startIndex, System.Int32 count) => __ProxyValue.SetTextDecorations(@textDecorations, @startIndex, @count);
        public void SetMaxTextWidths(System.Double[] maxTextWidths) => __ProxyValue.SetMaxTextWidths(@maxTextWidths);
        public System.Double[] GetMaxTextWidths() => __ProxyValue.GetMaxTextWidths();
        public System.Windows.Media.Geometry BuildHighlightGeometry(System.Windows.Point origin) => __ProxyValue.BuildHighlightGeometry(@origin);
        public System.Windows.Media.Geometry BuildGeometry(System.Windows.Point origin) => __ProxyValue.BuildGeometry(@origin);
        public System.Windows.Media.Geometry BuildHighlightGeometry(System.Windows.Point origin, System.Int32 startIndex, System.Int32 count) => __ProxyValue.BuildHighlightGeometry(@origin, @startIndex, @count);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}