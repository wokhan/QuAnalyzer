namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class StylusDevice : Proxy<global::Windows.UI.Xaml.Input.StylusDevice>
    {
        public System.Windows.IInputElement Target
        {
            get => __ProxyValue.Target;
        }

        public System.Boolean IsValid
        {
            get => __ProxyValue.IsValid;
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

        public System.Windows.Input.TabletDevice TabletDevice
        {
            get => __ProxyValue.TabletDevice;
        }

        public System.String Name
        {
            get => __ProxyValue.Name;
        }

        public System.Int32 Id
        {
            get => __ProxyValue.Id;
        }

        public System.Windows.Input.StylusButtonCollection StylusButtons
        {
            get => __ProxyValue.StylusButtons;
        }

        public System.Boolean InAir
        {
            get => __ProxyValue.InAir;
        }

        public System.Boolean Inverted
        {
            get => __ProxyValue.Inverted;
        }

        public System.Boolean InRange
        {
            get => __ProxyValue.InRange;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public System.Boolean Capture(System.Windows.IInputElement element, System.Windows.Input.CaptureMode captureMode) => __ProxyValue.Capture(@element, @captureMode);
        public System.Boolean Capture(System.Windows.IInputElement element) => __ProxyValue.Capture(@element);
        public void Synchronize() => __ProxyValue.Synchronize();
        public override System.String ToString() => __ProxyValue.ToString();
        public System.Windows.Input.StylusPointCollection GetStylusPoints(System.Windows.IInputElement relativeTo) => __ProxyValue.GetStylusPoints(@relativeTo);
        public System.Windows.Input.StylusPointCollection GetStylusPoints(System.Windows.IInputElement relativeTo, System.Windows.Input.StylusPointDescription subsetToReformatTo) => __ProxyValue.GetStylusPoints(@relativeTo, @subsetToReformatTo);
        public System.Windows.Point GetPosition(System.Windows.IInputElement relativeTo) => __ProxyValue.GetPosition(@relativeTo);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}