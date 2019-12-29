namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridSortingEventArgs : Proxy<global::Windows.UI.Xaml.Controls.DataGridSortingEventArgs>
    {
        public System.Boolean Handled
        {
            get => __ProxyValue.Handled;
            set => __ProxyValue.Handled = value;
        }

        public System.Windows.Controls.DataGridColumn Column
        {
            get => __ProxyValue.Column;
        }

        public DataGridSortingEventArgs(System.Windows.Controls.DataGridColumn @column): base(@column)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}