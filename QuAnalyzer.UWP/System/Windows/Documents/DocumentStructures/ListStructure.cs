namespace System.Windows.Documents.DocumentStructures
{
    using Uno.UI.Generic;

    public class ListStructure : Proxy<global::Windows.UI.Xaml.Documents.DocumentStructures.ListStructure>
    {
        public ListStructure(): base()
        {
        }

        public void Add(System.Windows.Documents.DocumentStructures.ListItemStructure listItem) => __ProxyValue.Add(@listItem);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}