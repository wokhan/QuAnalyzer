namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridRowDetailsEventArgs : Proxy<global::Windows.UI.Xaml.Controls.DataGridRowDetailsEventArgs>
    {
        public System.Windows.FrameworkElement DetailsElement
        {
            get => __ProxyValue.DetailsElement;
        }

        public System.Windows.Controls.DataGridRow Row
        {
            get => __ProxyValue.Row;
        }

        public DataGridRowDetailsEventArgs(System.Windows.Controls.DataGridRow @row, System.Windows.FrameworkElement @detailsElement): base(@row, @detailsElement)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}