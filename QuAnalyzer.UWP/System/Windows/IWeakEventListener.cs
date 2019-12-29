namespace System.Windows
{
    using Uno.UI.Generic;

    public class IWeakEventListener : Proxy<global::Windows.UI.Xaml.IWeakEventListener>
    {
        public System.Boolean ReceiveWeakEvent(System.Type managerType, System.Object sender, System.EventArgs e) => __ProxyValue.ReceiveWeakEvent(@managerType, @sender, @e);
    }
}