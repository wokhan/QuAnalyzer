namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class MSG : Proxy<global::Windows.UI.Xaml.Interop.MSG>
    {
        public System.IntPtr hwnd
        {
            get => __ProxyValue.hwnd;
            set => __ProxyValue.hwnd = value;
        }

        public System.Int32 message
        {
            get => __ProxyValue.message;
            set => __ProxyValue.message = value;
        }

        public System.IntPtr wParam
        {
            get => __ProxyValue.wParam;
            set => __ProxyValue.wParam = value;
        }

        public System.IntPtr lParam
        {
            get => __ProxyValue.lParam;
            set => __ProxyValue.lParam = value;
        }

        public System.Int32 time
        {
            get => __ProxyValue.time;
            set => __ProxyValue.time = value;
        }

        public System.Int32 pt_x
        {
            get => __ProxyValue.pt_x;
            set => __ProxyValue.pt_x = value;
        }

        public System.Int32 pt_y
        {
            get => __ProxyValue.pt_y;
            set => __ProxyValue.pt_y = value;
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}