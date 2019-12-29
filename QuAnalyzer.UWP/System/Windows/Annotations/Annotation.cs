namespace System.Windows.Annotations
{
    using Uno.UI.Generic;

    public class Annotation : Proxy<global::Windows.UI.Xaml.Annotations.Annotation>
    {
        public System.Guid Id
        {
            get => __ProxyValue.Id;
        }

        public System.Xml.XmlQualifiedName AnnotationType
        {
            get => __ProxyValue.AnnotationType;
        }

        public System.DateTime CreationTime
        {
            get => __ProxyValue.CreationTime;
        }

        public System.DateTime LastModificationTime
        {
            get => __ProxyValue.LastModificationTime;
        }

        public System.Collections.ObjectModel.Collection<System.String> Authors
        {
            get => __ProxyValue.Authors;
        }

        public System.Collections.ObjectModel.Collection<System.Windows.Annotations.AnnotationResource> Anchors
        {
            get => __ProxyValue.Anchors;
        }

        public System.Collections.ObjectModel.Collection<System.Windows.Annotations.AnnotationResource> Cargos
        {
            get => __ProxyValue.Cargos;
        }

        public Annotation(): base()
        {
        }

        public Annotation(System.Xml.XmlQualifiedName @annotationType): base(@annotationType)
        {
        }

        public Annotation(System.Xml.XmlQualifiedName @annotationType, System.Guid @id, System.DateTime @creationTime, System.DateTime @lastModificationTime): base(@annotationType, @id, @creationTime, @lastModificationTime)
        {
        }

        public System.Xml.Schema.XmlSchema GetSchema() => __ProxyValue.GetSchema();
        public void WriteXml(System.Xml.XmlWriter writer) => __ProxyValue.WriteXml(@writer);
        public void ReadXml(System.Xml.XmlReader reader) => __ProxyValue.ReadXml(@reader);
        public void add_AuthorChanged(System.Windows.Annotations.AnnotationAuthorChangedEventHandler value) => __ProxyValue.add_AuthorChanged(@value);
        public void remove_AuthorChanged(System.Windows.Annotations.AnnotationAuthorChangedEventHandler value) => __ProxyValue.remove_AuthorChanged(@value);
        public void add_AnchorChanged(System.Windows.Annotations.AnnotationResourceChangedEventHandler value) => __ProxyValue.add_AnchorChanged(@value);
        public void remove_AnchorChanged(System.Windows.Annotations.AnnotationResourceChangedEventHandler value) => __ProxyValue.remove_AnchorChanged(@value);
        public void add_CargoChanged(System.Windows.Annotations.AnnotationResourceChangedEventHandler value) => __ProxyValue.add_CargoChanged(@value);
        public void remove_CargoChanged(System.Windows.Annotations.AnnotationResourceChangedEventHandler value) => __ProxyValue.remove_CargoChanged(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}