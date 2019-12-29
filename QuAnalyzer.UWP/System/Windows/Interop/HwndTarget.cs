namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class HwndTarget : Proxy<global::Windows.UI.Xaml.Interop.HwndTarget>
    {
        public System.Windows.Interop.RenderMode RenderMode
        {
            get => __ProxyValue.RenderMode;
            set => __ProxyValue.RenderMode = value;
        }

        public System.Windows.Media.Visual RootVisual
        {
            set => __ProxyValue.RootVisual = value;
        }

        public System.Windows.Media.Matrix TransformToDevice
        {
            get => __ProxyValue.TransformToDevice;
        }

        public System.Windows.Media.Matrix TransformFromDevice
        {
            get => __ProxyValue.TransformFromDevice;
        }

        public System.Windows.Media.Color BackgroundColor
        {
            get => __ProxyValue.BackgroundColor;
            set => __ProxyValue.BackgroundColor = value;
        }

        public System.Boolean UsesPerPixelOpacity
        {
            get => __ProxyValue.UsesPerPixelOpacity;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public HwndTarget(System.IntPtr @hwnd): base(@hwnd)
        {
        }

        public void Dispose() => __ProxyValue.Dispose();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}