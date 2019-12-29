namespace System.Windows.Controls.Primitives
{
    using Uno.UI.Generic;

    public class CustomPopupPlacement : Proxy<global::Windows.UI.Xaml.Controls.Primitives.CustomPopupPlacement>
    {
        public System.Windows.Point Point
        {
            get => __ProxyValue.Point;
            set => __ProxyValue.Point = value;
        }

        public System.Windows.Controls.Primitives.PopupPrimaryAxis PrimaryAxis
        {
            get => __ProxyValue.PrimaryAxis;
            set => __ProxyValue.PrimaryAxis = value;
        }

        public CustomPopupPlacement(System.Windows.Point @point, System.Windows.Controls.Primitives.PopupPrimaryAxis @primaryAxis): base(@point, @primaryAxis)
        {
        }

        public static System.Boolean op_Equality(System.Windows.Controls.Primitives.CustomPopupPlacement placement1, System.Windows.Controls.Primitives.CustomPopupPlacement placement2) => Windows.UI.Xaml.Controls.Primitives.CustomPopupPlacement.op_Equality(@placement1, @placement2);
        public static System.Boolean op_Inequality(System.Windows.Controls.Primitives.CustomPopupPlacement placement1, System.Windows.Controls.Primitives.CustomPopupPlacement placement2) => Windows.UI.Xaml.Controls.Primitives.CustomPopupPlacement.op_Inequality(@placement1, @placement2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}