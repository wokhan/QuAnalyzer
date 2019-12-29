namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridRowEditEndingEventArgs : Proxy<global::Windows.UI.Xaml.Controls.DataGridRowEditEndingEventArgs>
    {
        public System.Boolean Cancel
        {
            get => __ProxyValue.Cancel;
            set => __ProxyValue.Cancel = value;
        }

        public System.Windows.Controls.DataGridRow Row
        {
            get => __ProxyValue.Row;
        }

        public System.Windows.Controls.DataGridEditAction EditAction
        {
            get => __ProxyValue.EditAction;
        }

        public DataGridRowEditEndingEventArgs(System.Windows.Controls.DataGridRow @row, System.Windows.Controls.DataGridEditAction @editAction): base(@row, @editAction)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}