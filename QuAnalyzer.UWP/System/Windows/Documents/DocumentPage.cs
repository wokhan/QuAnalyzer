namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class DocumentPage : Proxy<global::Windows.UI.Xaml.Documents.DocumentPage>
    {
        public System.Windows.Media.Visual Visual
        {
            get => __ProxyValue.Visual;
        }

        public System.Windows.Size Size
        {
            get => __ProxyValue.Size;
        }

        public System.Windows.Rect BleedBox
        {
            get => __ProxyValue.BleedBox;
        }

        public System.Windows.Rect ContentBox
        {
            get => __ProxyValue.ContentBox;
        }

        public DocumentPage(System.Windows.Media.Visual @visual): base(@visual)
        {
        }

        public DocumentPage(System.Windows.Media.Visual @visual, System.Windows.Size @pageSize, System.Windows.Rect @bleedBox, System.Windows.Rect @contentBox): base(@visual, @pageSize, @bleedBox, @contentBox)
        {
        }

        public void Dispose() => __ProxyValue.Dispose();
        public void add_PageDestroyed(System.EventHandler value) => __ProxyValue.add_PageDestroyed(@value);
        public void remove_PageDestroyed(System.EventHandler value) => __ProxyValue.remove_PageDestroyed(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}