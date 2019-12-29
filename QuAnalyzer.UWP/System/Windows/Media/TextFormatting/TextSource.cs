namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextSource : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextSource>
    {
        public System.Double PixelsPerDip
        {
            get => __ProxyValue.PixelsPerDip;
            set => __ProxyValue.PixelsPerDip = value;
        }

        public System.Windows.Media.TextFormatting.TextRun GetTextRun(System.Int32 textSourceCharacterIndex) => __ProxyValue.GetTextRun(@textSourceCharacterIndex);
        public System.Windows.Media.TextFormatting.TextSpan<System.Windows.Media.TextFormatting.CultureSpecificCharacterBufferRange> GetPrecedingText(System.Int32 textSourceCharacterIndexLimit) => __ProxyValue.GetPrecedingText(@textSourceCharacterIndexLimit);
        public System.Int32 GetTextEffectCharacterIndexFromTextSourceCharacterIndex(System.Int32 textSourceCharacterIndex) => __ProxyValue.GetTextEffectCharacterIndexFromTextSourceCharacterIndex(@textSourceCharacterIndex);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}