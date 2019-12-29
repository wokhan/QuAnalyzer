namespace System.Windows.Navigation
{
    using Uno.UI.Generic;

    public class NavigatingCancelEventArgs : Proxy<global::Windows.UI.Xaml.Navigation.NavigatingCancelEventArgs>
    {
        public System.Uri Uri
        {
            get => __ProxyValue.Uri;
        }

        public System.Object Content
        {
            get => __ProxyValue.Content;
        }

        public System.Windows.Navigation.CustomContentState TargetContentState
        {
            get => __ProxyValue.TargetContentState;
        }

        public System.Windows.Navigation.CustomContentState ContentStateToSave
        {
            get => __ProxyValue.ContentStateToSave;
            set => __ProxyValue.ContentStateToSave = value;
        }

        public System.Object ExtraData
        {
            get => __ProxyValue.ExtraData;
        }

        public System.Windows.Navigation.NavigationMode NavigationMode
        {
            get => __ProxyValue.NavigationMode;
        }

        public System.Net.WebRequest WebRequest
        {
            get => __ProxyValue.WebRequest;
        }

        public System.Boolean IsNavigationInitiator
        {
            get => __ProxyValue.IsNavigationInitiator;
        }

        public System.Object Navigator
        {
            get => __ProxyValue.Navigator;
        }

        public System.Boolean Cancel
        {
            get => __ProxyValue.Cancel;
            set => __ProxyValue.Cancel = value;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}