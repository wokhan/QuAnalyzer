namespace System.Windows.Threading
{
    using Uno.UI.Generic;

    public class DispatcherHookEventArgs : Proxy<global::Windows.UI.Xaml.Threading.DispatcherHookEventArgs>
    {
        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public System.Windows.Threading.DispatcherOperation Operation
        {
            get => __ProxyValue.Operation;
        }

        public DispatcherHookEventArgs(System.Windows.Threading.DispatcherOperation @operation): base(@operation)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}