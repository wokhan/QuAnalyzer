namespace System.Windows
{
    using Uno.UI.Generic;

    public class WeakEventManager`2<TEventSource, TEventArgs> : Proxy<global::Windows.UI.Xaml.WeakEventManager<TEventSource, TEventArgs>>
    {
        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public static void AddHandler(TEventSource source, System.String eventName, System.EventHandler<TEventArgs> handler) => Windows.UI.Xaml.WeakEventManager`2.AddHandler(@source, @eventName, @handler);
        public static void RemoveHandler(TEventSource source, System.String eventName, System.EventHandler<TEventArgs> handler) => Windows.UI.Xaml.WeakEventManager`2.RemoveHandler(@source, @eventName, @handler);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}