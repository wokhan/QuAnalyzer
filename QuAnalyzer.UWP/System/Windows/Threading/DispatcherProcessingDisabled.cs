namespace System.Windows.Threading
{
    using Uno.UI.Generic;

    public class DispatcherProcessingDisabled : Proxy<global::Windows.UI.Xaml.Threading.DispatcherProcessingDisabled>
    {
        public void Dispose() => __ProxyValue.Dispose();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Boolean op_Equality(System.Windows.Threading.DispatcherProcessingDisabled left, System.Windows.Threading.DispatcherProcessingDisabled right) => Windows.UI.Xaml.Threading.DispatcherProcessingDisabled.op_Equality(@left, @right);
        public static System.Boolean op_Inequality(System.Windows.Threading.DispatcherProcessingDisabled left, System.Windows.Threading.DispatcherProcessingDisabled right) => Windows.UI.Xaml.Threading.DispatcherProcessingDisabled.op_Inequality(@left, @right);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}