namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class Quaternion : Proxy<global::Windows.UI.Xaml.Media.Media3D.Quaternion>
    {
        public static System.Windows.Media.Media3D.Quaternion Identity
        {
            get => __ProxyValue.Identity;
        }

        public System.Windows.Media.Media3D.Vector3D Axis
        {
            get => __ProxyValue.Axis;
        }

        public System.Double Angle
        {
            get => __ProxyValue.Angle;
        }

        public System.Boolean IsNormalized
        {
            get => __ProxyValue.IsNormalized;
        }

        public System.Boolean IsIdentity
        {
            get => __ProxyValue.IsIdentity;
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

        public System.Double W
        {
            get => __ProxyValue.W;
            set => __ProxyValue.W = value;
        }

        public Quaternion(System.Double @x, System.Double @y, System.Double @z, System.Double @w): base(@x, @y, @z, @w)
        {
        }

        public Quaternion(System.Windows.Media.Media3D.Vector3D @axisOfRotation, System.Double @angleInDegrees): base(@axisOfRotation, @angleInDegrees)
        {
        }

        public void Conjugate() => __ProxyValue.Conjugate();
        public void Invert() => __ProxyValue.Invert();
        public void Normalize() => __ProxyValue.Normalize();
        public static System.Windows.Media.Media3D.Quaternion op_Addition(System.Windows.Media.Media3D.Quaternion left, System.Windows.Media.Media3D.Quaternion right) => Windows.UI.Xaml.Media.Media3D.Quaternion.op_Addition(@left, @right);
        public static System.Windows.Media.Media3D.Quaternion Add(System.Windows.Media.Media3D.Quaternion left, System.Windows.Media.Media3D.Quaternion right) => Windows.UI.Xaml.Media.Media3D.Quaternion.Add(@left, @right);
        public static System.Windows.Media.Media3D.Quaternion op_Subtraction(System.Windows.Media.Media3D.Quaternion left, System.Windows.Media.Media3D.Quaternion right) => Windows.UI.Xaml.Media.Media3D.Quaternion.op_Subtraction(@left, @right);
        public static System.Windows.Media.Media3D.Quaternion Subtract(System.Windows.Media.Media3D.Quaternion left, System.Windows.Media.Media3D.Quaternion right) => Windows.UI.Xaml.Media.Media3D.Quaternion.Subtract(@left, @right);
        public static System.Windows.Media.Media3D.Quaternion op_Multiply(System.Windows.Media.Media3D.Quaternion left, System.Windows.Media.Media3D.Quaternion right) => Windows.UI.Xaml.Media.Media3D.Quaternion.op_Multiply(@left, @right);
        public static System.Windows.Media.Media3D.Quaternion Multiply(System.Windows.Media.Media3D.Quaternion left, System.Windows.Media.Media3D.Quaternion right) => Windows.UI.Xaml.Media.Media3D.Quaternion.Multiply(@left, @right);
        public static System.Windows.Media.Media3D.Quaternion Slerp(System.Windows.Media.Media3D.Quaternion from, System.Windows.Media.Media3D.Quaternion to, System.Double t) => Windows.UI.Xaml.Media.Media3D.Quaternion.Slerp(@from, @to, @t);
        public static System.Windows.Media.Media3D.Quaternion Slerp(System.Windows.Media.Media3D.Quaternion from, System.Windows.Media.Media3D.Quaternion to, System.Double t, System.Boolean useShortestPath) => Windows.UI.Xaml.Media.Media3D.Quaternion.Slerp(@from, @to, @t, @useShortestPath);
        public static System.Boolean op_Equality(System.Windows.Media.Media3D.Quaternion quaternion1, System.Windows.Media.Media3D.Quaternion quaternion2) => Windows.UI.Xaml.Media.Media3D.Quaternion.op_Equality(@quaternion1, @quaternion2);
        public static System.Boolean op_Inequality(System.Windows.Media.Media3D.Quaternion quaternion1, System.Windows.Media.Media3D.Quaternion quaternion2) => Windows.UI.Xaml.Media.Media3D.Quaternion.op_Inequality(@quaternion1, @quaternion2);
        public static System.Boolean Equals(System.Windows.Media.Media3D.Quaternion quaternion1, System.Windows.Media.Media3D.Quaternion quaternion2) => Windows.UI.Xaml.Media.Media3D.Quaternion.Equals(@quaternion1, @quaternion2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Boolean Equals(System.Windows.Media.Media3D.Quaternion value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Windows.Media.Media3D.Quaternion Parse(System.String source) => Windows.UI.Xaml.Media.Media3D.Quaternion.Parse(@source);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
    }
}