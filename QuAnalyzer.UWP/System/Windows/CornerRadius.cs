namespace System.Windows
{
    using Uno.UI.Generic;

    public class CornerRadius : Proxy<global::Windows.UI.Xaml.CornerRadius>
    {
        public System.Double TopLeft
        {
            get => __ProxyValue.TopLeft;
            set => __ProxyValue.TopLeft = value;
        }

        public System.Double TopRight
        {
            get => __ProxyValue.TopRight;
            set => __ProxyValue.TopRight = value;
        }

        public System.Double BottomRight
        {
            get => __ProxyValue.BottomRight;
            set => __ProxyValue.BottomRight = value;
        }

        public System.Double BottomLeft
        {
            get => __ProxyValue.BottomLeft;
            set => __ProxyValue.BottomLeft = value;
        }

        public CornerRadius(System.Double @uniformRadius): base(@uniformRadius)
        {
        }

        public CornerRadius(System.Double @topLeft, System.Double @topRight, System.Double @bottomRight, System.Double @bottomLeft): base(@topLeft, @topRight, @bottomRight, @bottomLeft)
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Boolean Equals(System.Windows.CornerRadius cornerRadius) => __ProxyValue.Equals(@cornerRadius);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
        public static System.Boolean op_Equality(System.Windows.CornerRadius cr1, System.Windows.CornerRadius cr2) => Windows.UI.Xaml.CornerRadius.op_Equality(@cr1, @cr2);
        public static System.Boolean op_Inequality(System.Windows.CornerRadius cr1, System.Windows.CornerRadius cr2) => Windows.UI.Xaml.CornerRadius.op_Inequality(@cr1, @cr2);
    }
}