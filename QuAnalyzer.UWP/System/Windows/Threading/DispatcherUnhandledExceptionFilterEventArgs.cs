namespace System.Windows.Threading
{
    using Uno.UI.Generic;

    public class DispatcherUnhandledExceptionFilterEventArgs : Proxy<global::Windows.UI.Xaml.Threading.DispatcherUnhandledExceptionFilterEventArgs>
    {
        public System.Exception Exception
        {
            get => __ProxyValue.Exception;
        }

        public System.Boolean RequestCatch
        {
            get => __ProxyValue.RequestCatch;
            set => __ProxyValue.RequestCatch = value;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}