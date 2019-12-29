namespace System.Windows
{
    using Uno.UI.Generic;

    public class QueryContinueDragEventArgs : Proxy<global::Windows.UI.Xaml.QueryContinueDragEventArgs>
    {
        public System.Boolean EscapePressed
        {
            get => __ProxyValue.EscapePressed;
        }

        public System.Windows.DragDropKeyStates KeyStates
        {
            get => __ProxyValue.KeyStates;
        }

        public System.Windows.DragAction Action
        {
            get => __ProxyValue.Action;
            set => __ProxyValue.Action = value;
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