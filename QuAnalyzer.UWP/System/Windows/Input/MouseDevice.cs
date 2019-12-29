namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class MouseDevice : Proxy<global::Windows.UI.Xaml.Input.MouseDevice>
    {
        public System.Windows.IInputElement Target
        {
            get => __ProxyValue.Target;
        }

        public System.Windows.PresentationSource ActiveSource
        {
            get => __ProxyValue.ActiveSource;
        }

        public System.Windows.IInputElement DirectlyOver
        {
            get => __ProxyValue.DirectlyOver;
        }

        public System.Windows.IInputElement Captured
        {
            get => __ProxyValue.Captured;
        }

        public System.Windows.Input.Cursor OverrideCursor
        {
            get => __ProxyValue.OverrideCursor;
            set => __ProxyValue.OverrideCursor = value;
        }

        public System.Windows.Input.MouseButtonState LeftButton
        {
            get => __ProxyValue.LeftButton;
        }

        public System.Windows.Input.MouseButtonState RightButton
        {
            get => __ProxyValue.RightButton;
        }

        public System.Windows.Input.MouseButtonState MiddleButton
        {
            get => __ProxyValue.MiddleButton;
        }

        public System.Windows.Input.MouseButtonState XButton1
        {
            get => __ProxyValue.XButton1;
        }

        public System.Windows.Input.MouseButtonState XButton2
        {
            get => __ProxyValue.XButton2;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public System.Boolean Capture(System.Windows.IInputElement element) => __ProxyValue.Capture(@element);
        public System.Boolean Capture(System.Windows.IInputElement element, System.Windows.Input.CaptureMode captureMode) => __ProxyValue.Capture(@element, @captureMode);
        public System.Boolean SetCursor(System.Windows.Input.Cursor cursor) => __ProxyValue.SetCursor(@cursor);
        public System.Windows.Point GetPosition(System.Windows.IInputElement relativeTo) => __ProxyValue.GetPosition(@relativeTo);
        public void Synchronize() => __ProxyValue.Synchronize();
        public void UpdateCursor() => __ProxyValue.UpdateCursor();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}