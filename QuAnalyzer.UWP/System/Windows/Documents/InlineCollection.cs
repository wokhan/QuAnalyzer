namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class InlineCollection : Proxy<global::Windows.UI.Xaml.Documents.InlineCollection>
    {
        public System.Windows.Documents.Inline FirstInline
        {
            get => __ProxyValue.FirstInline;
        }

        public System.Windows.Documents.Inline LastInline
        {
            get => __ProxyValue.LastInline;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public void Add(System.String text) => __ProxyValue.Add(@text);
        public void Add(System.Windows.UIElement uiElement) => __ProxyValue.Add(@uiElement);
        public void Add(System.Windows.Documents.Inline item) => __ProxyValue.Add(@item);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(System.Windows.Documents.Inline item) => __ProxyValue.Contains(@item);
        public void CopyTo(System.Windows.Documents.Inline[] array, System.Int32 arrayIndex) => __ProxyValue.CopyTo(@array, @arrayIndex);
        public System.Boolean Remove(System.Windows.Documents.Inline item) => __ProxyValue.Remove(@item);
        public void InsertAfter(System.Windows.Documents.Inline previousSibling, System.Windows.Documents.Inline newItem) => __ProxyValue.InsertAfter(@previousSibling, @newItem);
        public void InsertBefore(System.Windows.Documents.Inline nextSibling, System.Windows.Documents.Inline newItem) => __ProxyValue.InsertBefore(@nextSibling, @newItem);
        public void AddRange(System.Collections.IEnumerable range) => __ProxyValue.AddRange(@range);
        public System.Collections.Generic.IEnumerator<System.Windows.Documents.Inline> GetEnumerator() => __ProxyValue.GetEnumerator();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}