namespace System.Windows
{
    using Uno.UI.Generic;

    public class DynamicResourceExtension : Proxy<global::Windows.UI.Xaml.DynamicResourceExtension>
    {
        public System.Object ResourceKey
        {
            get => __ProxyValue.ResourceKey;
            set => __ProxyValue.ResourceKey = value;
        }

        public DynamicResourceExtension(): base()
        {
        }

        public DynamicResourceExtension(System.Object @resourceKey): base(@resourceKey)
        {
        }

        public System.Object ProvideValue(System.IServiceProvider serviceProvider) => __ProxyValue.ProvideValue(@serviceProvider);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}