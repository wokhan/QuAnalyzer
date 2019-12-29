namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextRunBounds : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextRunBounds>
    {
        public System.Int32 TextSourceCharacterIndex
        {
            get => __ProxyValue.TextSourceCharacterIndex;
        }

        public System.Int32 Length
        {
            get => __ProxyValue.Length;
        }

        public System.Windows.Rect Rectangle
        {
            get => __ProxyValue.Rectangle;
        }

        public System.Windows.Media.TextFormatting.TextRun TextRun
        {
            get => __ProxyValue.TextRun;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}