namespace System.Windows
{
    using Uno.UI.Generic;

    public class Point : Proxy<global::Windows.UI.Xaml.Point>
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

        public Point(System.Double @x, System.Double @y): base(@x, @y)
        {
        }

        public static System.Boolean op_Equality(System.Windows.Point point1, System.Windows.Point point2) => Windows.UI.Xaml.Point.op_Equality(@point1, @point2);
        public static System.Boolean op_Inequality(System.Windows.Point point1, System.Windows.Point point2) => Windows.UI.Xaml.Point.op_Inequality(@point1, @point2);
        public static System.Boolean Equals(System.Windows.Point point1, System.Windows.Point point2) => Windows.UI.Xaml.Point.Equals(@point1, @point2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Boolean Equals(System.Windows.Point value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Windows.Point Parse(System.String source) => Windows.UI.Xaml.Point.Parse(@source);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
        public void Offset(System.Double offsetX, System.Double offsetY) => __ProxyValue.Offset(@offsetX, @offsetY);
        public static System.Windows.Point op_Addition(System.Windows.Point point, System.Windows.Vector vector) => Windows.UI.Xaml.Point.op_Addition(@point, @vector);
        public static System.Windows.Point Add(System.Windows.Point point, System.Windows.Vector vector) => Windows.UI.Xaml.Point.Add(@point, @vector);
        public static System.Windows.Point op_Subtraction(System.Windows.Point point, System.Windows.Vector vector) => Windows.UI.Xaml.Point.op_Subtraction(@point, @vector);
        public static System.Windows.Point Subtract(System.Windows.Point point, System.Windows.Vector vector) => Windows.UI.Xaml.Point.Subtract(@point, @vector);
        public static System.Windows.Vector op_Subtraction(System.Windows.Point point1, System.Windows.Point point2) => Windows.UI.Xaml.Point.op_Subtraction(@point1, @point2);
        public static System.Windows.Vector Subtract(System.Windows.Point point1, System.Windows.Point point2) => Windows.UI.Xaml.Point.Subtract(@point1, @point2);
        public static System.Windows.Point op_Multiply(System.Windows.Point point, System.Windows.Media.Matrix matrix) => Windows.UI.Xaml.Point.op_Multiply(@point, @matrix);
        public static System.Windows.Point Multiply(System.Windows.Point point, System.Windows.Media.Matrix matrix) => Windows.UI.Xaml.Point.Multiply(@point, @matrix);
        public static System.Windows.Size op_Explicit(System.Windows.Point point) => Windows.UI.Xaml.Point.op_Explicit(@point);
        public static System.Windows.Vector op_Explicit(System.Windows.Point point) => Windows.UI.Xaml.Point.op_Explicit(@point);
    }
}