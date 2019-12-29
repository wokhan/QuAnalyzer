namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class Size3D : Proxy<global::Windows.UI.Xaml.Media.Media3D.Size3D>
    {
        public static System.Windows.Media.Media3D.Size3D Empty
        {
            get => __ProxyValue.Empty;
        }

        public System.Boolean IsEmpty
        {
            get => __ProxyValue.IsEmpty;
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

        public Size3D(System.Double @x, System.Double @y, System.Double @z): base(@x, @y, @z)
        {
        }

        public static System.Windows.Media.Media3D.Vector3D op_Explicit(System.Windows.Media.Media3D.Size3D size) => Windows.UI.Xaml.Media.Media3D.Size3D.op_Explicit(@size);
        public static System.Windows.Media.Media3D.Point3D op_Explicit(System.Windows.Media.Media3D.Size3D size) => Windows.UI.Xaml.Media.Media3D.Size3D.op_Explicit(@size);
        public static System.Boolean op_Equality(System.Windows.Media.Media3D.Size3D size1, System.Windows.Media.Media3D.Size3D size2) => Windows.UI.Xaml.Media.Media3D.Size3D.op_Equality(@size1, @size2);
        public static System.Boolean op_Inequality(System.Windows.Media.Media3D.Size3D size1, System.Windows.Media.Media3D.Size3D size2) => Windows.UI.Xaml.Media.Media3D.Size3D.op_Inequality(@size1, @size2);
        public static System.Boolean Equals(System.Windows.Media.Media3D.Size3D size1, System.Windows.Media.Media3D.Size3D size2) => Windows.UI.Xaml.Media.Media3D.Size3D.Equals(@size1, @size2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Boolean Equals(System.Windows.Media.Media3D.Size3D value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Windows.Media.Media3D.Size3D Parse(System.String source) => Windows.UI.Xaml.Media.Media3D.Size3D.Parse(@source);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
    }
}