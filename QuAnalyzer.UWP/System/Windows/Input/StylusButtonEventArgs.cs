namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class StylusButtonEventArgs : Proxy<global::Windows.UI.Xaml.Input.StylusButtonEventArgs>
    {
        public System.Windows.Input.StylusButton StylusButton
        {
            get => __ProxyValue.StylusButton;
        }

        public System.Windows.Input.StylusDevice StylusDevice
        {
            get => __ProxyValue.StylusDevice;
        }

        public System.Boolean InAir
        {
            get => __ProxyValue.InAir;
        }

        public System.Boolean Inverted
        {
            get => __ProxyValue.Inverted;
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

        public StylusButtonEventArgs(System.Windows.Input.StylusDevice @stylusDevice, System.Int32 @timestamp, System.Windows.Input.StylusButton @button): base(@stylusDevice, @timestamp, @button)
        {
        }

        public System.Windows.Point GetPosition(System.Windows.IInputElement relativeTo) => __ProxyValue.GetPosition(@relativeTo);
        public System.Windows.Input.StylusPointCollection GetStylusPoints(System.Windows.IInputElement relativeTo) => __ProxyValue.GetStylusPoints(@relativeTo);
        public System.Windows.Input.StylusPointCollection GetStylusPoints(System.Windows.IInputElement relativeTo, System.Windows.Input.StylusPointDescription subsetToReformatTo) => __ProxyValue.GetStylusPoints(@relativeTo, @subsetToReformatTo);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}