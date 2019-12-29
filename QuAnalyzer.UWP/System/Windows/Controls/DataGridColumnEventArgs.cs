namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridColumnEventArgs : Proxy<global::Windows.UI.Xaml.Controls.DataGridColumnEventArgs>
    {
        public System.Windows.Controls.DataGridColumn Column
        {
            get => __ProxyValue.Column;
        }

        public DataGridColumnEventArgs(System.Windows.Controls.DataGridColumn @column): base(@column)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}