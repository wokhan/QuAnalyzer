namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class AccessKeyManager : Proxy<global::Windows.UI.Xaml.Input.AccessKeyManager>
    {
        public static void Register(System.String key, System.Windows.IInputElement element) => Windows.UI.Xaml.Input.AccessKeyManager.Register(@key, @element);
        public static void Unregister(System.String key, System.Windows.IInputElement element) => Windows.UI.Xaml.Input.AccessKeyManager.Unregister(@key, @element);
        public static System.Boolean IsKeyRegistered(System.Object scope, System.String key) => Windows.UI.Xaml.Input.AccessKeyManager.IsKeyRegistered(@scope, @key);
        public static System.Boolean ProcessKey(System.Object scope, System.String key, System.Boolean isMultiple) => Windows.UI.Xaml.Input.AccessKeyManager.ProcessKey(@scope, @key, @isMultiple);
        public static void AddAccessKeyPressedHandler(System.Windows.DependencyObject element, System.Windows.Input.AccessKeyPressedEventHandler handler) => Windows.UI.Xaml.Input.AccessKeyManager.AddAccessKeyPressedHandler(@element, @handler);
        public static void RemoveAccessKeyPressedHandler(System.Windows.DependencyObject element, System.Windows.Input.AccessKeyPressedEventHandler handler) => Windows.UI.Xaml.Input.AccessKeyManager.RemoveAccessKeyPressedHandler(@element, @handler);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}