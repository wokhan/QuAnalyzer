namespace System.Windows
{
    using Uno.UI.Generic;

    public class RoutedEvent : Proxy<global::Windows.UI.Xaml.RoutedEvent>
    {
        public System.String Name
        {
            get => __ProxyValue.Name;
        }

        public System.Windows.RoutingStrategy RoutingStrategy
        {
            get => __ProxyValue.RoutingStrategy;
        }

        public System.Type HandlerType
        {
            get => __ProxyValue.HandlerType;
        }

        public System.Type OwnerType
        {
            get => __ProxyValue.OwnerType;
        }

        public System.Windows.RoutedEvent AddOwner(System.Type ownerType) => __ProxyValue.AddOwner(@ownerType);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}