namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InertiaExpansionBehavior : Proxy<global::Windows.UI.Xaml.Input.InertiaExpansionBehavior>
    {
        public System.Windows.Vector InitialVelocity
        {
            get => __ProxyValue.InitialVelocity;
            set => __ProxyValue.InitialVelocity = value;
        }

        public System.Double DesiredDeceleration
        {
            get => __ProxyValue.DesiredDeceleration;
            set => __ProxyValue.DesiredDeceleration = value;
        }

        public System.Windows.Vector DesiredExpansion
        {
            get => __ProxyValue.DesiredExpansion;
            set => __ProxyValue.DesiredExpansion = value;
        }

        public System.Double InitialRadius
        {
            get => __ProxyValue.InitialRadius;
            set => __ProxyValue.InitialRadius = value;
        }

        public InertiaExpansionBehavior(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}