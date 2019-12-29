namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridCellEditEndingEventArgs : Proxy<global::Windows.UI.Xaml.Controls.DataGridCellEditEndingEventArgs>
    {
        public System.Boolean Cancel
        {
            get => __ProxyValue.Cancel;
            set => __ProxyValue.Cancel = value;
        }

        public System.Windows.Controls.DataGridColumn Column
        {
            get => __ProxyValue.Column;
        }

        public System.Windows.Controls.DataGridRow Row
        {
            get => __ProxyValue.Row;
        }

        public System.Windows.FrameworkElement EditingElement
        {
            get => __ProxyValue.EditingElement;
        }

        public System.Windows.Controls.DataGridEditAction EditAction
        {
            get => __ProxyValue.EditAction;
        }

        public DataGridCellEditEndingEventArgs(System.Windows.Controls.DataGridColumn @column, System.Windows.Controls.DataGridRow @row, System.Windows.FrameworkElement @editingElement, System.Windows.Controls.DataGridEditAction @editAction): base(@column, @row, @editingElement, @editAction)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}