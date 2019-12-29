namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class Tablet : Proxy<global::Windows.UI.Xaml.Input.Tablet>
    {
        public static System.Windows.Input.TabletDevice CurrentTabletDevice
        {
            get => __ProxyValue.CurrentTabletDevice;
        }

        public static System.Windows.Input.TabletDeviceCollection TabletDevices
        {
            get => __ProxyValue.TabletDevices;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}