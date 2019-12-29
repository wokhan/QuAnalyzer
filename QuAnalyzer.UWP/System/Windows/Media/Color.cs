namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class Color : Proxy<global::Windows.UI.Xaml.Media.Color>
    {
        public System.Windows.Media.ColorContext ColorContext
        {
            get => __ProxyValue.ColorContext;
        }

        public System.Byte A
        {
            get => __ProxyValue.A;
            set => __ProxyValue.A = value;
        }

        public System.Byte R
        {
            get => __ProxyValue.R;
            set => __ProxyValue.R = value;
        }

        public System.Byte G
        {
            get => __ProxyValue.G;
            set => __ProxyValue.G = value;
        }

        public System.Byte B
        {
            get => __ProxyValue.B;
            set => __ProxyValue.B = value;
        }

        public System.Single ScA
        {
            get => __ProxyValue.ScA;
            set => __ProxyValue.ScA = value;
        }

        public System.Single ScR
        {
            get => __ProxyValue.ScR;
            set => __ProxyValue.ScR = value;
        }

        public System.Single ScG
        {
            get => __ProxyValue.ScG;
            set => __ProxyValue.ScG = value;
        }

        public System.Single ScB
        {
            get => __ProxyValue.ScB;
            set => __ProxyValue.ScB = value;
        }

        public static System.Windows.Media.Color FromAValues(System.Single a, System.Single[] values, System.Uri profileUri) => Windows.UI.Xaml.Media.Color.FromAValues(@a, @values, @profileUri);
        public static System.Windows.Media.Color FromValues(System.Single[] values, System.Uri profileUri) => Windows.UI.Xaml.Media.Color.FromValues(@values, @profileUri);
        public static System.Windows.Media.Color FromScRgb(System.Single a, System.Single r, System.Single g, System.Single b) => Windows.UI.Xaml.Media.Color.FromScRgb(@a, @r, @g, @b);
        public static System.Windows.Media.Color FromArgb(System.Byte a, System.Byte r, System.Byte g, System.Byte b) => Windows.UI.Xaml.Media.Color.FromArgb(@a, @r, @g, @b);
        public static System.Windows.Media.Color FromRgb(System.Byte r, System.Byte g, System.Byte b) => Windows.UI.Xaml.Media.Color.FromRgb(@r, @g, @b);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
        public static System.Boolean AreClose(System.Windows.Media.Color color1, System.Windows.Media.Color color2) => Windows.UI.Xaml.Media.Color.AreClose(@color1, @color2);
        public void Clamp() => __ProxyValue.Clamp();
        public System.Single[] GetNativeColorValues() => __ProxyValue.GetNativeColorValues();
        public static System.Windows.Media.Color op_Addition(System.Windows.Media.Color color1, System.Windows.Media.Color color2) => Windows.UI.Xaml.Media.Color.op_Addition(@color1, @color2);
        public static System.Windows.Media.Color Add(System.Windows.Media.Color color1, System.Windows.Media.Color color2) => Windows.UI.Xaml.Media.Color.Add(@color1, @color2);
        public static System.Windows.Media.Color op_Subtraction(System.Windows.Media.Color color1, System.Windows.Media.Color color2) => Windows.UI.Xaml.Media.Color.op_Subtraction(@color1, @color2);
        public static System.Windows.Media.Color Subtract(System.Windows.Media.Color color1, System.Windows.Media.Color color2) => Windows.UI.Xaml.Media.Color.Subtract(@color1, @color2);
        public static System.Windows.Media.Color op_Multiply(System.Windows.Media.Color color, System.Single coefficient) => Windows.UI.Xaml.Media.Color.op_Multiply(@color, @coefficient);
        public static System.Windows.Media.Color Multiply(System.Windows.Media.Color color, System.Single coefficient) => Windows.UI.Xaml.Media.Color.Multiply(@color, @coefficient);
        public static System.Boolean Equals(System.Windows.Media.Color color1, System.Windows.Media.Color color2) => Windows.UI.Xaml.Media.Color.Equals(@color1, @color2);
        public System.Boolean Equals(System.Windows.Media.Color color) => __ProxyValue.Equals(@color);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public static System.Boolean op_Equality(System.Windows.Media.Color color1, System.Windows.Media.Color color2) => Windows.UI.Xaml.Media.Color.op_Equality(@color1, @color2);
        public static System.Boolean op_Inequality(System.Windows.Media.Color color1, System.Windows.Media.Color color2) => Windows.UI.Xaml.Media.Color.op_Inequality(@color1, @color2);
    }
}