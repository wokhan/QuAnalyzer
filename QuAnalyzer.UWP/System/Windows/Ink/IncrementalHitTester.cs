namespace System.Windows.Ink
{
    using Uno.UI.Generic;

    public class IncrementalHitTester : Proxy<global::Windows.UI.Xaml.Ink.IncrementalHitTester>
    {
        public System.Boolean IsValid
        {
            get => __ProxyValue.IsValid;
        }

        public void AddPoint(System.Windows.Point point) => __ProxyValue.AddPoint(@point);
        public void AddPoints(System.Collections.Generic.IEnumerable<System.Windows.Point> points) => __ProxyValue.AddPoints(@points);
        public void AddPoints(System.Windows.Input.StylusPointCollection stylusPoints) => __ProxyValue.AddPoints(@stylusPoints);
        public void EndHitTesting() => __ProxyValue.EndHitTesting();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}