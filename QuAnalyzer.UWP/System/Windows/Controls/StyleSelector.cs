namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class StyleSelector : Proxy<global::Windows.UI.Xaml.Controls.StyleSelector>
    {
        public StyleSelector(): base()
        {
        }

        public System.Windows.Style SelectStyle(System.Object item, System.Windows.DependencyObject container) => __ProxyValue.SelectStyle(@item, @container);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}