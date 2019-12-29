namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class IndexedGlyphRun : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.IndexedGlyphRun>
    {
        public System.Int32 TextSourceCharacterIndex
        {
            get => __ProxyValue.TextSourceCharacterIndex;
        }

        public System.Int32 TextSourceLength
        {
            get => __ProxyValue.TextSourceLength;
        }

        public System.Windows.Media.GlyphRun GlyphRun
        {
            get => __ProxyValue.GlyphRun;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}