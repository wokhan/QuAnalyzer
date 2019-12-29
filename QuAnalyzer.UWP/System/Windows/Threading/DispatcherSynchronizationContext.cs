namespace System.Windows.Threading
{
    using Uno.UI.Generic;

    public class DispatcherSynchronizationContext : Proxy<global::Windows.UI.Xaml.Threading.DispatcherSynchronizationContext>
    {
        public DispatcherSynchronizationContext(): base()
        {
        }

        public DispatcherSynchronizationContext(System.Windows.Threading.Dispatcher @dispatcher): base(@dispatcher)
        {
        }

        public DispatcherSynchronizationContext(System.Windows.Threading.Dispatcher @dispatcher, System.Windows.Threading.DispatcherPriority @priority): base(@dispatcher, @priority)
        {
        }

        public void Send(System.Threading.SendOrPostCallback d, System.Object state) => __ProxyValue.Send(@d, @state);
        public void Post(System.Threading.SendOrPostCallback d, System.Object state) => __ProxyValue.Post(@d, @state);
        public System.Int32 Wait(System.IntPtr[] waitHandles, System.Boolean waitAll, System.Int32 millisecondsTimeout) => __ProxyValue.Wait(@waitHandles, @waitAll, @millisecondsTimeout);
        public System.Threading.SynchronizationContext CreateCopy() => __ProxyValue.CreateCopy();
        public System.Boolean IsWaitNotificationRequired() => __ProxyValue.IsWaitNotificationRequired();
        public void OperationStarted() => __ProxyValue.OperationStarted();
        public void OperationCompleted() => __ProxyValue.OperationCompleted();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}