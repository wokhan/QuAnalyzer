namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridCellInfo : Proxy<global::Windows.UI.Xaml.Controls.DataGridCellInfo>
    {
        public System.Object Item
        {
            get => __ProxyValue.Item;
        }

        public System.Windows.Controls.DataGridColumn Column
        {
            get => __ProxyValue.Column;
        }

        public System.Boolean IsValid
        {
            get => __ProxyValue.IsValid;
        }

        public DataGridCellInfo(System.Object @item, System.Windows.Controls.DataGridColumn @column): base(@item, @column)
        {
        }

        public DataGridCellInfo(System.Windows.Controls.DataGridCell @cell): base(@cell)
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public static System.Boolean op_Equality(System.Windows.Controls.DataGridCellInfo cell1, System.Windows.Controls.DataGridCellInfo cell2) => Windows.UI.Xaml.Controls.DataGridCellInfo.op_Equality(@cell1, @cell2);
        public static System.Boolean op_Inequality(System.Windows.Controls.DataGridCellInfo cell1, System.Windows.Controls.DataGridCellInfo cell2) => Windows.UI.Xaml.Controls.DataGridCellInfo.op_Inequality(@cell1, @cell2);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}