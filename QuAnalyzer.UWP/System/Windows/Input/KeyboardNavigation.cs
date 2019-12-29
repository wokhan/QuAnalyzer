namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class KeyboardNavigation : Proxy<global::Windows.UI.Xaml.Input.KeyboardNavigation>
    {
        public static void SetTabIndex(System.Windows.DependencyObject element, System.Int32 index) => Windows.UI.Xaml.Input.KeyboardNavigation.SetTabIndex(@element, @index);
        public static System.Int32 GetTabIndex(System.Windows.DependencyObject element) => Windows.UI.Xaml.Input.KeyboardNavigation.GetTabIndex(@element);
        public static void SetIsTabStop(System.Windows.DependencyObject element, System.Boolean isTabStop) => Windows.UI.Xaml.Input.KeyboardNavigation.SetIsTabStop(@element, @isTabStop);
        public static System.Boolean GetIsTabStop(System.Windows.DependencyObject element) => Windows.UI.Xaml.Input.KeyboardNavigation.GetIsTabStop(@element);
        public static void SetTabNavigation(System.Windows.DependencyObject element, System.Windows.Input.KeyboardNavigationMode mode) => Windows.UI.Xaml.Input.KeyboardNavigation.SetTabNavigation(@element, @mode);
        public static System.Windows.Input.KeyboardNavigationMode GetTabNavigation(System.Windows.DependencyObject element) => Windows.UI.Xaml.Input.KeyboardNavigation.GetTabNavigation(@element);
        public static void SetControlTabNavigation(System.Windows.DependencyObject element, System.Windows.Input.KeyboardNavigationMode mode) => Windows.UI.Xaml.Input.KeyboardNavigation.SetControlTabNavigation(@element, @mode);
        public static System.Windows.Input.KeyboardNavigationMode GetControlTabNavigation(System.Windows.DependencyObject element) => Windows.UI.Xaml.Input.KeyboardNavigation.GetControlTabNavigation(@element);
        public static void SetDirectionalNavigation(System.Windows.DependencyObject element, System.Windows.Input.KeyboardNavigationMode mode) => Windows.UI.Xaml.Input.KeyboardNavigation.SetDirectionalNavigation(@element, @mode);
        public static System.Windows.Input.KeyboardNavigationMode GetDirectionalNavigation(System.Windows.DependencyObject element) => Windows.UI.Xaml.Input.KeyboardNavigation.GetDirectionalNavigation(@element);
        public static void SetAcceptsReturn(System.Windows.DependencyObject element, System.Boolean enabled) => Windows.UI.Xaml.Input.KeyboardNavigation.SetAcceptsReturn(@element, @enabled);
        public static System.Boolean GetAcceptsReturn(System.Windows.DependencyObject element) => Windows.UI.Xaml.Input.KeyboardNavigation.GetAcceptsReturn(@element);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}