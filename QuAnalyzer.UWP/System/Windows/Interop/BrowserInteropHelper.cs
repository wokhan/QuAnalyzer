namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class BrowserInteropHelper : Proxy<global::Windows.UI.Xaml.Interop.BrowserInteropHelper>
    {
        public static System.Object ClientSite
        {
            get => __ProxyValue.ClientSite;
        }

        public static System.Object HostScript
        {
            get => __ProxyValue.HostScript;
        }

        public static System.Boolean IsBrowserHosted
        {
            get => __ProxyValue.IsBrowserHosted;
        }

        public static System.Uri Source
        {
            get => __ProxyValue.Source;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}