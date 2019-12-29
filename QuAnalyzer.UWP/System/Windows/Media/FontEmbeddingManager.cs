namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class FontEmbeddingManager : Proxy<global::Windows.UI.Xaml.Media.FontEmbeddingManager>
    {
        public System.Collections.Generic.ICollection<System.Uri> GlyphTypefaceUris
        {
            get => __ProxyValue.GlyphTypefaceUris;
        }

        public FontEmbeddingManager(): base()
        {
        }

        public void RecordUsage(System.Windows.Media.GlyphRun glyphRun) => __ProxyValue.RecordUsage(@glyphRun);
        public System.Collections.Generic.ICollection<System.UInt16> GetUsedGlyphs(System.Uri glyphTypeface) => __ProxyValue.GetUsedGlyphs(@glyphTypeface);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}