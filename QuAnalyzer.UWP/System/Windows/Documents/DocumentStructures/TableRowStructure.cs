namespace System.Windows.Documents.DocumentStructures
{
    using Uno.UI.Generic;

    public class TableRowStructure : Proxy<global::Windows.UI.Xaml.Documents.DocumentStructures.TableRowStructure>
    {
        public TableRowStructure(): base()
        {
        }

        public void Add(System.Windows.Documents.DocumentStructures.TableCellStructure tableCell) => __ProxyValue.Add(@tableCell);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}