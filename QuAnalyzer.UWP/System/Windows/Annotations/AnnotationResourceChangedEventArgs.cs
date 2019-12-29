namespace System.Windows.Annotations
{
    using Uno.UI.Generic;

    public class AnnotationResourceChangedEventArgs : Proxy<global::Windows.UI.Xaml.Annotations.AnnotationResourceChangedEventArgs>
    {
        public System.Windows.Annotations.Annotation Annotation
        {
            get => __ProxyValue.Annotation;
        }

        public System.Windows.Annotations.AnnotationResource Resource
        {
            get => __ProxyValue.Resource;
        }

        public System.Windows.Annotations.AnnotationAction Action
        {
            get => __ProxyValue.Action;
        }

        public AnnotationResourceChangedEventArgs(System.Windows.Annotations.Annotation @annotation, System.Windows.Annotations.AnnotationAction @action, System.Windows.Annotations.AnnotationResource @resource): base(@annotation, @action, @resource)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}