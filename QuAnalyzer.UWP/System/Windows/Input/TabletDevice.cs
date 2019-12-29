namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class TabletDevice : Proxy<global::Windows.UI.Xaml.Input.TabletDevice>
    {
        public System.Windows.IInputElement Target
        {
            get => __ProxyValue.Target;
        }

        public System.Windows.PresentationSource ActiveSource
        {
            get => __ProxyValue.ActiveSource;
        }

        public System.Int32 Id
        {
            get => __ProxyValue.Id;
        }

        public System.String Name
        {
            get => __ProxyValue.Name;
        }

        public System.String ProductId
        {
            get => __ProxyValue.ProductId;
        }

        public System.Windows.Input.TabletHardwareCapabilities TabletHardwareCapabilities
        {
            get => __ProxyValue.TabletHardwareCapabilities;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.Input.StylusPointProperty> SupportedStylusPointProperties
        {
            get => __ProxyValue.SupportedStylusPointProperties;
        }

        public System.Windows.Input.TabletDeviceType Type
        {
            get => __ProxyValue.Type;
        }

        public System.Windows.Input.StylusDeviceCollection StylusDevices
        {
            get => __ProxyValue.StylusDevices;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}