namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class SelectionChangedEventArgs : Proxy<global::Windows.UI.Xaml.Controls.SelectionChangedEventArgs>
    {
        public System.Collections.IList RemovedItems
        {
            get => __ProxyValue.RemovedItems;
        }

        public System.Collections.IList AddedItems
        {
            get => __ProxyValue.AddedItems;
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

        public SelectionChangedEventArgs(System.Windows.RoutedEvent @id, System.Collections.IList @removedItems, System.Collections.IList @addedItems): base(@id, @removedItems, @addedItems)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}