namespace System.Windows.Navigation
{
    using Uno.UI.Generic;

    public class NavigationProgressEventArgs : Proxy<global::Windows.UI.Xaml.Navigation.NavigationProgressEventArgs>
    {
        public System.Uri Uri
        {
            get => __ProxyValue.Uri;
        }

        public System.Int64 BytesRead
        {
            get => __ProxyValue.BytesRead;
        }

        public System.Int64 MaxBytes
        {
            get => __ProxyValue.MaxBytes;
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