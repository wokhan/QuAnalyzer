namespace System.Windows
{
    using Uno.UI.Generic;

    public class DataTemplateKey : Proxy<global::Windows.UI.Xaml.DataTemplateKey>
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

        public DataTemplateKey(): base()
        {
        }

        public DataTemplateKey(System.Object @dataType): base(@dataType)
        {
        }

        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.Object ProvideValue(System.IServiceProvider serviceProvider) => __ProxyValue.ProvideValue(@serviceProvider);
    }
}