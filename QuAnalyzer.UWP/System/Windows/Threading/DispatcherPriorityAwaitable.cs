namespace System.Windows.Threading
{
    using Uno.UI.Generic;

    public class DispatcherPriorityAwaitable : Proxy<global::Windows.UI.Xaml.Threading.DispatcherPriorityAwaitable>
    {
        public System.Windows.Threading.DispatcherPriorityAwaiter GetAwaiter() => __ProxyValue.GetAwaiter();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}