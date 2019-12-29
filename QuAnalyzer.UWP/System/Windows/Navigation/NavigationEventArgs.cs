namespace System.Windows.Navigation
{
    using Uno.UI.Generic;

    public class NavigationEventArgs : Proxy<global::Windows.UI.Xaml.Navigation.NavigationEventArgs>
    {
        public System.Uri Uri
        {
            get => __ProxyValue.Uri;
        }

        public System.Object Content
        {
            get => __ProxyValue.Content;
        }

        public System.Boolean IsNavigationInitiator
        {
            get => __ProxyValue.IsNavigationInitiator;
        }

        public System.Object ExtraData
        {
            get => __ProxyValue.ExtraData;
        }

        public System.Net.WebResponse WebResponse
        {
            get => __ProxyValue.WebResponse;
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