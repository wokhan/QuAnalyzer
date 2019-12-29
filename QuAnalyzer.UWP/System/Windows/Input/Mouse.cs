namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class Mouse : Proxy<global::Windows.UI.Xaml.Input.Mouse>
    {
        public static System.Windows.IInputElement DirectlyOver
        {
            get => __ProxyValue.DirectlyOver;
        }

        public static System.Windows.IInputElement Captured
        {
            get => __ProxyValue.Captured;
        }

        public static System.Windows.Input.Cursor OverrideCursor
        {
            get => __ProxyValue.OverrideCursor;
            set => __ProxyValue.OverrideCursor = value;
        }

        public static System.Windows.Input.MouseButtonState LeftButton
        {
            get => __ProxyValue.LeftButton;
        }

        public static System.Windows.Input.MouseButtonState RightButton
        {
            get => __ProxyValue.RightButton;
        }

        public static System.Windows.Input.MouseButtonState MiddleButton
        {
            get => __ProxyValue.MiddleButton;
        }

        public static System.Windows.Input.MouseButtonState XButton1
        {
            get => __ProxyValue.XButton1;
        }

        public static System.Windows.Input.MouseButtonState XButton2
        {
            get => __ProxyValue.XButton2;
        }

        public static System.Windows.Input.MouseDevice PrimaryDevice
        {
            get => __ProxyValue.PrimaryDevice;
        }

        public static void AddPreviewMouseMoveHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddPreviewMouseMoveHandler(@element, @handler);
        public static void RemovePreviewMouseMoveHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemovePreviewMouseMoveHandler(@element, @handler);
        public static void AddMouseMoveHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddMouseMoveHandler(@element, @handler);
        public static void RemoveMouseMoveHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemoveMouseMoveHandler(@element, @handler);
        public static void AddPreviewMouseDownOutsideCapturedElementHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseButtonEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddPreviewMouseDownOutsideCapturedElementHandler(@element, @handler);
        public static void RemovePreviewMouseDownOutsideCapturedElementHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseButtonEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemovePreviewMouseDownOutsideCapturedElementHandler(@element, @handler);
        public static void AddPreviewMouseUpOutsideCapturedElementHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseButtonEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddPreviewMouseUpOutsideCapturedElementHandler(@element, @handler);
        public static void RemovePreviewMouseUpOutsideCapturedElementHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseButtonEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemovePreviewMouseUpOutsideCapturedElementHandler(@element, @handler);
        public static void AddPreviewMouseDownHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseButtonEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddPreviewMouseDownHandler(@element, @handler);
        public static void RemovePreviewMouseDownHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseButtonEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemovePreviewMouseDownHandler(@element, @handler);
        public static void AddMouseDownHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseButtonEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddMouseDownHandler(@element, @handler);
        public static void RemoveMouseDownHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseButtonEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemoveMouseDownHandler(@element, @handler);
        public static void AddPreviewMouseUpHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseButtonEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddPreviewMouseUpHandler(@element, @handler);
        public static void RemovePreviewMouseUpHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseButtonEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemovePreviewMouseUpHandler(@element, @handler);
        public static void AddMouseUpHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseButtonEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddMouseUpHandler(@element, @handler);
        public static void RemoveMouseUpHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseButtonEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemoveMouseUpHandler(@element, @handler);
        public static void AddPreviewMouseWheelHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseWheelEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddPreviewMouseWheelHandler(@element, @handler);
        public static void RemovePreviewMouseWheelHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseWheelEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemovePreviewMouseWheelHandler(@element, @handler);
        public static void AddMouseWheelHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseWheelEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddMouseWheelHandler(@element, @handler);
        public static void RemoveMouseWheelHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseWheelEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemoveMouseWheelHandler(@element, @handler);
        public static void AddMouseEnterHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddMouseEnterHandler(@element, @handler);
        public static void RemoveMouseEnterHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemoveMouseEnterHandler(@element, @handler);
        public static void AddMouseLeaveHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddMouseLeaveHandler(@element, @handler);
        public static void RemoveMouseLeaveHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemoveMouseLeaveHandler(@element, @handler);
        public static void AddGotMouseCaptureHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddGotMouseCaptureHandler(@element, @handler);
        public static void RemoveGotMouseCaptureHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemoveGotMouseCaptureHandler(@element, @handler);
        public static void AddLostMouseCaptureHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddLostMouseCaptureHandler(@element, @handler);
        public static void RemoveLostMouseCaptureHandler(System.Windows.DependencyObject element, System.Windows.Input.MouseEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemoveLostMouseCaptureHandler(@element, @handler);
        public static void AddQueryCursorHandler(System.Windows.DependencyObject element, System.Windows.Input.QueryCursorEventHandler handler) => Windows.UI.Xaml.Input.Mouse.AddQueryCursorHandler(@element, @handler);
        public static void RemoveQueryCursorHandler(System.Windows.DependencyObject element, System.Windows.Input.QueryCursorEventHandler handler) => Windows.UI.Xaml.Input.Mouse.RemoveQueryCursorHandler(@element, @handler);
        public static System.Boolean Capture(System.Windows.IInputElement element) => Windows.UI.Xaml.Input.Mouse.Capture(@element);
        public static System.Boolean Capture(System.Windows.IInputElement element, System.Windows.Input.CaptureMode captureMode) => Windows.UI.Xaml.Input.Mouse.Capture(@element, @captureMode);
        public static System.Int32 GetIntermediatePoints(System.Windows.IInputElement relativeTo, System.Windows.Point[] points) => Windows.UI.Xaml.Input.Mouse.GetIntermediatePoints(@relativeTo, @points);
        public static System.Boolean SetCursor(System.Windows.Input.Cursor cursor) => Windows.UI.Xaml.Input.Mouse.SetCursor(@cursor);
        public static System.Windows.Point GetPosition(System.Windows.IInputElement relativeTo) => Windows.UI.Xaml.Input.Mouse.GetPosition(@relativeTo);
        public static void Synchronize() => Windows.UI.Xaml.Input.Mouse.Synchronize();
        public static void UpdateCursor() => Windows.UI.Xaml.Input.Mouse.UpdateCursor();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}