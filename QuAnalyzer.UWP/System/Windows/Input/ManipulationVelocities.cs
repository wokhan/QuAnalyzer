namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class ManipulationVelocities : Proxy<global::Windows.UI.Xaml.Input.ManipulationVelocities>
    {
        public System.Windows.Vector LinearVelocity
        {
            get => __ProxyValue.LinearVelocity;
        }

        public System.Double AngularVelocity
        {
            get => __ProxyValue.AngularVelocity;
        }

        public System.Windows.Vector ExpansionVelocity
        {
            get => __ProxyValue.ExpansionVelocity;
        }

        public ManipulationVelocities(System.Windows.Vector @linearVelocity, System.Double @angularVelocity, System.Windows.Vector @expansionVelocity): base(@linearVelocity, @angularVelocity, @expansionVelocity)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}