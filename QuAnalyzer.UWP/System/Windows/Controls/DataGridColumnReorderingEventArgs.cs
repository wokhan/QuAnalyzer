namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridColumnReorderingEventArgs : Proxy<global::Windows.UI.Xaml.Controls.DataGridColumnReorderingEventArgs>
    {
        public System.Boolean Cancel
        {
            get => __ProxyValue.Cancel;
            set => __ProxyValue.Cancel = value;
        }

        public System.Windows.Controls.Control DropLocationIndicator
        {
            get => __ProxyValue.DropLocationIndicator;
            set => __ProxyValue.DropLocationIndicator = value;
        }

        public System.Windows.Controls.Control DragIndicator
        {
            get => __ProxyValue.DragIndicator;
            set => __ProxyValue.DragIndicator = value;
        }

        public System.Windows.Controls.DataGridColumn Column
        {
            get => __ProxyValue.Column;
        }

        public DataGridColumnReorderingEventArgs(System.Windows.Controls.DataGridColumn @dataGridColumn): base(@dataGridColumn)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}