namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class ManipulationDelta : Proxy<global::Windows.UI.Xaml.Input.ManipulationDelta>
    {
        public System.Windows.Vector Translation
        {
            get => __ProxyValue.Translation;
        }

        public System.Double Rotation
        {
            get => __ProxyValue.Rotation;
        }

        public System.Windows.Vector Scale
        {
            get => __ProxyValue.Scale;
        }

        public System.Windows.Vector Expansion
        {
            get => __ProxyValue.Expansion;
        }

        public ManipulationDelta(System.Windows.Vector @translation, System.Double @rotation, System.Windows.Vector @scale, System.Windows.Vector @expansion): base(@translation, @rotation, @scale, @expansion)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}