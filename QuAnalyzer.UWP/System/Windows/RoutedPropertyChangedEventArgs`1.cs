namespace System.Windows
{
    using Uno.UI.Generic;

    public class RoutedPropertyChangedEventArgs`1<T> : Proxy<global::Windows.UI.Xaml.RoutedPropertyChangedEventArgs<T>>
    {
        public T OldValue
        {
            get => __ProxyValue.OldValue;
        }

        public T NewValue
        {
            get => __ProxyValue.NewValue;
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

        public RoutedPropertyChangedEventArgs`1(T @oldValue, T @newValue): base(@oldValue, @newValue)
        {
        }

        public RoutedPropertyChangedEventArgs`1(T @oldValue, T @newValue, System.Windows.RoutedEvent @routedEvent): base(@oldValue, @newValue, @routedEvent)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}