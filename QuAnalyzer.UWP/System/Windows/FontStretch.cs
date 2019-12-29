namespace System.Windows
{
    using Uno.UI.Generic;

    public class FontStretch : Proxy<global::Windows.UI.Xaml.FontStretch>
    {
        public static System.Windows.FontStretch FromOpenTypeStretch(System.Int32 stretchValue) => Windows.UI.Xaml.FontStretch.FromOpenTypeStretch(@stretchValue);
        public System.Int32 ToOpenTypeStretch() => __ProxyValue.ToOpenTypeStretch();
        public static System.Int32 Compare(System.Windows.FontStretch left, System.Windows.FontStretch right) => Windows.UI.Xaml.FontStretch.Compare(@left, @right);
        public static System.Boolean op_LessThan(System.Windows.FontStretch left, System.Windows.FontStretch right) => Windows.UI.Xaml.FontStretch.op_LessThan(@left, @right);
        public static System.Boolean op_LessThanOrEqual(System.Windows.FontStretch left, System.Windows.FontStretch right) => Windows.UI.Xaml.FontStretch.op_LessThanOrEqual(@left, @right);
        public static System.Boolean op_GreaterThan(System.Windows.FontStretch left, System.Windows.FontStretch right) => Windows.UI.Xaml.FontStretch.op_GreaterThan(@left, @right);
        public static System.Boolean op_GreaterThanOrEqual(System.Windows.FontStretch left, System.Windows.FontStretch right) => Windows.UI.Xaml.FontStretch.op_GreaterThanOrEqual(@left, @right);
        public static System.Boolean op_Equality(System.Windows.FontStretch left, System.Windows.FontStretch right) => Windows.UI.Xaml.FontStretch.op_Equality(@left, @right);
        public static System.Boolean op_Inequality(System.Windows.FontStretch left, System.Windows.FontStretch right) => Windows.UI.Xaml.FontStretch.op_Inequality(@left, @right);
        public System.Boolean Equals(System.Windows.FontStretch obj) => __ProxyValue.Equals(@obj);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}