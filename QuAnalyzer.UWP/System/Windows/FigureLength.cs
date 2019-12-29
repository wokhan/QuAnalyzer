namespace System.Windows
{
    using Uno.UI.Generic;

    public class FigureLength : Proxy<global::Windows.UI.Xaml.FigureLength>
    {
        public System.Boolean IsAbsolute
        {
            get => __ProxyValue.IsAbsolute;
        }

        public System.Boolean IsAuto
        {
            get => __ProxyValue.IsAuto;
        }

        public System.Boolean IsColumn
        {
            get => __ProxyValue.IsColumn;
        }

        public System.Boolean IsContent
        {
            get => __ProxyValue.IsContent;
        }

        public System.Boolean IsPage
        {
            get => __ProxyValue.IsPage;
        }

        public System.Double Value
        {
            get => __ProxyValue.Value;
        }

        public System.Windows.FigureUnitType FigureUnitType
        {
            get => __ProxyValue.FigureUnitType;
        }

        public FigureLength(System.Double @pixels): base(@pixels)
        {
        }

        public FigureLength(System.Double @value, System.Windows.FigureUnitType @type): base(@value, @type)
        {
        }

        public static System.Boolean op_Equality(System.Windows.FigureLength fl1, System.Windows.FigureLength fl2) => Windows.UI.Xaml.FigureLength.op_Equality(@fl1, @fl2);
        public static System.Boolean op_Inequality(System.Windows.FigureLength fl1, System.Windows.FigureLength fl2) => Windows.UI.Xaml.FigureLength.op_Inequality(@fl1, @fl2);
        public override System.Boolean Equals(System.Object oCompare) => __ProxyValue.Equals(@oCompare);
        public System.Boolean Equals(System.Windows.FigureLength figureLength) => __ProxyValue.Equals(@figureLength);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}