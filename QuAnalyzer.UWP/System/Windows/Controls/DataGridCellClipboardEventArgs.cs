namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridCellClipboardEventArgs : Proxy<global::Windows.UI.Xaml.Controls.DataGridCellClipboardEventArgs>
    {
        public System.Object Content
        {
            get => __ProxyValue.Content;
            set => __ProxyValue.Content = value;
        }

        public System.Object Item
        {
            get => __ProxyValue.Item;
        }

        public System.Windows.Controls.DataGridColumn Column
        {
            get => __ProxyValue.Column;
        }

        public DataGridCellClipboardEventArgs(System.Object @item, System.Windows.Controls.DataGridColumn @column, System.Object @content): base(@item, @column, @content)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}