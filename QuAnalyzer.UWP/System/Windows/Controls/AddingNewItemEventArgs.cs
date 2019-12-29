namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class AddingNewItemEventArgs : Proxy<global::Windows.UI.Xaml.Controls.AddingNewItemEventArgs>
    {
        public System.Object NewItem
        {
            get => __ProxyValue.NewItem;
            set => __ProxyValue.NewItem = value;
        }

        public AddingNewItemEventArgs(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}