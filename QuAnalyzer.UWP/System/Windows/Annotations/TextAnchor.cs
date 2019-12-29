namespace System.Windows.Annotations
{
    using Uno.UI.Generic;

    public class TextAnchor : Proxy<global::Windows.UI.Xaml.Annotations.TextAnchor>
    {
        public System.Windows.Documents.ContentPosition BoundingStart
        {
            get => __ProxyValue.BoundingStart;
        }

        public System.Windows.Documents.ContentPosition BoundingEnd
        {
            get => __ProxyValue.BoundingEnd;
        }

        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}