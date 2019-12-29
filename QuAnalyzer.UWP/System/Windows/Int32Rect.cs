namespace System.Windows
{
    using Uno.UI.Generic;

    public class Int32Rect : Proxy<global::Windows.UI.Xaml.Int32Rect>
    {
        public System.Int32 X
        {
            get => __ProxyValue.X;
            set => __ProxyValue.X = value;
        }

        public System.Int32 Y
        {
            get => __ProxyValue.Y;
            set => __ProxyValue.Y = value;
        }

        public System.Int32 Width
        {
            get => __ProxyValue.Width;
            set => __ProxyValue.Width = value;
        }

        public System.Int32 Height
        {
            get => __ProxyValue.Height;
            set => __ProxyValue.Height = value;
        }

        public static System.Windows.Int32Rect Empty
        {
            get => __ProxyValue.Empty;
        }

        public System.Boolean IsEmpty
        {
            get => __ProxyValue.IsEmpty;
        }

        public System.Boolean HasArea
        {
            get => __ProxyValue.HasArea;
        }

        public Int32Rect(System.Int32 @x, System.Int32 @y, System.Int32 @width, System.Int32 @height): base(@x, @y, @width, @height)
        {
        }

        public static System.Boolean op_Equality(System.Windows.Int32Rect int32Rect1, System.Windows.Int32Rect int32Rect2) => Windows.UI.Xaml.Int32Rect.op_Equality(@int32Rect1, @int32Rect2);
        public static System.Boolean op_Inequality(System.Windows.Int32Rect int32Rect1, System.Windows.Int32Rect int32Rect2) => Windows.UI.Xaml.Int32Rect.op_Inequality(@int32Rect1, @int32Rect2);
        public static System.Boolean Equals(System.Windows.Int32Rect int32Rect1, System.Windows.Int32Rect int32Rect2) => Windows.UI.Xaml.Int32Rect.Equals(@int32Rect1, @int32Rect2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Boolean Equals(System.Windows.Int32Rect value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Windows.Int32Rect Parse(System.String source) => Windows.UI.Xaml.Int32Rect.Parse(@source);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
    }
}