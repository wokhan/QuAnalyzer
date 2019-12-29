namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class BindingBase : Proxy<global::Windows.UI.Xaml.Data.BindingBase>
    {
        public System.Object FallbackValue
        {
            get => __ProxyValue.FallbackValue;
            set => __ProxyValue.FallbackValue = value;
        }

        public System.String StringFormat
        {
            get => __ProxyValue.StringFormat;
            set => __ProxyValue.StringFormat = value;
        }

        public System.Object TargetNullValue
        {
            get => __ProxyValue.TargetNullValue;
            set => __ProxyValue.TargetNullValue = value;
        }

        public System.String BindingGroupName
        {
            get => __ProxyValue.BindingGroupName;
            set => __ProxyValue.BindingGroupName = value;
        }

        public System.Int32 Delay
        {
            get => __ProxyValue.Delay;
            set => __ProxyValue.Delay = value;
        }

        public System.Boolean ShouldSerializeFallbackValue() => __ProxyValue.ShouldSerializeFallbackValue();
        public System.Boolean ShouldSerializeTargetNullValue() => __ProxyValue.ShouldSerializeTargetNullValue();
        public System.Object ProvideValue(System.IServiceProvider serviceProvider) => __ProxyValue.ProvideValue(@serviceProvider);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}