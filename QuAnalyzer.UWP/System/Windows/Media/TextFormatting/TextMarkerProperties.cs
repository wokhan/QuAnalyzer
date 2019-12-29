namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextMarkerProperties : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextMarkerProperties>
    {
        public System.Double Offset
        {
            get => __ProxyValue.Offset;
        }

        public System.Windows.Media.TextFormatting.TextSource TextSource
        {
            get => __ProxyValue.TextSource;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}