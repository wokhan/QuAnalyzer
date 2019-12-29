namespace System.Windows.Diagnostics
{
    using Uno.UI.Generic;

    public class VisualDiagnostics : Proxy<global::Windows.UI.Xaml.Diagnostics.VisualDiagnostics>
    {
        public static void add_VisualTreeChanged(System.EventHandler<System.Windows.Diagnostics.VisualTreeChangeEventArgs> value) => Windows.UI.Xaml.Diagnostics.VisualDiagnostics.add_VisualTreeChanged(@value);
        public static void remove_VisualTreeChanged(System.EventHandler<System.Windows.Diagnostics.VisualTreeChangeEventArgs> value) => Windows.UI.Xaml.Diagnostics.VisualDiagnostics.remove_VisualTreeChanged(@value);
        public static void EnableVisualTreeChanged() => Windows.UI.Xaml.Diagnostics.VisualDiagnostics.EnableVisualTreeChanged();
        public static void DisableVisualTreeChanged() => Windows.UI.Xaml.Diagnostics.VisualDiagnostics.DisableVisualTreeChanged();
        public static System.Windows.Diagnostics.XamlSourceInfo GetXamlSourceInfo(System.Object obj) => Windows.UI.Xaml.Diagnostics.VisualDiagnostics.GetXamlSourceInfo(@obj);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}