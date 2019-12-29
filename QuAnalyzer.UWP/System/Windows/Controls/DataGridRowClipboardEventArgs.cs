namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridRowClipboardEventArgs : Proxy<global::Windows.UI.Xaml.Controls.DataGridRowClipboardEventArgs>
    {
        public System.Object Item
        {
            get => __ProxyValue.Item;
        }

        public System.Collections.Generic.List<System.Windows.Controls.DataGridClipboardCellContent> ClipboardRowContent
        {
            get => __ProxyValue.ClipboardRowContent;
        }

        public System.Int32 StartColumnDisplayIndex
        {
            get => __ProxyValue.StartColumnDisplayIndex;
        }

        public System.Int32 EndColumnDisplayIndex
        {
            get => __ProxyValue.EndColumnDisplayIndex;
        }

        public System.Boolean IsColumnHeadersRow
        {
            get => __ProxyValue.IsColumnHeadersRow;
        }

        public DataGridRowClipboardEventArgs(System.Object @item, System.Int32 @startColumnDisplayIndex, System.Int32 @endColumnDisplayIndex, System.Boolean @isColumnHeadersRow): base(@item, @startColumnDisplayIndex, @endColumnDisplayIndex, @isColumnHeadersRow)
        {
        }

        public System.String FormatClipboardCellValues(System.String format) => __ProxyValue.FormatClipboardCellValues(@format);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}