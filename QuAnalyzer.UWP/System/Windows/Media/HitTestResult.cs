namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class HitTestResult : Proxy<global::Windows.UI.Xaml.Media.HitTestResult>
    {
        public System.Windows.DependencyObject VisualHit
        {
            get => __ProxyValue.VisualHit;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}