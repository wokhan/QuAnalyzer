namespace System.Windows
{
    using Uno.UI.Generic;

    public class TemplateBindingExpression : Proxy<global::Windows.UI.Xaml.TemplateBindingExpression>
    {
        public System.Windows.TemplateBindingExtension TemplateBindingExtension
        {
            get => __ProxyValue.TemplateBindingExtension;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}