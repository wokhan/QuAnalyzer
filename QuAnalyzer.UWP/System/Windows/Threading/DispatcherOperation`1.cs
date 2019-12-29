namespace System.Windows.Threading
{
    using Uno.UI.Generic;

    public class DispatcherOperation`1<TResult> : Proxy<global::Windows.UI.Xaml.Threading.DispatcherOperation<TResult>>
    {
        public System.Threading.Tasks.Task<TResult> Task
        {
            get => __ProxyValue.Task;
        }

        public TResult Result
        {
            get => __ProxyValue.Result;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public System.Windows.Threading.DispatcherPriority Priority
        {
            get => __ProxyValue.Priority;
            set => __ProxyValue.Priority = value;
        }

        public System.Windows.Threading.DispatcherOperationStatus Status
        {
            get => __ProxyValue.Status;
        }

        public System.Runtime.CompilerServices.TaskAwaiter<TResult> GetAwaiter() => __ProxyValue.GetAwaiter();
        public System.Windows.Threading.DispatcherOperationStatus Wait() => __ProxyValue.Wait();
        public System.Windows.Threading.DispatcherOperationStatus Wait(System.TimeSpan timeout) => __ProxyValue.Wait(@timeout);
        public System.Boolean Abort() => __ProxyValue.Abort();
        public void add_Aborted(System.EventHandler value) => __ProxyValue.add_Aborted(@value);
        public void remove_Aborted(System.EventHandler value) => __ProxyValue.remove_Aborted(@value);
        public void add_Completed(System.EventHandler value) => __ProxyValue.add_Completed(@value);
        public void remove_Completed(System.EventHandler value) => __ProxyValue.remove_Completed(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}