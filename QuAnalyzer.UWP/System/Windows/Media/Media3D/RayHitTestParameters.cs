namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class RayHitTestParameters : Proxy<global::Windows.UI.Xaml.Media.Media3D.RayHitTestParameters>
    {
        public System.Windows.Media.Media3D.Point3D Origin
        {
            get => __ProxyValue.Origin;
        }

        public System.Windows.Media.Media3D.Vector3D Direction
        {
            get => __ProxyValue.Direction;
        }

        public RayHitTestParameters(System.Windows.Media.Media3D.Point3D @origin, System.Windows.Media.Media3D.Vector3D @direction): base(@origin, @direction)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}