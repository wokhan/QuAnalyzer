namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextSimpleMarkerProperties : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextSimpleMarkerProperties>
    {
        public System.Double Offset
        {
            get => __ProxyValue.Offset;
        }

        public System.Windows.Media.TextFormatting.TextSource TextSource
        {
            get => __ProxyValue.TextSource;
        }

        public TextSimpleMarkerProperties(System.Windows.TextMarkerStyle @style, System.Double @offset, System.Int32 @autoNumberingIndex, System.Windows.Media.TextFormatting.TextParagraphProperties @textParagraphProperties): base(@style, @offset, @autoNumberingIndex, @textParagraphProperties)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}