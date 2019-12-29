namespace System.Windows.Documents.DocumentStructures
{
    using Uno.UI.Generic;

    public class TableRowGroupStructure : Proxy<global::Windows.UI.Xaml.Documents.DocumentStructures.TableRowGroupStructure>
    {
        public TableRowGroupStructure(): base()
        {
        }

        public void Add(System.Windows.Documents.DocumentStructures.TableRowStructure tableRow) => __ProxyValue.Add(@tableRow);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}