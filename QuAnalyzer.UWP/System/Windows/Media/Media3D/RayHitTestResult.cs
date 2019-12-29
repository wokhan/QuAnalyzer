namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class RayHitTestResult : Proxy<global::Windows.UI.Xaml.Media.Media3D.RayHitTestResult>
    {
        public System.Windows.Media.Media3D.Visual3D VisualHit
        {
            get => __ProxyValue.VisualHit;
        }

        public System.Windows.Media.Media3D.Model3D ModelHit
        {
            get => __ProxyValue.ModelHit;
        }

        public System.Windows.Media.Media3D.Point3D PointHit
        {
            get => __ProxyValue.PointHit;
        }

        public System.Double DistanceToRayOrigin
        {
            get => __ProxyValue.DistanceToRayOrigin;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}