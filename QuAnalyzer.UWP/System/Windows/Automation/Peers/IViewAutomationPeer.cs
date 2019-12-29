namespace System.Windows.Automation.Peers
{
    using Uno.UI.Generic;

    public class IViewAutomationPeer : Proxy<global::Windows.UI.Xaml.Automation.Peers.IViewAutomationPeer>
    {
        public System.Windows.Automation.Peers.AutomationControlType GetAutomationControlType() => __ProxyValue.GetAutomationControlType();
        public System.Object GetPattern(System.Windows.Automation.Peers.PatternInterface patternInterface) => __ProxyValue.GetPattern(@patternInterface);
        public System.Collections.Generic.List<System.Windows.Automation.Peers.AutomationPeer> GetChildren(System.Collections.Generic.List<System.Windows.Automation.Peers.AutomationPeer> children) => __ProxyValue.GetChildren(@children);
        public System.Windows.Automation.Peers.ItemAutomationPeer CreateItemAutomationPeer(System.Object item) => __ProxyValue.CreateItemAutomationPeer(@item);
        public void ItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => __ProxyValue.ItemsChanged(@e);
        public void ViewDetached() => __ProxyValue.ViewDetached();
    }
}