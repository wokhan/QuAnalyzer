namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class Point3D : Proxy<global::Windows.UI.Xaml.Media.Media3D.Point3D>
    {
        public System.Double X
        {
            get => __ProxyValue.X;
            set => __ProxyValue.X = value;
        }

        public System.Double Y
        {
            get => __ProxyValue.Y;
            set => __ProxyValue.Y = value;
        }

        public System.Double Z
        {
            get => __ProxyValue.Z;
            set => __ProxyValue.Z = value;
        }

        public Point3D(System.Double @x, System.Double @y, System.Double @z): base(@x, @y, @z)
        {
        }

        public void Offset(System.Double offsetX, System.Double offsetY, System.Double offsetZ) => __ProxyValue.Offset(@offsetX, @offsetY, @offsetZ);
        public static System.Windows.Media.Media3D.Point3D op_Addition(System.Windows.Media.Media3D.Point3D point, System.Windows.Media.Media3D.Vector3D vector) => Windows.UI.Xaml.Media.Media3D.Point3D.op_Addition(@point, @vector);
        public static System.Windows.Media.Media3D.Point3D Add(System.Windows.Media.Media3D.Point3D point, System.Windows.Media.Media3D.Vector3D vector) => Windows.UI.Xaml.Media.Media3D.Point3D.Add(@point, @vector);
        public static System.Windows.Media.Media3D.Point3D op_Subtraction(System.Windows.Media.Media3D.Point3D point, System.Windows.Media.Media3D.Vector3D vector) => Windows.UI.Xaml.Media.Media3D.Point3D.op_Subtraction(@point, @vector);
        public static System.Windows.Media.Media3D.Point3D Subtract(System.Windows.Media.Media3D.Point3D point, System.Windows.Media.Media3D.Vector3D vector) => Windows.UI.Xaml.Media.Media3D.Point3D.Subtract(@point, @vector);
        public static System.Windows.Media.Media3D.Vector3D op_Subtraction(System.Windows.Media.Media3D.Point3D point1, System.Windows.Media.Media3D.Point3D point2) => Windows.UI.Xaml.Media.Media3D.Point3D.op_Subtraction(@point1, @point2);
        public static System.Windows.Media.Media3D.Vector3D Subtract(System.Windows.Media.Media3D.Point3D point1, System.Windows.Media.Media3D.Point3D point2) => Windows.UI.Xaml.Media.Media3D.Point3D.Subtract(@point1, @point2);
        public static System.Windows.Media.Media3D.Point3D op_Multiply(System.Windows.Media.Media3D.Point3D point, System.Windows.Media.Media3D.Matrix3D matrix) => Windows.UI.Xaml.Media.Media3D.Point3D.op_Multiply(@point, @matrix);
        public static System.Windows.Media.Media3D.Point3D Multiply(System.Windows.Media.Media3D.Point3D point, System.Windows.Media.Media3D.Matrix3D matrix) => Windows.UI.Xaml.Media.Media3D.Point3D.Multiply(@point, @matrix);
        public static System.Windows.Media.Media3D.Vector3D op_Explicit(System.Windows.Media.Media3D.Point3D point) => Windows.UI.Xaml.Media.Media3D.Point3D.op_Explicit(@point);
        public static System.Windows.Media.Media3D.Point4D op_Explicit(System.Windows.Media.Media3D.Point3D point) => Windows.UI.Xaml.Media.Media3D.Point3D.op_Explicit(@point);
        public static System.Boolean op_Equality(System.Windows.Media.Media3D.Point3D point1, System.Windows.Media.Media3D.Point3D point2) => Windows.UI.Xaml.Media.Media3D.Point3D.op_Equality(@point1, @point2);
        public static System.Boolean op_Inequality(System.Windows.Media.Media3D.Point3D point1, System.Windows.Media.Media3D.Point3D point2) => Windows.UI.Xaml.Media.Media3D.Point3D.op_Inequality(@point1, @point2);
        public static System.Boolean Equals(System.Windows.Media.Media3D.Point3D point1, System.Windows.Media.Media3D.Point3D point2) => Windows.UI.Xaml.Media.Media3D.Point3D.Equals(@point1, @point2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Boolean Equals(System.Windows.Media.Media3D.Point3D value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Windows.Media.Media3D.Point3D Parse(System.String source) => Windows.UI.Xaml.Media.Media3D.Point3D.Parse(@source);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
    }
}