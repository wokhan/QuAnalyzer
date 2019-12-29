namespace System.Windows
{
    using Uno.UI.Generic;

    public class SystemCommands : Proxy<global::Windows.UI.Xaml.SystemCommands>
    {
        public static System.Windows.Input.RoutedCommand CloseWindowCommand
        {
            get => __ProxyValue.CloseWindowCommand;
        }

        public static System.Windows.Input.RoutedCommand MaximizeWindowCommand
        {
            get => __ProxyValue.MaximizeWindowCommand;
        }

        public static System.Windows.Input.RoutedCommand MinimizeWindowCommand
        {
            get => __ProxyValue.MinimizeWindowCommand;
        }

        public static System.Windows.Input.RoutedCommand RestoreWindowCommand
        {
            get => __ProxyValue.RestoreWindowCommand;
        }

        public static System.Windows.Input.RoutedCommand ShowSystemMenuCommand
        {
            get => __ProxyValue.ShowSystemMenuCommand;
        }

        public static void CloseWindow(System.Windows.Window window) => Windows.UI.Xaml.SystemCommands.CloseWindow(@window);
        public static void MaximizeWindow(System.Windows.Window window) => Windows.UI.Xaml.SystemCommands.MaximizeWindow(@window);
        public static void MinimizeWindow(System.Windows.Window window) => Windows.UI.Xaml.SystemCommands.MinimizeWindow(@window);
        public static void RestoreWindow(System.Windows.Window window) => Windows.UI.Xaml.SystemCommands.RestoreWindow(@window);
        public static void ShowSystemMenu(System.Windows.Window window, System.Windows.Point screenLocation) => Windows.UI.Xaml.SystemCommands.ShowSystemMenu(@window, @screenLocation);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}