namespace System.Windows
{
    using Uno.UI.Generic;

    public class Vector : Proxy<global::Windows.UI.Xaml.Vector>
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

        public System.Double Length
        {
            get => __ProxyValue.Length;
        }

        public System.Double LengthSquared
        {
            get => __ProxyValue.LengthSquared;
        }

        public Vector(System.Double @x, System.Double @y): base(@x, @y)
        {
        }

        public static System.Boolean op_Equality(System.Windows.Vector vector1, System.Windows.Vector vector2) => Windows.UI.Xaml.Vector.op_Equality(@vector1, @vector2);
        public static System.Boolean op_Inequality(System.Windows.Vector vector1, System.Windows.Vector vector2) => Windows.UI.Xaml.Vector.op_Inequality(@vector1, @vector2);
        public static System.Boolean Equals(System.Windows.Vector vector1, System.Windows.Vector vector2) => Windows.UI.Xaml.Vector.Equals(@vector1, @vector2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Boolean Equals(System.Windows.Vector value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Windows.Vector Parse(System.String source) => Windows.UI.Xaml.Vector.Parse(@source);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
        public void Normalize() => __ProxyValue.Normalize();
        public static System.Double CrossProduct(System.Windows.Vector vector1, System.Windows.Vector vector2) => Windows.UI.Xaml.Vector.CrossProduct(@vector1, @vector2);
        public static System.Double AngleBetween(System.Windows.Vector vector1, System.Windows.Vector vector2) => Windows.UI.Xaml.Vector.AngleBetween(@vector1, @vector2);
        public static System.Windows.Vector op_UnaryNegation(System.Windows.Vector vector) => Windows.UI.Xaml.Vector.op_UnaryNegation(@vector);
        public void Negate() => __ProxyValue.Negate();
        public static System.Windows.Vector op_Addition(System.Windows.Vector vector1, System.Windows.Vector vector2) => Windows.UI.Xaml.Vector.op_Addition(@vector1, @vector2);
        public static System.Windows.Vector Add(System.Windows.Vector vector1, System.Windows.Vector vector2) => Windows.UI.Xaml.Vector.Add(@vector1, @vector2);
        public static System.Windows.Vector op_Subtraction(System.Windows.Vector vector1, System.Windows.Vector vector2) => Windows.UI.Xaml.Vector.op_Subtraction(@vector1, @vector2);
        public static System.Windows.Vector Subtract(System.Windows.Vector vector1, System.Windows.Vector vector2) => Windows.UI.Xaml.Vector.Subtract(@vector1, @vector2);
        public static System.Windows.Point op_Addition(System.Windows.Vector vector, System.Windows.Point point) => Windows.UI.Xaml.Vector.op_Addition(@vector, @point);
        public static System.Windows.Point Add(System.Windows.Vector vector, System.Windows.Point point) => Windows.UI.Xaml.Vector.Add(@vector, @point);
        public static System.Windows.Vector op_Multiply(System.Windows.Vector vector, System.Double scalar) => Windows.UI.Xaml.Vector.op_Multiply(@vector, @scalar);
        public static System.Windows.Vector Multiply(System.Windows.Vector vector, System.Double scalar) => Windows.UI.Xaml.Vector.Multiply(@vector, @scalar);
        public static System.Windows.Vector op_Multiply(System.Double scalar, System.Windows.Vector vector) => Windows.UI.Xaml.Vector.op_Multiply(@scalar, @vector);
        public static System.Windows.Vector Multiply(System.Double scalar, System.Windows.Vector vector) => Windows.UI.Xaml.Vector.Multiply(@scalar, @vector);
        public static System.Windows.Vector op_Division(System.Windows.Vector vector, System.Double scalar) => Windows.UI.Xaml.Vector.op_Division(@vector, @scalar);
        public static System.Windows.Vector Divide(System.Windows.Vector vector, System.Double scalar) => Windows.UI.Xaml.Vector.Divide(@vector, @scalar);
        public static System.Windows.Vector op_Multiply(System.Windows.Vector vector, System.Windows.Media.Matrix matrix) => Windows.UI.Xaml.Vector.op_Multiply(@vector, @matrix);
        public static System.Windows.Vector Multiply(System.Windows.Vector vector, System.Windows.Media.Matrix matrix) => Windows.UI.Xaml.Vector.Multiply(@vector, @matrix);
        public static System.Double op_Multiply(System.Windows.Vector vector1, System.Windows.Vector vector2) => Windows.UI.Xaml.Vector.op_Multiply(@vector1, @vector2);
        public static System.Double Multiply(System.Windows.Vector vector1, System.Windows.Vector vector2) => Windows.UI.Xaml.Vector.Multiply(@vector1, @vector2);
        public static System.Double Determinant(System.Windows.Vector vector1, System.Windows.Vector vector2) => Windows.UI.Xaml.Vector.Determinant(@vector1, @vector2);
        public static System.Windows.Size op_Explicit(System.Windows.Vector vector) => Windows.UI.Xaml.Vector.op_Explicit(@vector);
        public static System.Windows.Point op_Explicit(System.Windows.Vector vector) => Windows.UI.Xaml.Vector.op_Explicit(@vector);
    }
}