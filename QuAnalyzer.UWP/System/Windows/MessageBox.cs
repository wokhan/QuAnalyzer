namespace System.Windows
{
    using Uno.UI.Generic;

    public class MessageBox : Proxy<global::Windows.UI.Xaml.MessageBox>
    {
        public static System.Windows.MessageBoxResult Show(System.String messageBoxText, System.String caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.MessageBoxResult defaultResult, System.Windows.MessageBoxOptions options) => Windows.UI.Xaml.MessageBox.Show(@messageBoxText, @caption, @button, @icon, @defaultResult, @options);
        public static System.Windows.MessageBoxResult Show(System.String messageBoxText, System.String caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.MessageBoxResult defaultResult) => Windows.UI.Xaml.MessageBox.Show(@messageBoxText, @caption, @button, @icon, @defaultResult);
        public static System.Windows.MessageBoxResult Show(System.String messageBoxText, System.String caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon) => Windows.UI.Xaml.MessageBox.Show(@messageBoxText, @caption, @button, @icon);
        public static System.Windows.MessageBoxResult Show(System.String messageBoxText, System.String caption, System.Windows.MessageBoxButton button) => Windows.UI.Xaml.MessageBox.Show(@messageBoxText, @caption, @button);
        public static System.Windows.MessageBoxResult Show(System.String messageBoxText, System.String caption) => Windows.UI.Xaml.MessageBox.Show(@messageBoxText, @caption);
        public static System.Windows.MessageBoxResult Show(System.String messageBoxText) => Windows.UI.Xaml.MessageBox.Show(@messageBoxText);
        public static System.Windows.MessageBoxResult Show(System.Windows.Window owner, System.String messageBoxText, System.String caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.MessageBoxResult defaultResult, System.Windows.MessageBoxOptions options) => Windows.UI.Xaml.MessageBox.Show(@owner, @messageBoxText, @caption, @button, @icon, @defaultResult, @options);
        public static System.Windows.MessageBoxResult Show(System.Windows.Window owner, System.String messageBoxText, System.String caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.MessageBoxResult defaultResult) => Windows.UI.Xaml.MessageBox.Show(@owner, @messageBoxText, @caption, @button, @icon, @defaultResult);
        public static System.Windows.MessageBoxResult Show(System.Windows.Window owner, System.String messageBoxText, System.String caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon) => Windows.UI.Xaml.MessageBox.Show(@owner, @messageBoxText, @caption, @button, @icon);
        public static System.Windows.MessageBoxResult Show(System.Windows.Window owner, System.String messageBoxText, System.String caption, System.Windows.MessageBoxButton button) => Windows.UI.Xaml.MessageBox.Show(@owner, @messageBoxText, @caption, @button);
        public static System.Windows.MessageBoxResult Show(System.Windows.Window owner, System.String messageBoxText, System.String caption) => Windows.UI.Xaml.MessageBox.Show(@owner, @messageBoxText, @caption);
        public static System.Windows.MessageBoxResult Show(System.Windows.Window owner, System.String messageBoxText) => Windows.UI.Xaml.MessageBox.Show(@owner, @messageBoxText);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}