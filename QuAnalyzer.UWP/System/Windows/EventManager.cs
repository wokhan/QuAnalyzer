namespace System.Windows
{
    using Uno.UI.Generic;

    public class EventManager : Proxy<global::Windows.UI.Xaml.EventManager>
    {
        public static System.Windows.RoutedEvent RegisterRoutedEvent(System.String name, System.Windows.RoutingStrategy routingStrategy, System.Type handlerType, System.Type ownerType) => Windows.UI.Xaml.EventManager.RegisterRoutedEvent(@name, @routingStrategy, @handlerType, @ownerType);
        public static void RegisterClassHandler(System.Type classType, System.Windows.RoutedEvent routedEvent, System.Delegate handler) => Windows.UI.Xaml.EventManager.RegisterClassHandler(@classType, @routedEvent, @handler);
        public static void RegisterClassHandler(System.Type classType, System.Windows.RoutedEvent routedEvent, System.Delegate handler, System.Boolean handledEventsToo) => Windows.UI.Xaml.EventManager.RegisterClassHandler(@classType, @routedEvent, @handler, @handledEventsToo);
        public static System.Windows.RoutedEvent[] GetRoutedEvents() => Windows.UI.Xaml.EventManager.GetRoutedEvents();
        public static System.Windows.RoutedEvent[] GetRoutedEventsForOwner(System.Type ownerType) => Windows.UI.Xaml.EventManager.GetRoutedEventsForOwner(@ownerType);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}