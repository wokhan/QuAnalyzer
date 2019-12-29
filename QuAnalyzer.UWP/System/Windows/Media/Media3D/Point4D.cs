namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class Point4D : Proxy<global::Windows.UI.Xaml.Media.Media3D.Point4D>
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

        public System.Double W
        {
            get => __ProxyValue.W;
            set => __ProxyValue.W = value;
        }

        public Point4D(System.Double @x, System.Double @y, System.Double @z, System.Double @w): base(@x, @y, @z, @w)
        {
        }

        public void Offset(System.Double deltaX, System.Double deltaY, System.Double deltaZ, System.Double deltaW) => __ProxyValue.Offset(@deltaX, @deltaY, @deltaZ, @deltaW);
        public static System.Windows.Media.Media3D.Point4D op_Addition(System.Windows.Media.Media3D.Point4D point1, System.Windows.Media.Media3D.Point4D point2) => Windows.UI.Xaml.Media.Media3D.Point4D.op_Addition(@point1, @point2);
        public static System.Windows.Media.Media3D.Point4D Add(System.Windows.Media.Media3D.Point4D point1, System.Windows.Media.Media3D.Point4D point2) => Windows.UI.Xaml.Media.Media3D.Point4D.Add(@point1, @point2);
        public static System.Windows.Media.Media3D.Point4D op_Subtraction(System.Windows.Media.Media3D.Point4D point1, System.Windows.Media.Media3D.Point4D point2) => Windows.UI.Xaml.Media.Media3D.Point4D.op_Subtraction(@point1, @point2);
        public static System.Windows.Media.Media3D.Point4D Subtract(System.Windows.Media.Media3D.Point4D point1, System.Windows.Media.Media3D.Point4D point2) => Windows.UI.Xaml.Media.Media3D.Point4D.Subtract(@point1, @point2);
        public static System.Windows.Media.Media3D.Point4D op_Multiply(System.Windows.Media.Media3D.Point4D point, System.Windows.Media.Media3D.Matrix3D matrix) => Windows.UI.Xaml.Media.Media3D.Point4D.op_Multiply(@point, @matrix);
        public static System.Windows.Media.Media3D.Point4D Multiply(System.Windows.Media.Media3D.Point4D point, System.Windows.Media.Media3D.Matrix3D matrix) => Windows.UI.Xaml.Media.Media3D.Point4D.Multiply(@point, @matrix);
        public static System.Boolean op_Equality(System.Windows.Media.Media3D.Point4D point1, System.Windows.Media.Media3D.Point4D point2) => Windows.UI.Xaml.Media.Media3D.Point4D.op_Equality(@point1, @point2);
        public static System.Boolean op_Inequality(System.Windows.Media.Media3D.Point4D point1, System.Windows.Media.Media3D.Point4D point2) => Windows.UI.Xaml.Media.Media3D.Point4D.op_Inequality(@point1, @point2);
        public static System.Boolean Equals(System.Windows.Media.Media3D.Point4D point1, System.Windows.Media.Media3D.Point4D point2) => Windows.UI.Xaml.Media.Media3D.Point4D.Equals(@point1, @point2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Boolean Equals(System.Windows.Media.Media3D.Point4D value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Windows.Media.Media3D.Point4D Parse(System.String source) => Windows.UI.Xaml.Media.Media3D.Point4D.Parse(@source);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
    }
}