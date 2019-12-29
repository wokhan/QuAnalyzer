namespace System.Windows.Threading
{
    using Uno.UI.Generic;

    public class DispatcherFrame : Proxy<global::Windows.UI.Xaml.Threading.DispatcherFrame>
    {
        public System.Boolean Continue
        {
            get => __ProxyValue.Continue;
            set => __ProxyValue.Continue = value;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public DispatcherFrame(): base()
        {
        }

        public DispatcherFrame(System.Boolean @exitWhenRequested): base(@exitWhenRequested)
        {
        }

        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}