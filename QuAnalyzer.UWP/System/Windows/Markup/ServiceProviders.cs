namespace System.Windows.Markup
{
    using Uno.UI.Generic;

    public class ServiceProviders : Proxy<global::Windows.UI.Xaml.Markup.ServiceProviders>
    {
        public ServiceProviders(): base()
        {
        }

        public System.Object GetService(System.Type serviceType) => __ProxyValue.GetService(@serviceType);
        public void AddService(System.Type serviceType, System.Object service) => __ProxyValue.AddService(@serviceType, @service);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}