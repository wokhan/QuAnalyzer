namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridBeginningEditEventArgs : Proxy<global::Windows.UI.Xaml.Controls.DataGridBeginningEditEventArgs>
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

        public System.Windows.RoutedEventArgs EditingEventArgs
        {
            get => __ProxyValue.EditingEventArgs;
        }

        public DataGridBeginningEditEventArgs(System.Windows.Controls.DataGridColumn @column, System.Windows.Controls.DataGridRow @row, System.Windows.RoutedEventArgs @editingEventArgs): base(@column, @row, @editingEventArgs)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}