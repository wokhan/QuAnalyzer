namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class CanExecuteRoutedEventArgs : Proxy<global::Windows.UI.Xaml.Input.CanExecuteRoutedEventArgs>
    {
        public System.Windows.Input.ICommand Command
        {
            get => __ProxyValue.Command;
        }

        public System.Object Parameter
        {
            get => __ProxyValue.Parameter;
        }

        public System.Boolean CanExecute
        {
            get => __ProxyValue.CanExecute;
            set => __ProxyValue.CanExecute = value;
        }

        public System.Boolean ContinueRouting
        {
            get => __ProxyValue.ContinueRouting;
            set => __ProxyValue.ContinueRouting = value;
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