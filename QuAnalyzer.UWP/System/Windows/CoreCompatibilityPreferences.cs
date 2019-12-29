namespace System.Windows
{
    using Uno.UI.Generic;

    public class CoreCompatibilityPreferences : Proxy<global::Windows.UI.Xaml.CoreCompatibilityPreferences>
    {
        public static System.Boolean IsAltKeyRequiredInAccessKeyDefaultScope
        {
            get => __ProxyValue.IsAltKeyRequiredInAccessKeyDefaultScope;
            set => __ProxyValue.IsAltKeyRequiredInAccessKeyDefaultScope = value;
        }

        public static System.Nullable<System.Boolean> EnableMultiMonitorDisplayClipping
        {
            get => __ProxyValue.EnableMultiMonitorDisplayClipping;
            set => __ProxyValue.EnableMultiMonitorDisplayClipping = value;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}