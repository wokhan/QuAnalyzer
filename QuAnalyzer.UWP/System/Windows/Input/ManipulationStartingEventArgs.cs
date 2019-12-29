namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class ManipulationStartingEventArgs : Proxy<global::Windows.UI.Xaml.Input.ManipulationStartingEventArgs>
    {
        public System.Windows.Input.ManipulationModes Mode
        {
            get => __ProxyValue.Mode;
            set => __ProxyValue.Mode = value;
        }

        public System.Windows.IInputElement ManipulationContainer
        {
            get => __ProxyValue.ManipulationContainer;
            set => __ProxyValue.ManipulationContainer = value;
        }

        public System.Windows.Input.ManipulationPivot Pivot
        {
            get => __ProxyValue.Pivot;
            set => __ProxyValue.Pivot = value;
        }

        public System.Boolean IsSingleTouchEnabled
        {
            get => __ProxyValue.IsSingleTouchEnabled;
            set => __ProxyValue.IsSingleTouchEnabled = value;
        }

        public System.Collections.Generic.IEnumerable<System.Windows.Input.IManipulator> Manipulators
        {
            get => __ProxyValue.Manipulators;
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

        public System.Boolean Cancel() => __ProxyValue.Cancel();
        public void SetManipulationParameter(System.Windows.Input.Manipulations.ManipulationParameters2D parameter) => __ProxyValue.SetManipulationParameter(@parameter);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}