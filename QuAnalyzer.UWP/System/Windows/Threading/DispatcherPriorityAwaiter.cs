namespace System.Windows.Threading
{
    using Uno.UI.Generic;

    public class DispatcherPriorityAwaiter : Proxy<global::Windows.UI.Xaml.Threading.DispatcherPriorityAwaiter>
    {
        public System.Boolean IsCompleted
        {
            get => __ProxyValue.IsCompleted;
        }

        public void GetResult() => __ProxyValue.GetResult();
        public void OnCompleted(System.Action continuation) => __ProxyValue.OnCompleted(@continuation);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}