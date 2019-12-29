namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextEmbeddedObjectMetrics : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextEmbeddedObjectMetrics>
    {
        public System.Double Width
        {
            get => __ProxyValue.Width;
        }

        public System.Double Height
        {
            get => __ProxyValue.Height;
        }

        public System.Double Baseline
        {
            get => __ProxyValue.Baseline;
        }

        public TextEmbeddedObjectMetrics(System.Double @width, System.Double @height, System.Double @baseline): base(@width, @height, @baseline)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}