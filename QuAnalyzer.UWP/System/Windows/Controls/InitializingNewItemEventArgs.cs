namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class InitializingNewItemEventArgs : Proxy<global::Windows.UI.Xaml.Controls.InitializingNewItemEventArgs>
    {
        public System.Object NewItem
        {
            get => __ProxyValue.NewItem;
        }

        public InitializingNewItemEventArgs(System.Object @newItem): base(@newItem)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}