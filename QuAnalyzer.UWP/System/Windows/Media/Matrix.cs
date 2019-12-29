namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class Matrix : Proxy<global::Windows.UI.Xaml.Media.Matrix>
    {
        public static System.Windows.Media.Matrix Identity
        {
            get => __ProxyValue.Identity;
        }

        public System.Boolean IsIdentity
        {
            get => __ProxyValue.IsIdentity;
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

        public Matrix(System.Double @m11, System.Double @m12, System.Double @m21, System.Double @m22, System.Double @offsetX, System.Double @offsetY): base(@m11, @m12, @m21, @m22, @offsetX, @offsetY)
        {
        }

        public void SetIdentity() => __ProxyValue.SetIdentity();
        public static System.Windows.Media.Matrix op_Multiply(System.Windows.Media.Matrix trans1, System.Windows.Media.Matrix trans2) => Windows.UI.Xaml.Media.Matrix.op_Multiply(@trans1, @trans2);
        public static System.Windows.Media.Matrix Multiply(System.Windows.Media.Matrix trans1, System.Windows.Media.Matrix trans2) => Windows.UI.Xaml.Media.Matrix.Multiply(@trans1, @trans2);
        public void Append(System.Windows.Media.Matrix matrix) => __ProxyValue.Append(@matrix);
        public void Prepend(System.Windows.Media.Matrix matrix) => __ProxyValue.Prepend(@matrix);
        public void Rotate(System.Double angle) => __ProxyValue.Rotate(@angle);
        public void RotatePrepend(System.Double angle) => __ProxyValue.RotatePrepend(@angle);
        public void RotateAt(System.Double angle, System.Double centerX, System.Double centerY) => __ProxyValue.RotateAt(@angle, @centerX, @centerY);
        public void RotateAtPrepend(System.Double angle, System.Double centerX, System.Double centerY) => __ProxyValue.RotateAtPrepend(@angle, @centerX, @centerY);
        public void Scale(System.Double scaleX, System.Double scaleY) => __ProxyValue.Scale(@scaleX, @scaleY);
        public void ScalePrepend(System.Double scaleX, System.Double scaleY) => __ProxyValue.ScalePrepend(@scaleX, @scaleY);
        public void ScaleAt(System.Double scaleX, System.Double scaleY, System.Double centerX, System.Double centerY) => __ProxyValue.ScaleAt(@scaleX, @scaleY, @centerX, @centerY);
        public void ScaleAtPrepend(System.Double scaleX, System.Double scaleY, System.Double centerX, System.Double centerY) => __ProxyValue.ScaleAtPrepend(@scaleX, @scaleY, @centerX, @centerY);
        public void Skew(System.Double skewX, System.Double skewY) => __ProxyValue.Skew(@skewX, @skewY);
        public void SkewPrepend(System.Double skewX, System.Double skewY) => __ProxyValue.SkewPrepend(@skewX, @skewY);
        public void Translate(System.Double offsetX, System.Double offsetY) => __ProxyValue.Translate(@offsetX, @offsetY);
        public void TranslatePrepend(System.Double offsetX, System.Double offsetY) => __ProxyValue.TranslatePrepend(@offsetX, @offsetY);
        public System.Windows.Point Transform(System.Windows.Point point) => __ProxyValue.Transform(@point);
        public void Transform(System.Windows.Point[] points) => __ProxyValue.Transform(@points);
        public System.Windows.Vector Transform(System.Windows.Vector vector) => __ProxyValue.Transform(@vector);
        public void Transform(System.Windows.Vector[] vectors) => __ProxyValue.Transform(@vectors);
        public void Invert() => __ProxyValue.Invert();
        public static System.Boolean op_Equality(System.Windows.Media.Matrix matrix1, System.Windows.Media.Matrix matrix2) => Windows.UI.Xaml.Media.Matrix.op_Equality(@matrix1, @matrix2);
        public static System.Boolean op_Inequality(System.Windows.Media.Matrix matrix1, System.Windows.Media.Matrix matrix2) => Windows.UI.Xaml.Media.Matrix.op_Inequality(@matrix1, @matrix2);
        public static System.Boolean Equals(System.Windows.Media.Matrix matrix1, System.Windows.Media.Matrix matrix2) => Windows.UI.Xaml.Media.Matrix.Equals(@matrix1, @matrix2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Boolean Equals(System.Windows.Media.Matrix value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Windows.Media.Matrix Parse(System.String source) => Windows.UI.Xaml.Media.Matrix.Parse(@source);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
    }
}