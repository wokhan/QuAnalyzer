namespace System.Windows.Threading
{
    using Uno.UI.Generic;

    public class DispatcherHooks : Proxy<global::Windows.UI.Xaml.Threading.DispatcherHooks>
    {
        public void add_DispatcherInactive(System.EventHandler value) => __ProxyValue.add_DispatcherInactive(@value);
        public void remove_DispatcherInactive(System.EventHandler value) => __ProxyValue.remove_DispatcherInactive(@value);
        public void add_OperationPosted(System.Windows.Threading.DispatcherHookEventHandler value) => __ProxyValue.add_OperationPosted(@value);
        public void remove_OperationPosted(System.Windows.Threading.DispatcherHookEventHandler value) => __ProxyValue.remove_OperationPosted(@value);
        public void add_OperationStarted(System.Windows.Threading.DispatcherHookEventHandler value) => __ProxyValue.add_OperationStarted(@value);
        public void remove_OperationStarted(System.Windows.Threading.DispatcherHookEventHandler value) => __ProxyValue.remove_OperationStarted(@value);
        public void add_OperationCompleted(System.Windows.Threading.DispatcherHookEventHandler value) => __ProxyValue.add_OperationCompleted(@value);
        public void remove_OperationCompleted(System.Windows.Threading.DispatcherHookEventHandler value) => __ProxyValue.remove_OperationCompleted(@value);
        public void add_OperationPriorityChanged(System.Windows.Threading.DispatcherHookEventHandler value) => __ProxyValue.add_OperationPriorityChanged(@value);
        public void remove_OperationPriorityChanged(System.Windows.Threading.DispatcherHookEventHandler value) => __ProxyValue.remove_OperationPriorityChanged(@value);
        public void add_OperationAborted(System.Windows.Threading.DispatcherHookEventHandler value) => __ProxyValue.add_OperationAborted(@value);
        public void remove_OperationAborted(System.Windows.Threading.DispatcherHookEventHandler value) => __ProxyValue.remove_OperationAborted(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}