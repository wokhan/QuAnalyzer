namespace System.Windows.Markup
{
    using Uno.UI.Generic;

    public class XamlDesignerSerializationManager : Proxy<global::Windows.UI.Xaml.Markup.XamlDesignerSerializationManager>
    {
        public System.Windows.Markup.XamlWriterMode XamlWriterMode
        {
            get => __ProxyValue.XamlWriterMode;
            set => __ProxyValue.XamlWriterMode = value;
        }

        public XamlDesignerSerializationManager(System.Xml.XmlWriter @xmlWriter): base(@xmlWriter)
        {
        }

        public System.Object GetService(System.Type serviceType) => __ProxyValue.GetService(@serviceType);
        public void AddService(System.Type serviceType, System.Object service) => __ProxyValue.AddService(@serviceType, @service);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}