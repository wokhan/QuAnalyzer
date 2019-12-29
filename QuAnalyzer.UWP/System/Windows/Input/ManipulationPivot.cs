namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class ManipulationPivot : Proxy<global::Windows.UI.Xaml.Input.ManipulationPivot>
    {
        public System.Windows.Point Center
        {
            get => __ProxyValue.Center;
            set => __ProxyValue.Center = value;
        }

        public System.Double Radius
        {
            get => __ProxyValue.Radius;
            set => __ProxyValue.Radius = value;
        }

        public ManipulationPivot(): base()
        {
        }

        public ManipulationPivot(System.Windows.Point @center, System.Double @radius): base(@center, @radius)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}