namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class ItemContainerTemplateKey : Proxy<global::Windows.UI.Xaml.Controls.ItemContainerTemplateKey>
    {
        public System.Object DataType
        {
            get => __ProxyValue.DataType;
            set => __ProxyValue.DataType = value;
        }

        public System.Reflection.Assembly Assembly
        {
            get => __ProxyValue.Assembly;
        }

        public ItemContainerTemplateKey(): base()
        {
        }

        public ItemContainerTemplateKey(System.Object @dataType): base(@dataType)
        {
        }

        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.Object ProvideValue(System.IServiceProvider serviceProvider) => __ProxyValue.ProvideValue(@serviceProvider);
    }
}