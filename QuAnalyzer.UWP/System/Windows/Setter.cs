namespace System.Windows
{
    using Uno.UI.Generic;

    public class Setter : Proxy<global::Windows.UI.Xaml.Setter>
    {
        public System.Windows.DependencyProperty Property
        {
            get => __ProxyValue.Property;
            set => __ProxyValue.Property = value;
        }

        public System.Object Value
        {
            get => __ProxyValue.Value;
            set => __ProxyValue.Value = value;
        }

        public System.String TargetName
        {
            get => __ProxyValue.TargetName;
            set => __ProxyValue.TargetName = value;
        }

        public System.Boolean IsSealed
        {
            get => __ProxyValue.IsSealed;
        }

        public Setter(): base()
        {
        }

        public Setter(System.Windows.DependencyProperty @property, System.Object @value): base(@property, @value)
        {
        }

        public Setter(System.Windows.DependencyProperty @property, System.Object @value, System.String @targetName): base(@property, @value, @targetName)
        {
        }

        public static void ReceiveMarkupExtension(System.Object targetObject, System.Windows.Markup.XamlSetMarkupExtensionEventArgs eventArgs) => Windows.UI.Xaml.Setter.ReceiveMarkupExtension(@targetObject, @eventArgs);
        public static void ReceiveTypeConverter(System.Object targetObject, System.Windows.Markup.XamlSetTypeConverterEventArgs eventArgs) => Windows.UI.Xaml.Setter.ReceiveTypeConverter(@targetObject, @eventArgs);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}