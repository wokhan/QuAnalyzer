namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class PointHitTestParameters : Proxy<global::Windows.UI.Xaml.Media.PointHitTestParameters>
    {
        public System.Windows.Point HitPoint
        {
            get => __ProxyValue.HitPoint;
        }

        public PointHitTestParameters(System.Windows.Point @point): base(@point)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}