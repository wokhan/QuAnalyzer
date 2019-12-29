namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class HwndSourceHook : Proxy<global::Windows.UI.Xaml.Interop.HwndSourceHook>
    {
        public System.Object Target
        {
            get => __ProxyValue.Target;
        }

        public System.Reflection.MethodInfo Method
        {
            get => __ProxyValue.Method;
        }

        public HwndSourceHook(System.Object @object, System.IntPtr @method): base(@object, @method)
        {
        }

        public System.IntPtr Invoke(System.IntPtr hwnd, System.Int32 msg, System.IntPtr wParam, System.IntPtr lParam, System.Boolean handled) => __ProxyValue.Invoke(@hwnd, @msg, @wParam, @lParam, @handled);
        public System.IAsyncResult BeginInvoke(System.IntPtr hwnd, System.Int32 msg, System.IntPtr wParam, System.IntPtr lParam, System.Boolean handled, System.AsyncCallback callback, System.Object object) => __ProxyValue.BeginInvoke(@hwnd, @msg, @wParam, @lParam, @handled, @callback, @object);
        public System.IntPtr EndInvoke(System.Boolean handled, System.IAsyncResult result) => __ProxyValue.EndInvoke(@handled, @result);
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => __ProxyValue.GetObjectData(@info, @context);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Delegate[] GetInvocationList() => __ProxyValue.GetInvocationList();
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Object Clone() => __ProxyValue.Clone();
        public System.Object DynamicInvoke(System.Object[] args) => __ProxyValue.DynamicInvoke(@args);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}