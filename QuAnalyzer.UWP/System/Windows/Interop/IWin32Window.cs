namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class IWin32Window : Proxy<global::Windows.UI.Xaml.Interop.IWin32Window>
    {
        public System.IntPtr Handle
        {
            get => __ProxyValue.Handle;
        }
    }
}