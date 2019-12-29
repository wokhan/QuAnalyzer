namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class CharacterMetrics : Proxy<global::Windows.UI.Xaml.Media.CharacterMetrics>
    {
        public System.String Metrics
        {
            get => __ProxyValue.Metrics;
            set => __ProxyValue.Metrics = value;
        }

        public System.Double BlackBoxWidth
        {
            get => __ProxyValue.BlackBoxWidth;
        }

        public System.Double BlackBoxHeight
        {
            get => __ProxyValue.BlackBoxHeight;
        }

        public System.Double Baseline
        {
            get => __ProxyValue.Baseline;
        }

        public System.Double LeftSideBearing
        {
            get => __ProxyValue.LeftSideBearing;
        }

        public System.Double RightSideBearing
        {
            get => __ProxyValue.RightSideBearing;
        }

        public System.Double TopSideBearing
        {
            get => __ProxyValue.TopSideBearing;
        }

        public System.Double BottomSideBearing
        {
            get => __ProxyValue.BottomSideBearing;
        }

        public CharacterMetrics(): base()
        {
        }

        public CharacterMetrics(System.String @metrics): base(@metrics)
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}