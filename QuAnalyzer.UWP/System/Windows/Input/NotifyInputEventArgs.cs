namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class NotifyInputEventArgs : Proxy<global::Windows.UI.Xaml.Input.NotifyInputEventArgs>
    {
        public System.Windows.Input.StagingAreaInputItem StagingItem
        {
            get => __ProxyValue.StagingItem;
        }

        public System.Windows.Input.InputManager InputManager
        {
            get => __ProxyValue.InputManager;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}