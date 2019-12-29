namespace System.Windows.Shell
{
    using Uno.UI.Generic;

    public class JumpItemsRemovedEventArgs : Proxy<global::Windows.UI.Xaml.Shell.JumpItemsRemovedEventArgs>
    {
        public System.Collections.Generic.IList<System.Windows.Shell.JumpItem> RemovedItems
        {
            get => __ProxyValue.RemovedItems;
        }

        public JumpItemsRemovedEventArgs(): base()
        {
        }

        public JumpItemsRemovedEventArgs(System.Collections.Generic.IList<System.Windows.Shell.JumpItem> @removedItems): base(@removedItems)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}