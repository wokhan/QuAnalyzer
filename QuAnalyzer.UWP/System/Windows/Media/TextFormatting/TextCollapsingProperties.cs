namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextCollapsingProperties : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextCollapsingProperties>
    {
        public System.Double Width
        {
            get => __ProxyValue.Width;
        }

        public System.Windows.Media.TextFormatting.TextRun Symbol
        {
            get => __ProxyValue.Symbol;
        }

        public System.Windows.Media.TextFormatting.TextCollapsingStyle Style
        {
            get => __ProxyValue.Style;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}