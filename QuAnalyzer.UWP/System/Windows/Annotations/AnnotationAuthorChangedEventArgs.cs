namespace System.Windows.Annotations
{
    using Uno.UI.Generic;

    public class AnnotationAuthorChangedEventArgs : Proxy<global::Windows.UI.Xaml.Annotations.AnnotationAuthorChangedEventArgs>
    {
        public System.Windows.Annotations.Annotation Annotation
        {
            get => __ProxyValue.Annotation;
        }

        public System.Object Author
        {
            get => __ProxyValue.Author;
        }

        public System.Windows.Annotations.AnnotationAction Action
        {
            get => __ProxyValue.Action;
        }

        public AnnotationAuthorChangedEventArgs(System.Windows.Annotations.Annotation @annotation, System.Windows.Annotations.AnnotationAction @action, System.Object @author): base(@annotation, @action, @author)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}