namespace System.Windows.Annotations
{
    using Uno.UI.Generic;

    public class AnnotationService : Proxy<global::Windows.UI.Xaml.Annotations.AnnotationService>
    {
        public System.Boolean IsEnabled
        {
            get => __ProxyValue.IsEnabled;
        }

        public System.Windows.Annotations.Storage.AnnotationStore Store
        {
            get => __ProxyValue.Store;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public AnnotationService(System.Windows.Controls.Primitives.DocumentViewerBase @viewer): base(@viewer)
        {
        }

        public AnnotationService(System.Windows.Controls.FlowDocumentScrollViewer @viewer): base(@viewer)
        {
        }

        public AnnotationService(System.Windows.Controls.FlowDocumentReader @viewer): base(@viewer)
        {
        }

        public void Enable(System.Windows.Annotations.Storage.AnnotationStore annotationStore) => __ProxyValue.Enable(@annotationStore);
        public void Disable() => __ProxyValue.Disable();
        public static System.Windows.Annotations.AnnotationService GetService(System.Windows.Controls.Primitives.DocumentViewerBase viewer) => Windows.UI.Xaml.Annotations.AnnotationService.GetService(@viewer);
        public static System.Windows.Annotations.AnnotationService GetService(System.Windows.Controls.FlowDocumentReader reader) => Windows.UI.Xaml.Annotations.AnnotationService.GetService(@reader);
        public static System.Windows.Annotations.AnnotationService GetService(System.Windows.Controls.FlowDocumentScrollViewer viewer) => Windows.UI.Xaml.Annotations.AnnotationService.GetService(@viewer);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}