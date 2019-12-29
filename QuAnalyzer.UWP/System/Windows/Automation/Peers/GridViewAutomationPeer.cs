namespace System.Windows.Automation.Peers
{
    using Uno.UI.Generic;

    public class GridViewAutomationPeer : Proxy<global::Windows.UI.Xaml.Automation.Peers.GridViewAutomationPeer>
    {
        public GridViewAutomationPeer(System.Windows.Controls.GridView @owner, System.Windows.Controls.ListView @listview): base(@owner, @listview)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}