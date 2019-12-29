namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class TouchPoint : Proxy<global::Windows.UI.Xaml.Input.TouchPoint>
    {
        public System.Windows.Input.TouchDevice TouchDevice
        {
            get => __ProxyValue.TouchDevice;
        }

        public System.Windows.Point Position
        {
            get => __ProxyValue.Position;
        }

        public System.Windows.Rect Bounds
        {
            get => __ProxyValue.Bounds;
        }

        public System.Windows.Size Size
        {
            get => __ProxyValue.Size;
        }

        public System.Windows.Input.TouchAction Action
        {
            get => __ProxyValue.Action;
        }

        public TouchPoint(System.Windows.Input.TouchDevice @device, System.Windows.Point @position, System.Windows.Rect @bounds, System.Windows.Input.TouchAction @action): base(@device, @position, @bounds, @action)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}