namespace System.Windows
{
    using Uno.UI.Generic;

    public class EventRoute : Proxy<global::Windows.UI.Xaml.EventRoute>
    {
        public EventRoute(System.Windows.RoutedEvent @routedEvent): base(@routedEvent)
        {
        }

        public void Add(System.Object target, System.Delegate handler, System.Boolean handledEventsToo) => __ProxyValue.Add(@target, @handler, @handledEventsToo);
        public void PushBranchNode(System.Object node, System.Object source) => __ProxyValue.PushBranchNode(@node, @source);
        public System.Object PopBranchNode() => __ProxyValue.PopBranchNode();
        public System.Object PeekBranchNode() => __ProxyValue.PeekBranchNode();
        public System.Object PeekBranchSource() => __ProxyValue.PeekBranchSource();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}