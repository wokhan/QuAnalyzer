namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class PageContentCollection : Proxy<global::Windows.UI.Xaml.Documents.PageContentCollection>
    {
        public System.Windows.Documents.PageContent Item
        {
            get => __ProxyValue.Item;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Int32 Add(System.Windows.Documents.PageContent newPageContent) => __ProxyValue.Add(@newPageContent);
        public System.Collections.Generic.IEnumerator<System.Windows.Documents.PageContent> GetEnumerator() => __ProxyValue.GetEnumerator();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}