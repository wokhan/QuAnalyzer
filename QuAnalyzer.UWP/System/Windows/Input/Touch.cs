namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class Touch : Proxy<global::Windows.UI.Xaml.Input.Touch>
    {
        public static void add_FrameReported(System.Windows.Input.TouchFrameEventHandler value) => Windows.UI.Xaml.Input.Touch.add_FrameReported(@value);
        public static void remove_FrameReported(System.Windows.Input.TouchFrameEventHandler value) => Windows.UI.Xaml.Input.Touch.remove_FrameReported(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}