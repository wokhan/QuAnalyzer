namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class DataSourceProvider : Proxy<global::Windows.UI.Xaml.Data.DataSourceProvider>
    {
        public System.Boolean IsInitialLoadEnabled
        {
            get => __ProxyValue.IsInitialLoadEnabled;
            set => __ProxyValue.IsInitialLoadEnabled = value;
        }

        public System.Object Data
        {
            get => __ProxyValue.Data;
        }

        public System.Exception Error
        {
            get => __ProxyValue.Error;
        }

        public void InitialLoad() => __ProxyValue.InitialLoad();
        public void Refresh() => __ProxyValue.Refresh();
        public void add_DataChanged(System.EventHandler value) => __ProxyValue.add_DataChanged(@value);
        public void remove_DataChanged(System.EventHandler value) => __ProxyValue.remove_DataChanged(@value);
        public System.IDisposable DeferRefresh() => __ProxyValue.DeferRefresh();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}