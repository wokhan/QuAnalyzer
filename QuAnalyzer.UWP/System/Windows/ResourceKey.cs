namespace System.Windows
{
    using Uno.UI.Generic;

    public class ResourceKey : Proxy<global::Windows.UI.Xaml.ResourceKey>
    {
        public System.Reflection.Assembly Assembly
        {
            get => __ProxyValue.Assembly;
        }

        public System.Object ProvideValue(System.IServiceProvider serviceProvider) => __ProxyValue.ProvideValue(@serviceProvider);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}