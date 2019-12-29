namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridRowEventArgs : Proxy<global::Windows.UI.Xaml.Controls.DataGridRowEventArgs>
    {
        public System.Windows.Controls.DataGridRow Row
        {
            get => __ProxyValue.Row;
        }

        public DataGridRowEventArgs(System.Windows.Controls.DataGridRow @row): base(@row)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}