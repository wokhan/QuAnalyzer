namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridPreparingCellForEditEventArgs : Proxy<global::Windows.UI.Xaml.Controls.DataGridPreparingCellForEditEventArgs>
    {
        public System.Windows.Controls.DataGridColumn Column
        {
            get => __ProxyValue.Column;
        }

        public System.Windows.Controls.DataGridRow Row
        {
            get => __ProxyValue.Row;
        }

        public System.Windows.RoutedEventArgs EditingEventArgs
        {
            get => __ProxyValue.EditingEventArgs;
        }

        public System.Windows.FrameworkElement EditingElement
        {
            get => __ProxyValue.EditingElement;
        }

        public DataGridPreparingCellForEditEventArgs(System.Windows.Controls.DataGridColumn @column, System.Windows.Controls.DataGridRow @row, System.Windows.RoutedEventArgs @editingEventArgs, System.Windows.FrameworkElement @editingElement): base(@column, @row, @editingEventArgs, @editingElement)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}