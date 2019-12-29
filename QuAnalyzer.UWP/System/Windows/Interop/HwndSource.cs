namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class HwndSource : Proxy<global::Windows.UI.Xaml.Interop.HwndSource>
    {
        public System.Boolean IsDisposed
        {
            get => __ProxyValue.IsDisposed;
        }

        public System.Windows.Media.Visual RootVisual
        {
            get => __ProxyValue.RootVisual;
            set => __ProxyValue.RootVisual = value;
        }

        public System.Collections.Generic.IEnumerable<System.Windows.Interop.IKeyboardInputSink> ChildKeyboardInputSinks
        {
            get => __ProxyValue.ChildKeyboardInputSinks;
        }

        public System.Windows.Interop.HwndTarget CompositionTarget
        {
            get => __ProxyValue.CompositionTarget;
        }

        public System.IntPtr Handle
        {
            get => __ProxyValue.Handle;
        }

        public System.Windows.SizeToContent SizeToContent
        {
            get => __ProxyValue.SizeToContent;
            set => __ProxyValue.SizeToContent = value;
        }

        public System.Boolean UsesPerPixelOpacity
        {
            get => __ProxyValue.UsesPerPixelOpacity;
        }

        public System.Windows.Input.RestoreFocusMode RestoreFocusMode
        {
            get => __ProxyValue.RestoreFocusMode;
        }

        public static System.Boolean DefaultAcquireHwndFocusInMenuMode
        {
            get => __ProxyValue.DefaultAcquireHwndFocusInMenuMode;
            set => __ProxyValue.DefaultAcquireHwndFocusInMenuMode = value;
        }

        public System.Boolean AcquireHwndFocusInMenuMode
        {
            get => __ProxyValue.AcquireHwndFocusInMenuMode;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public HwndSource(System.Int32 @classStyle, System.Int32 @style, System.Int32 @exStyle, System.Int32 @x, System.Int32 @y, System.String @name, System.IntPtr @parent): base(@classStyle, @style, @exStyle, @x, @y, @name, @parent)
        {
        }

        public HwndSource(System.Int32 @classStyle, System.Int32 @style, System.Int32 @exStyle, System.Int32 @x, System.Int32 @y, System.Int32 @width, System.Int32 @height, System.String @name, System.IntPtr @parent, System.Boolean @adjustSizingForNonClientArea): base(@classStyle, @style, @exStyle, @x, @y, @width, @height, @name, @parent, @adjustSizingForNonClientArea)
        {
        }

        public HwndSource(System.Int32 @classStyle, System.Int32 @style, System.Int32 @exStyle, System.Int32 @x, System.Int32 @y, System.Int32 @width, System.Int32 @height, System.String @name, System.IntPtr @parent): base(@classStyle, @style, @exStyle, @x, @y, @width, @height, @name, @parent)
        {
        }

        public HwndSource(System.Windows.Interop.HwndSourceParameters @parameters): base(@parameters)
        {
        }

        public void Dispose() => __ProxyValue.Dispose();
        public void AddHook(System.Windows.Interop.HwndSourceHook hook) => __ProxyValue.AddHook(@hook);
        public void RemoveHook(System.Windows.Interop.HwndSourceHook hook) => __ProxyValue.RemoveHook(@hook);
        public void add_Disposed(System.EventHandler value) => __ProxyValue.add_Disposed(@value);
        public void remove_Disposed(System.EventHandler value) => __ProxyValue.remove_Disposed(@value);
        public void add_SizeToContentChanged(System.EventHandler value) => __ProxyValue.add_SizeToContentChanged(@value);
        public void remove_SizeToContentChanged(System.EventHandler value) => __ProxyValue.remove_SizeToContentChanged(@value);
        public void add_DpiChanged(System.Windows.HwndDpiChangedEventHandler value) => __ProxyValue.add_DpiChanged(@value);
        public void remove_DpiChanged(System.Windows.HwndDpiChangedEventHandler value) => __ProxyValue.remove_DpiChanged(@value);
        public static System.Windows.Interop.HwndSource FromHwnd(System.IntPtr hwnd) => Windows.UI.Xaml.Interop.HwndSource.FromHwnd(@hwnd);
        public void add_AutoResized(System.Windows.AutoResizedEventHandler value) => __ProxyValue.add_AutoResized(@value);
        public void remove_AutoResized(System.Windows.AutoResizedEventHandler value) => __ProxyValue.remove_AutoResized(@value);
        public System.Runtime.InteropServices.HandleRef CreateHandleRef() => __ProxyValue.CreateHandleRef();
        public void add_ContentRendered(System.EventHandler value) => __ProxyValue.add_ContentRendered(@value);
        public void remove_ContentRendered(System.EventHandler value) => __ProxyValue.remove_ContentRendered(@value);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}