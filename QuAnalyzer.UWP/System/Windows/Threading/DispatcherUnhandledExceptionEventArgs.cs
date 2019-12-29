namespace System.Windows.Threading
{
    using Uno.UI.Generic;

    public class DispatcherUnhandledExceptionEventArgs : Proxy<global::Windows.UI.Xaml.Threading.DispatcherUnhandledExceptionEventArgs>
    {
        public System.Exception Exception
        {
            get => __ProxyValue.Exception;
        }

        public System.Boolean Handled
        {
            get => __ProxyValue.Handled;
            set => __ProxyValue.Handled = value;
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