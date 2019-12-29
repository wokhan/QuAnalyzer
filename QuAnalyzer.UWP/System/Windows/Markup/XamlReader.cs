namespace System.Windows.Markup
{
    using Uno.UI.Generic;

    public class XamlReader : Proxy<global::Windows.UI.Xaml.Markup.XamlReader>
    {
        public XamlReader(): base()
        {
        }

        public static System.Object Parse(System.String xamlText) => Windows.UI.Xaml.Markup.XamlReader.Parse(@xamlText);
        public static System.Object Parse(System.String xamlText, System.Windows.Markup.ParserContext parserContext) => Windows.UI.Xaml.Markup.XamlReader.Parse(@xamlText, @parserContext);
        public static System.Object Load(System.IO.Stream stream) => Windows.UI.Xaml.Markup.XamlReader.Load(@stream);
        public static System.Object Load(System.Xml.XmlReader reader) => Windows.UI.Xaml.Markup.XamlReader.Load(@reader);
        public static System.Object Load(System.IO.Stream stream, System.Windows.Markup.ParserContext parserContext) => Windows.UI.Xaml.Markup.XamlReader.Load(@stream, @parserContext);
        public System.Object LoadAsync(System.IO.Stream stream) => __ProxyValue.LoadAsync(@stream);
        public System.Object LoadAsync(System.Xml.XmlReader reader) => __ProxyValue.LoadAsync(@reader);
        public System.Object LoadAsync(System.IO.Stream stream, System.Windows.Markup.ParserContext parserContext) => __ProxyValue.LoadAsync(@stream, @parserContext);
        public void CancelAsync() => __ProxyValue.CancelAsync();
        public void add_LoadCompleted(System.ComponentModel.AsyncCompletedEventHandler value) => __ProxyValue.add_LoadCompleted(@value);
        public void remove_LoadCompleted(System.ComponentModel.AsyncCompletedEventHandler value) => __ProxyValue.remove_LoadCompleted(@value);
        public static System.Xaml.XamlSchemaContext GetWpfSchemaContext() => Windows.UI.Xaml.Markup.XamlReader.GetWpfSchemaContext();
        public static System.Object Load(System.Xaml.XamlReader reader) => Windows.UI.Xaml.Markup.XamlReader.Load(@reader);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}