namespace System.Windows.Navigation
{
    using Uno.UI.Generic;

    public class NavigationFailedEventArgs : Proxy<global::Windows.UI.Xaml.Navigation.NavigationFailedEventArgs>
    {
        public System.Uri Uri
        {
            get => __ProxyValue.Uri;
        }

        public System.Object ExtraData
        {
            get => __ProxyValue.ExtraData;
        }

        public System.Object Navigator
        {
            get => __ProxyValue.Navigator;
        }

        public System.Net.WebRequest WebRequest
        {
            get => __ProxyValue.WebRequest;
        }

        public System.Net.WebResponse WebResponse
        {
            get => __ProxyValue.WebResponse;
        }

        public System.Exception Exception
        {
            get => __ProxyValue.Exception;
        }

        public System.Boolean Handled
        {
            get => __ProxyValue.Handled;
            set => __ProxyValue.Handled = value;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}