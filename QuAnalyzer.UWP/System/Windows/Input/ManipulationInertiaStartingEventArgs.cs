namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class ManipulationInertiaStartingEventArgs : Proxy<global::Windows.UI.Xaml.Input.ManipulationInertiaStartingEventArgs>
    {
        public System.Windows.IInputElement ManipulationContainer
        {
            get => __ProxyValue.ManipulationContainer;
        }

        public System.Windows.Point ManipulationOrigin
        {
            get => __ProxyValue.ManipulationOrigin;
            set => __ProxyValue.ManipulationOrigin = value;
        }

        public System.Windows.Input.ManipulationVelocities InitialVelocities
        {
            get => __ProxyValue.InitialVelocities;
        }

        public System.Windows.Input.InertiaTranslationBehavior TranslationBehavior
        {
            get => __ProxyValue.TranslationBehavior;
            set => __ProxyValue.TranslationBehavior = value;
        }

        public System.Windows.Input.InertiaRotationBehavior RotationBehavior
        {
            get => __ProxyValue.RotationBehavior;
            set => __ProxyValue.RotationBehavior = value;
        }

        public System.Windows.Input.InertiaExpansionBehavior ExpansionBehavior
        {
            get => __ProxyValue.ExpansionBehavior;
            set => __ProxyValue.ExpansionBehavior = value;
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
        public void SetInertiaParameter(System.Windows.Input.Manipulations.InertiaParameters2D parameter) => __ProxyValue.SetInertiaParameter(@parameter);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}