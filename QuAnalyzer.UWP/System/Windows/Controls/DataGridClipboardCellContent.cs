namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridClipboardCellContent : Proxy<global::Windows.UI.Xaml.Controls.DataGridClipboardCellContent>
    {
        public System.Object Item
        {
            get => __ProxyValue.Item;
        }

        public System.Windows.Controls.DataGridColumn Column
        {
            get => __ProxyValue.Column;
        }

        public System.Object Content
        {
            get => __ProxyValue.Content;
        }

        public DataGridClipboardCellContent(System.Object @item, System.Windows.Controls.DataGridColumn @column, System.Object @content): base(@item, @column, @content)
        {
        }

        public override System.Boolean Equals(System.Object data) => __ProxyValue.Equals(@data);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Boolean op_Equality(System.Windows.Controls.DataGridClipboardCellContent clipboardCellContent1, System.Windows.Controls.DataGridClipboardCellContent clipboardCellContent2) => Windows.UI.Xaml.Controls.DataGridClipboardCellContent.op_Equality(@clipboardCellContent1, @clipboardCellContent2);
        public static System.Boolean op_Inequality(System.Windows.Controls.DataGridClipboardCellContent clipboardCellContent1, System.Windows.Controls.DataGridClipboardCellContent clipboardCellContent2) => Windows.UI.Xaml.Controls.DataGridClipboardCellContent.op_Inequality(@clipboardCellContent1, @clipboardCellContent2);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}