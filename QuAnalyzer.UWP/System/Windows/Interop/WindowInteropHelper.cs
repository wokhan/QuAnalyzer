namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class WindowInteropHelper : Proxy<global::Windows.UI.Xaml.Interop.WindowInteropHelper>
    {
        public System.IntPtr Handle
        {
            get => __ProxyValue.Handle;
        }

        public System.IntPtr Owner
        {
            get => __ProxyValue.Owner;
            set => __ProxyValue.Owner = value;
        }

        public WindowInteropHelper(System.Windows.Window @window): base(@window)
        {
        }

        public System.IntPtr EnsureHandle() => __ProxyValue.EnsureHandle();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}