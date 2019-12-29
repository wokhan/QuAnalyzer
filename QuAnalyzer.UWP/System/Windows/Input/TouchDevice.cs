namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class TouchDevice : Proxy<global::Windows.UI.Xaml.Input.TouchDevice>
    {
        public System.Int32 Id
        {
            get => __ProxyValue.Id;
        }

        public System.Boolean IsActive
        {
            get => __ProxyValue.IsActive;
        }

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

        public System.Windows.Input.CaptureMode CaptureMode
        {
            get => __ProxyValue.CaptureMode;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public void add_Activated(System.EventHandler value) => __ProxyValue.add_Activated(@value);
        public void remove_Activated(System.EventHandler value) => __ProxyValue.remove_Activated(@value);
        public void add_Deactivated(System.EventHandler value) => __ProxyValue.add_Deactivated(@value);
        public void remove_Deactivated(System.EventHandler value) => __ProxyValue.remove_Deactivated(@value);
        public System.Windows.Input.TouchPoint GetTouchPoint(System.Windows.IInputElement relativeTo) => __ProxyValue.GetTouchPoint(@relativeTo);
        public System.Windows.Input.TouchPointCollection GetIntermediateTouchPoints(System.Windows.IInputElement relativeTo) => __ProxyValue.GetIntermediateTouchPoints(@relativeTo);
        public System.Boolean Capture(System.Windows.IInputElement element) => __ProxyValue.Capture(@element);
        public System.Boolean Capture(System.Windows.IInputElement element, System.Windows.Input.CaptureMode captureMode) => __ProxyValue.Capture(@element, @captureMode);
        public void Synchronize() => __ProxyValue.Synchronize();
        public void add_Updated(System.EventHandler value) => __ProxyValue.add_Updated(@value);
        public void remove_Updated(System.EventHandler value) => __ProxyValue.remove_Updated(@value);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}