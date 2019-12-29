namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridAutoGeneratingColumnEventArgs : Proxy<global::Windows.UI.Xaml.Controls.DataGridAutoGeneratingColumnEventArgs>
    {
        public System.Windows.Controls.DataGridColumn Column
        {
            get => __ProxyValue.Column;
            set => __ProxyValue.Column = value;
        }

        public System.String PropertyName
        {
            get => __ProxyValue.PropertyName;
        }

        public System.Type PropertyType
        {
            get => __ProxyValue.PropertyType;
        }

        public System.Object PropertyDescriptor
        {
            get => __ProxyValue.PropertyDescriptor;
        }

        public System.Boolean Cancel
        {
            get => __ProxyValue.Cancel;
            set => __ProxyValue.Cancel = value;
        }

        public DataGridAutoGeneratingColumnEventArgs(System.String @propertyName, System.Type @propertyType, System.Windows.Controls.DataGridColumn @column): base(@propertyName, @propertyType, @column)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}