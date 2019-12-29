namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextRunCache : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextRunCache>
    {
        public TextRunCache(): base()
        {
        }

        public void Change(System.Int32 textSourceCharacterIndex, System.Int32 addition, System.Int32 removal) => __ProxyValue.Change(@textSourceCharacterIndex, @addition, @removal);
        public void Invalidate() => __ProxyValue.Invalidate();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}