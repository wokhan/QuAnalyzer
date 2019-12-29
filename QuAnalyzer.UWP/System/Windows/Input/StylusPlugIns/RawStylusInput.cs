namespace System.Windows.Input.StylusPlugIns
{
    using Uno.UI.Generic;

    public class RawStylusInput : Proxy<global::Windows.UI.Xaml.Input.StylusPlugIns.RawStylusInput>
    {
        public System.Int32 StylusDeviceId
        {
            get => __ProxyValue.StylusDeviceId;
        }

        public System.Int32 TabletDeviceId
        {
            get => __ProxyValue.TabletDeviceId;
        }

        public System.Int32 Timestamp
        {
            get => __ProxyValue.Timestamp;
        }

        public System.Windows.Input.StylusPointCollection GetStylusPoints() => __ProxyValue.GetStylusPoints();
        public void SetStylusPoints(System.Windows.Input.StylusPointCollection stylusPoints) => __ProxyValue.SetStylusPoints(@stylusPoints);
        public void NotifyWhenProcessed(System.Object callbackData) => __ProxyValue.NotifyWhenProcessed(@callbackData);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}