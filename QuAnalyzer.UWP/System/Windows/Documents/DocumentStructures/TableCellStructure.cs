namespace System.Windows.Documents.DocumentStructures
{
    using Uno.UI.Generic;

    public class TableCellStructure : Proxy<global::Windows.UI.Xaml.Documents.DocumentStructures.TableCellStructure>
    {
        public System.Int32 RowSpan
        {
            get => __ProxyValue.RowSpan;
            set => __ProxyValue.RowSpan = value;
        }

        public System.Int32 ColumnSpan
        {
            get => __ProxyValue.ColumnSpan;
            set => __ProxyValue.ColumnSpan = value;
        }

        public TableCellStructure(): base()
        {
        }

        public void Add(System.Windows.Documents.DocumentStructures.BlockElement element) => __ProxyValue.Add(@element);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}