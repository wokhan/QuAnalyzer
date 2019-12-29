namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class HwndSourceParameters : Proxy<global::Windows.UI.Xaml.Interop.HwndSourceParameters>
    {
        public System.Int32 WindowClassStyle
        {
            get => __ProxyValue.WindowClassStyle;
            set => __ProxyValue.WindowClassStyle = value;
        }

        public System.Int32 WindowStyle
        {
            get => __ProxyValue.WindowStyle;
            set => __ProxyValue.WindowStyle = value;
        }

        public System.Int32 ExtendedWindowStyle
        {
            get => __ProxyValue.ExtendedWindowStyle;
            set => __ProxyValue.ExtendedWindowStyle = value;
        }

        public System.Int32 PositionX
        {
            get => __ProxyValue.PositionX;
            set => __ProxyValue.PositionX = value;
        }

        public System.Int32 PositionY
        {
            get => __ProxyValue.PositionY;
            set => __ProxyValue.PositionY = value;
        }

        public System.Int32 Width
        {
            get => __ProxyValue.Width;
            set => __ProxyValue.Width = value;
        }

        public System.Int32 Height
        {
            get => __ProxyValue.Height;
            set => __ProxyValue.Height = value;
        }

        public System.Boolean HasAssignedSize
        {
            get => __ProxyValue.HasAssignedSize;
        }

        public System.String WindowName
        {
            get => __ProxyValue.WindowName;
            set => __ProxyValue.WindowName = value;
        }

        public System.IntPtr ParentWindow
        {
            get => __ProxyValue.ParentWindow;
            set => __ProxyValue.ParentWindow = value;
        }

        public System.Windows.Interop.HwndSourceHook HwndSourceHook
        {
            get => __ProxyValue.HwndSourceHook;
            set => __ProxyValue.HwndSourceHook = value;
        }

        public System.Boolean AdjustSizingForNonClientArea
        {
            get => __ProxyValue.AdjustSizingForNonClientArea;
            set => __ProxyValue.AdjustSizingForNonClientArea = value;
        }

        public System.Boolean TreatAncestorsAsNonClientArea
        {
            get => __ProxyValue.TreatAncestorsAsNonClientArea;
            set => __ProxyValue.TreatAncestorsAsNonClientArea = value;
        }

        public System.Boolean UsesPerPixelOpacity
        {
            get => __ProxyValue.UsesPerPixelOpacity;
            set => __ProxyValue.UsesPerPixelOpacity = value;
        }

        public System.Boolean UsesPerPixelTransparency
        {
            get => __ProxyValue.UsesPerPixelTransparency;
            set => __ProxyValue.UsesPerPixelTransparency = value;
        }

        public System.Windows.Input.RestoreFocusMode RestoreFocusMode
        {
            get => __ProxyValue.RestoreFocusMode;
            set => __ProxyValue.RestoreFocusMode = value;
        }

        public System.Boolean AcquireHwndFocusInMenuMode
        {
            get => __ProxyValue.AcquireHwndFocusInMenuMode;
            set => __ProxyValue.AcquireHwndFocusInMenuMode = value;
        }

        public System.Boolean TreatAsInputRoot
        {
            get => __ProxyValue.TreatAsInputRoot;
            set => __ProxyValue.TreatAsInputRoot = value;
        }

        public HwndSourceParameters(System.String @name): base(@name)
        {
        }

        public HwndSourceParameters(System.String @name, System.Int32 @width, System.Int32 @height): base(@name, @width, @height)
        {
        }

        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public void SetPosition(System.Int32 x, System.Int32 y) => __ProxyValue.SetPosition(@x, @y);
        public void SetSize(System.Int32 width, System.Int32 height) => __ProxyValue.SetSize(@width, @height);
        public static System.Boolean op_Equality(System.Windows.Interop.HwndSourceParameters a, System.Windows.Interop.HwndSourceParameters b) => Windows.UI.Xaml.Interop.HwndSourceParameters.op_Equality(@a, @b);
        public static System.Boolean op_Inequality(System.Windows.Interop.HwndSourceParameters a, System.Windows.Interop.HwndSourceParameters b) => Windows.UI.Xaml.Interop.HwndSourceParameters.op_Inequality(@a, @b);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Boolean Equals(System.Windows.Interop.HwndSourceParameters obj) => __ProxyValue.Equals(@obj);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}