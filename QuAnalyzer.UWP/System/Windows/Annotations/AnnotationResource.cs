namespace System.Windows.Annotations
{
    using Uno.UI.Generic;

    public class AnnotationResource : Proxy<global::Windows.UI.Xaml.Annotations.AnnotationResource>
    {
        public System.Guid Id
        {
            get => __ProxyValue.Id;
        }

        public System.String Name
        {
            get => __ProxyValue.Name;
            set => __ProxyValue.Name = value;
        }

        public System.Collections.ObjectModel.Collection<System.Windows.Annotations.ContentLocatorBase> ContentLocators
        {
            get => __ProxyValue.ContentLocators;
        }

        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Contents
        {
            get => __ProxyValue.Contents;
        }

        public AnnotationResource(): base()
        {
        }

        public AnnotationResource(System.String @name): base(@name)
        {
        }

        public AnnotationResource(System.Guid @id): base(@id)
        {
        }

        public System.Xml.Schema.XmlSchema GetSchema() => __ProxyValue.GetSchema();
        public void WriteXml(System.Xml.XmlWriter writer) => __ProxyValue.WriteXml(@writer);
        public void ReadXml(System.Xml.XmlReader reader) => __ProxyValue.ReadXml(@reader);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}