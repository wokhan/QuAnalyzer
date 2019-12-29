namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class TextElementCollection`1<TextElementType> : Proxy<global::Windows.UI.Xaml.Documents.TextElementCollection<TextElementType>>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public void Add(TextElementType item) => __ProxyValue.Add(@item);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(TextElementType item) => __ProxyValue.Contains(@item);
        public void CopyTo(System.Windows.Documents.TextElementType[] array, System.Int32 arrayIndex) => __ProxyValue.CopyTo(@array, @arrayIndex);
        public System.Boolean Remove(TextElementType item) => __ProxyValue.Remove(@item);
        public void InsertAfter(TextElementType previousSibling, TextElementType newItem) => __ProxyValue.InsertAfter(@previousSibling, @newItem);
        public void InsertBefore(TextElementType nextSibling, TextElementType newItem) => __ProxyValue.InsertBefore(@nextSibling, @newItem);
        public void AddRange(System.Collections.IEnumerable range) => __ProxyValue.AddRange(@range);
        public System.Collections.Generic.IEnumerator<TextElementType> GetEnumerator() => __ProxyValue.GetEnumerator();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}