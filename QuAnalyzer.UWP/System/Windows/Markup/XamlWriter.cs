namespace System.Windows.Markup
{
    using Uno.UI.Generic;

    public class XamlWriter : Proxy<global::Windows.UI.Xaml.Markup.XamlWriter>
    {
        public static System.String Save(System.Object obj) => Windows.UI.Xaml.Markup.XamlWriter.Save(@obj);
        public static void Save(System.Object obj, System.IO.TextWriter writer) => Windows.UI.Xaml.Markup.XamlWriter.Save(@obj, @writer);
        public static void Save(System.Object obj, System.IO.Stream stream) => Windows.UI.Xaml.Markup.XamlWriter.Save(@obj, @stream);
        public static void Save(System.Object obj, System.Xml.XmlWriter xmlWriter) => Windows.UI.Xaml.Markup.XamlWriter.Save(@obj, @xmlWriter);
        public static void Save(System.Object obj, System.Windows.Markup.XamlDesignerSerializationManager manager) => Windows.UI.Xaml.Markup.XamlWriter.Save(@obj, @manager);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}