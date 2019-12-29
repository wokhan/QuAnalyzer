namespace System.Windows.Shell
{
    using Uno.UI.Generic;

    public class JumpItemsRejectedEventArgs : Proxy<global::Windows.UI.Xaml.Shell.JumpItemsRejectedEventArgs>
    {
        public System.Collections.Generic.IList<System.Windows.Shell.JumpItem> RejectedItems
        {
            get => __ProxyValue.RejectedItems;
        }

        public System.Collections.Generic.IList<System.Windows.Shell.JumpItemRejectionReason> RejectionReasons
        {
            get => __ProxyValue.RejectionReasons;
        }

        public JumpItemsRejectedEventArgs(): base()
        {
        }

        public JumpItemsRejectedEventArgs(System.Collections.Generic.IList<System.Windows.Shell.JumpItem> @rejectedItems, System.Collections.Generic.IList<System.Windows.Shell.JumpItemRejectionReason> @reasons): base(@rejectedItems, @reasons)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}