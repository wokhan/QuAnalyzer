namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class TextCompositionEventArgs : Proxy<global::Windows.UI.Xaml.Input.TextCompositionEventArgs>
    {
        public System.Windows.Input.TextComposition TextComposition
        {
            get => __ProxyValue.TextComposition;
        }

        public System.String Text
        {
            get => __ProxyValue.Text;
        }

        public System.String SystemText
        {
            get => __ProxyValue.SystemText;
        }

        public System.String ControlText
        {
            get => __ProxyValue.ControlText;
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

        public TextCompositionEventArgs(System.Windows.Input.InputDevice @inputDevice, System.Windows.Input.TextComposition @composition): base(@inputDevice, @composition)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}