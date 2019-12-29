namespace System.Windows
{
    using Uno.UI.Generic;

    public class Rect : Proxy<global::Windows.UI.Xaml.Rect>
    {
        public static System.Windows.Rect Empty
        {
            get => __ProxyValue.Empty;
        }

        public System.Boolean IsEmpty
        {
            get => __ProxyValue.IsEmpty;
        }

        public System.Windows.Point Location
        {
            get => __ProxyValue.Location;
            set => __ProxyValue.Location = value;
        }

        public System.Windows.Size Size
        {
            get => __ProxyValue.Size;
            set => __ProxyValue.Size = value;
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

        public System.Double Width
        {
            get => __ProxyValue.Width;
            set => __ProxyValue.Width = value;
        }

        public System.Double Height
        {
            get => __ProxyValue.Height;
            set => __ProxyValue.Height = value;
        }

        public System.Double Left
        {
            get => __ProxyValue.Left;
        }

        public System.Double Top
        {
            get => __ProxyValue.Top;
        }

        public System.Double Right
        {
            get => __ProxyValue.Right;
        }

        public System.Double Bottom
        {
            get => __ProxyValue.Bottom;
        }

        public System.Windows.Point TopLeft
        {
            get => __ProxyValue.TopLeft;
        }

        public System.Windows.Point TopRight
        {
            get => __ProxyValue.TopRight;
        }

        public System.Windows.Point BottomLeft
        {
            get => __ProxyValue.BottomLeft;
        }

        public System.Windows.Point BottomRight
        {
            get => __ProxyValue.BottomRight;
        }

        public Rect(System.Windows.Point @location, System.Windows.Size @size): base(@location, @size)
        {
        }

        public Rect(System.Double @x, System.Double @y, System.Double @width, System.Double @height): base(@x, @y, @width, @height)
        {
        }

        public Rect(System.Windows.Point @point1, System.Windows.Point @point2): base(@point1, @point2)
        {
        }

        public Rect(System.Windows.Point @point, System.Windows.Vector @vector): base(@point, @vector)
        {
        }

        public Rect(System.Windows.Size @size): base(@size)
        {
        }

        public static System.Boolean op_Equality(System.Windows.Rect rect1, System.Windows.Rect rect2) => Windows.UI.Xaml.Rect.op_Equality(@rect1, @rect2);
        public static System.Boolean op_Inequality(System.Windows.Rect rect1, System.Windows.Rect rect2) => Windows.UI.Xaml.Rect.op_Inequality(@rect1, @rect2);
        public static System.Boolean Equals(System.Windows.Rect rect1, System.Windows.Rect rect2) => Windows.UI.Xaml.Rect.Equals(@rect1, @rect2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Boolean Equals(System.Windows.Rect value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Windows.Rect Parse(System.String source) => Windows.UI.Xaml.Rect.Parse(@source);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
        public System.Boolean Contains(System.Windows.Point point) => __ProxyValue.Contains(@point);
        public System.Boolean Contains(System.Double x, System.Double y) => __ProxyValue.Contains(@x, @y);
        public System.Boolean Contains(System.Windows.Rect rect) => __ProxyValue.Contains(@rect);
        public System.Boolean IntersectsWith(System.Windows.Rect rect) => __ProxyValue.IntersectsWith(@rect);
        public void Intersect(System.Windows.Rect rect) => __ProxyValue.Intersect(@rect);
        public static System.Windows.Rect Intersect(System.Windows.Rect rect1, System.Windows.Rect rect2) => Windows.UI.Xaml.Rect.Intersect(@rect1, @rect2);
        public void Union(System.Windows.Rect rect) => __ProxyValue.Union(@rect);
        public static System.Windows.Rect Union(System.Windows.Rect rect1, System.Windows.Rect rect2) => Windows.UI.Xaml.Rect.Union(@rect1, @rect2);
        public void Union(System.Windows.Point point) => __ProxyValue.Union(@point);
        public static System.Windows.Rect Union(System.Windows.Rect rect, System.Windows.Point point) => Windows.UI.Xaml.Rect.Union(@rect, @point);
        public void Offset(System.Windows.Vector offsetVector) => __ProxyValue.Offset(@offsetVector);
        public void Offset(System.Double offsetX, System.Double offsetY) => __ProxyValue.Offset(@offsetX, @offsetY);
        public static System.Windows.Rect Offset(System.Windows.Rect rect, System.Windows.Vector offsetVector) => Windows.UI.Xaml.Rect.Offset(@rect, @offsetVector);
        public static System.Windows.Rect Offset(System.Windows.Rect rect, System.Double offsetX, System.Double offsetY) => Windows.UI.Xaml.Rect.Offset(@rect, @offsetX, @offsetY);
        public void Inflate(System.Windows.Size size) => __ProxyValue.Inflate(@size);
        public void Inflate(System.Double width, System.Double height) => __ProxyValue.Inflate(@width, @height);
        public static System.Windows.Rect Inflate(System.Windows.Rect rect, System.Windows.Size size) => Windows.UI.Xaml.Rect.Inflate(@rect, @size);
        public static System.Windows.Rect Inflate(System.Windows.Rect rect, System.Double width, System.Double height) => Windows.UI.Xaml.Rect.Inflate(@rect, @width, @height);
        public static System.Windows.Rect Transform(System.Windows.Rect rect, System.Windows.Media.Matrix matrix) => Windows.UI.Xaml.Rect.Transform(@rect, @matrix);
        public void Transform(System.Windows.Media.Matrix matrix) => __ProxyValue.Transform(@matrix);
        public void Scale(System.Double scaleX, System.Double scaleY) => __ProxyValue.Scale(@scaleX, @scaleY);
    }
}