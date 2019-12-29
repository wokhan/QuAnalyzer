namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InertiaRotationBehavior : Proxy<global::Windows.UI.Xaml.Input.InertiaRotationBehavior>
    {
        public System.Double InitialVelocity
        {
            get => __ProxyValue.InitialVelocity;
            set => __ProxyValue.InitialVelocity = value;
        }

        public System.Double DesiredDeceleration
        {
            get => __ProxyValue.DesiredDeceleration;
            set => __ProxyValue.DesiredDeceleration = value;
        }

        public System.Double DesiredRotation
        {
            get => __ProxyValue.DesiredRotation;
            set => __ProxyValue.DesiredRotation = value;
        }

        public InertiaRotationBehavior(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}