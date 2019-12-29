namespace System.Windows
{
    using Uno.UI.Generic;

    public class TemplateBindingExtension : Proxy<global::Windows.UI.Xaml.TemplateBindingExtension>
    {
        public System.Windows.DependencyProperty Property
        {
            get => __ProxyValue.Property;
            set => __ProxyValue.Property = value;
        }

        public System.Windows.Data.IValueConverter Converter
        {
            get => __ProxyValue.Converter;
            set => __ProxyValue.Converter = value;
        }

        public System.Object ConverterParameter
        {
            get => __ProxyValue.ConverterParameter;
            set => __ProxyValue.ConverterParameter = value;
        }

        public TemplateBindingExtension(): base()
        {
        }

        public TemplateBindingExtension(System.Windows.DependencyProperty @property): base(@property)
        {
        }

        public System.Object ProvideValue(System.IServiceProvider serviceProvider) => __ProxyValue.ProvideValue(@serviceProvider);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}