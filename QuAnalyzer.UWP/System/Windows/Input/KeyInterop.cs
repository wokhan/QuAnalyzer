namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class KeyInterop : Proxy<global::Windows.UI.Xaml.Input.KeyInterop>
    {
        public static System.Windows.Input.Key KeyFromVirtualKey(System.Int32 virtualKey) => Windows.UI.Xaml.Input.KeyInterop.KeyFromVirtualKey(@virtualKey);
        public static System.Int32 VirtualKeyFromKey(System.Windows.Input.Key key) => Windows.UI.Xaml.Input.KeyInterop.VirtualKeyFromKey(@key);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}