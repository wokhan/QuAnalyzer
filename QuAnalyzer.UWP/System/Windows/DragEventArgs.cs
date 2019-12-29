namespace System.Windows
{
    using Uno.UI.Generic;

    public class DragEventArgs : Proxy<global::Windows.UI.Xaml.DragEventArgs>
    {
        public System.Windows.IDataObject Data
        {
            get => __ProxyValue.Data;
        }

        public System.Windows.DragDropKeyStates KeyStates
        {
            get => __ProxyValue.KeyStates;
        }

        public System.Windows.DragDropEffects AllowedEffects
        {
            get => __ProxyValue.AllowedEffects;
        }

        public System.Windows.DragDropEffects Effects
        {
            get => __ProxyValue.Effects;
            set => __ProxyValue.Effects = value;
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

        public System.Windows.Point GetPosition(System.Windows.IInputElement relativeTo) => __ProxyValue.GetPosition(@relativeTo);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}