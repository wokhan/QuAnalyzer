namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGridLength : Proxy<global::Windows.UI.Xaml.Controls.DataGridLength>
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

        public System.Boolean IsSizeToCells
        {
            get => __ProxyValue.IsSizeToCells;
        }

        public System.Boolean IsSizeToHeader
        {
            get => __ProxyValue.IsSizeToHeader;
        }

        public System.Double Value
        {
            get => __ProxyValue.Value;
        }

        public System.Windows.Controls.DataGridLengthUnitType UnitType
        {
            get => __ProxyValue.UnitType;
        }

        public System.Double DesiredValue
        {
            get => __ProxyValue.DesiredValue;
        }

        public System.Double DisplayValue
        {
            get => __ProxyValue.DisplayValue;
        }

        public static System.Windows.Controls.DataGridLength Auto
        {
            get => __ProxyValue.Auto;
        }

        public static System.Windows.Controls.DataGridLength SizeToCells
        {
            get => __ProxyValue.SizeToCells;
        }

        public static System.Windows.Controls.DataGridLength SizeToHeader
        {
            get => __ProxyValue.SizeToHeader;
        }

        public DataGridLength(System.Double @pixels): base(@pixels)
        {
        }

        public DataGridLength(System.Double @value, System.Windows.Controls.DataGridLengthUnitType @type): base(@value, @type)
        {
        }

        public DataGridLength(System.Double @value, System.Windows.Controls.DataGridLengthUnitType @type, System.Double @desiredValue, System.Double @displayValue): base(@value, @type, @desiredValue, @displayValue)
        {
        }

        public static System.Boolean op_Equality(System.Windows.Controls.DataGridLength gl1, System.Windows.Controls.DataGridLength gl2) => Windows.UI.Xaml.Controls.DataGridLength.op_Equality(@gl1, @gl2);
        public static System.Boolean op_Inequality(System.Windows.Controls.DataGridLength gl1, System.Windows.Controls.DataGridLength gl2) => Windows.UI.Xaml.Controls.DataGridLength.op_Inequality(@gl1, @gl2);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Boolean Equals(System.Windows.Controls.DataGridLength other) => __ProxyValue.Equals(@other);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
        public static System.Windows.Controls.DataGridLength op_Implicit(System.Double value) => Windows.UI.Xaml.Controls.DataGridLength.op_Implicit(@value);
    }
}