namespace System.Windows.Automation.Peers
{
    using Uno.UI.Generic;

    public class HostedWindowWrapper : Proxy<global::Windows.UI.Xaml.Automation.Peers.HostedWindowWrapper>
    {
        public HostedWindowWrapper(System.IntPtr @hwnd): base(@hwnd)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}