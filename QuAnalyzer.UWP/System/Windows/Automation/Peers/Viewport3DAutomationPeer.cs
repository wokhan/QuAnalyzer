namespace System.Windows.Automation.Peers
{
    using Uno.UI.Generic;

    public class Viewport3DAutomationPeer : Proxy<global::Windows.UI.Xaml.Automation.Peers.Viewport3DAutomationPeer>
    {
        public System.Windows.UIElement Owner
        {
            get => __ProxyValue.Owner;
        }

        public System.Windows.Automation.Peers.AutomationPeer EventsSource
        {
            get => __ProxyValue.EventsSource;
            set => __ProxyValue.EventsSource = value;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public Viewport3DAutomationPeer(System.Windows.Controls.Viewport3D @owner): base(@owner)
        {
        }

        public System.Object GetPattern(System.Windows.Automation.Peers.PatternInterface patternInterface) => __ProxyValue.GetPattern(@patternInterface);
        public void InvalidatePeer() => __ProxyValue.InvalidatePeer();
        public void RaiseAutomationEvent(System.Windows.Automation.Peers.AutomationEvents eventId) => __ProxyValue.RaiseAutomationEvent(@eventId);
        public void RaisePropertyChangedEvent(System.Windows.Automation.AutomationProperty property, System.Object oldValue, System.Object newValue) => __ProxyValue.RaisePropertyChangedEvent(@property, @oldValue, @newValue);
        public void RaiseAsyncContentLoadedEvent(System.Windows.Automation.AsyncContentLoadedEventArgs args) => __ProxyValue.RaiseAsyncContentLoadedEvent(@args);
        public System.Windows.Rect GetBoundingRectangle() => __ProxyValue.GetBoundingRectangle();
        public System.Boolean IsOffscreen() => __ProxyValue.IsOffscreen();
        public System.Windows.Automation.Peers.AutomationOrientation GetOrientation() => __ProxyValue.GetOrientation();
        public System.String GetItemType() => __ProxyValue.GetItemType();
        public System.String GetClassName() => __ProxyValue.GetClassName();
        public System.String GetItemStatus() => __ProxyValue.GetItemStatus();
        public System.Boolean IsRequiredForForm() => __ProxyValue.IsRequiredForForm();
        public System.Boolean IsKeyboardFocusable() => __ProxyValue.IsKeyboardFocusable();
        public System.Boolean HasKeyboardFocus() => __ProxyValue.HasKeyboardFocus();
        public System.Boolean IsEnabled() => __ProxyValue.IsEnabled();
        public System.Boolean IsPassword() => __ProxyValue.IsPassword();
        public System.String GetAutomationId() => __ProxyValue.GetAutomationId();
        public System.String GetName() => __ProxyValue.GetName();
        public System.Windows.Automation.Peers.AutomationControlType GetAutomationControlType() => __ProxyValue.GetAutomationControlType();
        public System.String GetLocalizedControlType() => __ProxyValue.GetLocalizedControlType();
        public System.Boolean IsContentElement() => __ProxyValue.IsContentElement();
        public System.Boolean IsControlElement() => __ProxyValue.IsControlElement();
        public System.Windows.Automation.Peers.AutomationPeer GetLabeledBy() => __ProxyValue.GetLabeledBy();
        public System.String GetHelpText() => __ProxyValue.GetHelpText();
        public System.String GetAcceleratorKey() => __ProxyValue.GetAcceleratorKey();
        public System.String GetAccessKey() => __ProxyValue.GetAccessKey();
        public System.Windows.Point GetClickablePoint() => __ProxyValue.GetClickablePoint();
        public void SetFocus() => __ProxyValue.SetFocus();
        public System.Windows.Automation.AutomationLiveSetting GetLiveSetting() => __ProxyValue.GetLiveSetting();
        public System.Collections.Generic.List<System.Windows.Automation.Peers.AutomationPeer> GetControlledPeers() => __ProxyValue.GetControlledPeers();
        public System.Int32 GetSizeOfSet() => __ProxyValue.GetSizeOfSet();
        public System.Int32 GetPositionInSet() => __ProxyValue.GetPositionInSet();
        public System.Windows.Automation.Peers.AutomationPeer GetParent() => __ProxyValue.GetParent();
        public System.Collections.Generic.List<System.Windows.Automation.Peers.AutomationPeer> GetChildren() => __ProxyValue.GetChildren();
        public void ResetChildrenCache() => __ProxyValue.ResetChildrenCache();
        public System.Windows.Automation.Peers.AutomationPeer GetPeerFromPoint(System.Windows.Point point) => __ProxyValue.GetPeerFromPoint(@point);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}