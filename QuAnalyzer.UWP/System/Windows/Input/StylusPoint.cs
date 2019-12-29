namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class StylusPoint : Proxy<global::Windows.UI.Xaml.Input.StylusPoint>
    {
        public System.Double X
        {
            get => __ProxyValue.X;
            set => __ProxyValue.X = value;
        }

        public System.Double Y
        {
            get => __ProxyValue.Y;
            set => __ProxyValue.Y = value;
        }

        public System.Single PressureFactor
        {
            get => __ProxyValue.PressureFactor;
            set => __ProxyValue.PressureFactor = value;
        }

        public System.Windows.Input.StylusPointDescription Description
        {
            get => __ProxyValue.Description;
        }

        public StylusPoint(System.Double @x, System.Double @y): base(@x, @y)
        {
        }

        public StylusPoint(System.Double @x, System.Double @y, System.Single @pressureFactor): base(@x, @y, @pressureFactor)
        {
        }

        public StylusPoint(System.Double @x, System.Double @y, System.Single @pressureFactor, System.Windows.Input.StylusPointDescription @stylusPointDescription, System.Int32[] @additionalValues): base(@x, @y, @pressureFactor, @stylusPointDescription, @additionalValues)
        {
        }

        public System.Boolean HasProperty(System.Windows.Input.StylusPointProperty stylusPointProperty) => __ProxyValue.HasProperty(@stylusPointProperty);
        public System.Int32 GetPropertyValue(System.Windows.Input.StylusPointProperty stylusPointProperty) => __ProxyValue.GetPropertyValue(@stylusPointProperty);
        public void SetPropertyValue(System.Windows.Input.StylusPointProperty stylusPointProperty, System.Int32 value) => __ProxyValue.SetPropertyValue(@stylusPointProperty, @value);
        public static System.Windows.Point op_Explicit(System.Windows.Input.StylusPoint stylusPoint) => Windows.UI.Xaml.Input.StylusPoint.op_Explicit(@stylusPoint);
        public System.Windows.Point ToPoint() => __ProxyValue.ToPoint();
        public static System.Boolean op_Equality(System.Windows.Input.StylusPoint stylusPoint1, System.Windows.Input.StylusPoint stylusPoint2) => Windows.UI.Xaml.Input.StylusPoint.op_Equality(@stylusPoint1, @stylusPoint2);
        public static System.Boolean op_Inequality(System.Windows.Input.StylusPoint stylusPoint1, System.Windows.Input.StylusPoint stylusPoint2) => Windows.UI.Xaml.Input.StylusPoint.op_Inequality(@stylusPoint1, @stylusPoint2);
        public static System.Boolean Equals(System.Windows.Input.StylusPoint stylusPoint1, System.Windows.Input.StylusPoint stylusPoint2) => Windows.UI.Xaml.Input.StylusPoint.Equals(@stylusPoint1, @stylusPoint2);
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public System.Boolean Equals(System.Windows.Input.StylusPoint value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}