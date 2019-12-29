namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataTemplateSelector : Proxy<global::Windows.UI.Xaml.Controls.DataTemplateSelector>
    {
        public DataTemplateSelector(): base()
        {
        }

        public System.Windows.DataTemplate SelectTemplate(System.Object item, System.Windows.DependencyObject container) => __ProxyValue.SelectTemplate(@item, @container);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}