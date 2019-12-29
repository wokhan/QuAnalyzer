namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class PointHitTestResult : Proxy<global::Windows.UI.Xaml.Media.PointHitTestResult>
    {
        public System.Windows.Point PointHit
        {
            get => __ProxyValue.PointHit;
        }

        public System.Windows.Media.Visual VisualHit
        {
            get => __ProxyValue.VisualHit;
        }

        public PointHitTestResult(System.Windows.Media.Visual @visualHit, System.Windows.Point @pointHit): base(@visualHit, @pointHit)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}