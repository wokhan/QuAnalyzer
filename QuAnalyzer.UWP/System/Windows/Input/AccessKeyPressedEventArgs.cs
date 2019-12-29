namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class AccessKeyPressedEventArgs : Proxy<global::Windows.UI.Xaml.Input.AccessKeyPressedEventArgs>
    {
        public System.Object Scope
        {
            get => __ProxyValue.Scope;
            set => __ProxyValue.Scope = value;
        }

        public System.Windows.UIElement Target
        {
            get => __ProxyValue.Target;
            set => __ProxyValue.Target = value;
        }

        public System.String Key
        {
            get => __ProxyValue.Key;
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

        public AccessKeyPressedEventArgs(): base()
        {
        }

        public AccessKeyPressedEventArgs(System.String @key): base(@key)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}