namespace System.Windows.Documents.DocumentStructures
{
    using Uno.UI.Generic;

    public class TableStructure : Proxy<global::Windows.UI.Xaml.Documents.DocumentStructures.TableStructure>
    {
        public TableStructure(): base()
        {
        }

        public void Add(System.Windows.Documents.DocumentStructures.TableRowGroupStructure tableRowGroup) => __ProxyValue.Add(@tableRowGroup);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}