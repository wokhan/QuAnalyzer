namespace System.Windows.Annotations.Storage
{
    using Uno.UI.Generic;

    public class XmlStreamStore : Proxy<global::Windows.UI.Xaml.Annotations.Storage.XmlStreamStore>
    {
        public System.Boolean AutoFlush
        {
            get => __ProxyValue.AutoFlush;
            set => __ProxyValue.AutoFlush = value;
        }

        public System.Collections.Generic.IList<System.Uri> IgnoredNamespaces
        {
            get => __ProxyValue.IgnoredNamespaces;
        }

        public static System.Collections.Generic.IList<System.Uri> WellKnownNamespaces
        {
            get => __ProxyValue.WellKnownNamespaces;
        }

        public XmlStreamStore(System.IO.Stream @stream): base(@stream)
        {
        }

        public XmlStreamStore(System.IO.Stream @stream, System.Collections.Generic.IDictionary<System.Uri, System.Collections.Generic.IList<System.Uri>> @knownNamespaces): base(@stream, @knownNamespaces)
        {
        }

        public void AddAnnotation(System.Windows.Annotations.Annotation newAnnotation) => __ProxyValue.AddAnnotation(@newAnnotation);
        public System.Windows.Annotations.Annotation DeleteAnnotation(System.Guid annotationId) => __ProxyValue.DeleteAnnotation(@annotationId);
        public System.Collections.Generic.IList<System.Windows.Annotations.Annotation> GetAnnotations(System.Windows.Annotations.ContentLocator anchorLocator) => __ProxyValue.GetAnnotations(@anchorLocator);
        public System.Collections.Generic.IList<System.Windows.Annotations.Annotation> GetAnnotations() => __ProxyValue.GetAnnotations();
        public System.Windows.Annotations.Annotation GetAnnotation(System.Guid annotationId) => __ProxyValue.GetAnnotation(@annotationId);
        public void Flush() => __ProxyValue.Flush();
        public static System.Collections.Generic.IList<System.Uri> GetWellKnownCompatibleNamespaces(System.Uri name) => Windows.UI.Xaml.Annotations.Storage.XmlStreamStore.GetWellKnownCompatibleNamespaces(@name);
        public void Dispose() => __ProxyValue.Dispose();
        public void add_StoreContentChanged(System.Windows.Annotations.Storage.StoreContentChangedEventHandler value) => __ProxyValue.add_StoreContentChanged(@value);
        public void remove_StoreContentChanged(System.Windows.Annotations.Storage.StoreContentChangedEventHandler value) => __ProxyValue.remove_StoreContentChanged(@value);
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