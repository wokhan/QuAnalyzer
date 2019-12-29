namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextParagraphProperties : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextParagraphProperties>
    {
        public System.Windows.FlowDirection FlowDirection
        {
            get => __ProxyValue.FlowDirection;
        }

        public System.Windows.TextAlignment TextAlignment
        {
            get => __ProxyValue.TextAlignment;
        }

        public System.Double LineHeight
        {
            get => __ProxyValue.LineHeight;
        }

        public System.Boolean FirstLineInParagraph
        {
            get => __ProxyValue.FirstLineInParagraph;
        }

        public System.Boolean AlwaysCollapsible
        {
            get => __ProxyValue.AlwaysCollapsible;
        }

        public System.Windows.Media.TextFormatting.TextRunProperties DefaultTextRunProperties
        {
            get => __ProxyValue.DefaultTextRunProperties;
        }

        public System.Windows.TextDecorationCollection TextDecorations
        {
            get => __ProxyValue.TextDecorations;
        }

        public System.Windows.TextWrapping TextWrapping
        {
            get => __ProxyValue.TextWrapping;
        }

        public System.Windows.Media.TextFormatting.TextMarkerProperties TextMarkerProperties
        {
            get => __ProxyValue.TextMarkerProperties;
        }

        public System.Double Indent
        {
            get => __ProxyValue.Indent;
        }

        public System.Double ParagraphIndent
        {
            get => __ProxyValue.ParagraphIndent;
        }

        public System.Double DefaultIncrementalTab
        {
            get => __ProxyValue.DefaultIncrementalTab;
        }

        public System.Collections.Generic.IList<System.Windows.Media.TextFormatting.TextTabProperties> Tabs
        {
            get => __ProxyValue.Tabs;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}