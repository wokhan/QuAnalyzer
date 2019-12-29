namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class ManipulationDeltaEventArgs : Proxy<global::Windows.UI.Xaml.Input.ManipulationDeltaEventArgs>
    {
        public System.Boolean IsInertial
        {
            get => __ProxyValue.IsInertial;
        }

        public System.Windows.IInputElement ManipulationContainer
        {
            get => __ProxyValue.ManipulationContainer;
        }

        public System.Windows.Point ManipulationOrigin
        {
            get => __ProxyValue.ManipulationOrigin;
        }

        public System.Windows.Input.ManipulationDelta CumulativeManipulation
        {
            get => __ProxyValue.CumulativeManipulation;
        }

        public System.Windows.Input.ManipulationDelta DeltaManipulation
        {
            get => __ProxyValue.DeltaManipulation;
        }

        public System.Windows.Input.ManipulationVelocities Velocities
        {
            get => __ProxyValue.Velocities;
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

        public void ReportBoundaryFeedback(System.Windows.Input.ManipulationDelta unusedManipulation) => __ProxyValue.ReportBoundaryFeedback(@unusedManipulation);
        public void Complete() => __ProxyValue.Complete();
        public void StartInertia() => __ProxyValue.StartInertia();
        public System.Boolean Cancel() => __ProxyValue.Cancel();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}