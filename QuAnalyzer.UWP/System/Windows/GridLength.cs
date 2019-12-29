namespace System.Windows
{
    using Uno.UI.Generic;

    public class GridLength : Proxy<global::Windows.UI.Xaml.GridLength>
    {
        public System.Boolean IsAbsolute
        {
            get => __ProxyValue.IsAbsolute;
        }

        public System.Boolean IsAuto
        {
            get => __ProxyValue.IsAuto;
        }

        public System.Boolean IsStar
        {
            get => __ProxyValue.IsStar;
        }

        public System.Double Value
        {
            get => __ProxyValue.Value;
        }

        public System.Windows.GridUnitType GridUnitType
        {
            get => __ProxyValue.GridUnitType;
        }

        public static System.Windows.GridLength Auto
        {
            get => __ProxyValue.Auto;
        }

        public GridLength(System.Double @pixels): base(@pixels)
        {
        }

        public GridLength(System.Double @value, System.Windows.GridUnitType @type): base(@value, @type)
        {
        }

        public static System.Boolean op_Equality(System.Windows.GridLength gl1, System.Windows.GridLength gl2) => Windows.UI.Xaml.GridLength.op_Equality(@gl1, @gl2);
        public static System.Boolean op_Inequality(System.Windows.GridLength gl1, System.Windows.GridLength gl2) => Windows.UI.Xaml.GridLength.op_Inequality(@gl1, @gl2);
        public override System.Boolean Equals(System.Object oCompare) => __ProxyValue.Equals(@oCompare);
        public System.Boolean Equals(System.Windows.GridLength gridLength) => __ProxyValue.Equals(@gridLength);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}