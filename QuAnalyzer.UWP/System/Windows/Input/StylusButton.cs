namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class StylusButton : Proxy<global::Windows.UI.Xaml.Input.StylusButton>
    {
        public System.Guid Guid
        {
            get => __ProxyValue.Guid;
        }

        public System.Windows.Input.StylusButtonState StylusButtonState
        {
            get => __ProxyValue.StylusButtonState;
        }

        public System.String Name
        {
            get => __ProxyValue.Name;
        }

        public System.Windows.Input.StylusDevice StylusDevice
        {
            get => __ProxyValue.StylusDevice;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}