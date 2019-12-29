namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextFormatter : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextFormatter>
    {
        public static System.Windows.Media.TextFormatting.TextFormatter Create(System.Windows.Media.TextFormattingMode textFormattingMode) => Windows.UI.Xaml.Media.TextFormatting.TextFormatter.Create(@textFormattingMode);
        public static System.Windows.Media.TextFormatting.TextFormatter Create() => Windows.UI.Xaml.Media.TextFormatting.TextFormatter.Create();
        public void Dispose() => __ProxyValue.Dispose();
        public System.Windows.Media.TextFormatting.TextLine FormatLine(System.Windows.Media.TextFormatting.TextSource textSource, System.Int32 firstCharIndex, System.Double paragraphWidth, System.Windows.Media.TextFormatting.TextParagraphProperties paragraphProperties, System.Windows.Media.TextFormatting.TextLineBreak previousLineBreak) => __ProxyValue.FormatLine(@textSource, @firstCharIndex, @paragraphWidth, @paragraphProperties, @previousLineBreak);
        public System.Windows.Media.TextFormatting.TextLine FormatLine(System.Windows.Media.TextFormatting.TextSource textSource, System.Int32 firstCharIndex, System.Double paragraphWidth, System.Windows.Media.TextFormatting.TextParagraphProperties paragraphProperties, System.Windows.Media.TextFormatting.TextLineBreak previousLineBreak, System.Windows.Media.TextFormatting.TextRunCache textRunCache) => __ProxyValue.FormatLine(@textSource, @firstCharIndex, @paragraphWidth, @paragraphProperties, @previousLineBreak, @textRunCache);
        public System.Windows.Media.TextFormatting.MinMaxParagraphWidth FormatMinMaxParagraphWidth(System.Windows.Media.TextFormatting.TextSource textSource, System.Int32 firstCharIndex, System.Windows.Media.TextFormatting.TextParagraphProperties paragraphProperties) => __ProxyValue.FormatMinMaxParagraphWidth(@textSource, @firstCharIndex, @paragraphProperties);
        public System.Windows.Media.TextFormatting.MinMaxParagraphWidth FormatMinMaxParagraphWidth(System.Windows.Media.TextFormatting.TextSource textSource, System.Int32 firstCharIndex, System.Windows.Media.TextFormatting.TextParagraphProperties paragraphProperties, System.Windows.Media.TextFormatting.TextRunCache textRunCache) => __ProxyValue.FormatMinMaxParagraphWidth(@textSource, @firstCharIndex, @paragraphProperties, @textRunCache);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}