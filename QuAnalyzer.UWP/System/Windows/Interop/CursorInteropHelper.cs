namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class CursorInteropHelper : Proxy<global::Windows.UI.Xaml.Interop.CursorInteropHelper>
    {
        public static System.Windows.Input.Cursor Create(System.Runtime.InteropServices.SafeHandle cursorHandle) => Windows.UI.Xaml.Interop.CursorInteropHelper.Create(@cursorHandle);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}