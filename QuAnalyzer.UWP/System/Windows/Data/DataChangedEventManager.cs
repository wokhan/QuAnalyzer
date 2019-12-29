namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class DataChangedEventManager : Proxy<global::Windows.UI.Xaml.Data.DataChangedEventManager>
    {
        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public static void AddListener(System.Windows.Data.DataSourceProvider source, System.Windows.IWeakEventListener listener) => Windows.UI.Xaml.Data.DataChangedEventManager.AddListener(@source, @listener);
        public static void RemoveListener(System.Windows.Data.DataSourceProvider source, System.Windows.IWeakEventListener listener) => Windows.UI.Xaml.Data.DataChangedEventManager.RemoveListener(@source, @listener);
        public static void AddHandler(System.Windows.Data.DataSourceProvider source, System.EventHandler<System.EventArgs> handler) => Windows.UI.Xaml.Data.DataChangedEventManager.AddHandler(@source, @handler);
        public static void RemoveHandler(System.Windows.Data.DataSourceProvider source, System.EventHandler<System.EventArgs> handler) => Windows.UI.Xaml.Data.DataChangedEventManager.RemoveHandler(@source, @handler);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}