namespace System.Windows
{
    using Uno.UI.Generic;

    public class EventSetter : Proxy<global::Windows.UI.Xaml.EventSetter>
    {
        public System.Windows.RoutedEvent Event
        {
            get => __ProxyValue.Event;
            set => __ProxyValue.Event = value;
        }

        public System.Delegate Handler
        {
            get => __ProxyValue.Handler;
            set => __ProxyValue.Handler = value;
        }

        public System.Boolean HandledEventsToo
        {
            get => __ProxyValue.HandledEventsToo;
            set => __ProxyValue.HandledEventsToo = value;
        }

        public System.Boolean IsSealed
        {
            get => __ProxyValue.IsSealed;
        }

        public EventSetter(): base()
        {
        }

        public EventSetter(System.Windows.RoutedEvent @routedEvent, System.Delegate @handler): base(@routedEvent, @handler)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}