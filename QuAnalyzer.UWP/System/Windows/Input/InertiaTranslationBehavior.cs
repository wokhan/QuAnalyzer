namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InertiaTranslationBehavior : Proxy<global::Windows.UI.Xaml.Input.InertiaTranslationBehavior>
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

        public System.Double DesiredDisplacement
        {
            get => __ProxyValue.DesiredDisplacement;
            set => __ProxyValue.DesiredDisplacement = value;
        }

        public InertiaTranslationBehavior(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}