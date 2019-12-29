namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class AdornerHitTestResult : Proxy<global::Windows.UI.Xaml.Media.AdornerHitTestResult>
    {
        public System.Windows.Documents.Adorner Adorner
        {
            get => __ProxyValue.Adorner;
        }

        public System.Windows.Point PointHit
        {
            get => __ProxyValue.PointHit;
        }

        public System.Windows.Media.Visual VisualHit
        {
            get => __ProxyValue.VisualHit;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}