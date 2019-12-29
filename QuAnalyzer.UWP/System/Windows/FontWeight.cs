namespace System.Windows
{
    using Uno.UI.Generic;

    public class FontWeight : Proxy<global::Windows.UI.Xaml.FontWeight>
    {
        public static System.Windows.FontWeight FromOpenTypeWeight(System.Int32 weightValue) => Windows.UI.Xaml.FontWeight.FromOpenTypeWeight(@weightValue);
        public System.Int32 ToOpenTypeWeight() => __ProxyValue.ToOpenTypeWeight();
        public static System.Int32 Compare(System.Windows.FontWeight left, System.Windows.FontWeight right) => Windows.UI.Xaml.FontWeight.Compare(@left, @right);
        public static System.Boolean op_LessThan(System.Windows.FontWeight left, System.Windows.FontWeight right) => Windows.UI.Xaml.FontWeight.op_LessThan(@left, @right);
        public static System.Boolean op_LessThanOrEqual(System.Windows.FontWeight left, System.Windows.FontWeight right) => Windows.UI.Xaml.FontWeight.op_LessThanOrEqual(@left, @right);
        public static System.Boolean op_GreaterThan(System.Windows.FontWeight left, System.Windows.FontWeight right) => Windows.UI.Xaml.FontWeight.op_GreaterThan(@left, @right);
        public static System.Boolean op_GreaterThanOrEqual(System.Windows.FontWeight left, System.Windows.FontWeight right) => Windows.UI.Xaml.FontWeight.op_GreaterThanOrEqual(@left, @right);
        public static System.Boolean op_Equality(System.Windows.FontWeight left, System.Windows.FontWeight right) => Windows.UI.Xaml.FontWeight.op_Equality(@left, @right);
        public static System.Boolean op_Inequality(System.Windows.FontWeight left, System.Windows.FontWeight right) => Windows.UI.Xaml.FontWeight.op_Inequality(@left, @right);
        public System.Boolean Equals(System.Windows.FontWeight obj) => __ProxyValue.Equals(@obj);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}