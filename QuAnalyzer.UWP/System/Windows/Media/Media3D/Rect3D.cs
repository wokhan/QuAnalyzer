namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class Rect3D : Proxy<global::Windows.UI.Xaml.Media.Media3D.Rect3D>
    {
        public static System.Windows.Media.Media3D.Rect3D Empty
        {
            get => __ProxyValue.Empty;
        }

        public System.Boolean IsEmpty
        {
            get => __ProxyValue.IsEmpty;
        }

        public System.Windows.Media.Media3D.Point3D Location
        {
            get => __ProxyValue.Location;
            set => __ProxyValue.Location = value;
        }

        public System.Windows.Media.Media3D.Size3D Size
        {
            get => __ProxyValue.Size;
            set => __ProxyValue.Size = value;
        }

        public System.Double SizeX
        {
            get => __ProxyValue.SizeX;
            set => __ProxyValue.SizeX = value;
        }

        public System.Double SizeY
        {
            get => __ProxyValue.SizeY;
            set => __ProxyValue.SizeY = value;
        }

        public System.Double SizeZ
        {
            get => __ProxyValue.SizeZ;
            set => __ProxyValue.SizeZ = value;
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

        public Rect3D(System.Windows.Media.Media3D.Point3D @location, System.Windows.Media.Media3D.Size3D @size): base(@location, @size)
        {
        }

        public Rect3D(System.Double @x, System.Double @y, System.Double @z, System.Double @sizeX, System.Double @sizeY, System.Double @sizeZ): base(@x, @y, @z, @sizeX, @sizeY, @sizeZ)
        {
        }

        public System.Boolean Contains(System.Windows.Media.Media3D.Point3D point) => __ProxyValue.Contains(@point);
        public System.Boolean Contains(System.Double x, System.Double y, System.Double z) => __ProxyValue.Contains(@x, @y, @z);
        public System.Boolean Contains(System.Windows.Media.Media3D.Rect3D rect) => __ProxyValue.Contains(@rect);
        public System.Boolean IntersectsWith(System.Windows.Media.Media3D.Rect3D rect) => __ProxyValue.IntersectsWith(@rect);
        public void Intersect(System.Windows.Media.Media3D.Rect3D rect) => __ProxyValue.Intersect(@rect);
        public static System.Windows.Media.Media3D.Rect3D Intersect(System.Windows.Media.Media3D.Rect3D rect1, System.Windows.Media.Media3D.Rect3D rect2) => Windows.UI.Xaml.Media.Media3D.Rect3D.Intersect(@rect1, @rect2);
        public void Union(System.Windows.Media.Media3D.Rect3D rect) => __ProxyValue.Union(@rect);
        public static System.Windows.Media.Media3D.Rect3D Union(System.Windows.Media.Media3D.Rect3D rect1, System.Windows.Media.Media3D.Rect3D rect2) => Windows.UI.Xaml.Media.Media3D.Rect3D.Union(@rect1, @rect2);
        public void Union(System.Windows.Media.Media3D.Point3D point) => __ProxyValue.Union(@point);
        public static System.Windows.Media.Media3D.Rect3D Union(System.Windows.Media.Media3D.Rect3D rect, System.Windows.Media.Media3D.Point3D point) => Windows.UI.Xaml.Media.Media3D.Rect3D.Union(@rect, @point);
        public void Offset(System.Windows.Media.Media3D.Vector3D offsetVector) => __ProxyValue.Offset(@offsetVector);
        public void Offset(System.Double offsetX, System.Double offsetY, System.Double offsetZ) => __ProxyValue.Offset(@offsetX, @offsetY, @offsetZ);
        public static System.Windows.Media.Media3D.Rect3D Offset(System.Windows.Media.Media3D.Rect3D rect, System.Windows.Media.Media3D.Vector3D offsetVector) => Windows.UI.Xaml.Media.Media3D.Rect3D.Offset(@rect, @offsetVector);
        public static System.Windows.Media.Media3D.Rect3D Offset(System.Windows.Media.Media3D.Rect3D rect, System.Double offsetX, System.Double offsetY, System.Double offsetZ) => Windows.UI.Xaml.Media.Media3D.Rect3D.Offset(@rect, @offsetX, @offsetY, @offsetZ);
        public static System.Boolean op_Equality(System.Windows.Media.Media3D.Rect3D rect1, System.Windows.Media.Media3D.Rect3D rect2) => Windows.UI.Xaml.Media.Media3D.Rect3D.op_Equality(@rect1, @rect2);
        public static System.Boolean op_Inequality(System.Windows.Media.Media3D.Rect3D rect1, System.Windows.Media.Media3D.Rect3D rect2) => Windows.UI.Xaml.Media.Media3D.Rect3D.op_Inequality(@rect1, @rect2);
        public static System.Boolean Equals(System.Windows.Media.Media3D.Rect3D rect1, System.Windows.Media.Media3D.Rect3D rect2) => Windows.UI.Xaml.Media.Media3D.Rect3D.Equals(@rect1, @rect2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Boolean Equals(System.Windows.Media.Media3D.Rect3D value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Windows.Media.Media3D.Rect3D Parse(System.String source) => Windows.UI.Xaml.Media.Media3D.Rect3D.Parse(@source);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
    }
}