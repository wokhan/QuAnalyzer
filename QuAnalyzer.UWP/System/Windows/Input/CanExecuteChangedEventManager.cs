namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class CanExecuteChangedEventManager : Proxy<global::Windows.UI.Xaml.Input.CanExecuteChangedEventManager>
    {
        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public static void AddHandler(System.Windows.Input.ICommand source, System.EventHandler<System.EventArgs> handler) => Windows.UI.Xaml.Input.CanExecuteChangedEventManager.AddHandler(@source, @handler);
        public static void RemoveHandler(System.Windows.Input.ICommand source, System.EventHandler<System.EventArgs> handler) => Windows.UI.Xaml.Input.CanExecuteChangedEventManager.RemoveHandler(@source, @handler);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}