namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class TouchFrameEventArgs : Proxy<global::Windows.UI.Xaml.Input.TouchFrameEventArgs>
    {
        public System.Int32 Timestamp
        {
            get => __ProxyValue.Timestamp;
        }

        public System.Windows.Input.TouchPointCollection GetTouchPoints(System.Windows.IInputElement relativeTo) => __ProxyValue.GetTouchPoints(@relativeTo);
        public System.Windows.Input.TouchPoint GetPrimaryTouchPoint(System.Windows.IInputElement relativeTo) => __ProxyValue.GetPrimaryTouchPoint(@relativeTo);
        public void SuspendMousePromotionUntilTouchUp() => __ProxyValue.SuspendMousePromotionUntilTouchUp();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}