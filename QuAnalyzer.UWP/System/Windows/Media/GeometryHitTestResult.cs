namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class GeometryHitTestResult : Proxy<global::Windows.UI.Xaml.Media.GeometryHitTestResult>
    {
        public System.Windows.Media.IntersectionDetail IntersectionDetail
        {
            get => __ProxyValue.IntersectionDetail;
        }

        public System.Windows.Media.Visual VisualHit
        {
            get => __ProxyValue.VisualHit;
        }

        public GeometryHitTestResult(System.Windows.Media.Visual @visualHit, System.Windows.Media.IntersectionDetail @intersectionDetail): base(@visualHit, @intersectionDetail)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}