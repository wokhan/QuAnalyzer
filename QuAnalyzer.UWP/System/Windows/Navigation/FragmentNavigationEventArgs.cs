namespace System.Windows.Navigation
{
    using Uno.UI.Generic;

    public class FragmentNavigationEventArgs : Proxy<global::Windows.UI.Xaml.Navigation.FragmentNavigationEventArgs>
    {
        public System.String Fragment
        {
            get => __ProxyValue.Fragment;
        }

        public System.Boolean Handled
        {
            get => __ProxyValue.Handled;
            set => __ProxyValue.Handled = value;
        }

        public System.Object Navigator
        {
            get => __ProxyValue.Navigator;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}