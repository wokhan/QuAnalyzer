namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class RayMeshGeometry3DHitTestResult : Proxy<global::Windows.UI.Xaml.Media.Media3D.RayMeshGeometry3DHitTestResult>
    {
        public System.Windows.Media.Media3D.Point3D PointHit
        {
            get => __ProxyValue.PointHit;
        }

        public System.Double DistanceToRayOrigin
        {
            get => __ProxyValue.DistanceToRayOrigin;
        }

        public System.Int32 VertexIndex1
        {
            get => __ProxyValue.VertexIndex1;
        }

        public System.Int32 VertexIndex2
        {
            get => __ProxyValue.VertexIndex2;
        }

        public System.Int32 VertexIndex3
        {
            get => __ProxyValue.VertexIndex3;
        }

        public System.Double VertexWeight1
        {
            get => __ProxyValue.VertexWeight1;
        }

        public System.Double VertexWeight2
        {
            get => __ProxyValue.VertexWeight2;
        }

        public System.Double VertexWeight3
        {
            get => __ProxyValue.VertexWeight3;
        }

        public System.Windows.Media.Media3D.MeshGeometry3D MeshHit
        {
            get => __ProxyValue.MeshHit;
        }

        public System.Windows.Media.Media3D.Visual3D VisualHit
        {
            get => __ProxyValue.VisualHit;
        }

        public System.Windows.Media.Media3D.Model3D ModelHit
        {
            get => __ProxyValue.ModelHit;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}