namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class TouchEventArgs : Proxy<global::Windows.UI.Xaml.Input.TouchEventArgs>
    {
        public System.Windows.Input.TouchDevice TouchDevice
        {
            get => __ProxyValue.TouchDevice;
        }

        public System.Windows.Input.InputDevice Device
        {
            get => __ProxyValue.Device;
        }

        public System.Int32 Timestamp
        {
            get => __ProxyValue.Timestamp;
        }

        public System.Windows.RoutedEvent RoutedEvent
        {
            get => __ProxyValue.RoutedEvent;
            set => __ProxyValue.RoutedEvent = value;
        }

        public System.Boolean Handled
        {
            get => __ProxyValue.Handled;
            set => __ProxyValue.Handled = value;
        }

        public System.Object Source
        {
            get => __ProxyValue.Source;
            set => __ProxyValue.Source = value;
        }

        public System.Object OriginalSource
        {
            get => __ProxyValue.OriginalSource;
        }

        public TouchEventArgs(System.Windows.Input.TouchDevice @touchDevice, System.Int32 @timestamp): base(@touchDevice, @timestamp)
        {
        }

        public System.Windows.Input.TouchPoint GetTouchPoint(System.Windows.IInputElement relativeTo) => __ProxyValue.GetTouchPoint(@relativeTo);
        public System.Windows.Input.TouchPointCollection GetIntermediateTouchPoints(System.Windows.IInputElement relativeTo) => __ProxyValue.GetIntermediateTouchPoints(@relativeTo);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}