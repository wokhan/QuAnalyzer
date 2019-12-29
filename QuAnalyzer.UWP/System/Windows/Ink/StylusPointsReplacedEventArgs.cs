namespace System.Windows.Ink
{
    using Uno.UI.Generic;

    public class StylusPointsReplacedEventArgs : Proxy<global::Windows.UI.Xaml.Ink.StylusPointsReplacedEventArgs>
    {
        public System.Windows.Input.StylusPointCollection NewStylusPoints
        {
            get => __ProxyValue.NewStylusPoints;
        }

        public System.Windows.Input.StylusPointCollection PreviousStylusPoints
        {
            get => __ProxyValue.PreviousStylusPoints;
        }

        public StylusPointsReplacedEventArgs(System.Windows.Input.StylusPointCollection @newStylusPoints, System.Windows.Input.StylusPointCollection @previousStylusPoints): base(@newStylusPoints, @previousStylusPoints)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}