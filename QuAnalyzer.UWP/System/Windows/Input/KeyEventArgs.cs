namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class KeyEventArgs : Proxy<global::Windows.UI.Xaml.Input.KeyEventArgs>
    {
        public System.Windows.PresentationSource InputSource
        {
            get => __ProxyValue.InputSource;
        }

        public System.Windows.Input.Key Key
        {
            get => __ProxyValue.Key;
        }

        public System.Windows.Input.Key ImeProcessedKey
        {
            get => __ProxyValue.ImeProcessedKey;
        }

        public System.Windows.Input.Key SystemKey
        {
            get => __ProxyValue.SystemKey;
        }

        public System.Windows.Input.Key DeadCharProcessedKey
        {
            get => __ProxyValue.DeadCharProcessedKey;
        }

        public System.Windows.Input.KeyStates KeyStates
        {
            get => __ProxyValue.KeyStates;
        }

        public System.Boolean IsRepeat
        {
            get => __ProxyValue.IsRepeat;
        }

        public System.Boolean IsDown
        {
            get => __ProxyValue.IsDown;
        }

        public System.Boolean IsUp
        {
            get => __ProxyValue.IsUp;
        }

        public System.Boolean IsToggled
        {
            get => __ProxyValue.IsToggled;
        }

        public System.Windows.Input.KeyboardDevice KeyboardDevice
        {
            get => __ProxyValue.KeyboardDevice;
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

        public KeyEventArgs(System.Windows.Input.KeyboardDevice @keyboard, System.Windows.PresentationSource @inputSource, System.Int32 @timestamp, System.Windows.Input.Key @key): base(@keyboard, @inputSource, @timestamp, @key)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}