namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class FocusManager : Proxy<global::Windows.UI.Xaml.Input.FocusManager>
    {
        public static void AddGotFocusHandler(System.Windows.DependencyObject element, System.Windows.RoutedEventHandler handler) => Windows.UI.Xaml.Input.FocusManager.AddGotFocusHandler(@element, @handler);
        public static void RemoveGotFocusHandler(System.Windows.DependencyObject element, System.Windows.RoutedEventHandler handler) => Windows.UI.Xaml.Input.FocusManager.RemoveGotFocusHandler(@element, @handler);
        public static void AddLostFocusHandler(System.Windows.DependencyObject element, System.Windows.RoutedEventHandler handler) => Windows.UI.Xaml.Input.FocusManager.AddLostFocusHandler(@element, @handler);
        public static void RemoveLostFocusHandler(System.Windows.DependencyObject element, System.Windows.RoutedEventHandler handler) => Windows.UI.Xaml.Input.FocusManager.RemoveLostFocusHandler(@element, @handler);
        public static System.Windows.IInputElement GetFocusedElement(System.Windows.DependencyObject element) => Windows.UI.Xaml.Input.FocusManager.GetFocusedElement(@element);
        public static void SetFocusedElement(System.Windows.DependencyObject element, System.Windows.IInputElement value) => Windows.UI.Xaml.Input.FocusManager.SetFocusedElement(@element, @value);
        public static void SetIsFocusScope(System.Windows.DependencyObject element, System.Boolean value) => Windows.UI.Xaml.Input.FocusManager.SetIsFocusScope(@element, @value);
        public static System.Boolean GetIsFocusScope(System.Windows.DependencyObject element) => Windows.UI.Xaml.Input.FocusManager.GetIsFocusScope(@element);
        public static System.Windows.DependencyObject GetFocusScope(System.Windows.DependencyObject element) => Windows.UI.Xaml.Input.FocusManager.GetFocusScope(@element);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}