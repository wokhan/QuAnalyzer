namespace System.Windows
{
    using Uno.UI.Generic;

    public class Thickness : Proxy<global::Windows.UI.Xaml.Thickness>
    {
        public System.Double Left
        {
            get => __ProxyValue.Left;
            set => __ProxyValue.Left = value;
        }

        public System.Double Top
        {
            get => __ProxyValue.Top;
            set => __ProxyValue.Top = value;
        }

        public System.Double Right
        {
            get => __ProxyValue.Right;
            set => __ProxyValue.Right = value;
        }

        public System.Double Bottom
        {
            get => __ProxyValue.Bottom;
            set => __ProxyValue.Bottom = value;
        }

        public Thickness(System.Double @uniformLength): base(@uniformLength)
        {
        }

        public Thickness(System.Double @left, System.Double @top, System.Double @right, System.Double @bottom): base(@left, @top, @right, @bottom)
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Boolean Equals(System.Windows.Thickness thickness) => __ProxyValue.Equals(@thickness);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
        public static System.Boolean op_Equality(System.Windows.Thickness t1, System.Windows.Thickness t2) => Windows.UI.Xaml.Thickness.op_Equality(@t1, @t2);
        public static System.Boolean op_Inequality(System.Windows.Thickness t1, System.Windows.Thickness t2) => Windows.UI.Xaml.Thickness.op_Inequality(@t1, @t2);
    }
}