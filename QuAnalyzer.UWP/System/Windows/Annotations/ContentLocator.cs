namespace System.Windows.Annotations
{
    using Uno.UI.Generic;

    public class ContentLocator : Proxy<global::Windows.UI.Xaml.Annotations.ContentLocator>
    {
        public System.Collections.ObjectModel.Collection<System.Windows.Annotations.ContentLocatorPart> Parts
        {
            get => __ProxyValue.Parts;
        }

        public ContentLocator(): base()
        {
        }

        public System.Boolean StartsWith(System.Windows.Annotations.ContentLocator locator) => __ProxyValue.StartsWith(@locator);
        public System.Object Clone() => __ProxyValue.Clone();
        public System.Xml.Schema.XmlSchema GetSchema() => __ProxyValue.GetSchema();
        public void WriteXml(System.Xml.XmlWriter writer) => __ProxyValue.WriteXml(@writer);
        public void ReadXml(System.Xml.XmlReader reader) => __ProxyValue.ReadXml(@reader);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}