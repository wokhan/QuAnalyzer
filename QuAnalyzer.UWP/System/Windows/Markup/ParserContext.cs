namespace System.Windows.Markup
{
    using Uno.UI.Generic;

    public class ParserContext : Proxy<global::Windows.UI.Xaml.Markup.ParserContext>
    {
        public System.Windows.Markup.XmlnsDictionary XmlnsDictionary
        {
            get => __ProxyValue.XmlnsDictionary;
        }

        public System.String XmlLang
        {
            get => __ProxyValue.XmlLang;
            set => __ProxyValue.XmlLang = value;
        }

        public System.String XmlSpace
        {
            get => __ProxyValue.XmlSpace;
            set => __ProxyValue.XmlSpace = value;
        }

        public System.Windows.Markup.XamlTypeMapper XamlTypeMapper
        {
            get => __ProxyValue.XamlTypeMapper;
            set => __ProxyValue.XamlTypeMapper = value;
        }

        public System.Uri BaseUri
        {
            get => __ProxyValue.BaseUri;
            set => __ProxyValue.BaseUri = value;
        }

        public ParserContext(): base()
        {
        }

        public ParserContext(System.Xml.XmlParserContext @xmlParserContext): base(@xmlParserContext)
        {
        }

        public static System.Xml.XmlParserContext op_Implicit(System.Windows.Markup.ParserContext parserContext) => Windows.UI.Xaml.Markup.ParserContext.op_Implicit(@parserContext);
        public static System.Xml.XmlParserContext ToXmlParserContext(System.Windows.Markup.ParserContext parserContext) => Windows.UI.Xaml.Markup.ParserContext.ToXmlParserContext(@parserContext);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}