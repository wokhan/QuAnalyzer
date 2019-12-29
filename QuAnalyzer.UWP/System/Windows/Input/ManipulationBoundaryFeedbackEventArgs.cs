﻿namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class ManipulationBoundaryFeedbackEventArgs : Proxy<global::Windows.UI.Xaml.Input.ManipulationBoundaryFeedbackEventArgs>
    {
        public System.Windows.IInputElement ManipulationContainer
        {
            get => __ProxyValue.ManipulationContainer;
        }

        public System.Windows.Input.ManipulationDelta BoundaryFeedback
        {
            get => __ProxyValue.BoundaryFeedback;
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

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}