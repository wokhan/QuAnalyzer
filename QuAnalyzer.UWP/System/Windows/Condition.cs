namespace System.Windows
{
    using Uno.UI.Generic;

    public class Condition : Proxy<global::Windows.UI.Xaml.Condition>
    {
        public System.Windows.DependencyProperty Property
        {
            get => __ProxyValue.Property;
            set => __ProxyValue.Property = value;
        }

        public System.Windows.Data.BindingBase Binding
        {
            get => __ProxyValue.Binding;
            set => __ProxyValue.Binding = value;
        }

        public System.Object Value
        {
            get => __ProxyValue.Value;
            set => __ProxyValue.Value = value;
        }

        public System.String SourceName
        {
            get => __ProxyValue.SourceName;
            set => __ProxyValue.SourceName = value;
        }

        public Condition(): base()
        {
        }

        public Condition(System.Windows.DependencyProperty @conditionProperty, System.Object @conditionValue): base(@conditionProperty, @conditionValue)
        {
        }

        public Condition(System.Windows.DependencyProperty @conditionProperty, System.Object @conditionValue, System.String @sourceName): base(@conditionProperty, @conditionValue, @sourceName)
        {
        }

        public Condition(System.Windows.Data.BindingBase @binding, System.Object @conditionValue): base(@binding, @conditionValue)
        {
        }

        public static void ReceiveMarkupExtension(System.Object targetObject, System.Windows.Markup.XamlSetMarkupExtensionEventArgs eventArgs) => Windows.UI.Xaml.Condition.ReceiveMarkupExtension(@targetObject, @eventArgs);
        public static void ReceiveTypeConverter(System.Object targetObject, System.Windows.Markup.XamlSetTypeConverterEventArgs eventArgs) => Windows.UI.Xaml.Condition.ReceiveTypeConverter(@targetObject, @eventArgs);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}