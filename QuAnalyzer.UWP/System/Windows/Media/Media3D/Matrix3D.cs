namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class Matrix3D : Proxy<global::Windows.UI.Xaml.Media.Media3D.Matrix3D>
    {
        public static System.Windows.Media.Media3D.Matrix3D Identity
        {
            get => __ProxyValue.Identity;
        }

        public System.Boolean IsIdentity
        {
            get => __ProxyValue.IsIdentity;
        }

        public System.Boolean IsAffine
        {
            get => __ProxyValue.IsAffine;
        }

        public System.Double Determinant
        {
            get => __ProxyValue.Determinant;
        }

        public System.Boolean HasInverse
        {
            get => __ProxyValue.HasInverse;
        }

        public System.Double M11
        {
            get => __ProxyValue.M11;
            set => __ProxyValue.M11 = value;
        }

        public System.Double M12
        {
            get => __ProxyValue.M12;
            set => __ProxyValue.M12 = value;
        }

        public System.Double M13
        {
            get => __ProxyValue.M13;
            set => __ProxyValue.M13 = value;
        }

        public System.Double M14
        {
            get => __ProxyValue.M14;
            set => __ProxyValue.M14 = value;
        }

        public System.Double M21
        {
            get => __ProxyValue.M21;
            set => __ProxyValue.M21 = value;
        }

        public System.Double M22
        {
            get => __ProxyValue.M22;
            set => __ProxyValue.M22 = value;
        }

        public System.Double M23
        {
            get => __ProxyValue.M23;
            set => __ProxyValue.M23 = value;
        }

        public System.Double M24
        {
            get => __ProxyValue.M24;
            set => __ProxyValue.M24 = value;
        }

        public System.Double M31
        {
            get => __ProxyValue.M31;
            set => __ProxyValue.M31 = value;
        }

        public System.Double M32
        {
            get => __ProxyValue.M32;
            set => __ProxyValue.M32 = value;
        }

        public System.Double M33
        {
            get => __ProxyValue.M33;
            set => __ProxyValue.M33 = value;
        }

        public System.Double M34
        {
            get => __ProxyValue.M34;
            set => __ProxyValue.M34 = value;
        }

        public System.Double OffsetX
        {
            get => __ProxyValue.OffsetX;
            set => __ProxyValue.OffsetX = value;
        }

        public System.Double OffsetY
        {
            get => __ProxyValue.OffsetY;
            set => __ProxyValue.OffsetY = value;
        }

        public System.Double OffsetZ
        {
            get => __ProxyValue.OffsetZ;
            set => __ProxyValue.OffsetZ = value;
        }

        public System.Double M44
        {
            get => __ProxyValue.M44;
            set => __ProxyValue.M44 = value;
        }

        public Matrix3D(System.Double @m11, System.Double @m12, System.Double @m13, System.Double @m14, System.Double @m21, System.Double @m22, System.Double @m23, System.Double @m24, System.Double @m31, System.Double @m32, System.Double @m33, System.Double @m34, System.Double @offsetX, System.Double @offsetY, System.Double @offsetZ, System.Double @m44): base(@m11, @m12, @m13, @m14, @m21, @m22, @m23, @m24, @m31, @m32, @m33, @m34, @offsetX, @offsetY, @offsetZ, @m44)
        {
        }

        public void SetIdentity() => __ProxyValue.SetIdentity();
        public void Prepend(System.Windows.Media.Media3D.Matrix3D matrix) => __ProxyValue.Prepend(@matrix);
        public void Append(System.Windows.Media.Media3D.Matrix3D matrix) => __ProxyValue.Append(@matrix);
        public void Rotate(System.Windows.Media.Media3D.Quaternion quaternion) => __ProxyValue.Rotate(@quaternion);
        public void RotatePrepend(System.Windows.Media.Media3D.Quaternion quaternion) => __ProxyValue.RotatePrepend(@quaternion);
        public void RotateAt(System.Windows.Media.Media3D.Quaternion quaternion, System.Windows.Media.Media3D.Point3D center) => __ProxyValue.RotateAt(@quaternion, @center);
        public void RotateAtPrepend(System.Windows.Media.Media3D.Quaternion quaternion, System.Windows.Media.Media3D.Point3D center) => __ProxyValue.RotateAtPrepend(@quaternion, @center);
        public void Scale(System.Windows.Media.Media3D.Vector3D scale) => __ProxyValue.Scale(@scale);
        public void ScalePrepend(System.Windows.Media.Media3D.Vector3D scale) => __ProxyValue.ScalePrepend(@scale);
        public void ScaleAt(System.Windows.Media.Media3D.Vector3D scale, System.Windows.Media.Media3D.Point3D center) => __ProxyValue.ScaleAt(@scale, @center);
        public void ScaleAtPrepend(System.Windows.Media.Media3D.Vector3D scale, System.Windows.Media.Media3D.Point3D center) => __ProxyValue.ScaleAtPrepend(@scale, @center);
        public void Translate(System.Windows.Media.Media3D.Vector3D offset) => __ProxyValue.Translate(@offset);
        public void TranslatePrepend(System.Windows.Media.Media3D.Vector3D offset) => __ProxyValue.TranslatePrepend(@offset);
        public static System.Windows.Media.Media3D.Matrix3D op_Multiply(System.Windows.Media.Media3D.Matrix3D matrix1, System.Windows.Media.Media3D.Matrix3D matrix2) => Windows.UI.Xaml.Media.Media3D.Matrix3D.op_Multiply(@matrix1, @matrix2);
        public static System.Windows.Media.Media3D.Matrix3D Multiply(System.Windows.Media.Media3D.Matrix3D matrix1, System.Windows.Media.Media3D.Matrix3D matrix2) => Windows.UI.Xaml.Media.Media3D.Matrix3D.Multiply(@matrix1, @matrix2);
        public System.Windows.Media.Media3D.Point3D Transform(System.Windows.Media.Media3D.Point3D point) => __ProxyValue.Transform(@point);
        public void Transform(System.Windows.Media.Media3D.Point3D[] points) => __ProxyValue.Transform(@points);
        public System.Windows.Media.Media3D.Point4D Transform(System.Windows.Media.Media3D.Point4D point) => __ProxyValue.Transform(@point);
        public void Transform(System.Windows.Media.Media3D.Point4D[] points) => __ProxyValue.Transform(@points);
        public System.Windows.Media.Media3D.Vector3D Transform(System.Windows.Media.Media3D.Vector3D vector) => __ProxyValue.Transform(@vector);
        public void Transform(System.Windows.Media.Media3D.Vector3D[] vectors) => __ProxyValue.Transform(@vectors);
        public void Invert() => __ProxyValue.Invert();
        public static System.Boolean op_Equality(System.Windows.Media.Media3D.Matrix3D matrix1, System.Windows.Media.Media3D.Matrix3D matrix2) => Windows.UI.Xaml.Media.Media3D.Matrix3D.op_Equality(@matrix1, @matrix2);
        public static System.Boolean op_Inequality(System.Windows.Media.Media3D.Matrix3D matrix1, System.Windows.Media.Media3D.Matrix3D matrix2) => Windows.UI.Xaml.Media.Media3D.Matrix3D.op_Inequality(@matrix1, @matrix2);
        public static System.Boolean Equals(System.Windows.Media.Media3D.Matrix3D matrix1, System.Windows.Media.Media3D.Matrix3D matrix2) => Windows.UI.Xaml.Media.Media3D.Matrix3D.Equals(@matrix1, @matrix2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Boolean Equals(System.Windows.Media.Media3D.Matrix3D value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Windows.Media.Media3D.Matrix3D Parse(System.String source) => Windows.UI.Xaml.Media.Media3D.Matrix3D.Parse(@source);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
    }
}