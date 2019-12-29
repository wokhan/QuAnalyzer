namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class TraversalRequest : Proxy<global::Windows.UI.Xaml.Input.TraversalRequest>
    {
        public System.Boolean Wrapped
        {
            get => __ProxyValue.Wrapped;
            set => __ProxyValue.Wrapped = value;
        }

        public System.Windows.Input.FocusNavigationDirection FocusNavigationDirection
        {
            get => __ProxyValue.FocusNavigationDirection;
        }

        public TraversalRequest(System.Windows.Input.FocusNavigationDirection @focusNavigationDirection): base(@focusNavigationDirection)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}