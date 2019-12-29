namespace System.Windows
{
    using Uno.UI.Generic;

    public class Size : Proxy<global::Windows.UI.Xaml.Size>
    {
        public static System.Windows.Size Empty
        {
            get => __ProxyValue.Empty;
        }

        public System.Boolean IsEmpty
        {
            get => __ProxyValue.IsEmpty;
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

        public Size(System.Double @width, System.Double @height): base(@width, @height)
        {
        }

        public static System.Boolean op_Equality(System.Windows.Size size1, System.Windows.Size size2) => Windows.UI.Xaml.Size.op_Equality(@size1, @size2);
        public static System.Boolean op_Inequality(System.Windows.Size size1, System.Windows.Size size2) => Windows.UI.Xaml.Size.op_Inequality(@size1, @size2);
        public static System.Boolean Equals(System.Windows.Size size1, System.Windows.Size size2) => Windows.UI.Xaml.Size.Equals(@size1, @size2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Boolean Equals(System.Windows.Size value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Windows.Size Parse(System.String source) => Windows.UI.Xaml.Size.Parse(@source);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
        public static System.Windows.Vector op_Explicit(System.Windows.Size size) => Windows.UI.Xaml.Size.op_Explicit(@size);
        public static System.Windows.Point op_Explicit(System.Windows.Size size) => Windows.UI.Xaml.Size.op_Explicit(@size);
    }
}