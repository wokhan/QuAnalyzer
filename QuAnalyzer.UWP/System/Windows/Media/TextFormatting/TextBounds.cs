namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextBounds : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextBounds>
    {
        public System.Windows.Rect Rectangle
        {
            get => __ProxyValue.Rectangle;
        }

        public System.Collections.Generic.IList<System.Windows.Media.TextFormatting.TextRunBounds> TextRunBounds
        {
            get => __ProxyValue.TextRunBounds;
        }

        public System.Windows.FlowDirection FlowDirection
        {
            get => __ProxyValue.FlowDirection;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}