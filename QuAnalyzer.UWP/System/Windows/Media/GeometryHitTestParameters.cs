namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class GeometryHitTestParameters : Proxy<global::Windows.UI.Xaml.Media.GeometryHitTestParameters>
    {
        public System.Windows.Media.Geometry HitGeometry
        {
            get => __ProxyValue.HitGeometry;
        }

        public GeometryHitTestParameters(System.Windows.Media.Geometry @geometry): base(@geometry)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}