namespace System.Windows.Annotations.Storage
{
    using Uno.UI.Generic;

    public class StoreContentChangedEventArgs : Proxy<global::Windows.UI.Xaml.Annotations.Storage.StoreContentChangedEventArgs>
    {
        public System.Windows.Annotations.Annotation Annotation
        {
            get => __ProxyValue.Annotation;
        }

        public System.Windows.Annotations.Storage.StoreContentAction Action
        {
            get => __ProxyValue.Action;
        }

        public StoreContentChangedEventArgs(System.Windows.Annotations.Storage.StoreContentAction @action, System.Windows.Annotations.Annotation @annotation): base(@action, @annotation)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}