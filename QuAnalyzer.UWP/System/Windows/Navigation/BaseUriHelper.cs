namespace System.Windows.Navigation
{
    using Uno.UI.Generic;

    public class BaseUriHelper : Proxy<global::Windows.UI.Xaml.Navigation.BaseUriHelper>
    {
        public static System.Uri GetBaseUri(System.Windows.DependencyObject element) => Windows.UI.Xaml.Navigation.BaseUriHelper.GetBaseUri(@element);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}