namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class TextChangedEventArgs : Proxy<global::Windows.UI.Xaml.Controls.TextChangedEventArgs>
    {
        public System.Windows.Controls.UndoAction UndoAction
        {
            get => __ProxyValue.UndoAction;
        }

        public System.Collections.Generic.ICollection<System.Windows.Controls.TextChange> Changes
        {
            get => __ProxyValue.Changes;
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

        public TextChangedEventArgs(System.Windows.RoutedEvent @id, System.Windows.Controls.UndoAction @action, System.Collections.Generic.ICollection<System.Windows.Controls.TextChange> @changes): base(@id, @action, @changes)
        {
        }

        public TextChangedEventArgs(System.Windows.RoutedEvent @id, System.Windows.Controls.UndoAction @action): base(@id, @action)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}