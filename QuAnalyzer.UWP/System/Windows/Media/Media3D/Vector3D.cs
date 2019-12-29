namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class Vector3D : Proxy<global::Windows.UI.Xaml.Media.Media3D.Vector3D>
    {
        public System.Double Length
        {
            get => __ProxyValue.Length;
        }

        public System.Double LengthSquared
        {
            get => __ProxyValue.LengthSquared;
        }

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

        public Vector3D(System.Double @x, System.Double @y, System.Double @z): base(@x, @y, @z)
        {
        }

        public void Normalize() => __ProxyValue.Normalize();
        public static System.Double AngleBetween(System.Windows.Media.Media3D.Vector3D vector1, System.Windows.Media.Media3D.Vector3D vector2) => Windows.UI.Xaml.Media.Media3D.Vector3D.AngleBetween(@vector1, @vector2);
        public static System.Windows.Media.Media3D.Vector3D op_UnaryNegation(System.Windows.Media.Media3D.Vector3D vector) => Windows.UI.Xaml.Media.Media3D.Vector3D.op_UnaryNegation(@vector);
        public void Negate() => __ProxyValue.Negate();
        public static System.Windows.Media.Media3D.Vector3D op_Addition(System.Windows.Media.Media3D.Vector3D vector1, System.Windows.Media.Media3D.Vector3D vector2) => Windows.UI.Xaml.Media.Media3D.Vector3D.op_Addition(@vector1, @vector2);
        public static System.Windows.Media.Media3D.Vector3D Add(System.Windows.Media.Media3D.Vector3D vector1, System.Windows.Media.Media3D.Vector3D vector2) => Windows.UI.Xaml.Media.Media3D.Vector3D.Add(@vector1, @vector2);
        public static System.Windows.Media.Media3D.Vector3D op_Subtraction(System.Windows.Media.Media3D.Vector3D vector1, System.Windows.Media.Media3D.Vector3D vector2) => Windows.UI.Xaml.Media.Media3D.Vector3D.op_Subtraction(@vector1, @vector2);
        public static System.Windows.Media.Media3D.Vector3D Subtract(System.Windows.Media.Media3D.Vector3D vector1, System.Windows.Media.Media3D.Vector3D vector2) => Windows.UI.Xaml.Media.Media3D.Vector3D.Subtract(@vector1, @vector2);
        public static System.Windows.Media.Media3D.Point3D op_Addition(System.Windows.Media.Media3D.Vector3D vector, System.Windows.Media.Media3D.Point3D point) => Windows.UI.Xaml.Media.Media3D.Vector3D.op_Addition(@vector, @point);
        public static System.Windows.Media.Media3D.Point3D Add(System.Windows.Media.Media3D.Vector3D vector, System.Windows.Media.Media3D.Point3D point) => Windows.UI.Xaml.Media.Media3D.Vector3D.Add(@vector, @point);
        public static System.Windows.Media.Media3D.Point3D op_Subtraction(System.Windows.Media.Media3D.Vector3D vector, System.Windows.Media.Media3D.Point3D point) => Windows.UI.Xaml.Media.Media3D.Vector3D.op_Subtraction(@vector, @point);
        public static System.Windows.Media.Media3D.Point3D Subtract(System.Windows.Media.Media3D.Vector3D vector, System.Windows.Media.Media3D.Point3D point) => Windows.UI.Xaml.Media.Media3D.Vector3D.Subtract(@vector, @point);
        public static System.Windows.Media.Media3D.Vector3D op_Multiply(System.Windows.Media.Media3D.Vector3D vector, System.Double scalar) => Windows.UI.Xaml.Media.Media3D.Vector3D.op_Multiply(@vector, @scalar);
        public static System.Windows.Media.Media3D.Vector3D Multiply(System.Windows.Media.Media3D.Vector3D vector, System.Double scalar) => Windows.UI.Xaml.Media.Media3D.Vector3D.Multiply(@vector, @scalar);
        public static System.Windows.Media.Media3D.Vector3D op_Multiply(System.Double scalar, System.Windows.Media.Media3D.Vector3D vector) => Windows.UI.Xaml.Media.Media3D.Vector3D.op_Multiply(@scalar, @vector);
        public static System.Windows.Media.Media3D.Vector3D Multiply(System.Double scalar, System.Windows.Media.Media3D.Vector3D vector) => Windows.UI.Xaml.Media.Media3D.Vector3D.Multiply(@scalar, @vector);
        public static System.Windows.Media.Media3D.Vector3D op_Division(System.Windows.Media.Media3D.Vector3D vector, System.Double scalar) => Windows.UI.Xaml.Media.Media3D.Vector3D.op_Division(@vector, @scalar);
        public static System.Windows.Media.Media3D.Vector3D Divide(System.Windows.Media.Media3D.Vector3D vector, System.Double scalar) => Windows.UI.Xaml.Media.Media3D.Vector3D.Divide(@vector, @scalar);
        public static System.Windows.Media.Media3D.Vector3D op_Multiply(System.Windows.Media.Media3D.Vector3D vector, System.Windows.Media.Media3D.Matrix3D matrix) => Windows.UI.Xaml.Media.Media3D.Vector3D.op_Multiply(@vector, @matrix);
        public static System.Windows.Media.Media3D.Vector3D Multiply(System.Windows.Media.Media3D.Vector3D vector, System.Windows.Media.Media3D.Matrix3D matrix) => Windows.UI.Xaml.Media.Media3D.Vector3D.Multiply(@vector, @matrix);
        public static System.Double DotProduct(System.Windows.Media.Media3D.Vector3D vector1, System.Windows.Media.Media3D.Vector3D vector2) => Windows.UI.Xaml.Media.Media3D.Vector3D.DotProduct(@vector1, @vector2);
        public static System.Windows.Media.Media3D.Vector3D CrossProduct(System.Windows.Media.Media3D.Vector3D vector1, System.Windows.Media.Media3D.Vector3D vector2) => Windows.UI.Xaml.Media.Media3D.Vector3D.CrossProduct(@vector1, @vector2);
        public static System.Windows.Media.Media3D.Point3D op_Explicit(System.Windows.Media.Media3D.Vector3D vector) => Windows.UI.Xaml.Media.Media3D.Vector3D.op_Explicit(@vector);
        public static System.Windows.Media.Media3D.Size3D op_Explicit(System.Windows.Media.Media3D.Vector3D vector) => Windows.UI.Xaml.Media.Media3D.Vector3D.op_Explicit(@vector);
        public static System.Boolean op_Equality(System.Windows.Media.Media3D.Vector3D vector1, System.Windows.Media.Media3D.Vector3D vector2) => Windows.UI.Xaml.Media.Media3D.Vector3D.op_Equality(@vector1, @vector2);
        public static System.Boolean op_Inequality(System.Windows.Media.Media3D.Vector3D vector1, System.Windows.Media.Media3D.Vector3D vector2) => Windows.UI.Xaml.Media.Media3D.Vector3D.op_Inequality(@vector1, @vector2);
        public static System.Boolean Equals(System.Windows.Media.Media3D.Vector3D vector1, System.Windows.Media.Media3D.Vector3D vector2) => Windows.UI.Xaml.Media.Media3D.Vector3D.Equals(@vector1, @vector2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Boolean Equals(System.Windows.Media.Media3D.Vector3D value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Windows.Media.Media3D.Vector3D Parse(System.String source) => Windows.UI.Xaml.Media.Media3D.Vector3D.Parse(@source);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
    }
}